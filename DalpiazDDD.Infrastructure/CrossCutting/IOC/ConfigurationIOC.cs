using Autofac;
using DalpiazDDD.Application;
using DalpiazDDD.Application.Interfaces;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Application.Mappers;
using DalpiazDDD.Domain.Core.Interfaces.Repositorys;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Services;
using DalpiazDDD.Infrastructure.Data.Repositorys;

namespace DalpiazDDD.Infrastructure.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC

            builder.RegisterType<AplicationServiceFuncionario>().As<IApplicationServiceFuncionario>();
            builder.RegisterType<ServiceFuncionario>().As<IServiceFuncionario>();
            builder.RegisterType<RepositoryFuncionario>().As<IRepositoryFuncionario>();
            builder.RegisterType<MapperFuncionario>().As<IMapperFuncionario>();

            builder.RegisterType<ApplicationServiceCalculoFuncionario>().As<IApplicationServiceCalculoFuncionario>();
            builder.RegisterType<ServiceCalculoFuncionario>().As<IServiceCalculoFuncionario>();
            builder.RegisterType<MapperCalculoFuncionario>().As<IMapperCalculoFuncionario>();


            #endregion IOC
        }
    }
}