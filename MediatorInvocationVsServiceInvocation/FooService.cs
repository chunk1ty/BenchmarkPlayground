using System.Threading.Tasks;
using MediatR;

namespace MediatorInvocationVsServiceInvocation
{
    public class FooService
    {
        private readonly IMediator _mediator;
        private readonly MyEventService _myEventService;

        public FooService(IMediator mediator, MyEventService myEventService)
        {
            _mediator = mediator;
            _myEventService = myEventService;
        }

        public async Task FooMediator(string message)
        {
            await _mediator.Publish(new MyEvent(message));
        }

        public async Task FooMyEventService(string message)
        {
            await _myEventService.Foo(message);
        }
    }
}
