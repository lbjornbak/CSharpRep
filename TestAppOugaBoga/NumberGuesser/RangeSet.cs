using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAppOugaBoga.NumberGuesser
{
    public static class RangeSet
    {
        public static string GetRange(int start, int end)
        {
            if (start <= end)
            {
                return $"{start} - {end}";
            }
            else
            {
                return "Invalid range: start should be less than or equal to end.";
            }
        }
    }
}
