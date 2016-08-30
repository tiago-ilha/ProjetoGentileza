using ProjetoGentileza.ControleDeAcesso.Data.Configuracao;
using ProjetoGentileza.Utilitarios.UoW;
using System;
using System.Data.Entity;

namespace ProjetoGentileza.ControleDeAcesso.Data.UoW
{
	public class UnitOfWork : IUnitOfWork
	{
		private ControleDeAcessoContexto _contexto;
		private DbContextTransaction _transacao;

		public UnitOfWork(ControleDeAcessoContexto contexto)
		{
			_contexto = contexto;
		}

		public void AbrirTransacao()
		{
			_transacao = _contexto.Database.BeginTransaction();
		}

		public void Comitar()
		{
			_contexto.SaveChanges();
			_transacao.Commit();
		}

		public void Desfazer()
		{
			_transacao.Rollback();
		}

		public void Dispose()
		{
			if (_transacao != null)
			{
				_transacao.Dispose();
				GC.SuppressFinalize(this);
			}
		}
	}
}
