using System.Collections.Generic;
using System.Threading;
using AsyncMethodLibrary;

namespace ForDotNetFramework
{
    public partial class InstanceClass
    {
        [ForAsync]
        public void NoParameter()
        {
        }

        [ForAsync]
        public void NoReturn(int a)
        {
        }

        [ForAsync]
        public int ScalarReturn(int a, int b)
        {
            return a + b;
        }

        [ForAsync]
        public List<int> GenericReturn(int a, int b)
        {
            return new List<int> {a + b, a - b};
        }

        [ForAsync]
        public List<int> GenericParameter(List<int> values)
        {
            return values.ConvertAll(x => x + 1);
        }

        [ForAsync]
        private List<int> Private(List<int> values)
        {
            return values.ConvertAll(x => x + 1);
        }
    }
}