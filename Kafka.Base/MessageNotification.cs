using MediatR;

namespace Kafka.Base
{
    public class MessageNotification<TMessage> : INotification
        where TMessage : IMessage
    {
        public MessageNotification(TMessage message)
        {
            Message = message;
        }

        public TMessage Message { get; }
    }
}