using System;

namespace DornadzorTestWebApi.BLL.Exeptions
{
    public class ServiceNotEnoughDataExeption : Exception
    {
        public ServiceNotEnoughDataExeption(string message) : base(message)
        {

        }
    }
}
