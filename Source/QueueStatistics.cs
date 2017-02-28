namespace MikhailIo.ServiceBusEntityMetrics
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using Newtonsoft.Json;

    public class QueueStatistics : IDisposable
    {
        private readonly AzureManagementClient client;
        private readonly string serviceBusNamespace;
        private readonly string queueName;

        public QueueStatistics(X509Certificate2 certificate, string serviceBusNamespace, string queueName)
        {
            this.client = new AzureManagementClient(certificate);
            this.serviceBusNamespace = serviceBusNamespace;
            this.queueName = queueName;
        }

        public DataPoint[] GetMetricSince(string metric, DateTime utcTime)
        {
            var time = utcTime.ToString("yyyy-MM-ddTHH:mm:ss") + "Z";
            var url = $"https://management.core.windows.net/51483f81-2dd8-4fd7-9706-3fe8e873d898/services/servicebus/namespaces/{this.serviceBusNamespace}/queues/{this.queueName}/Metrics/{metric}/Rollups/PT5M/Values?$filter=Timestamp%20ge%20datetime'{time}'";
            var result = client.DownloadString(url);
            return JsonConvert.DeserializeObject<DataPoint[]>(result);
        }

        public void Dispose() => this.client.Dispose();
    }
}
