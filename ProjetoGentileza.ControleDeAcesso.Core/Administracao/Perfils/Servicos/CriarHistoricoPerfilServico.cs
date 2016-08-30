using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos.Intefaces;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.NucleoCompartilhado.Enums;
using System;

namespace ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos
{
	public class CriarHistoricoPerfilServico : ICriarHistoricoPerfilServico
	{
		public HistoricoPerfil Criar(Guid idPerfil, DateTime dataOperacao, TipoOperacaoEnum tipoOperacao)
		{
			HistoricoPerfil historico;

			if (idPerfil == null || idPerfil == Guid.Empty)
				throw new Exception("Não foi possivel criar um histórico para esse perfil!");

			historico = new HistoricoPerfil(idPerfil, dataOperacao, tipoOperacao);

			return historico;
		}
	}
}
