﻿#region License Information (GPL v3)

/*
    ShareX - A program that allows you to take screenshots and share any file type
    Copyright (c) 2007-2018 ShareX Team

    This program is free software; you can redistribute it and/or
    modify it under the terms of the GNU General Public License
    as published by the Free Software Foundation; either version 2
    of the License, or (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.

    Optionally you can also view the license at <http://www.gnu.org/licenses/>.
*/

#endregion License Information (GPL v3)

using ShareX.HelpersLib;
using ShareX.Properties;
using ShareX.UploadersLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareX
{
    internal static class Program
    {
        public static ShareXBuild Build
        {
            get
            {
#if RELEASE
                return ShareXBuild.Release;
#elif STEAM
                return ShareXBuild.Steam;
#elif WindowsStore
                return ShareXBuild.MicrosoftStore;
#elif DEBUG
                return ShareXBuild.Debug;
#else
                return ShareXBuild.Unknown;
#endif
            }
        }

        public static string Title
        {
            get
            {
                Version version = Version.Parse(Application.ProductVersion);
                string title = string.Format("ShareX {0}.{1}", version.Major, version.Minor);
                if (version.Build > 0) title += "." + version.Build;
                if (version.Revision > 0) title += "." + version.Revision;
                if (Dev) title += " Dev";
                if (Portable) title += " Portable";
                return title;
            }
        }

        public static string TitleLong => $"{Title} ({Build})";

        public static bool Dev { get; } = true;
        public static bool MultiInstance { get; private set; }
        public static bool Portable { get; private set; }
        public static bool PortableApps { get; private set; }
        public static bool SilentRun { get; private set; }
        public static bool Sandbox { get; private set; }
        public static bool SteamFirstTimeConfig { get; private set; }
        public static bool IgnoreHotkeyWarning { get; private set; }
        public static bool PuushMode { get; private set; }

        internal static ApplicationConfig Settings { get; set; }
        internal static TaskSettings DefaultTaskSettings { get; set; }
        internal static UploadersConfig UploadersConfig { get; set; }
        internal static HotkeysConfig HotkeysConfig { get; set; }

        internal static MainForm MainForm { get; private set; }
        internal static Stopwatch StartTimer { get; private set; }
        internal static HotkeyManager HotkeyManager { get; set; }
        internal static WatchFolderManager WatchFolderManager { get; set; }
        internal static GitHubUpdateManager UpdateManager { get; private set; }
        internal static CLIManager CLI { get; private set; }

        private static bool restarting;

        #region Paths

        private const string AppName = "ShareX";
        private const string PersonalPathConfigFileName = "PersonalPath.cfg";

        public static readonly string DefaultPersonalFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppName);
        public static readonly string PortablePersonalFolder = Helpers.GetAbsolutePath(AppName);
        public static readonly string PortableAppsPersonalFolder = Helpers.GetAbsolutePath(@"..\..\Data");

        private static string PersonalPathConfigFilePath
        {
            get
            {
                string relativePath = Helpers.GetAbsolutePath(PersonalPathConfigFileName);

                if (File.Exists(relativePath))
                {
                    return relativePath;
                }

                return CurrentPersonalPathConfigFilePath;
            }
        }

        private static readonly string CurrentPersonalPathConfigFilePath = Path.Combine(DefaultPersonalFolder, PersonalPathConfigFileName);

        private static readonly string PreviousPersonalPathConfigFilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            AppName, PersonalPathConfigFileName);

        private static readonly string PortableCheckFilePath = Helpers.GetAbsolutePath("Portable");
        private static readonly string PortableAppsCheckFilePath = Helpers.GetAbsolutePath("PortableApps");
        public static readonly string NativeMessagingHostFilePath = Helpers.GetAbsolutePath("ShareX_NativeMessagingHost.exe");
        public static readonly string SteamInAppFilePath = Helpers.GetAbsolutePath("Steam");

        private static string CustomPersonalPath { get; set; }

        public static string PersonalFolder
        {
            get
            {
                if (!string.IsNullOrEmpty(CustomPersonalPath))
                {
                    return Helpers.ExpandFolderVariables(CustomPersonalPath);
                }

                return DefaultPersonalFolder;
            }
        }

        public const string HistoryFilename = "History.xml";

        public static string HistoryFilePath
        {
            get
            {
                if (Sandbox) return null;

                return Path.Combine(PersonalFolder, HistoryFilename);
            }
        }

        public const string LogsFoldername = "Logs";

        public static string LogsFolder => Path.Combine(PersonalFolder, LogsFoldername);

        public static string LogsFilePath
        {
            get
            {
                string filename = string.Format("ShareX-Log-{0:yyyy-MM}.txt", DateTime.Now);
                return Path.Combine(LogsFolder, filename);
            }
        }

        public static string RequestLogsFilePath => Path.Combine(LogsFolder, "ShareX-Request-Logs.txt");

        public static string ScreenshotsParentFolder
        {
            get
            {
                if (Settings != null && Settings.UseCustomScreenshotsPath)
                {
                    string path = Settings.CustomScreenshotsPath;
                    string path2 = Settings.CustomScreenshotsPath2;

                    if (!string.IsNullOrEmpty(path))
                    {
                        path = Helpers.ExpandFolderVariables(path);

                        if (string.IsNullOrEmpty(path2) || Directory.Exists(path))
                        {
                            return path;
                        }
                    }

                    if (!string.IsNullOrEmpty(path2))
                    {
                        path2 = Helpers.ExpandFolderVariables(path2);

                        if (Directory.Exists(path2))
                        {
                            return path2;
                        }
                    }
                }

                return Path.Combine(PersonalFolder, "Screenshots");
            }
        }

        public static string ScreenshotsFolder
        {
            get
            {
                string subFolderName = NameParser.Parse(NameParserType.FolderPath, Settings.SaveImageSubFolderPattern);
                string folderPath = Path.Combine(ScreenshotsParentFolder, subFolderName);
                return Helpers.GetAbsolutePath(folderPath);
            }
        }

        public static string ToolsFolder => Path.Combine(PersonalFolder, "Tools");
        public static string ScreenRecorderCacheFilePath => Path.Combine(PersonalFolder, "ScreenRecorder.avi");
        public static string DefaultFFmpegFilePath => Path.Combine(ToolsFolder, "ffmpeg.exe");
        public static string ChromeHostManifestFilePath => Path.Combine(ToolsFolder, "Chrome-host-manifest.json");
        public static string FirefoxHostManifestFilePath => Path.Combine(ToolsFolder, "Firefox-host-manifest.json");

        private static string PersonalPathDetectionMethod;

        #endregion Paths

        [STAThread]
        private static void Main(string[] args)
        {
#if !DEBUG // Allow Visual Studio to break on exceptions in Debug builds.
            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
#endif

            StartTimer = Stopwatch.StartNew(); // For be able to show startup time

            CLI = new CLIManager(args);
            CLI.ParseCommands();

#if STEAM
            if (CheckUninstall()) return; // Steam will run ShareX with -Uninstall when uninstalling
#endif

            if (CheckAdminTasks()) return; // If ShareX opened just for be able to execute task as Admin

            UpdatePersonalPath();

            DebugHelper.Init(LogsFilePath);

            MultiInstance = CLI.IsCommandExist("multi", "m");

            using (ApplicationInstanceManager instanceManager = new ApplicationInstanceManager(!MultiInstance, args, SingleInstanceCallback))
            {
                Run();
            }

            if (restarting)
            {
                DebugHelper.WriteLine("ShareX restarting.");
                Process.Start(Application.ExecutablePath);
            }
        }

        private static void Run()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DebugHelper.WriteLine(Title);
            DebugHelper.WriteLine("Build: " + Build);
            DebugHelper.WriteLine("Command line: " + Environment.CommandLine);

            if (!string.IsNullOrEmpty(PersonalPathDetectionMethod))
            {
                DebugHelper.WriteLine("Personal path detection method: " + PersonalPathDetectionMethod);
            }

            DebugHelper.WriteLine("Personal path: " + PersonalFolder);
            DebugHelper.WriteLine("Operating system: " + Helpers.GetWindowsProductName());

            SilentRun = CLI.IsCommandExist("silent", "s");

#if STEAM
            SteamFirstTimeConfig = CLI.IsCommandExist("SteamConfig");
#endif

            IgnoreHotkeyWarning = CLI.IsCommandExist("NoHotkeys");

            CheckPuushMode();
            DebugWriteFlags();
            CleanTempFiles();

            SettingManager.LoadInitialSettings();

            Uploader.UpdateServicePointManager();
            UpdateManager = new GitHubUpdateManager("ShareX", "ShareX", Dev, Portable);

            LanguageHelper.ChangeLanguage(Settings.Language);

            Helpers.TryFixHandCursor();
            DebugHelper.WriteLine("MainForm init started.");
            MainForm = new MainForm();
            DebugHelper.WriteLine("MainForm init finished.");

            Application.Run(MainForm);

            if (WatchFolderManager != null) WatchFolderManager.Dispose();
            SettingManager.SaveAllSettings();

            DebugHelper.Logger.AsyncWrite = false;
            DebugHelper.WriteLine("ShareX closing.");
        }

        public static void Restart()
        {
            restarting = true;
            Application.Exit();
        }

        private static void SingleInstanceCallback(object sender, InstanceCallbackEventArgs args)
        {
            if (WaitFormLoad(5000))
            {
                Action d = () =>
                {
                    if (args.CommandLineArgs == null || args.CommandLineArgs.Length < 1)
                    {
                        if (MainForm.niTray != null && MainForm.niTray.Visible)
                        {
                            // Workaround for Windows startup tray icon bug
                            MainForm.niTray.Visible = false;
                            MainForm.niTray.Visible = true;
                        }

                        MainForm.ForceActivate();
                    }
                    else if (MainForm.Visible)
                    {
                        MainForm.ForceActivate();
                    }

                    CLIManager cli = new CLIManager(args.CommandLineArgs);
                    cli.ParseCommands();
                    MainForm.UseCommandLineArgs(cli.Commands);
                };

                MainForm.InvokeSafe(d);
            }
        }

        private static bool WaitFormLoad(int wait)
        {
            Stopwatch timer = Stopwatch.StartNew();

            while (timer.ElapsedMilliseconds < wait)
            {
                if (MainForm != null && MainForm.IsReady) return true;

                Thread.Sleep(10);
            }

            return false;
        }

        private static void UpdatePersonalPath()
        {
            Sandbox = CLI.IsCommandExist("sandbox");

            if (!Sandbox)
            {
                if (CLI.IsCommandExist("portable", "p"))
                {
                    Portable = true;
                    CustomPersonalPath = PortablePersonalFolder;
                    PersonalPathDetectionMethod = "Portable CLI flag";
                }
                else if (File.Exists(PortableCheckFilePath))
                {
                    Portable = true;
                    CustomPersonalPath = PortablePersonalFolder;
                    PersonalPathDetectionMethod = $"Portable file ({PortableCheckFilePath})";
                }
                else if (File.Exists(PortableAppsCheckFilePath))
                {
                    Portable = PortableApps = true;
                    CustomPersonalPath = PortableAppsPersonalFolder;
                    PersonalPathDetectionMethod = $"PortableApps file ({PortableAppsCheckFilePath})";
                }
                else
                {
#if !WindowsStore
                    MigratePersonalPathConfig();
#endif

                    string customPersonalPath = ReadPersonalPathConfig();

                    if (!string.IsNullOrEmpty(customPersonalPath))
                    {
                        CustomPersonalPath = Helpers.GetAbsolutePath(customPersonalPath);
                        PersonalPathDetectionMethod = $"PersonalPath.cfg file ({PersonalPathConfigFilePath})";
                    }
                }

                if (!Directory.Exists(PersonalFolder))
                {
                    try
                    {
                        Directory.CreateDirectory(PersonalFolder);
                    }
                    catch (Exception e)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.AppendFormat("{0} \"{1}\"", Resources.Program_Run_Unable_to_create_folder_, PersonalFolder);
                        sb.AppendLine();

                        if (!string.IsNullOrEmpty(PersonalPathDetectionMethod))
                        {
                            sb.AppendLine("Personal path detection method: " + PersonalPathDetectionMethod);
                        }

                        sb.AppendLine();
                        sb.Append(e);

                        MessageBox.Show(sb.ToString(), "ShareX - " + Resources.Program_Run_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CustomPersonalPath = "";
                    }
                }
            }
        }

        private static void MigratePersonalPathConfig()
        {
            if (File.Exists(PreviousPersonalPathConfigFilePath))
            {
                try
                {
                    if (!File.Exists(CurrentPersonalPathConfigFilePath))
                    {
                        Helpers.CreateDirectoryFromFilePath(CurrentPersonalPathConfigFilePath);
                        File.Move(PreviousPersonalPathConfigFilePath, CurrentPersonalPathConfigFilePath);
                    }

                    File.Delete(PreviousPersonalPathConfigFilePath);
                    Directory.Delete(Path.GetDirectoryName(PreviousPersonalPathConfigFilePath));
                }
                catch (Exception e)
                {
                    e.ShowError();
                }
            }
        }

        public static string ReadPersonalPathConfig()
        {
            if (File.Exists(PersonalPathConfigFilePath))
            {
                return File.ReadAllText(PersonalPathConfigFilePath, Encoding.UTF8).Trim();
            }

            return "";
        }

        public static bool WritePersonalPathConfig(string path)
        {
            if (path == null)
            {
                path = "";
            }
            else
            {
                path = path.Trim();
            }

            bool isDefaultPath = string.IsNullOrEmpty(path) && !File.Exists(PersonalPathConfigFilePath);

            if (!isDefaultPath)
            {
                string currentPath = ReadPersonalPathConfig();

                if (!path.Equals(currentPath, StringComparison.InvariantCultureIgnoreCase))
                {
                    try
                    {
                        Helpers.CreateDirectoryFromFilePath(PersonalPathConfigFilePath);
                        File.WriteAllText(PersonalPathConfigFilePath, path, Encoding.UTF8);
                        return true;
                    }
                    catch (UnauthorizedAccessException)
                    {
                        MessageBox.Show(string.Format(Resources.Program_WritePersonalPathConfig_Cant_access_to_file, PersonalPathConfigFilePath),
                            "ShareX", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            return false;
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            OnError(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            OnError((Exception)e.ExceptionObject);
        }

        private static void OnError(Exception e)
        {
            using (ErrorForm errorForm = new ErrorForm(e.Message, $"{e}\r\n\r\n{TitleLong}", LogsFilePath, Links.URL_ISSUES))
            {
                errorForm.ShowDialog();
            }
        }

        private static bool CheckAdminTasks()
        {
            if (CLI.IsCommandExist("dnschanger"))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Helpers.TryFixHandCursor();
                Application.Run(new DNSChangerForm());
                return true;
            }

            return false;
        }

        private static bool CheckUninstall()
        {
            if (CLI.IsCommandExist("uninstall"))
            {
                try
                {
                    IntegrationHelpers.Uninstall();
                }
                catch
                {
                }

                return true;
            }

            return false;
        }

        private static bool CheckPuushMode()
        {
            string puushPath = Helpers.GetAbsolutePath("puush");
            PuushMode = File.Exists(puushPath);
            return PuushMode;
        }

        private static void DebugWriteFlags()
        {
            List<string> flags = new List<string>();

            if (Dev) flags.Add(nameof(Dev));
            if (MultiInstance) flags.Add(nameof(MultiInstance));
            if (Portable) flags.Add(nameof(Portable));
            if (PortableApps) flags.Add(nameof(PortableApps));
            if (SilentRun) flags.Add(nameof(SilentRun));
            if (Sandbox) flags.Add(nameof(Sandbox));
            if (SteamFirstTimeConfig) flags.Add(nameof(SteamFirstTimeConfig));
            if (IgnoreHotkeyWarning) flags.Add(nameof(IgnoreHotkeyWarning));
            if (PuushMode) flags.Add(nameof(PuushMode));

            string output = string.Join(", ", flags);

            if (!string.IsNullOrEmpty(output))
            {
                DebugHelper.WriteLine("Flags: " + output);
            }
        }

        private static void CleanTempFiles()
        {
            Task.Run(() =>
            {
                try
                {
                    string tempFolder = Path.GetTempPath();

                    if (!string.IsNullOrEmpty(tempFolder))
                    {
                        string folderPath = Path.Combine(tempFolder, "ShareX");

                        if (Directory.Exists(folderPath))
                        {
                            Directory.Delete(folderPath, true);

                            DebugHelper.WriteLine($"Temp files cleaned: {folderPath}");
                        }
                    }
                }
                catch (Exception e)
                {
                    DebugHelper.WriteException(e);
                }
            });
        }
    }
}