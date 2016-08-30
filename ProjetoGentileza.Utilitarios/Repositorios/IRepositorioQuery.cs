using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ProjetoGentileza.Utilitarios.Repositorios
{
	public interface IRepositorioQuery<T> where T : class
	{
		IEnumerable<T> Listar();
		IEnumerable<T> Listar(int skip, int take);
		IEnumerable<T> Filtrar(Expression<Func<T, bool>> predicate);
		T ObterPorId(Guid Id);
	}
}
