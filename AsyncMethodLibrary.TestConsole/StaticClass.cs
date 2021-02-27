using System.Collections.Generic;
using System.Threading;

namespace AsyncMethodLibrary.TestConsole
{
    public static partial class StaticClass
    {
        [AsyncGen]
        public static void NoReturn(this int a)
        {
        }

        [AsyncGen]
        public static int ScalarReturn(this int a, int b)
        {
            return a + b;
        }

        [AsyncGen]
        public static List<int> GenericReturn(this int a, int b)
        {
            return new List<int> {a + b, a - b};
        }

        [AsyncGen]
        public static List<int> GenericParameter(this List<int> values)
        {
            return values.ConvertAll(x => x + 1);
        }
    }
}