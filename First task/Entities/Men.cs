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
        public Men(string surname, string name, string patronomic, string gender, int year, int month, int day) : base(surname, name, patronomic, year, month, day)
        {
            this.gender = gender;
        }
        public override void HumanCompare(Human human)
        {
            if (this.surname.CompareTo(human.surname) == 0)
            {
                if (this.name.CompareTo(human.name) == 0)
                {
                    if (this.patronomic.CompareTo(human.patronomic) == 0)
                    {
                        if(this.gender==human.gender && human.gender == "men")
                        {
                            Console.WriteLine(this.birthDate.CompareTo(human.birthDate));
                        }
                    }
                    else
                    {
                        Console.WriteLine(this.patronomic.CompareTo(human.patronomic));
                    }
                }
                else
                {
                    Console.WriteLine(this.name.CompareTo(human.name));
                }

            }
            else
            {
                Console.WriteLine(this.surname.CompareTo(human.surname));
            }
        }
    }
}
