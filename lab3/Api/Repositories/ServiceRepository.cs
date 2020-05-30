using Api.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class ServiceRepository : IRepository<Service>
    {
        private readonly SoapContext context;

        public ServiceRepository(SoapContext context)
        {
            this.context = context;
        }


        public Service Create(Service entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            context.Services.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(Service entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            context.Services.Remove(entity);
            context.SaveChanges();
        }

        public Service Read(int id)
        {
            return context.Services.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Service> ReadAll()
        {
            return context.Services.AsEnumerable();
        }

        public Service Update(Service entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            Service existing = context.Services.Find(entity.Id);
            context.Entry(existing).CurrentValues.SetValues(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
