using System;
using System.Linq;
using System.Reflection;


public static class CreateInstance
{
    /// <summary>
    /// Creates an instance of a class according to its name
    /// </summary>
    /// <param name="className"> name of the class to instanciate </param>
    /// <returns> An instance of the class </returns>

    public static object MagicallyCreateInstance(string className)
    {
        var assembly = Assembly.GetExecutingAssembly();

        var type = assembly.GetTypes().First(t => t.Name == className);

        return Activator.CreateInstance(type);
    }
}
