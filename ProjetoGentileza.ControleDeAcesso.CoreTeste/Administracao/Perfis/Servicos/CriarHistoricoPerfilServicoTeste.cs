using NUnit.Framework;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos;
using ProjetoGentileza.NucleoCompartilhado.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGentileza.ControleDeAcesso.CoreTeste.Administracao.Perfis.Servicos
{
	[TestFixture]
	public class CriarHistoricoPerfilServicoTeste
	{
		public Perfil _perfil;
		public CriarHistoricoPerfilServico _servico;

		[SetUp]
		public void Iniciar()
		{
			_perfil = new Perfil("Administrador");
			_servico = new CriarHistoricoPerfilServico();
		}

		[Test]
		public void DeveCriarHistoricoParaPerfil()
		{
			var historico = _servico.Criar(_perfil.Id, DateTime.Now, TipoOperacaoEnum.Cadastrar);
			Assert.IsNotNull(historico);

			_perfil.AdicionarHistorico(historico);
			Assert.True(_perfil.Historicos.Count > 0);
		}

		//[Test]		
		//public void NaoDeveCriarHistoricoParaPerfil()
		//{
		//	var historico = _servico.Criar(Guid.Empty, DateTime.Now, TipoOperacaoEnum.Cadastrar);			
		//	Assert.IsNull(historico);

		//	_perfil.AdicionarHistorico(historico);
		//	Assert.True(_perfil.Historicos.Count > 0);
		//}
	}
}
