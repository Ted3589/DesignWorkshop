using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ServiceModel;
using Api.Models;

namespace Api.Interfaces
{    
    [ServiceContract]
    public interface ISoapService
    {
        [OperationContract]
        Client CreateClient(Client client);

        [OperationContract]
        IEnumerable<Client> ReadAllClients();

        [OperationContract]
        Client UpdateClient(Client client);

        [OperationContract]
        void DeleteClient(Client client);

        [OperationContract]
        Service CreateService(Service service);

        [OperationContract]
        IEnumerable<Service> ReadAllServices();

        [OperationContract]
        Service UpdateService(Service service);

        [OperationContract]
        void DeleteService(Service service);

        [OperationContract]
        Request CreateRequest(Request request);

        [OperationContract]
        IEnumerable<Request> ReadAllRequests();

        [OperationContract]
        Request UpdateRequest(Request request);

        [OperationContract]
        void DeleteRequest(Request request);
    }
}
