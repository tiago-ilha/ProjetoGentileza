using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Repositorios;
using ProjetoGentileza.ControleDeAcesso.Data.Configuracao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ProjetoGentileza.ControleDeAcesso.Data.Repositorios
{
	public class PerfilRepositorio : IPerfilRepositorioQuery, IPerfilRepositorioComando
	{
		private ControleDeAcessoContexto _contexto;

		public PerfilRepositorio(ControleDeAcessoContexto contexto)
		{
			_contexto = contexto;
		}

		public IEnumerable<Perfil> Listar()
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Perfil> Listar(int skip, int take)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Perfil> Filtrar(Expression<Func<Perfil, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public Perfil ObterPorId(Guid Id)
		{
			return _contexto.Perfil.Find(Id);
		}

		public void Salvar(Perfil entidade)
		{
			_contexto.Perfil.Add(entidade);
		}

		public void Atualizar(Perfil entidade)
		{
			var entry = _contexto.Entry(entidade);
			if (entry.State == EntityState.Detached)
				_contexto.Perfil.Attach(entidade);

			_contexto.ChangeObjectState(entidade, EntityState.Modified);
		}

		public void Remover(Guid Id)
		{
			var entidadeBase = ObterPorId(Id);
			RemoverEntidade(entidadeBase);
		}

		private void RemoverEntidade(Perfil entidadeBase)
		{
			_contexto.Perfil.Remove(entidadeBase);
		}
	}
}
