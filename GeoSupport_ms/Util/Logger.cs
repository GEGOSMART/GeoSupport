using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoSupport_ms.Util
{
    public static class Logger
    {
        public static void Log(string msg)
        {
            System.Diagnostics.Debug.WriteLine("************");
            System.Diagnostics.Debug.WriteLine(msg);
            System.Diagnostics.Debug.WriteLine("************");
        }
    }
}
