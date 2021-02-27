using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncMethodLibrary.TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator.Generate(typeof(InstanceClass), @"C:\git\AsyncMethodLibrary\ForDotNetFramework\generated\InstanceClass.cs");
            Generator.Generate(typeof(StaticClass), @"C:\git\AsyncMethodLibrary\ForDotNetFramework\generated\StaticClass.cs");
        }
    }
}
