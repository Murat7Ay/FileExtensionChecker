using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FileTransfer.Models;
using System.IO;

namespace FileTransfer.FileControl
{
    public class ControlFile
    {
        public static FileTransferResponse CheckFile(FileTransferModel file)
        {
            if (file != null)
            {
                if (!string.IsNullOrEmpty(file.FileName))
                {
                    if (file.Content != null)
                    {
                        var checker = new FileTypeChecker();
                        Stream stream = new MemoryStream(file.Content);
                        try
                        {
                            var fileExtension = checker.GetFileType(stream);
                            if (fileExtension.Extension == ".pdf")
                            {
                                var filePath = FileOperations.SaveBytesToFile(file.FileName+".pdf", file.Content);
                                return new FileTransferResponse
                                {
                                    Status = "1",
                                    FileName = file.FileName + ".pdf",
                                    FilePath = filePath,
                                    FileType = ".pdf",
                                };
                            }
                            else
                            {
                                return new FileTransferResponse
                                {
                                    ErrorMessage = "File must be Portable Document Format.",
                                    Status = "-1"
                                };
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }

                    }
                    else
                    {
                        return new FileTransferResponse
                        {
                            ErrorMessage = "File content is null.",
                            Status = "-1"
                        };
                    }
                }
                else
                {
                    return new FileTransferResponse
                    {
                        ErrorMessage = "File name is null.",
                        Status = "-1"
                    };
                }
            }
            else
            {
                return new FileTransferResponse
                {
                    ErrorMessage = "Request is null.",
                    Status = "-1"
                };
            }
        }


    }
}