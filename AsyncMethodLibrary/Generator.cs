#region
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
#endregion

namespace AsyncMethodLibrary
{
    public class Generator
    {
        /// <summary>
        /// Generate and write async wrapper method for sync method of certain class types
        /// </summary>
        /// <param name="targetDirectory">a directory in which generated file(s) will be</param>
        /// <param name="types">types of classes which contain sync method</param>
        public static void Generate(string targetDirectory, params Type[] types)
        {
            foreach (var type in types)
                GenerateCore(targetDirectory, type);
        }

        /// <summary>
        /// Generate and write async wrapper method for sync method in assembly
        /// </summary>
        /// <param name="targetDirectory">a directory in which generated file(s) will be</param>
        /// <param name="assembly">an assembly which contains types of classes which contain sync method</param>
        public static void Generate(string targetDirectory, Assembly assembly)
        {
            var types = assembly.GetTypes();
            Generate(targetDirectory, types);
        }
        
        private static void GenerateCore(string targetDirectory, Type type)
        {
            var methods = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => x.GetCustomAttribute<ForAsync>() != null)
                .ToList();

            if (methods.Count == 0)
                return;

            StringBuilder builder = new StringBuilder();

            foreach (var method in methods)
            {
                var generatedCode = GenerateForMethod(method);
                builder.AppendLine(generatedCode);
                builder.AppendLine();
            }


            var @static = type.IsAbstract && type.IsSealed ? "static" : string.Empty;

            var contents  = 
$@"#region
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
#endregion

namespace {type.Namespace}
{{
    public {@static} partial class {type.Name}
    {{
        {builder}
    }}
}}";

            if (Directory.Exists(targetDirectory) == false)
                Directory.CreateDirectory(targetDirectory);

            string targetFile = Path.Combine(targetDirectory, type.Name + ".async.cs");
            if (File.Exists(targetFile))
            {
                Console.WriteLine("Output file exists already. Do you want to overwrite it? (n/[Y])");
                var input = Console.ReadLine();
                if (input.ToLower() == "n")
                    return;
            }

            File.WriteAllText(targetFile, contents);
        }

        private static string GenerateForMethod(MethodInfo method)
        {
            /*
             public static Task<IEnumerable<Price>> LoadPriceAsync(this Stock stock, DateTime from, DateTime to) => 
            Task.Factory.StartNew(() => LoadPrice(stock, from, to));
             */

            var pamameters = method.GetParameters();

            string @static = method.IsStatic ? "static " : string.Empty;
            string returnType = ExtractReturnType(method);
            string methodName = method.Name;
            string typeAndNames = ExtractParameterTypeAndNames(pamameters);
            string names = ExtractParameterNames(pamameters);
            string @this = ExtractThis(method);
            string accessModifier = ExtractAccessModifier(method);

            string contents = $"{accessModifier} {@static}{returnType} {methodName}Async({@this} {typeAndNames}) => \r\n            Task.Factory.StartNew(() => {methodName}({names}));";

            return contents;
        }

        private static string ExtractAccessModifier(MethodInfo method)
        {
            if (method.IsPrivate)
                return "private";
            if (method.IsFamily)
                return "protected";
            if (method.IsFamilyOrAssembly)
                return "protected internal";
            if (method.IsAssembly)
                return "internal";
            if (method.IsPublic)
                return "public";
            if (method.IsFamilyAndAssembly)
                return "private protected";
            
            throw new ArgumentException(method.Name);
        }

        private static string ExtractThis(MethodInfo method)
        {
            if (method.IsDefined(typeof(ExtensionAttribute), true))
                return "this ";
            else
                return string.Empty;
        }

        private static string ExtractReturnType(MethodInfo method)
        {
            // Task<IEnumerable<Price>>

            if (method.ReturnType == typeof(void))
                return "Task";
            else
                return $"Task<{ToGenericTypeString(method.ReturnType)}>";
        }

        private static string ToGenericTypeString(Type type)
        {
            // https://stackoverflow.com/questions/2448800/given-a-type-instance-how-to-get-generic-type-name-in-c

            if (!type.IsGenericType)
                return type.FullName;

            string genericTypeName = type.GetGenericTypeDefinition().FullName;
            genericTypeName = genericTypeName.Substring(0,
                genericTypeName.IndexOf('`'));
            string genericArgs = string.Join(",",
                type.GetGenericArguments()
                    .Select(ta => ToGenericTypeString(ta)).ToArray());
            return genericTypeName + "<" + genericArgs + ">";
        }

        private static string ExtractParameterNames(ParameterInfo[] parameters)
        {
            // stock, from, to
            var query = parameters.Select(x => x.Name);
            return string.Join(", ", query);
        }

        private static string ExtractParameterTypeAndNames(ParameterInfo[] parameters)
        {
            // Stock stock, DateTime from, DateTime to
            var query = parameters.Select(x => ToGenericTypeString(x.ParameterType) + " " + x.Name);
            return string.Join(", ", query);
        }
    }
}