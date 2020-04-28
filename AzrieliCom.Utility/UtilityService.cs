using AzrieliCom.Utility.Abstractions;
using System;
using System.Reflection;

namespace AzrieliCom.Utility
{
    public class UtilityService : IUtility
    {
        int position = 0;

        public void Handle<T>(T structObject, Action<string, string, int> printStruct, Action<string, string, int> printPublicAttribute) where T : AbstractStruct
        {
            printStruct(null, structObject.GetType().ToString(), position);

            Execute(structObject, printStruct, printPublicAttribute);
        }


        private void Execute(AbstractStruct structObject, Action<string, string, int> printStruct, Action<string, string, int> printPublicAttribute)
        {
            var props = structObject.GetPublicAttributes();
            position++;

            for (int i = 0; i < props.Length; i++)
            {

                if (props[i].GetValue(structObject, null) == null) continue;

                var innerStructObject = props[i].GetValue(structObject, null) as AbstractStruct;

                if (innerStructObject != null)
                {
                    printStruct(props[i].Name, innerStructObject.GetType().ToString(), position);

                    Execute(innerStructObject, printStruct, printPublicAttribute);
                    position--;
                }
                else if (props[i].PropertyType.IsPrimitive || props[i].PropertyType == typeof(string))
                {
                    var value = props[i].GetValue(structObject, null);

                    printPublicAttribute(props[i].Name, value.ToString(), position);
                }
                else throw new Exception($"Object of type {props[i].PropertyType.Name} is not supported yet!");
            }

        
        }
    }
}
