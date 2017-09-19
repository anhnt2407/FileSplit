using System;

namespace FileSplit
{
    public class FileProperty
    {
        public int FileId { get; set; }

        public string FileName { get; set; }

        public string FileDecsription { get; set; }

        public string Delimiter { get; set; }
        public DateTime CreateDate { get; set; }
    }
}