using System.Collections.Generic;
using System.Threading;

namespace AsyncMethodLibrary.TestConsole
{
    public partial class InstanceClass
    {
        [AsyncGen]
        public void NoParameter()
        {
        }

        [AsyncGen]
        public void NoReturn(int a)
        {
        }

        [AsyncGen]
        public int ScalarReturn(int a, int b)
        {
            return a + b;
        }

        [AsyncGen]
        public List<int> GenericReturn(int a, int b)
        {
            return new List<int> {a + b, a - b};
        }

        [AsyncGen]
        public List<int> GenericParameter(List<int> values)
        {
            return values.ConvertAll(x => x + 1);
        }

        [AsyncGen]
        private List<int> Private(List<int> values)
        {
            return values.ConvertAll(x => x + 1);
        }
    }
}