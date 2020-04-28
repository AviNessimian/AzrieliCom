using System;

namespace AzrieliCom.Utility.Abstractions
{
    public interface IUtility
    {
        void Handle<T>(T structObject, Action<string, string, int> printStruct, Action<string, string, int> printPublicAttribute) where T : AbstractStruct;

    }

}
