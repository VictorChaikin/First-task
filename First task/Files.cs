using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace First_task
{
    class Files
    {
        public static int GetFileStringsAmount(string path)
        {
            string str;
            int strAmount = 0;
            StreamReader file = new StreamReader(path, Encoding.GetEncoding(1251));

            do
            {
                strAmount++;
                str = file.ReadLine();
            }
            while (str != null);
            return strAmount - 1;
        }
        public static string WomanNames = "../../Data/WomanNames.txt";
        public string[] WomanNamesArray = new string[GetFileStringsAmount(WomanNames)];
        public static string Surnames = "../../Data/Surnames.txt";
        public string[] SurnamesArray = new string[GetFileStringsAmount(Surnames)];
        public static string ManNames = "../../Data/ManNames.txt";
        public string[] ManNamesArray = new string[GetFileStringsAmount(ManNames)];
        public string SortPath = "../../Data/SortData.txt";


        public void ReadFromFile(string path, string[] array)
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (StreamReader file = new StreamReader(path))
            {
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = file.ReadLine();
                    Console.WriteLine(array[i] + "  " + i);
                }
            }
        }

        public void FillArrays(Human[] array)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ReadFromFile(WomanNames, WomanNamesArray);
           
            ReadFromFile(Surnames, SurnamesArray);
            
            ReadFromFile(ManNames, ManNamesArray);
            Random random = new Random();
            long surname, patronomic;
            string genderValue;
            int gender, day, month = 12, name, year;

            for (long i = 0; i < array.Length; i++)
            {

                gender = random.Next(0, 2);
                if (gender == 0)
                {
                    surname = random.Next(0, SurnamesArray.Length - 1);
                    name = random.Next(0, WomanNamesArray.Length);
                    patronomic = random.Next(0, ManNamesArray.Length);
                    year = random.Next(1900, 2019);
                    month = random.Next(1, 13);
                    day = random.Next(1, 29);
                    year = random.Next(1900, 2019);
                    month = random.Next(1, 13);
                    genderValue = "women";
                    array[i] = new Women(SurnamesArray[surname], WomanNamesArray[name], ManNamesArray[patronomic], genderValue, year, month, day);
                }
                else
                {
                    surname = random.Next(0, SurnamesArray.Length - 1);
                    name = random.Next(0, ManNamesArray.Length - 1);
                    patronomic = random.Next(0, ManNamesArray.Length - 1);
                    year = random.Next(1900, 2019);
                    month = random.Next(1, 13);
                    day = random.Next(1, 29);
                    genderValue = "men";
                    array[i] = new Men(SurnamesArray[surname], ManNamesArray[name], ManNamesArray[patronomic], genderValue, year, month, day);
                }
            }

        }

        public void WriteIntoFile(Human[] array, string property)
        {
            StreamWriter file = new StreamWriter(SortPath, false, System.Text.Encoding.UTF8);

            for (int i = 0; i < array.Length; i++)
            {
                string write = array[i].surname + "," + array[i].name + "," + array[i].patronomic + "," + array[i].gender + "," +
                    array[i].birthDate.Day + "/" + array[i].birthDate.Month + "/" + array[i].birthDate.Year;
                file.WriteLine(write);
            }
            file.Close();
            Console.WriteLine($"File is filled with sort by {property} property.");
        }
    }
}
