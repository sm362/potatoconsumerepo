using System;
using System.Text.Json;
using Confluent.Kafka;

namespace potatoconsumer;


public class Cl_A {
    public int Id { get; set; }
    public string Name { get; set; }
}
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
                //Cl_A deserob = JsonSerializer.Deserialize<Cl_A>(response.Message.Value);
                Console.WriteLine($"🥣 {response.Message.Value}"  );
            }
        }
    }
}
