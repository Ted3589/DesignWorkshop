using Api.Interfaces;
using Api.Models;
using Api.Repositories;
using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {            
            builder.RegisterType<ClientRepository>().As<IRepository<Client>>().InstancePerLifetimeScope();
            builder.RegisterType<ServiceRepository>().As<IRepository<Service>>().InstancePerLifetimeScope();
            builder.RegisterType<RequestRepository>().As<IRepository<Request>>().InstancePerLifetimeScope();
        }
    }
}
