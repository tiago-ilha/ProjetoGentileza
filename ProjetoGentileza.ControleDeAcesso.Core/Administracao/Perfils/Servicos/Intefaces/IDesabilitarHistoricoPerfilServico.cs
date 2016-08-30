using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.NucleoCompartilhado.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos.Intefaces
{
	public interface IDesabilitarHistoricoPerfilServico
	{
		HistoricoPerfil Criar(Guid idPerfil, DateTime dataOperacao,TipoOperacaoEnum tipoOperacao, string observacao);
	}
}
