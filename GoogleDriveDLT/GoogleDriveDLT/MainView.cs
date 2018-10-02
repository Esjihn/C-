using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Caching;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Util.Store;

namespace GoogleDriveDLT
{
    public class MainView
    {
        static void Main(string[] args)
        {
            GDConsole();
        }

        static void GDConsole()
        {
            
            GoogleDriveFiles gdf = new GoogleDriveFiles();
            GoogleDriveFilesRepository.GetService();
            GoogleDriveFilesRepository.DownloadGoogleFile("1arDH16C-Qmv1jTMur3_XFFq2zqA6LB6I");
        }
    }
}
