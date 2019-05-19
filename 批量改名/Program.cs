using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace 批量改名
{
    class Program
    {
        static void Main(string[] args)
        {

            //获取当前运行程序的目录
            string fileDir = Environment.CurrentDirectory;
            Console.WriteLine("当前程序目录：" + fileDir);
            
         

            //获取子目录
            string path = fileDir;
            DirectoryInfo root = new DirectoryInfo(path);
            DirectoryInfo[] dics = root.GetDirectories();

           foreach(DirectoryInfo d in dics)
            {
                Console.WriteLine(d.FullName);
                DirectoryInfo fi = new DirectoryInfo(d.FullName);
                foreach (FileInfo f in fi.GetFiles())
                {
                    string ran=DateTime.Now.ToString("fffffff");
                    string oldname = f.FullName;
                    string newname = d.FullName +@"\"+ d.Name +ran+ Path.GetExtension(f.Name);
                    Console.WriteLine("旧"+oldname);
                    Console.WriteLine("新" + newname);

                    try { f.MoveTo(newname); }
                    catch {; }
                }

            }

            Console.ReadKey();
        }
    }
}
