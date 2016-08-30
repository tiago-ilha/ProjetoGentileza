using System.Data.Entity;

namespace ProjetoGentileza.ControleDeAcesso.Data.Configuracao
{
	public class Inicializador : DropCreateDatabaseAlways<ControleDeAcessoContexto>
	{
		public override void InitializeDatabase(ControleDeAcessoContexto context)
		{
			base.InitializeDatabase(context);
		}

		protected override void Seed(ControleDeAcessoContexto context)
		{
			base.Seed(context);
		}
	}
}
