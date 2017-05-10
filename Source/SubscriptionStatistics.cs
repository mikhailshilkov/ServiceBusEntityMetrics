namespace MikhailIo.ServiceBusEntityMetrics
{
    using System.Security.Cryptography.X509Certificates;

    public class SubscriptionStatistics : StatisticsBase
    {
        public SubscriptionStatistics(X509Certificate2 certificate, string subscriptionId, string serviceBusNamespace, string topicName, string subscriptionName)
        : base(certificate, subscriptionId, serviceBusNamespace, $"topics/{topicName}/subscriptions/{subscriptionName}")
        {
        }
    }
}
