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
	public class DesabilitarHistoricoPerfilServicoTeste
	{
		public Perfil _perfil;
		public DesabilitarHistoricoPerfilServico _servico;

		[SetUp]
		public void Iniciar()
		{
			_perfil = new Perfil("Administrador");
			_servico = new DesabilitarHistoricoPerfilServico();
		}

		[Test]
		public void DeveCriarHistoricoParaPerfil()
		{
			var historico = _servico.Criar(_perfil.Id, DateTime.Now, TipoOperacaoEnum.Desativar, "Desativado!");
			Assert.IsNotNull(historico);

			_perfil.AdicionarHistorico(historico);
			Assert.True(_perfil.Historicos.Count > 0);
		}
	}
}
