#region
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace ForDotNetFramework
{
    public static partial class StaticClass
    {
        public static Task NoReturnAsync(this  System.Int32 a) => 
            Task.Factory.StartNew(() => NoReturn(a));

public static Task<System.Int32> ScalarReturnAsync(this  System.Int32 a, System.Int32 b) => 
            Task.Factory.StartNew(() => ScalarReturn(a, b));

public static Task<System.Collections.Generic.List<System.Int32>> GenericReturnAsync(this  System.Int32 a, System.Int32 b) => 
            Task.Factory.StartNew(() => GenericReturn(a, b));

public static Task<System.Collections.Generic.List<System.Int32>> GenericParameterAsync(this  System.Collections.Generic.List<System.Int32> values) => 
            Task.Factory.StartNew(() => GenericParameter(values));


    }
}