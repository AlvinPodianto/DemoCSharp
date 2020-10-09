using DemoGateway.Contracts;
using Grpc.Net.Client;
using System.Net.Http;

namespace DemoGateway
{
    public class GrpcClient : IGrpcClient
    {
        public GrpcChannel DepartementChannel { get; }

        public GrpcClient() 
        {
            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            HttpClient httpClient = new HttpClient(httpClientHandler);

            DepartementChannel = GrpcChannel.ForAddress("https://localhost:5000", new GrpcChannelOptions { HttpClient = httpClient });
        }
    }
}