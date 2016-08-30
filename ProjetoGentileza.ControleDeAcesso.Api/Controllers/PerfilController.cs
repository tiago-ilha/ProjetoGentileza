using ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.Intefaces;
using ProjetoGentileza.ControleDeAcesso.Negocio.Administracao.Perfis.ViewModels;
using ProjetoGentileza.Utilitarios.UoW;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ProjetoGentileza.ControleDeAcesso.Api.Controllers
{
	[RoutePrefix("api/projeto-gentileza/controle-de-acesso/perfil")]
	public class PerfilController : ApiController
	{
		private HttpResponseMessage _response;

		private IRegistrarPerfilAplicacao _registrarPerfilAplicacao;
		private IUnitOfWork _unitOfWork;

		public PerfilController(IRegistrarPerfilAplicacao registrarPerfilAplicacao, IUnitOfWork unitOfWork)
		{
			_registrarPerfilAplicacao = registrarPerfilAplicacao;
			_unitOfWork = unitOfWork;
		}

		// GET: api/Perfil
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET: api/Perfil/5
		public string Get(int id)
		{
			return "value";
		}

		// POST: api/Perfil
		[HttpPost]
		[Route("cadastrar")]
		public Task<HttpResponseMessage> Cadastrar(RegistrarPerfilViewModel modelo)
		{
			_response = new HttpResponseMessage();

			_unitOfWork.AbrirTransacao();

			try
			{
				_registrarPerfilAplicacao.Executar(modelo);
				_unitOfWork.Comitar();

				_response = Request.CreateResponse(HttpStatusCode.OK, "Operação foi realizada com sucesso!");
			}
			catch (DataException e)
			{
				_response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
				_unitOfWork.Desfazer();
			}
			catch (SqlException e)
			{
				_response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
				_unitOfWork.Desfazer();
			}
			catch (Exception e)
			{
				_response = Request.CreateResponse(HttpStatusCode.BadRequest, e.Message);
				_unitOfWork.Desfazer();
			}

			var tarefa = new TaskCompletionSource<HttpResponseMessage>();
			tarefa.SetResult(_response);

			return tarefa.Task;
		}

		// PUT: api/Perfil/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Perfil/5
		public void Delete(int id)
		{
		}

		protected override void Dispose(bool disposing)
		{
			_unitOfWork.Dispose();
		}
	}
}
