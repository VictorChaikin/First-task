using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace First_task
{
    public abstract class Human : IPeopleCompare
    {

        public string surname;
        public string name;
        public string gender;
        public string patronomic;
        public DateTime birthDate;
        public Human() { }
        public Human(string surname, string name, string patronomic, int year, int month, int day)
        {
            this.surname = surname;
            this.name = name;
            this.patronomic = patronomic;
            this.birthDate = new DateTime(year, month, day);
        }
        public dynamic GiveProperty(string property)
        {
            if (property == "surname")
                return this.surname;
            if (property == "name")
                return this.name;
            if (property == "patronomic")
                return this.patronomic;
            if (property == "date")
                return this.birthDate;
            return this.gender;
        }

        public void ShowInfo()
        {
            Console.Write("{0,13}", this.surname);
            Console.Write("{0,13}", this.name);
            Console.Write("{0,17}", this.patronomic);
            Console.Write("{0,7}", this.gender);
            Console.Write("{0,5}", this.birthDate.Day + "/");
            Console.Write("{0,3}", this.birthDate.Month + "/");
            Console.Write("{0,4}", this.birthDate.Year);
            Console.WriteLine();
        }
       
        public virtual void HumanCompare(Human human)
        {
            if (this.surname.CompareTo(human.surname)==0)
            {
                if (this.name.CompareTo(human.name) == 0)
                {
                    if (this.patronomic.CompareTo(human.patronomic) == 0)
                    {
                        Console.WriteLine("They are equal");
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
