namespace MikhailIo.ServiceBusEntityMetrics
{
    using System.Security.Cryptography.X509Certificates;

    public class TopicStatistics : StatisticsBase
    {
        public TopicStatistics(X509Certificate2 certificate, string subscriptionId, string serviceBusNamespace, string topicName)
            : base(certificate, subscriptionId, serviceBusNamespace, $"topics/{topicName}")
        {
        }
    }
}
