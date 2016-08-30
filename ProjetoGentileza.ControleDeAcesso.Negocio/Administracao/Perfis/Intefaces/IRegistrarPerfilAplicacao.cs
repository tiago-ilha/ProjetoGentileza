using ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.Intefaces
{
	public interface IRegistrarPerfilAplicacao
	{
		void Executar(RegistrarPerfilViewModel modelo);
		void Executar(Guid id, RegistrarPerfilViewModel modelo);
	}
}
