using System;
using System.IO;

namespace DojoCMS 
{
    public class FileManager
    {
        static void MakeUserDirectory(string UserName)
        {
            string PathString = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Path.Combine(PathString, UserName);
            System.IO.Directory.CreateDirectory(PathString);
        }
        static void MakeUserViewsDirectory(string UserName, string PageName)
        {
            string PathString = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Path.Combine(PathString, UserName, PageName);
            System.IO.Directory.CreateDirectory(PathString);
        }
        static void MakePageFile(string UserName, string PageName, string HTMLString)
        {
            string PathString = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            Path.Combine(PathString, UserName, PageName, ".cshtml");
            System.IO.File.WriteAllText(PathString, HTMLString);
        }
        static void WriteToFile(string PageText)
        {

        }
    }
}