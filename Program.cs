using System;
using System.IO;

namespace FileSplit
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fileProcessing = new FileProcessing();
            var listOfFiles = Directory.GetFiles(fileProcessing.FileLocation);

            foreach (var file in listOfFiles)
            {
                Console.WriteLine("No of files generated for {0}: {1}", Path.GetFullPath(file),
                    fileProcessing.ProcessFile(Path.GetFileNameWithoutExtension(file), Path.GetFullPath(file)));
            }

            Console.Read();
        }

        /*FOR BATCH FILE 
         
        @ECHO OFF
        SETLOCAL
        SET "sourcedir=D:\WIT\554012"
        SET /a fcount = 199
        SET /a llimit = 10000
        SET /a lcount =% llimit %
        FOR / f "usebackqdelims=" %%a IN("%sourcedir%\Backup_2.sql") DO(
         CALL :select
         >>"%sourcedir%\file$$.sql" ECHO(%%a
        )
        SET /a lcount =% llimit %
        :select
        SET /a lcount+=1
        IF %lcount% lss %llimit% GOTO :EOF
        SET /a lcount = 0
        SET /a fcount+=1
        MOVE /y "%sourcedir%\file$$.sql" "%sourcedir%\file%fcount:~-2%.sql" >NUL 2>nul
        GOTO :EOF 
        
         */
    }
}