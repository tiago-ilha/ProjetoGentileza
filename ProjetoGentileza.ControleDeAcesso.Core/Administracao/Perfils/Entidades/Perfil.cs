using System;
using System.Collections.Generic;

namespace ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades
{
	public class Perfil
	{
		protected Perfil() { }

		public Perfil(string nome, string descricao)
		{
			Id = Guid.NewGuid();
			Nome = nome;
			Descricao = descricao;

			Historicos = new List<HistoricoPerfil>();
		}

		public Perfil(string nome) : this(nome, null) { }

		public Guid Id { get; private set; }
		public string Nome { get; private set; }
		public string Descricao { get; private set; }

		public ICollection<HistoricoPerfil> Historicos { get; private set; }

		public void EditarDados(string nome, string descricao)
		{
			Nome = nome;
			Descricao = descricao;
		}

		public void AdicionarHistorico(HistoricoPerfil historico)
		{
			Historicos.Add(historico);
		}
	}
}
