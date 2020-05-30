using Api.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Repositories
{
    public class RequestRepository : IRepository<Request>
    {
        private readonly SoapContext context;

        public RequestRepository(SoapContext context)
        {
            this.context = context;
        }


        public Request Create(Request entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            context.Requests.Add(entity);
            context.SaveChanges();
            return entity;
        }

        public void Delete(Request entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            context.Requests.Remove(entity);
            context.SaveChanges();
        }

        public Request Read(int id)
        {
            return context.Requests.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Request> ReadAll()
        {
            return context.Requests.AsEnumerable();
        }

        public Request Update(Request entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            Request existing = context.Requests.Find(entity.Id);
            context.Entry(existing).CurrentValues.SetValues(entity);
            context.SaveChanges();
            return entity;
        }
    }
}
