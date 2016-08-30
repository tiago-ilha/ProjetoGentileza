using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Entidades;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Repositorios;
using ProjetoGentileza.ControleDeAcesso.Core.Administracao.Perfils.Servicos.Intefaces;
using ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.Intefaces;
using ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.ViewModels;
using ProjetoGentileza.NucleoCompartilhado.Enums;
using System;

namespace ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.Servicos
{
	public class RegistrarPerfilAplicacao : IRegistrarPerfilAplicacao
	{
		private IPerfilRepositorioQuery _perfilQuery;
		private IPerfilRepositorioComando _perfilComando;

		private ICriarHistoricoPerfilServico _criarHistoricoPerfil;

		public RegistrarPerfilAplicacao(IPerfilRepositorioQuery perfilQuery,
										IPerfilRepositorioComando perfilComando,
										ICriarHistoricoPerfilServico criarHistoricoPerfil)
		{
			_perfilQuery = perfilQuery;
			_perfilComando = perfilComando;

			_criarHistoricoPerfil = criarHistoricoPerfil;
		}

		public void Executar(RegistrarPerfilViewModel modelo)
		{
			var perfil = new Perfil(modelo.Nome, modelo.Descricao);

			perfil.AdicionarHistorico(CriarHistoricoPerfil(perfil.Id, DateTime.Now, TipoOperacaoEnum.Cadastrar));
			_perfilComando.Salvar(perfil);
		}

		public void Executar(Guid id, RegistrarPerfilViewModel modelo)
		{
			Perfil perfil;

			if (id == Guid.Empty)
				throw new Exception("Nenhum registro foi encontrado!");

			perfil = _perfilQuery.ObterPorId(id);
			perfil.EditarDados(modelo.Nome, modelo.Descricao);

			perfil.AdicionarHistorico(CriarHistoricoPerfil(perfil.Id, DateTime.Now, TipoOperacaoEnum.Editar));

			AtualizarPerfil(perfil);
		}

		#region Métodos compartilhados

		private HistoricoPerfil CriarHistoricoPerfil(Guid idPerfil, DateTime dataOpercao, TipoOperacaoEnum tipoOperacao)
		{
			return _criarHistoricoPerfil.Criar(idPerfil, dataOpercao, tipoOperacao);
		}

		private void AtualizarPerfil(Perfil entidadeBase)
		{
			_perfilComando.Atualizar(entidadeBase);
		}

		#endregion
	}
}
