using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizeFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the path to process:");
            string folderName = Console.ReadLine();

            DirectoryInfo folder = new DirectoryInfo(folderName);
            if (folder.Exists)
            {

                foreach (FileInfo file in folder.GetFiles("*.*"))
                {
                    try
                    {

                        DateTime date = file.CreationTime;
                        DirectoryInfo dest = new DirectoryInfo(string.Format(@"{0}\{1}\{2}", folder.FullName, date.Year, date.Month));
                        if (!dest.Exists)
                        {
                            dest.Create();
                        }
                        file.MoveTo(string.Format(@"{0}\{1}", dest.FullName, file.Name));
                        Console.WriteLine(string.Format(@"{0} has been moved.", file.Name));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine(string.Format(@"Unable to move ""{0}"". Do you want to continue (Y/N)?", file.Name));
                        string response = Console.ReadLine().ToUpper();
                        if (response.Substring(0, 1) == "N")
                        {
                            break;
                        }
                        throw;
                    }
                }
            }
            else
            {
                //Folder doesn't exist.
                Console.WriteLine("Folder does not exist.");
            }

            Console.WriteLine("All done. Press any key to exit.");
            Console.ReadKey();


        }
    }
}
