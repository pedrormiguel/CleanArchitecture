using System;
namespace Application.Models.Export
{
    public abstract class BaseExportFile
    {
        public byte[] Content;
        public string ContentType;
        public string FileName;
        public string Extension;

        protected BaseExportFile(byte[] content, string contentType, string fileName, string extension)
        {
            Content = content;
            ContentType = contentType;
            FileName = fileName;
            Extension = extension;
        }


    }
}
