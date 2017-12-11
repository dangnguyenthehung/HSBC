using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace HSCB.Utilities
{
    public static class Utilities
    {
        public static T Cast<T>(this object myobj)
        {
            var objectType = myobj.GetType();
            var target = typeof(T);
            var x = Activator.CreateInstance(target, false);
            var z = from source in objectType.GetMembers().ToList()
                where source.MemberType == MemberTypes.Property
                select source;
            var d = from source in target.GetMembers().ToList()
                where source.MemberType == MemberTypes.Property
                select source;
            var members = d.Where(memberInfo => d.Select(c => c.Name)
                .ToList().Contains(memberInfo.Name)).ToList();

            foreach (var memberInfo in members)
            {
                var propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                var value = myobj.GetType().GetProperty(memberInfo.Name)?.GetValue(myobj, null);

                if (propertyInfo != null)
                {
                    propertyInfo.SetValue(x, value, null);
                }
            }
            return (T)x;
        }

        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }

        public static string EncryptMd5(string content)
        {
            // Tham khảo về MD5: https://msdn.microsoft.com/en-us/library/system.security.cryptography.md5(v=vs.110).aspx
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(content));
                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();
                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
    }
}