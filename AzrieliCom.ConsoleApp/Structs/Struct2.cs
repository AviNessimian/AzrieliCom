using AzrieliCom.Utility.Abstractions;

namespace AzrieliCom.ConsoleApp.Structs
{
    class Struct2 : AbstractStruct
    {
        public string Prop1 { get; set; }
        public Struct3 Prop2 { get; set; }
    }
}