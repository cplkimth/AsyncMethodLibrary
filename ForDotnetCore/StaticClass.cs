using System.Collections.Generic;
using System.Threading;
using AsyncMethodLibrary;

namespace ForDotNetFramework
{
    public static partial class StaticClass
    {
        [ForAsync]
        public static void NoReturn(this int a)
        {
        }

        [ForAsync]
        public static int ScalarReturn(this int a, int b)
        {
            return a + b;
        }

        [ForAsync]
        public static List<int> GenericReturn(this int a, int b)
        {
            return new List<int> {a + b, a - b};
        }

        [ForAsync]
        public static List<int> GenericParameter(this List<int> values)
        {
            return values.ConvertAll(x => x + 1);
        }
    }
}