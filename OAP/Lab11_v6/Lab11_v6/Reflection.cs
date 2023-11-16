using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Lab11_v6
{
    internal static class Reflection
    {
           




        public static void GetAssemblyName(Type type)
        {
            Console.WriteLine("Имя сборки: " + type.Assembly); //имя сборки
        }

        public static void GetConstructors(Type type)
        {
            Console.WriteLine("Конструкторы: ");
            foreach (var elem in type.GetConstructors())
            {
                Console.WriteLine(elem);// конструкторы
            }
        }

        public static void GetMethods(Type type)
        {

            Console.WriteLine("Методы: ");
            foreach (var elem in type.GetMethods())//методы
            {
                Console.WriteLine(elem);
            }
        }


        public static PropertyInfo[] GetProperties(Type type) => type.GetProperties();//свойства



        public static FieldInfo[] GetFields(Type type) => type.GetFields();//поля



        public static System.Type[] GetInterfaces(Type type) => type.GetInterfaces();//интерфейсы



        public static System.Reflection.MethodInfo[] GetMethodAttributes(Type type)=> type.GetMethods();//методы



        public static object InvokeMethodFile(Type type, string methodName)
        {
            var method = type.GetMethod(methodName);
            var parameters = method.GetParameters();

            object obj = Activator.CreateInstance(type);

            object[] values;
            using (var sr = new StreamReader(@"C:\Container\code\lab11.txt"))
            {
                values = sr.ReadToEnd().Split().ToArray();
            }


            object result = method.Invoke(obj, values);
            Console.WriteLine(result);

            return result;
        }


        public static void InvokeMethodRand(Type type, string methodName)
        {
            var method = type.GetMethod(methodName);
            var parameters = method.GetParameters();
            var values = new object[parameters.Length];

            object obj = Activator.CreateInstance(type);

            Random rnd = new Random();


            for (int i = 0; i < parameters.Length; i++)
            {
                values[i] =Convert.ToString( rnd.Next(0, 10));
            }
            method.Invoke(obj, values);
        }

        public static object Create(Type type)
        {
           object obj = Activator.CreateInstance(type);
            Console.WriteLine($"вы создали объект {obj}"); ;
            return obj;
        }




    }
}
