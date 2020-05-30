using Api.Interfaces;
using Api.Models;
using Api.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Services
{
    public class SoapService : ISoapService
    {
        private readonly IRepository<Client> clientRepository;
        private readonly IRepository<Service> serviceRepository;
        private readonly IRepository<Request> requestRepository;

        public SoapService(IRepository<Client> clientRepository, IRepository<Service> serviceRepository, IRepository<Request> requestRepository)
        {
            this.clientRepository = clientRepository;
            this.serviceRepository = serviceRepository;
            this.requestRepository = requestRepository;
        }

        public Client CreateClient(Client client)
        {
            Console.WriteLine("check");
            return clientRepository.Create(client);
        }

        public Request CreateRequest(Request request)
        {
            return requestRepository.Create(request);
        }

        public Service CreateService(Service service)
        {
            return serviceRepository.Create(service);
        }

        public void DeleteClient(Client client)
        {
            clientRepository.Delete(client);
        }

        public void DeleteRequest(Request request)
        {
            requestRepository.Delete(request);
        }

        public void DeleteService(Service service)
        {
            serviceRepository.Delete(service);
        }

        public IEnumerable<Client> ReadAllClients()
        {
            return clientRepository.ReadAll();
        }

        public IEnumerable<Request> ReadAllRequests()
        {
            return requestRepository.ReadAll();
        }

        public IEnumerable<Service> ReadAllServices()
        {
            return serviceRepository.ReadAll();
        }

        public Client UpdateClient(Client client)
        {
            return clientRepository.Update(client);
        }

        public Request UpdateRequest(Request request)
        {
            return requestRepository.Update(request);
        }

        public Service UpdateService(Service service)
        {
            return serviceRepository.Update(service);
        }
    }
}
