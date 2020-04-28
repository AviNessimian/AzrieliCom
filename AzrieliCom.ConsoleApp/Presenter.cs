using AzrieliCom.ConsoleApp.Structs;
using AzrieliCom.Utility.Abstractions;
using Microsoft.Extensions.Logging;
using System;

namespace AzrieliCom.ConsoleApp
{
    class Presenter
    {
        private readonly ILogger<Presenter> _logger;
        private readonly IUtility _utility;

        public Presenter(ILogger<Presenter> logger, IUtility utility)
        {
            _logger = logger;
            _utility = utility;
        }

        public void Handle(AppSettings appSettings)
        {
            _logger.LogInformation("Start");
            

            var struct1 = new Struct1()
            {
                Prop1 = "123",
                Prop2 = new Struct2()
                {
                    Prop1 = "456",
                    Prop2 = new Struct3()
                    {
                        Prop1 = "789"
                    }
                },
                Prop3 = "last"

            };

            _utility.Handle(struct1,
                (key, name, position) =>
                {
                    if (position == 0)
                    {
                        Console.WriteLine($"Object of Class {ClassNameOnly(name)}");
                        Console.WriteLine($"--------------------");
                    }
                    else
                    {
                        Console.WriteLine($"{Space(position)} {key} = ");
                        Console.WriteLine($"{Space(position)} Object of Class {ClassNameOnly(name)}");
                        Console.WriteLine($"{Space(position)} --------------------");
                    }
                },
                (key, value , position) =>
                {
                    Console.WriteLine($"{Space(position)} {key} = {value}");
                });

        }

        private Func<int, string> Space = (position) => String.Empty.PadRight((position * 10), ' ');

        private Func<string, string> ClassNameOnly = (str) => str.Substring(str.LastIndexOf('.') + 1);
    }
}
