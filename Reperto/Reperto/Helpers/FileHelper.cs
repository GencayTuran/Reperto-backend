using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reperto.Helpers
{
        public static class FileHelper
        {
            public static string FileToText(string filePath)
            {
                string content ="";
                using (StreamReader s = new StreamReader(filePath))
                {
                    content = s.ReadToEnd();
                }

                return content;
        }


        //Encode
        public static string Base64Encode(string file)
        {
            var bytes = Encoding.UTF8.GetBytes(file);
            return Convert.ToBase64String(bytes);
        }

        //Decode
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }


}
