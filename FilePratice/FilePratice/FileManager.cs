using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilePratice
{
    static class FileManager
    {
        public static void createDir(string dirName)
        {
            if (System.IO.Directory.Exists(dirName))
            {
                throw new Exception("Directory already exist!");
            }
            else
            {
                System.IO.Directory.CreateDirectory(dirName);
            }
        }
        public static List<string> listContent(string dirName)
        {
            List<string> listOfFiles = new List<string>();
            if (!System.IO.Directory.Exists(dirName))
            {
                throw new Exception("Directory not exist!");
            }
            else
            {
                foreach (string file in System.IO.Directory.GetFiles(dirName))
                {
                    listOfFiles.Add(System.IO.Path.GetFileName(file));
                }
            }
            return listOfFiles;
        }

        public static string readFile(string dirName)
        {
            string result = "";
            Debug.WriteLine(dirName);
            if (!File.Exists(dirName))
            {
                throw new Exception("Directory not exist!");
            }
            else
            {
                try
                {
                    using (StreamReader sr = new StreamReader(dirName))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                catch (Exception)
                {
                    throw new Exception("The file could not be read!");
                }
            }
            return result;
        }
    }
}
