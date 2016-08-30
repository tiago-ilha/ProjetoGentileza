using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos.Intefaces;
using ProjetoGentileza.NucleoCompartilhado.Enums;
using System;

namespace ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos
{
	public class DesabilitarHistoricoPerfilServico : IDesabilitarHistoricoPerfilServico
	{
		public HistoricoPerfil Criar(Guid idPerfil, DateTime dataOperacao, TipoOperacaoEnum tipoOperacao, string observacao)
		{
			HistoricoPerfil historico;

			if (idPerfil == null || idPerfil == Guid.Empty)
				throw new Exception("Não foi possivel criar um histórico para esse perfil!");

			historico = new HistoricoPerfil(idPerfil, dataOperacao, tipoOperacao, observacao);

			return historico;
		}
	}
}
