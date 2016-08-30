using System;
using System.Threading;

namespace ProjetoGentileza.Utilitarios.UoW
{
	public interface IUnitOfWork : IDisposable
	{
		void AbrirTransacao();
		void Comitar();
		void Desfazer();
	}
}
