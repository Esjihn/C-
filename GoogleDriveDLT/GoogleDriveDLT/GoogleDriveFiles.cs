using System;
using System.Runtime.InteropServices;

namespace GoogleDriveDLT
{
    public class GoogleDriveFiles
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public long? Size { get; set; }
        public long? Version { get; set; }
        public DateTime? CreatedTime { get; set; }

    }
}