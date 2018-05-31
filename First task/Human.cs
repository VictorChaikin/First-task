using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace First_task
{
    public class Human : Sort
    {
        
        public string surname;
        public string name;
        public string patronomic;
        public string gender;
        public DateTime birthDate;
        public Human() { }
        public  Human(string surname, string name, string patronomic, int year,int month,int day)
        {
            this.surname = surname;
            this.name = name;
            this.patronomic = patronomic;
            this.birthDate = new DateTime(year,month,day);
        }
        public dynamic Give( string property)
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
            Console.Write("{0,11}",surname);
            Console.Write("{0,13}", name);
            Console.Write("{0,15}", patronomic);
            Console.Write("{0,7}", gender);
            Console.Write("{0,5}", birthDate.Day + "/");
            Console.Write("{0,3}", birthDate.Month + "/");
            Console.Write("{0,4}", birthDate.Year);
            Console.WriteLine();
        }
        
    }
}
