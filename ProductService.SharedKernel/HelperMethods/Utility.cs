using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.SharedKernel.HelperMethods
{
    public class Utility
    {
        public static DateTime GetCurrentTime()
        {
            return DateTime.UtcNow.AddHours(1);
        }
    }
}
