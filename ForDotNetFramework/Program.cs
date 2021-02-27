using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AsyncMethodLibrary;

namespace ForDotNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator.Generate(@".\generated", typeof(StaticClass));
            Generator.Generate(@".\generated", typeof(StaticClass), typeof(InstanceClass));
            Generator.Generate(@".\generated", Assembly.GetExecutingAssembly());
            Generator.Generate(@"C:\git\AsyncMethodLibrary\ForDotNetCore\generated", Assembly.GetExecutingAssembly());
            Generator.Generate(@"C:\git\AsyncMethodLibrary\ForDotNetCore\generated", Assembly.GetExecutingAssembly());
        }
    }
}
