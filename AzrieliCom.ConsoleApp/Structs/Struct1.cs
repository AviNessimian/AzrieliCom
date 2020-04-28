using AzrieliCom.Utility.Abstractions;

namespace AzrieliCom.ConsoleApp.Structs
{
    class Struct1 : AbstractStruct
    {
        public string Prop1 { get; set; }
        public Struct2 Prop2 { get; set; }
        public string Prop3 { get; set; }
    }
}
