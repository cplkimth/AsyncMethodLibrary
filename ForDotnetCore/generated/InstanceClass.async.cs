#region
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace ForDotNetFramework
{
    public  partial class InstanceClass
    {
        public Task NoParameterAsync( ) => 
            Task.Factory.StartNew(() => NoParameter());

public Task NoReturnAsync( System.Int32 a) => 
            Task.Factory.StartNew(() => NoReturn(a));

public Task<System.Int32> ScalarReturnAsync( System.Int32 a, System.Int32 b) => 
            Task.Factory.StartNew(() => ScalarReturn(a, b));

public Task<System.Collections.Generic.List<System.Int32>> GenericReturnAsync( System.Int32 a, System.Int32 b) => 
            Task.Factory.StartNew(() => GenericReturn(a, b));

public Task<System.Collections.Generic.List<System.Int32>> GenericParameterAsync( System.Collections.Generic.List<System.Int32> values) => 
            Task.Factory.StartNew(() => GenericParameter(values));

private Task<System.Collections.Generic.List<System.Int32>> PrivateAsync( System.Collections.Generic.List<System.Int32> values) => 
            Task.Factory.StartNew(() => Private(values));


    }
}