namespace MikhailIo.ServiceBusEntityMetrics
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using Newtonsoft.Json;

    public abstract class StatisticsBase : IDisposable
    {
        private readonly AzureManagementClient client;
        private readonly string subscriptionId;
        private readonly string serviceBusNamespace;
        private readonly string path;

        protected StatisticsBase(X509Certificate2 certificate, string subscriptionId, string serviceBusNamespace, string path)
        {
            this.client = new AzureManagementClient(certificate);
            this.subscriptionId = subscriptionId;
            this.serviceBusNamespace = serviceBusNamespace;
            this.path = path;
        }

        public DataPoint[] GetMetricSince(string metric, DateTime utcTime)
        {
            var time = utcTime.ToString("yyyy-MM-ddTHH:mm:ss") + "Z";
            var url = $"https://management.core.windows.net/{this.subscriptionId}/services/servicebus/namespaces/{this.serviceBusNamespace}/{this.path}/Metrics/{metric}/Rollups/PT5M/Values?$filter=Timestamp%20ge%20datetime'{time}'";
            var result = client.DownloadString(url);
            return JsonConvert.DeserializeObject<DataPoint[]>(result);
        }

        public void Dispose() => this.client.Dispose();
    }
}
