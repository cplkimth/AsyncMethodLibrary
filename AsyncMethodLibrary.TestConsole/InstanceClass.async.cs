#region
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace AsyncMethodLibrary.TestConsole
{
    public partial class InstanceClass
    {
        public Task NoParameterAsync() =>
            Task.Factory.StartNew(() => NoParameter());

        public Task NoReturnAsync(int a) =>
            Task.Factory.StartNew(() => NoReturn(a));

        public Task<int> ScalarReturnAsync(int a, int b) =>
            Task.Factory.StartNew(() => ScalarReturn(a, b));

        public Task<List<int>> GenericReturnAsync(int a, int b) =>
            Task.Factory.StartNew(() => GenericReturn(a, b));

        public Task<List<int>> GenericParameterAsync(List<int> values) =>
            Task.Factory.StartNew(() => GenericParameter(values));

        private Task<List<int>> PrivateAsync(List<int> values) =>
            Task.Factory.StartNew(() => Private(values));
    }
}