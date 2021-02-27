#region
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace AsyncMethodLibrary.TestConsole
{
    public static partial class StaticClass
    {
        public static Task NoReturnAsync(this int a) =>
            Task.Factory.StartNew(() => NoReturn(a));

        public static Task<int> ScalarReturnAsync(this int a, int b) =>
            Task.Factory.StartNew(() => ScalarReturn(a, b));

        public static Task<List<int>> GenericReturnAsync(this int a, int b) =>
            Task.Factory.StartNew(() => GenericReturn(a, b));

        public static Task<List<int>> GenericParameterAsync(this List<int> values) =>
            Task.Factory.StartNew(() => GenericParameter(values));
    }
}