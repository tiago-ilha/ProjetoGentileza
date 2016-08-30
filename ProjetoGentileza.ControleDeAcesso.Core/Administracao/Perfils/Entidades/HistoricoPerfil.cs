using ProjetoGentileza.NucleoCompartilhado.Enums;
using ProjetoGentileza.NucleoCompartilhado.Interfaces;
using System;

namespace ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades
{
	public class HistoricoPerfil : IHistorico
	{
		protected HistoricoPerfil() { }

		public HistoricoPerfil(Guid idPerfil, DateTime dataOperacao, TipoOperacaoEnum tipoOperacao, string observacao)
		{
			Id = Guid.NewGuid();
			IdPerfil = idPerfil;
			DataOperacao = dataOperacao;
			TipoOperacao = tipoOperacao;
			Observacao = observacao;
		}

		public HistoricoPerfil(Guid idPerfil, DateTime dataOperacao, TipoOperacaoEnum tipoOperacao)
			: this(idPerfil, dataOperacao, tipoOperacao, null) { }

		public Guid Id { get; private set; }
		public Guid IdPerfil { get; set; }
		public DateTime DataOperacao { get; private set; }
		public TipoOperacaoEnum TipoOperacao { get; private set; }
		public string Observacao { get; private set; }
	}
}
