using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CedarLogic.Identity
{
    public static class ReflectionHelper
    {
        public static Dictionary<string,string> GetClaimTypes(Type type)
        {
            Dictionary<string, string> constants = new Dictionary<string, string>();

            FieldInfo[] fi = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            foreach (var item in fi)
            {
                if (item.IsLiteral && !item.IsInitOnly)
                    constants.Add(item.Name, (string)item.GetValue(null));
            }

            return constants;
        }
    }
}
