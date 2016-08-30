using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.NucleoCompartilhado.Enums;
using System;

namespace ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos.Intefaces
{
	public interface ICriarHistoricoPerfilServico
	{
		HistoricoPerfil Criar(Guid idPerfil, DateTime dataOperacao, TipoOperacaoEnum tipoOperacao);
	}
}
