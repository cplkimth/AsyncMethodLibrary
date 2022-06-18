#region
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace ForDotNetFramework
{
    public partial class InstanceClass
    {
        public Task NoParameterAsync() =>
            Task.Run(() => NoParameter());

        public Task NoReturnAsync(Int32 a) =>
            Task.Run(() => NoReturn(a));

        public Task<Int32> ScalarReturnAsync(Int32 a, Int32 b) =>
            Task.Run(() => ScalarReturn(a, b));

        public Task<List<Int32>> GenericReturnAsync(Int32 a, Int32 b) =>
            Task.Run(() => GenericReturn(a, b));

        public Task<List<Int32>> GenericParameterAsync(List<Int32> values) =>
            Task.Run(() => GenericParameter(values));

        private Task<List<Int32>> PrivateAsync(List<Int32> values) =>
            Task.Run(() => Private(values));
    }
}