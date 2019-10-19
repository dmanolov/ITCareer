using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _01.Копиране_на_двоичен_файл
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new FileStream("../sheep.jpg", FileMode.Open))
            {
                using (var destination =
                  new FileStream("../anothersheep.jpg", FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                            break;
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }

        }
    }
}
