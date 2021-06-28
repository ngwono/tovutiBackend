using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TovutiBackend.Files
{
    public class FileEngine
    {
        private string path = "";
        private FileStream fileStream = null;
        public FileEngine(string path)
        {
            this.path = path;
            //Directory.CreateDirectory(path);

        }
        public void open()
        {

            if (!File.Exists(path))
            {
                File.SetAttributes(path, FileAttributes.Normal);

                fileStream = File.Create(path);
            }
            else
            {
                fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            }
        }
        public void writeToFile(string text)
        {
            try
            {

                using (StreamWriter sw = File.CreateText(path))
                {

                    sw.WriteLine(text);

                }



            }
            catch (Exception Ex) { Ex.ToString(); }
        }
        public FileStream getFileStream()
        {
            return fileStream;
        }

        public void close()
        {
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
    }
}