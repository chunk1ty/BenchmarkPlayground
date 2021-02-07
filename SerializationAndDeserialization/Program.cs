using BenchmarkDotNet.Running;

namespace SerializationAndDeserialization
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
} 