using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace dotNET_module_15_homework
{
    class Program
    {
        static void ex1()
        {
            Console.WriteLine("\nЗАДАЧА №1\n");
            Type consoleType = typeof(Console);
            MethodInfo[] methods = consoleType.GetMethods();

            Console.WriteLine("Методы класса Console:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

        static void ex2()
        {
            Console.WriteLine("\nЗАДАЧА №2\n");

            MyClass myObject = new MyClass
            {
                Number = 1906,
                Text = "Привет!",
                Flag = true
            };

            Type myType = typeof(MyClass);
            PropertyInfo[] properties = myType.GetProperties();

            Console.WriteLine("Свойства объекта MyClass и их значения:");
            foreach (PropertyInfo prop in properties)
            {
                object value = prop.GetValue(myObject);
                Console.WriteLine($"{prop.Name}: {value}");
            }
        }
        
        static void ex3()
        {
            Console.WriteLine("\nЗАДАЧА №3\n");

            string originalString = "Пример строки для обрезки";
            Type stringType = typeof(string);
            MethodInfo substringMethod = stringType.GetMethod("Substring", new Type[] { typeof(int), typeof(int) });

            if (substringMethod != null)
            {
                object[] parameters = { 8, 6 }; // (8 = начальный индекс, 6 = длина подстроки)
                object result = substringMethod.Invoke(originalString, parameters);

                Console.WriteLine("Подстрока: " + result);
            }
        }
        
        static void ex4()
        {
            Console.WriteLine("\nЗАДАЧА №4\n");

            Type listType = typeof(List<>);
            Type[] typeArgs = { typeof(int) };
            Type constructedType = listType.MakeGenericType(typeArgs);

            ConstructorInfo[] constructors = constructedType.GetConstructors();

            Console.WriteLine("Конструкторы класса List<T>: ");
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine(constructor.ToString());
            }
        }
        static void Main(string[] args)
        {
            ex1();
            ex2();
            ex3();
            ex4();
        }
    }
}
