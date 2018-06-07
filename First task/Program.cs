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
            Human []array = new Human[1000];

            Files f = new Files();
            f.FillArrays(array);

            Men men = new Men();
            men.CompareByGender(array);

            Sort sort = new Sort();
            sort.SpeedWorkInfo(array, sortProperty);

            f.WriteIntoFile(array, sortProperty);
        }
    }
}
