using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace FileSplit
{
    public class FileProcessing
    {
        public string AddStringEof = ConfigurationManager.AppSettings["AddStringEOF"];
        public int CommitAfter = int.Parse(ConfigurationManager.AppSettings["CommitAfter"]);
        public string Delimiter = ConfigurationManager.AppSettings["Delimiter"];
        public string FileCreateFolder = ConfigurationManager.AppSettings["FileCreateFolder"];
        public string FileLocation = ConfigurationManager.AppSettings["FileLocation"];
        public long LimitLineSize = long.Parse(ConfigurationManager.AppSettings["LimitLineSize"]);

        public FileProcessing()
        {
            Console.WriteLine(" ******************************************* ");
            Console.WriteLine("INPUT LOCATION  : \t \"{0}\"", FileLocation);
            Console.WriteLine("OUTPUT LOCATION : \t \"{0}\"", FileCreateFolder);
            Console.WriteLine("LIMIT # OF LINES: \t {0}", LimitLineSize);
            Console.WriteLine("DELIMITER       : \t \"{0}\"", Delimiter);
            Console.WriteLine("ADD AT EOF      : \t \"{0}\"", AddStringEof);
            Console.WriteLine(" ******************************************* ");
        }

        public int ProcessFile(string fileNameWithoutExtension, string fileName)
        {
            var lines = File.ReadAllLines(fileName);
            var fileString = new StringBuilder();
            var addedCommit = false;

            //Create Output directory
            var newFolder = Directory.CreateDirectory(FileCreateFolder + "\\" + fileNameWithoutExtension);

            var multiplyingFactor = 1;
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            for (var i = 0; i < lines.Length; i++)
            {
                fileString.AppendLine(lines[i]);


                if (i > CommitAfter && i%CommitAfter == 0)
                    addedCommit = false;

                //Adding a commit after every file lines
                if (i > 5 && !addedCommit)
                {
                    if (lines[i].EndsWith(";"))
                    {
                        fileString.AppendLine(AddStringEof);
                        addedCommit = true;
                    }
                }

                if (i == LimitLineSize*multiplyingFactor)
                {
                    using (var tw = new StreamWriter(newFolder.FullName + "\\" + multiplyingFactor + ".sql", true))
                    {
                        do
                        {
                            //i++;
                        } while (lines[i].StartsWith(Delimiter));

                        fileString.AppendLine(AddStringEof);
                        tw.Write(fileString.ToString());
                        multiplyingFactor++;
                        tw.Close();
                        fileString.Clear();
                    }
                }
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
            return multiplyingFactor;
        }
    }
}