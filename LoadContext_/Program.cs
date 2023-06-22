using System.Runtime.Loader;
using System.Reflection;

Square(35);
GC.Collect();
GC.WaitForPendingFinalizers();

void Square(int number)
{
    AssemblyLoadContext context = new AssemblyLoadContext(name:"Square", isCollectible:true);
    context.Unloading += Context_Unloading;

    var assemblyPath =
        @"C:\Users\zamanov\source\repos\Zamanof\FBMS_1223\ThirdParty\bin\Debug\net6.0\ThirdParty.dll";
    var assembly = context.LoadFromAssemblyPath(assemblyPath);
    var type = assembly.GetType("ThirdParty.Program");
    if (type != null)
    {
        var squareMethod = type.GetMethod("Square", BindingFlags.Static | BindingFlags.NonPublic);
        var result = squareMethod?.Invoke(assembly, new object[] { number });
        if (result is int)
        {
            Console.WriteLine($"{number} ^ 2 = {result}");
        }
    }
    foreach (Assembly asm in AppDomain.CurrentDomain.GetAssemblies())
    {
        Console.WriteLine(asm.GetName().Name);
    }
    context.Unload();
}

void Context_Unloading(AssemblyLoadContext obj)
{
    Console.WriteLine("Assembly unload");
}