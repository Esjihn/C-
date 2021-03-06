﻿using System.IO;

namespace Extensibility
{
    public class FileLogger : ILogger
    {
        readonly string _path;

        public FileLogger(string path)
        {
            _path = path;
        }
        public void LogError(string message)
        {
            Log(message, "ERROR");
        }

        public void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        void Log(string message, string messageType)
        {
            //auto call to dispose
            using (var streamWrite = new StreamWriter(_path, true))
            {
                streamWrite.WriteLine(messageType + ": " + message);
            }
        }
    }
}