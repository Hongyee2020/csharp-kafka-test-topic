// // public class Program
// // {
// //     static async Task Main()
// //     {
// //         Console.WriteLine("Hello, World!");
// //         var config = new AdminClientConfig
// //         {
// //             BootstrapServers = "192.168.72.128:19092"
// //         };


// //         using (var adminClient = new AdminClientBuilder(config).Build())
// //         {
// //             try
// //             {
// //                 await adminClient.CreateTopicsAsync(new TopicSpecification[] {
// //                     new TopicSpecification { Name = "hello-topic2", ReplicationFactor = 3, NumPartitions = 2 } });
// //                 Console.WriteLine("ok");
// //             }
// //             catch (CreateTopicsException e)
// //             {
// //                 Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
// //             }
// //         }
// //     }
// // }


// using Confluent.Kafka;
// using System.Net;
// public class Program
// {
//     static async Task Main()
//     {
//         //定义 ProducerConfig 配置
//         var config = new ProducerConfig
//         {
//             // BootstrapServers = "192.168.72.128:19092"
//             BootstrapServers = "118.178.84.42:9092"
//         };

//         //第二步是定义发布消息的过程。例如要发布什么内容、如何记录错误消息、如何拦截异常、自定义消息分区等。
//         using (var producer = new ProducerBuilder<Null, string>(config).Build())
//         {
//             //Value 就是消息的内容。其实一条消息的结构比较复杂的，除了 Value ，还有 Key 和各种元数据，这个在后面的章节中我们再讨论。
//             var result = await producer.ProduceAsync("weblog", new Message<Null, string> { Value = "a log message" });
//         }
//     }

// }


// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;
using Confluent.Kafka.Admin;


public class Program
{
    static async Task Main()
    {
        Console.WriteLine("Hello, World!");
        var config = new AdminClientConfig
        {
            // BootstrapServers = "192.168.72.128:19092"
            BootstrapServers = "118.178.84.42:19092"
        };


        using (var adminClient = new AdminClientBuilder(config).Build())
        {
            try
            {
                await adminClient.CreateTopicsAsync(new TopicSpecification[] {
                    new TopicSpecification { Name = "hello-topic3", ReplicationFactor = 1, NumPartitions = 1 } });
                Console.WriteLine("ok");
            }
            catch (CreateTopicsException e)
            {
                Console.WriteLine($"An error occured creating topic {e.Results[0].Topic}: {e.Results[0].Error.Reason}");
            }
        }
    }
}