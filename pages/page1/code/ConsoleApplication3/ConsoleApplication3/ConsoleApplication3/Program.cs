using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using System.Reflection;
namespace ConsoleApplication3
{
    class Test
    {
        public void Mymethod(string name)
        {
            Console.WriteLine("Hello " + name);
        }
    }

    class Program
    {
        static void Main(string[] args)
        { 
            Assembly asm = Assembly.LoadFile(@"xxxxxxxxxxxxxxxxxxxc#.dll");
            Console.WriteLine(asm.FullName);
            Module[] m= asm.GetModules();//模块
            foreach (Module item in m)
            {
                //Console.WriteLine(item.Name);
            }
            Type[] t = asm.GetTypes(); 
            foreach (Type item in t)
            {
                //ConstructorInfo[] constructors = item.GetConstructors();
                ////Console.WriteLine(constructors);//System.Reflection.ConstructorInfo[]
                ////遍历构造函数
                //foreach (var constructor in constructors)
                //{
                //    Console.WriteLine("Constructor Name："+constructor.Name);
                //    //遍历参数
                //    ParameterInfo[] constructorArguments = constructor.GetParameters();
                //    Console.WriteLine("\n   --参数长度： - " + constructorArguments.Length);
                //    //
                //    foreach (var constructorArgument in constructorArguments)
                //    {
                //        Console.WriteLine("    --参数-" + constructorArgument.ParameterType);
                //    }
                //}
                //Console.WriteLine(item.Namespace);
                Console.WriteLine("------类名称："+item.Namespace+"-----"+item.Name); 
                foreach (MethodInfo classmethod in item.GetMethods())
                {
                    //if (classmethod.Name == "ToString")
                    //{
                    //    Console.WriteLine(classmethod.Invoke(obj, null));
                    //}
                    Console.WriteLine("         ------函数名称："+classmethod.Name);
                }
                foreach (var Proper in item.GetRuntimeProperties())
                {
                    var type = Proper.PropertyType.Name;
                    var IsGenericType = Proper.PropertyType.IsGenericType;
                    var list = Proper.PropertyType.GetInterface("IEnumerable", false);
                    Console.WriteLine($"                 ------属性名称：{item.Name}，类型：{type}");
                    //if (IsGenericType && list != null)
                    //{
                    //    var listVal = Proper.GetValue(model) as IEnumerable<object>;
                    //    if (listVal == null) continue;
                    //    foreach (var aa in listVal)
                    //    {
                    //        var dtype = aa.GetType();
                    //        foreach (var bb in dtype.GetProperties())
                    //        {
                    //            var dtlName = bb.Name.ToLower();
                    //            var dtlType = bb.PropertyType.Name;
                    //            var oldValue = bb.GetValue(aa);
                    //            if (dtlType == typeof(decimal).Name)
                    //            {
                    //                int dit = 4;
                    //                if (dtlName.Contains("price") || dtlName.Contains("amount"))
                    //                    dit = 2;
                    //                bb.SetValue(aa, Math.Round(Convert.ToDecimal(oldValue), dit, MidpointRounding.AwayFromZero));
                    //            }
                    //            Console.WriteLine($"子级属性名称：{dtlName}，类型：{dtlType}，值：{oldValue}");
                    //        }
                    //    }
                    //}
                }

                //Console.WriteLine("\n");
                ////var method = obj.GetType().GetMethod("Start");
                //var method = obj.GetType().GetMethod("ToString");
                ////int parametersLength = obj.GetType().GetMethod("Stop").GetParameters().Length;

                //method.Invoke(obj, null);
            }
            Console.ReadLine();
        }
    }
} 
