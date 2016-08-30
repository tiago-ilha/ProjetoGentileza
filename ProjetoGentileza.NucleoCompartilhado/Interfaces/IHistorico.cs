using ProjetoGentileza.NucleoCompartilhado.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGentileza.NucleoCompartilhado.Interfaces
{
	public interface IHistorico
	{
		DateTime DataOperacao { get; }
		TipoOperacaoEnum TipoOperacao { get; }
		string Observacao { get; }
	}
}
