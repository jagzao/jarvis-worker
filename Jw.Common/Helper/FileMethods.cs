using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jw.Common.Helper
{
    public static class FileMethods
    {
        public static void Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception ex)
            {

            }
        }

        public static List<Tuple<string, string>> GetFilesInFolder(string folderPath)
        {
            var fileList = new List<Tuple<string, string>>();
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);

                    foreach (string file in files)
                    {
                        string name = Path.GetFileNameWithoutExtension(file);
                        fileList.Add(new Tuple<string, string>(name, file));
                    }
                }
                else
                {
                    Console.WriteLine("La carpeta no existe.");
                }
            }
            catch (Exception ex)
            {
            }
            return fileList;
        }

        public static void Move(string v, string v1)
        {
            try
            {
                File.Move(v, v1);
            }
            catch (Exception)
            {

            }
        }
    }
}
