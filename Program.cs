using potatoconsumer;
using NLog;
internal class Program
{
    private static void Main(string[] args)
    {
        var logger = NLog.LogManager.GetCurrentClassLogger();
        var a = "🫎";
        logger.Info("in main fn 🌵 {0}", a);

        kafkaconscl ob = new kafkaconscl();
        ob.consfn();
    }
}


/*
> dotnet add package NLog --version 5.3.4
*/