
using Azure.Messaging.ServiceBus;

using DotNext;

using System;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Azure.ServiceBus
{
    public class AzSvcBusPlayground
    {
        private const string SvcBusUrl = "Endpoint=sb://btssvcbus.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Q/EiojtT7piIglv7m336u+esmBG7Qdn59+ASbMCvAUE=";

        public async Task<Result<T>> SendMessageAsync<T>(T objectToSend)
        {
            var client = new ServiceBusClient(SvcBusUrl);

            var sender = client.CreateSender("venueTopic");
            ;
            await sender.SendMessageAsync(new ServiceBusMessage()
            {
                ContentType = "application/json",
                Subject = "VenueCreated",
                Body = BinaryData.FromObjectAsJson(objectToSend)
            });

            return new Result<T>(objectToSend);
        }

        public async Task<Result<T>> ReceiveMessageAsync<T>(string queueName)
        {
            var client = new ServiceBusClient(SvcBusUrl);

            var receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions()
            {
                ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete
            });

            var message = await receiver.ReceiveMessageAsync();
            
            return new Result<T>(message.Body.ToObjectFromJson<T>());
        }
    }
}