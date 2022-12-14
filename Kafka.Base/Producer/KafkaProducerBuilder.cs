using Confluent.Kafka;

using Microsoft.Extensions.Options;

namespace Kafka.Base.Producer
{
    public class KafkaProducerBuilder : IKafkaProducerBuilder
    {
        private readonly KafkaConfigurations _kafkaOptions;

        public KafkaProducerBuilder(IOptions<KafkaConfigurations> producerWorkerOptions)
        {
            _kafkaOptions = producerWorkerOptions?.Value ??
                            throw new ArgumentNullException(nameof(producerWorkerOptions));
        }

        public IProducer<string, string> Build()
        {
            var config = new ClientConfig
            {
                BootstrapServers = _kafkaOptions.KafkaBootstrapServers
            };

            var producerBuilder = new ProducerBuilder<string, string>(config);

            return producerBuilder.Build();
        }
    }
}