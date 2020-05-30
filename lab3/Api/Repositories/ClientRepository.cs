using Api.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly SoapContext context;

        public ClientRepository(SoapContext context)
        {
            this.context = context;
        }

        public Client Create(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            context.Clients.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            context.Clients.Remove(entity);
            context.SaveChanges();            
        }

        public Client Read(int id)
        {
            return context.Clients.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Client> ReadAll()
        {
            return context.Clients.AsEnumerable();
        }

        public Client Update(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            Client existing = context.Clients.Find(entity.Id);
            context.Entry(existing).CurrentValues.SetValues(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
