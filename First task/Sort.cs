using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace First_task
{
   public  class Sort:Program
    {
         long QuickSortCounter = 0;
          long BubbleSortCounter = 0;
         long ShellSortCounter = 0;
        public Stopwatch quickStopwatch=new Stopwatch();
        public Stopwatch bubbleStopwatch=new Stopwatch();
        public Stopwatch shellStopwatch=new Stopwatch();

       
        public void CompareByGender(Human[] array)
        {
            long men = array.Length;
            men--;
            bool end = false;
            for (long j = 1; j < array.Length && end != true; j++)
            {
                if (array[j]is Men)
                {
                    bool flag = false;
                    for (long i = men; i > 0 && flag != true; i--)
                    {
                        if (array[i]is Men && j <= i)
                        {
                            Human temp = array[j];
                            array[j] = array[i];
                            array[i] = temp;
                            men = i - 1;
                            flag = true;
                            if (j > men)
                            {
                                end = true;
                            }
                        }

                    }
                }

            }
            Console.WriteLine();
            for (long i = 0; i < array.Length; i++)
            {
                array[i].ShowInfo();
            }
        }
        public void BubbleSort(Human[] array,string property)
        {
            Human change;
            for (long i = 0; i < array.Length - 1; i++)
            {
                for (long j = 0; j < array.Length - i - 1; j++) 
                {
                    if (array[j].Give(property).CompareTo(array[j + 1].Give(property)) != -1)
                    {
                        change = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = change;
                        BubbleSortCounter++;
                    }
                }
            }
        }
        public void QuickSort(long first, long last, Human[] arr,string property)
        {
            long pivot = (first + last) / 2, F = first, L = last;
            bool check = false;
            dynamic middle = arr[pivot].Give(property);
            for (long i = first; i < last-1 && check != true; i++)
            {
                if (arr[i].Give(property).CompareTo(arr[i + 1].Give(property)) != 1)
                {
                    check = false;
                }
                else
                {
                    check = true;
                }
            }

            if (check != false)
            {
                do
                {

                    if (arr[first].Give(property).CompareTo(middle) != -1)
                    {
                        if (arr[first].Give(property).CompareTo(arr[last].Give(property)) != -1)
                        {
                            if (arr[last].Give(property).CompareTo(middle) != 1)
                            {
                                Human temp = arr[first];
                                arr[first] = arr[last];
                                arr[last] = temp;
                                QuickSortCounter++;
                                first++;
                                last--;
                               
                            }
                            else
                            {
                                last--;
                            }
                        }
                        else
                        {
                            last--;
                        }
                    }
                    else
                    {
                        first++;
                    }

                } while (first <= last);

                if (first - F >= 1 || (first - F == 1 && arr[F].surname.CompareTo(arr[first].surname) != -1))
                { QuickSort(F, first - 1, arr,property); }
                if (L - last >= 1 || (L - last == 1 && arr[last].surname.CompareTo(arr[L].surname) != -1))
                { QuickSort(first, L, arr,property); }
            }
        }
        public void ShellSort(Human[] array, string property)
        {
            // Index(array.Length);
            long pivot = (array.Length % 2 == 0) ? array.Length / 2 : array.Length / 2 + 1;
            long first = 0, second = 0;
            bool flag = false;
            long counter = 0;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            do
            {
                for (long i = 0; i + pivot < array.Length; i++)
                {
                    first = i; second = i + pivot;
                    do
                    {
                        if (array[first].Give(property).CompareTo(array[second].Give(property)) == 1)
                        {
                            Human change = array[second];
                            array[second] = array[first];
                            array[first] = change;
                            ShellSortCounter++;
                            counter++;
                            first -= pivot;
                            second -= pivot;
                            if (first < 0)
                                flag = true;
                            else
                                flag = false;
                        }
                        else
                            flag = true;
                    } while (flag != true);
                }
                //pivot=(long)(pivot/1.5);
                pivot--;
            } while (pivot > 0);

            


            //for (long i = 0; i < array.Length; i++)
            //{
            //    array[i].ShowInfo();
            //}
            //bool check = false;
            //for (long i = 0; i < array.Length - 1 && check != true; i++)
            //{
            //    if (array[i].surname.CompareTo(array[i + 1].surname) != 1)
            //    {
            //        check = false;
            //    }
            //    else
            //    {
            //        check = true;


            //    }
            //}
            //if (check == false)
            //    Console.WriteLine("Yes");
            //Console.WriteLine("Counter = " + counter);
        }
        public void SpeedWorkInfo(Human[] array,string property)
        {
            Human[] bubbleArray = new Human[FileStringsAmount() - 1];
            WriteFromFile(bubbleArray);

            Human[] shellArray = new Human[FileStringsAmount() - 1];
            WriteFromFile(shellArray);

            Human[] quickArray = new Human[FileStringsAmount() - 1];
            WriteFromFile(quickArray);

            Console.WriteLine();

            bubbleStopwatch.Start();
            BubbleSort(bubbleArray,property);
            bubbleStopwatch.Stop();

            Console.WriteLine("Sort Array :");
            for(long i = 0; i < bubbleArray.Length; i++)
            {
                bubbleArray[i].ShowInfo();
                array[i] = bubbleArray[i];
            }
            Console.WriteLine();
            Console.WriteLine("BubbleSortCounter = "+BubbleSortCounter);
            Console.WriteLine("BubbleSortTime = " + bubbleStopwatch.Elapsed);
            Console.WriteLine();

            shellStopwatch.Start();
            ShellSort(shellArray, property);
            shellStopwatch.Stop();

            Console.WriteLine("ShellSortCounter = " + ShellSortCounter);
            Console.WriteLine("ShellSortTime = " + shellStopwatch.Elapsed);
            Console.WriteLine();
            
            quickStopwatch.Start();
            QuickSort(0,quickArray.Length-1,quickArray, property);
            quickStopwatch.Stop();
            
            Console.WriteLine("QuickSortCounter = " + QuickSortCounter);
            Console.WriteLine("QuickSortTime = " + quickStopwatch.Elapsed);
            Console.WriteLine();
        }
    }
}
