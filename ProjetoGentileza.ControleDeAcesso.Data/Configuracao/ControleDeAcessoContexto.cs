using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.ControleDeAcesso.Data.Mapeamentos;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace ProjetoGentileza.ControleDeAcesso.Data.Configuracao
{
	public class ControleDeAcessoContexto : DbContext
	{
		public ControleDeAcessoContexto()
			: base("ProjetoGentileza")
		{
			Database.Log = s => Debug.WriteLine(s);

			Database.SetInitializer(new Inicializador());

			Configuration.LazyLoadingEnabled = false;
			Configuration.ProxyCreationEnabled = false;
			//Configuration.ValidateOnSaveEnabled = false;
		}

		public DbSet<Perfil> Perfil { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			////Fazendo o mapeamento com o banco de dados
			////Pega todas as classes que estão implementando a interface IMapping
			////Assim o Entity Framework é capaz de carregar os mapeamentos
			//var typesToMapping = (from x in Assembly.GetExecutingAssembly().GetTypes()
			//					  where x.IsClass && typeof(IMapeamento).IsAssignableFrom(x)
			//					  select x).ToList();

			//// Varrendo todos os tipos que são mapeamento 
			//// Com ajuda do Reflection criamos as instancias 
			//// e adicionamos no Entity Framework
			//foreach (var mapping in typesToMapping)
			//{
			//	dynamic mappingClass = Activator.CreateInstance(mapping);
			//	modelBuilder.Configurations.Add(mappingClass);
			//}

			modelBuilder.Configurations.Add(new PerfilMap());
			modelBuilder.Configurations.Add(new HistoricoPerfilMap());
		}

		public virtual void ChangeObjectState(object model, EntityState state)
		{
			//Aqui trocamos o estado do objeto, 
			//facilita quando temos alterações e exclusões
			((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.ChangeObjectState(model, state);
		}
	}
}
