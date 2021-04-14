using BenchmarkDotNet.Running;

namespace MediatorInvocationVsServiceInvocation
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
