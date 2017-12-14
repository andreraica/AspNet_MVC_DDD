using Budget.Application;
using Budget.Application.Interfaces;
using Budget.Domain.Services;
using Budget.Domain.Services.Interfaces;
using Budget.Infrastructure.CrossCutting.Identity.Configuration;
using Budget.Infrastructure.CrossCutting.Identity.Context;
using Budget.Infrastructure.Data.Context;
using Budget.Infrastructure.Data.Interface;
using Budget.Infrastructure.Data.Interface.ReadOnly;
using Budget.Infrastructure.Data.Repositories;
using Budget.Infrastructure.Data.Repositories.ReadOnly;
using SimpleInjector;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Budget.Services.Interfaces;
using Budget.Services;
using Budget.Infrastructure.CrossCutting.Identity.Model;

namespace Budget.Infrastructure.CrossCuting.IoC
{
    public class DependencyResolution
    {
        private static Container _container;

        public static void Register(Container container)
        {
            _container = container;

            RegisterRepositories(Lifestyle.Scoped);
            RegisterApplications(Lifestyle.Scoped);
            RegisterServices(Lifestyle.Scoped);
        }

        static void RegisterApplications(ScopedLifestyle requestLifestyle)
        {
            _container.Register<IGerenciadorDeOrcamento, GerenciadorDeOrcamento>(requestLifestyle);
            _container.Register<IGerenciadorDeItemValor, GerenciadorDeItemValor>(requestLifestyle);
            _container.Register<IGerenciadorDeItemSubValor, GerenciadorDeItemSubValor>(requestLifestyle);

            //Identity
            _container.Register<IGerenciadorDeUsuario, GerenciadorDeUsuario>(requestLifestyle);

            _container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            _container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            _container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
        }

        static void RegisterServices(ScopedLifestyle requestLifestyle)
        {
            _container.Register<IOrcamentoService, OrcamentoService>(requestLifestyle);
            _container.Register<IItemValorService, ItemValorService>(requestLifestyle);
            _container.Register<IItemSubValorService, ItemSubValorService>(requestLifestyle);

            //Identity
            _container.Register<IUsuarioService, UsuarioService>(requestLifestyle);
        }

        static void RegisterRepositories(ScopedLifestyle requestLifestyle)
        {
            _container.Register<BudgetContext>(requestLifestyle);

            _container.Register<IOrcamentoRepository>(() => new OrcamentoRepository(_container.GetInstance<BudgetContext>()), requestLifestyle);
            _container.Register<IItemValorRepository>(() => new ItemValorRepository(_container.GetInstance<BudgetContext>()), requestLifestyle);
            _container.Register<IItemSubValorRepository>(() => new ItemSubValorRepository(_container.GetInstance<BudgetContext>()), requestLifestyle);

            _container.Register<IOrcamentoReadOnlyRepository>(() => new OrcamentoReadOnlyRepository(), requestLifestyle);
            _container.Register<IItemValorReadOnlyRepository>(() => new ItemValorReadOnlyRepository(), requestLifestyle);
            _container.Register<IItemSubValorReadOnlyRepository>(() => new ItemSubValorReadOnlyRepository(), requestLifestyle);

            //Identity
            _container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            _container.Register<IUsuarioRepository>(() => new UsuarioRepository(), requestLifestyle);

        }
        
    }
}
