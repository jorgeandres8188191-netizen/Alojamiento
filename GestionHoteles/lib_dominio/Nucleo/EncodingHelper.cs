using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lib_dominio.Nucleo
{
    public class EncodingHelper
    {
        public static string ToString(byte[] data)
        {
            return Convert.ToBase64String(data);
        }
        public static byte[] ToBytes(string data)
        {
            return Convert.FromBase64String(data);
        }
    }
}
