using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileTransfer.Models
{
    public class FileTransferModel
    {
        public string FileName { get; set; }

        public byte[] Content { get; set; }
    }

    public class FileTransferResponse
    {
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public string FileName { get; set; }

        public string FileType { get; set; }

        public string FilePath { get; set; }
    }
}