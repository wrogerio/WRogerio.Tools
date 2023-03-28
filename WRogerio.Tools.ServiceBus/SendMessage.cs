using Azure.Messaging.ServiceBus;

namespace WRogerio.Tools.ServiceBus
{
    public class SendMessage
    {
        /// <summary>
        /// Método usado para enviar mensagem para um tópico no Azure Service Bus
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="topicName"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task<bool> SendMessageToTopic(string connectionString, string topicName, object message)
        {
            await using ServiceBusClient client = new ServiceBusClient(connectionString);
            ServiceBusSender senderObj = client.CreateSender(topicName);

            ServiceBusMessage messageObg = new ServiceBusMessage(message.ToString());
            try
            {
                await senderObj.SendMessageAsync(messageObg);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}