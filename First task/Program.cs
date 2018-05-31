using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace First_task
{
    public class Program
    {
        public  static string UnSortPath = "UnSortData.txt";
        public static string SortPath = "SortData.txt";
        public static int FileStringsAmount()
        {
            string str;
            int strAmount = 0;
            StreamReader file = new StreamReader(UnSortPath, Encoding.GetEncoding(1251));
            do 
            {
                strAmount++;
                str = file.ReadLine();
            }
            while (str!=null || strAmount==1) ;
            return strAmount;
        }
        public static void WriteFromFile(Human []array)
        { 
            string s = null;
            char sym = ',';
            Console.OutputEncoding = Encoding.UTF8;
            StreamReader file = new StreamReader(UnSortPath, Encoding.GetEncoding(1251));
            for (int i = 0; i < array.Length; i++)
            {
                char def = '-';
                s = file.ReadLine();
                string[] arr = s.Split(sym);
                string[] date =arr[4].Split(def);
                int year = Convert.ToInt32(date[0]);
                int month = Convert.ToInt32(date[1]);
                int day = Convert.ToInt32(date[2]);

                if(arr[3]=="men")
                     array[i] = new Men(arr[1], arr[0],arr[2], year, month, day);
                else
                    array[i] = new Women(arr[1], arr[0], arr[2], year, month, day);

            }
        }
        public static void WriteIntoFile(Human[] array)
        {
            StreamWriter file = new StreamWriter(SortPath, false, System.Text.Encoding.UTF8);
            Console.WriteLine("Sort data");
            
            for (int i = 0; i < array.Length; i++)
            {
                string write = array[i].surname +","+ array[i].name + "," + array[i].patronomic + "," + array[i].gender + "," +
                    array[i].birthDate.Day + "/" + array[i].birthDate.Month + "/" + array[i].birthDate.Year;
                file.WriteLine(write);
                Console.WriteLine(write);
            }
            file.Close();

            //file.Close();
        }
        static void Main(string[] args)
        {
            Human[] array = new Human[FileStringsAmount() - 1];
            WriteFromFile(array);
            for (int i = 0; i < array.Length; i++)
            {
                array[i].ShowInfo();
            }
            Human h1 = new Human();
            string property = "афывафа";
            h1.SpeedWorkInfo(array,property);
            WriteIntoFile(array);
        }
    }
}
