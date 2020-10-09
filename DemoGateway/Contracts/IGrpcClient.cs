using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoGateway.Contracts
{
    public interface IGrpcClient
    {
        GrpcChannel DepartementChannel { get; }
        //GrpcChannel EmployeeClient { get; }
    }
}
