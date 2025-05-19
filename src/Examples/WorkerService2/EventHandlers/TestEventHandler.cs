using LightMediator;
using WorkerService2.Events;

namespace WorkerService2.EventHandlers;

internal class TestEventHandler : NotificationHandler<TestEvent>
{
    public override Task Handle(TestEvent message, CancellationToken? cancellationToken)
    {
        throw new NotImplementedException();
    }
}
