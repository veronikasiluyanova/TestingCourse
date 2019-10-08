
namespace LR3_UnitTesting
{
    public class Triangle
    {
        public static bool IsTriangleExisting(double x, double y, double z)
        {
            return x > 0 & y > 0 & z > 0 & x + y > z & x + z > y & y + z > x;            
        }

        static void Main(string[] args)
        {
        }
    }
}
