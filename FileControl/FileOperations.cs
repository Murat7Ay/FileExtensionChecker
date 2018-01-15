using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace FileTransfer.FileControl
{
    public class FileOperations
    {
        
        public static string SaveBytesToFile(string fileName, byte[] bytesToWrite)
        {
            string filename = @"C:\Files\" + fileName;
            if (filename != null && filename.Length > 0 && bytesToWrite != null)
            {
                if (!Directory.Exists(Path.GetDirectoryName(filename)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filename));

                FileStream file = File.Create(filename);

                file.Write(bytesToWrite, 0, bytesToWrite.Length);

                file.Close();
            }
            

            return filename;
        }
    }
}