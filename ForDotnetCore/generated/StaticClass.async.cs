#region
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace ForDotNetFramework
{
    public static partial class StaticClass
    {
        public static Task NoReturnAsync(this Int32 a) =>
            Task.Run(() => NoReturn(a));

        public static Task<Int32> ScalarReturnAsync(this Int32 a, Int32 b) =>
            Task.Run(() => ScalarReturn(a, b));

        public static Task<List<Int32>> GenericReturnAsync(this Int32 a, Int32 b) =>
            Task.Run(() => GenericReturn(a, b));

        public static Task<List<Int32>> GenericParameterAsync(this List<Int32> values) =>
            Task.Run(() => GenericParameter(values));
    }
}