using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TovutiBackend.Files
{
    public class LogFileEngine
    {
        private string path = "";
        private FileStream fileStream = null;
        public LogFileEngine(string path)
        {
            this.path = path;


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
                fileStream = new FileStream(path, FileMode.Open);
            }
        }
        public void writeToFile(string text)
        {
            try
            {
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {

                        sw.WriteLine(DateTime.Now + " : " + text);

                    }
                }

                else
                {
                    using (StreamWriter w = File.AppendText(path))
                    {

                        w.WriteLine(DateTime.Now + " : " + text);

                    }
                }
            }
            catch (Exception Ex) { Ex.ToString(); }
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