using System.Reflection;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MediatorInvocationVsServiceInvocation
{
    //|   Method |     Mean |    Error |   StdDev |   Median | Gen 0 | Gen 1 | Gen 2 | Allocated |
    //|--------- |---------:|---------:|---------:|---------:|------:|------:|------:|----------:|
    //| mediator | 125.8 us |  9.62 us | 28.22 us | 124.6 us |     - |     - |     - |     368 B |
    //|  service | 139.2 us | 11.83 us | 34.50 us | 120.5 us |     - |     - |     - |         - |

    //Mean      : Arithmetic mean of all measurements
    //Error     : Half of 99.9% confidence interval
    //StdDev    : Standard deviation of all measurements
    //Median    : Value separating the higher half of all measurements(50th percentile)
    //Gen 0     : GC Generation 0 collects per 1000 operations
    //Gen 1     : GC Generation 1 collects per 1000 operations
    //Gen 2     : GC Generation 2 collects per 1000 operations
    //Allocated : Allocated memory per single operation(managed only, inclusive, 1KB = 1024B)
    //1 us      : 1 Microsecond(0.000001 sec)
    [MemoryDiagnoser]
    public class Benchmark
    {
        private readonly ServiceProvider _serviceProvider;

        public Benchmark()
        {
            _serviceProvider = new ServiceCollection()
                                .AddMediatR(Assembly.GetExecutingAssembly())
                                .AddSingleton<FooService>()
                                .AddSingleton<MyEventService>()
                                .BuildServiceProvider();
        }

        [Benchmark(Description = "mediator")]
        public async Task DeserializeObject()
        {
            var fooService = _serviceProvider.GetService<FooService>();
            await fooService.FooMediator("mediator");
        }

        [Benchmark(Description = "service")]
        public async Task PopulateObject()
        {
            var fooService = _serviceProvider.GetService<FooService>();
            await fooService.FooMyEventService("service");
        }
    }
}
