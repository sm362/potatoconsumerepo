using System;
using Confluent.Kafka;

namespace potatoconsumer;

public class kafkaconscl
{
    public void consfn() 
    {
        
        var config = new ConsumerConfig {  // consumerconfig is from confluent kafka
            GroupId="potatoconsumergroup" ,
            BootstrapServers = "localhost:9092",
            AutoOffsetReset=AutoOffsetReset.Earliest
        };

        using var consumer = new ConsumerBuilder<Ignore,string>( config: config  ).Build();

        // CancellationTokenSource tokenSource = new CancellationTokenSource();

        consumer.Subscribe("potatotopic1");

        while(true)
        {
            var response = consumer.Consume();
            if(response.Message != null) 
            {
                Console.WriteLine($"🥣 {response.Message.Value}"  );
            }
        }
    }
}
