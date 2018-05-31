using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task
{
    class Women : Human
    {

        public Women() { }
        public Women(string surname, string name, string patronomic,  int year, int month, int day) : base(surname, name, patronomic, year, month, day)
        {
            this.gender = "women";
        }

    }
}
