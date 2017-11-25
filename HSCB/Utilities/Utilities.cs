using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    }
}