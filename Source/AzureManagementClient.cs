namespace MikhailIo.ServiceBusEntityMetrics
{
    using System;
    using System.Net;
    using System.Security.Cryptography.X509Certificates;

    internal class AzureManagementClient : WebClient
    {
        private readonly X509Certificate2 certificate;

        public AzureManagementClient(X509Certificate2 certificate)
        {
            this.certificate = certificate;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = (HttpWebRequest)base.GetWebRequest(address);

            request.ClientCertificates.Add(this.certificate);
            request.Headers.Add("x-ms-version: 2013-10-01");
            request.Accept = "application/json";

            return request;
        }
    }
}
