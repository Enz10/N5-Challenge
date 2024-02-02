using Confluent.Kafka;
using System;


namespace N5_Web_Api.Configuration
{
    public class KafkaProducer
    {
        private readonly string _bootstrapServers;
        private readonly string _topicName;

        public KafkaProducer(string bootstrapServers, string topicName)
        {
            _bootstrapServers = bootstrapServers;
            _topicName = topicName;
        }

        public async Task ProduceAsync(string operationName)
        {
            var config = new ProducerConfig { BootstrapServers = _bootstrapServers };

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                var message = new
                {
                    Id = Guid.NewGuid().ToString(),
                    OperationName = operationName
                };

                var messageValue = System.Text.Json.JsonSerializer.Serialize(message);

                await producer.ProduceAsync(_topicName, new Message<Null, string> { Value = messageValue });
                Console.WriteLine($"Mensaje producido: {messageValue}");
            }
        }
    }

}
