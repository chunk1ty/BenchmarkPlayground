using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatorInvocationVsServiceInvocation
{
    public class MyEvent : INotification
    {
        public MyEvent(string data)
        {
            Data = data;
        }

        public string Data { get;  }
    }

    public class MyEventHandler : INotificationHandler<MyEvent>
    {
        public Task Handle(MyEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(notification.Data);

            return Task.CompletedTask;
        }
    }
}
