class Program 
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Inicializando container");
        var arg1 = Environment.GetEnvironmentVariable("ARG1");
        var arg2 = Environment.GetEnvironmentVariable("ARG2");
        while(true)
        {
            Console.WriteLine($"{arg1} + {arg2}");
            Thread.Sleep(10000);
        }
    }
}