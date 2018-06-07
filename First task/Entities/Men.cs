using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task
{
    class Men : Human
    {
        public Men() { }
        public Men(string surname, string name, string patronomic,string gender, int year, int month, int day) : base(surname, name, patronomic, year, month, day)
        {
            this.gender = gender;
        }
        public void CompareByGender(Human[] array)
        {
            long men = array.Length;
            men--;
            bool end = false;
            for (long j = 1; j < array.Length && end != true; j++)
            {
                if (array[j] is Women)
                {
                    bool flag = false;
                    for (long i = men; i > 0 && flag != true; i--)
                    {
                        if (array[i] is Men && j <= i)
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
           
            Human change;
            for (long i = 0; i < men+1; i++)
            {
                for (long j = 0; j < men - i ; j++)
                {
                    if (array[j].birthDate.CompareTo(array[j + 1].birthDate) != -1)
                    {
                        change = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = change;
                    }
                }
            }
            for (long i = 0; i < array.Length; i++)
            {
                Console.Write("i = " + i);

                array[i].ShowInfo();
            }
        }
    }
}
