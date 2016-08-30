using System;
using System.Threading;

namespace ProjetoGentileza.Utilitarios.Repositorios
{
	public interface IRepositorioComando<T> where T : class
	{
		void Salvar(T entidade);
		void Atualizar(T entidade);
		void Remover(Guid Id);
	}
}
