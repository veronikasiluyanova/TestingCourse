using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR3_UnitTesting
{
    public class Triangle
    {
        public static bool CheckExisting(double x, double y, double z)
        {
            if (x <= 0 || y <= 0 || z <= 0)
                return false;
            else
            {
                if (x + y > z && x + z > y && y + z > x)
                    return true;
                else
                    return false;
            }
        }

        static void Main(string[] args)
        {
        }
    }
}
