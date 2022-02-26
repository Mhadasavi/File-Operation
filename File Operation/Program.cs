using System;
using System.Collections.Generic;
using System.IO;

namespace File_Operation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is file organizer");

            var folderPath = @"K:\Camera\Photos from 2021";

            int duplicate = 0;
            int total = 0;

            int[] ar = new int[2];
            string[] stringArr = { "*.jpg", "*png", "*.3gp", "*.jpeg", "*.mp4" };

            using StreamWriter file = new(@"k:\logs.txt", append: true);

            Program obj = new Program();

            for (int i = 0; i < stringArr.Length; i++)
            {
                ar = obj.FileOrganizer(folderPath, stringArr[i]);
                duplicate += ar[0];
                total += ar[1];
            }

            Console.WriteLine();
            Console.WriteLine("Total files : " + total);
            Console.WriteLine("Duplicate files : " + duplicate);

            file.WriteLine("Total files : " + total + " , Duplicate files : " + duplicate);
        }

        int[] FileOrganizer(string folderPath, string extension)
        {
            int fileCount = 0;
            int isExist = 0;
            int[] arr = new int[2];
            try
            {
                foreach (string file in Directory.EnumerateFiles(folderPath, extension))
                {
                    FileInfo fileInfo = new FileInfo(file);

                    if (fileInfo.Exists)
                    {
                        DateTime date = fileInfo.LastWriteTime;
                        //logic to move or copy files to another location based on year

                        int year = date.Year;

                        switch (year)
                        {
                            case 2021:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++;
                                break;
                            case 2020:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            case 2019:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            case 2018:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            case 2017:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            case 2016:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            case 2015:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            case 2014:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                break;
                            case 2013:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            case 2012:
                                isExist = fileMover(fileInfo, isExist, fileCount);
                                fileCount++; break;
                            default: break;
                        }

                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine(ex.ToString()); }

            Console.WriteLine(fileCount + "moved successfully");
            Console.WriteLine(isExist + " deleted successfully");
            arr[0] = isExist;
            arr[1] = fileCount;
            return arr;
        }

        public int fileMover(FileInfo fileInfo, int isExist, int fileCount)
        {
            string from = fileInfo.FullName;
            string to = @"K:\Organize Pic\" + fileInfo.LastWriteTime.Year + @"\" + fileInfo.Name;
            if (File.Exists(to))
            {
                File.Delete(to);
                isExist++;
            }
            File.Move(from, to);
            return isExist;
        }
    }

}
