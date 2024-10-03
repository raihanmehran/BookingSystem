namespace BookingSystem.Api.Services.Interfaces
{
    public interface IMessageProducer
    {
        public void SendingMessage<T>(T message);
    }
}