using System;
using System.Reflection;

namespace AzrieliCom.Utility.Abstractions
{
    public abstract class AbstractStruct
    {
        public PropertyInfo[] GetPublicAttributes() 
            => GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance);
    }
}
