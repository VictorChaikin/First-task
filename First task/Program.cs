using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_task
{
    public class Program
    {
        static void Main(string[] args)
        {

            string sortProperty = "name";
            Human[] humanArray = new Human[10000];

            Files f = new Files();
            f.FillArrays(humanArray);


            Sort sort = new Sort();
            sort.SpeedWorkInfo(humanArray, sortProperty);

            f.WriteIntoFile(humanArray, sortProperty);

            Men John = new Men("Петров", "Иван", "Иванов","men", 1999, 12, 12);
            Men Tom = new Men("Петров", "Иван", "Иванов", "men", 2000, 12, 12);
            John.HumanCompare(Tom);

            Women Masha = new Women("Петров", "Иван", "Иванов", "women", 1999, 12, 12);
            Masha.HumanCompare(John);
        }
    }
}
