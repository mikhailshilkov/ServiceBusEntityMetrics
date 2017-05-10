namespace MikhailIo.ServiceBusEntityMetrics
{
    using System.Security.Cryptography.X509Certificates;

    public class QueueStatistics : StatisticsBase
    {
        public QueueStatistics(X509Certificate2 certificate, string subscriptionId, string serviceBusNamespace, string queueName)
            : base(certificate, subscriptionId, serviceBusNamespace, $"queues/{queueName}")
        {
        }
    }
}
