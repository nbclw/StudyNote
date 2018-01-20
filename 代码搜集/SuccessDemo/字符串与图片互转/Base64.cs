﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormTest
{
    class Base64
    {
        //编码 
        public static string EncodeBase64(Encoding encode, string source)
        {
            string encodeStr = "";
            byte[] bytes = encode.GetBytes(source);
            try
            {
                encodeStr = Convert.ToBase64String(bytes);
            }
            catch
            {
                encodeStr = source;
            }
            return encodeStr;
        }
        //解码 
        public static string DecodeBase64(Encoding encode, string sourceStr)
        {
            string decode = "";
            byte[] bytes = Convert.FromBase64String(sourceStr);
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = sourceStr;
            }
            return decode;
        }
    }
}
