using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _02.Разделяне_на_файл_на_части
{
    class Program
    {
        static void Main(string[] args)
        {
            Slice("../sheep.jpg", "../Parts/", 5);
            List<string> files = new List<string>();
            files.Add("../Parts/Part-1.jpg");
            files.Add("../Parts/Part-2.jpg");
            files.Add("../Parts/Part-3.jpg");
            files.Add("../Parts/Part-4.jpg");
            files.Add("../Parts/Part-5.jpg");
            Assemble(files, "../Parts/");
        }

        static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (FileStream source = new FileStream(sourceFile, FileMode.Open))
            {
                byte[] buffer = new byte[source.Length / parts];
                for (int i = 1; i <= parts; i++)
                {
                    using (FileStream destination =
                        new FileStream(destinationDirectory + "Part-" + i + Path.GetExtension(sourceFile),
                                        FileMode.Create))
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }

        static void Assemble(List<string> files, string destinationDirectory)
        {
            using (FileStream destination =
                            new FileStream(destinationDirectory + "Assemble.jpg",
                                            FileMode.Create))
            {
                foreach (var fileName in files)
                {
                    using (FileStream source = new FileStream(fileName, FileMode.Open))
                    {
                        byte[] buffer = new byte[source.Length];
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
