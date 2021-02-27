using System;

namespace AsyncMethodLibrary
{
    /// <summary>
    /// Indicates that async wrapper method of this method will be generated
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ForAsync : Attribute
    {
    }
}