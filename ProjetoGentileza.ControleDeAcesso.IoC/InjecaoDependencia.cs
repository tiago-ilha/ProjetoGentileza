using Autofac;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos;
using ProjetoGentileza.ControleDeAcesso.Data.Configuracao;
using ProjetoGentileza.ControleDeAcesso.Data.Repositorios;
using ProjetoGentileza.ControleDeAcesso.Data.UoW;
using ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.Servicos;

namespace ProjetoGentileza.ControleDeAcesso.IoC
{
	public class InjecaoDependencia
	{
		public static void Resolver(ContainerBuilder contaner)
		{
			contaner.RegisterAssemblyTypes(typeof(RegistrarPerfilAplicacao).Assembly)
				.Where(x => x.Name.EndsWith("Aplicacao"))
				.AsImplementedInterfaces();

			contaner.RegisterAssemblyTypes(typeof(UnitOfWork).Assembly)
				.Where(x => x.Name.Equals("UnitOfWork"))
				.AsImplementedInterfaces();

			contaner.RegisterAssemblyTypes(typeof(PerfilRepositorio).Assembly)
				.Where(x => x.Name.EndsWith("Repositorio"))
				.AsImplementedInterfaces();

			contaner.RegisterAssemblyTypes(typeof(CriarHistoricoPerfilServico).Assembly)
				.Where(x => x.Name.EndsWith("Servico"))
				.AsImplementedInterfaces();

			contaner.RegisterType<ControleDeAcessoContexto>().As<ControleDeAcessoContexto>();
		}		
	}
}
