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
            Generator.Generate(@"C:\git\AsyncMethodLibrary\ForDotNetCore\generated", Assembly.GetExecutingAssembly());
        }
    }
}