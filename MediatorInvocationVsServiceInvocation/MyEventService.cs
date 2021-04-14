using System;
using System.Threading.Tasks;

namespace MediatorInvocationVsServiceInvocation
{
    public class MyEventService
    {
        public Task Foo(string data)
        {
            Console.WriteLine(data);

            return Task.CompletedTask;
        }
    }
}
