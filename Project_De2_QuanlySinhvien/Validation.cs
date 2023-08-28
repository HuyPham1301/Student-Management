using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_De2_QuanlySinhvien
{
    public class Validation
    {
        public bool checkDecimal(string input)
        {
            decimal number = 0;
            if (decimal.TryParse(input, out number))
                return true;
            return false;
        }

        public bool checkInt(string input)
        {
            int number = 0;
            if (int.TryParse(input, out number))
                return true;
            return false;
        }
    }
}
