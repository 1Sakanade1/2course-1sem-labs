using Lab11_v6;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

public class Program
{


    static void Main(string[] args)
    {

        Reflection.GetAssemblyName(typeof(MyClass));

        Console.WriteLine("properties------------------");

        Console.WriteLine(Reflection.GetProperties(typeof(MyClass)));

        Console.WriteLine("constructors------------------");

        Reflection.GetConstructors(typeof(MyClass));

        Console.WriteLine("methods------------------");

        Reflection.GetMethods(typeof(MyClass));

        Console.WriteLine("fields------------------");

        Reflection.GetFields(typeof(MyClass));

        Console.WriteLine("interfaces------------------");

        Reflection.GetInterfaces(typeof(MyClass));

        Console.WriteLine("attributes------------------");

        Reflection.GetMethodAttributes(typeof(MyClass));

        Console.WriteLine("------------------");




        Reflection.InvokeMethodFile(typeof(MyClass), "concatstr");
        Console.WriteLine("----------------------------");
        Reflection.InvokeMethodRand(typeof(MyClass), "concatstr");
        var newTest1 = Reflection.Create(typeof(MyClass));
    }


}