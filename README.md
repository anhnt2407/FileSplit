
Split a large file into small files - based on the config values

Reason for this program creation: Had huge insert scripts that had a 'commit' at the end of the file. 
I wanted to addd a commit statement after every few thousand lines (configurable).

Usage:
Set the config file:

<appSettings>
    <add key="FileLocation" value="D:\Test\Input" />
    <add key="FileCreateFolder" value="D:\Test\Output" />
    <add key="LimitLineSize" value="100000" />
    <add key="CommitAfter" value="5000" />
    <add key="Delimiter" value="INSERT" />
    <add key="AddStringEOF" value="commit;" />
</appSettings>

FileLocation : Set the input folder. All the files present in this folder will be processed.
FileCreateFolder : This is the output folder, the files will be split with sequence numbers 1,2,3... These files will be created in a folder which is the name of the file. For e.g. the file name was apple.sql. The output would be generated in D:\Test\Output\apple\
LimitLineSize : This is to limit the number of lines in a single file.
CommitAfter : If I want to add a specific character/ string after every few lines, for e.g. in this case I am adding a string "commit;" after those number of lines.
Delimiter : Since the script that I have is having million of insert scripts, I didn't want to split the file after every 100000 lines. The file will split once the limit of 100000 is reached and the line begins with "INSERT".
AddStringEOF : String that is added after every few # of lines.

Disclaimer: This was not the best solution to the problem and there were several other methods of solving it. One of them was to create a batch file and split the large file. I have added that in Program.cs (commented it). It was taking longer than usual and the additional feature to add a commit statement was not there.
Oracle also has a feature, but I wasn't sure how it worked.

Feel free to improve it and let me know all possible bugs and improper coding practices.







