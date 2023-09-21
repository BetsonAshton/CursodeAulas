using AutoMapper;
using Cursos.Data.Entities;
using Cursos.Data.Repositories;
using Cursos.Models.Authentication;
using Cursos.Models.Professor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Cursos.Controllers
{
    [Authorize]
    public class ProfessorController : Controller
    {
        private readonly IMapper? _mapper;

        public ProfessorController(IMapper? mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Cadastro()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(ProfessorCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var professor = _mapper.Map<Professor>(model);
                    professor.IdAdm = UsuarioAutenticado.IdAdm;

                    var professorRepository = new ProfessorRepository();
                    professorRepository.Adicionar(professor);

                    TempData["MensagemSucesso"] = $"Professor '{professor.Nome}', cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao cadastrar professor: {e.Message}";
                }
            }

            return View(model);
        }

        public IActionResult Consulta()
        {
            try
            {
                var professorRepository = new ProfessorRepository();
                ViewBag.Professor = professorRepository.ObterTodos
                    (c => c.IdAdm == UsuarioAutenticado.IdAdm);

            }
            catch(Exception e) 
            {
                TempData["MensagemErro"]= $"Falha ao consultar Professor: {e.Message}";


            }
            return View();
        }

        public IActionResult Edicao(Guid id)
        {
            var model = new ProfessorEdicaoViewModel();
            try
            {
                var professorRepository = new ProfessorRepository();
                var professor = professorRepository.Obter
                     (c => c.IdProfessor == id && c.IdAdm == UsuarioAutenticado.IdAdm);

                if(professor != null)
                {
                    model.IdProfessor = professor.IdProfessor;
                    model.Nome = professor.Nome;
                }
                else
                {
                    return RedirectToAction("Consulta");
                }

            }
            catch(Exception e) 
            {
                TempData["MensagemErro"] = $"Falha ao obter professor: {e.Message}";
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edicao(ProfessorEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var professorRepository = new ProfessorRepository();
                    var professor = professorRepository.ObterPorId(model.IdProfessor.Value);

                    professor.Nome = model.Nome;
                   

                    professorRepository.Atualizar(professor);

                    TempData["MensagemSucesso"] = $"Professor '{professor.Nome}', atualizado com sucesso.";
                    return RedirectToAction("Consulta");
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao atualizar professor: { e.Message}";
                }
            }

            return View(model);


        }

        public IActionResult Exclusao(Guid id)
        {
            try
            {
                var professorRepository = new ProfessorRepository();

                var categoria = professorRepository.Obter
                   (c => c.IdProfessor == id && c.IdAdm== UsuarioAutenticado.IdAdm);

                if (categoria != null)
                {
                    professorRepository.Excluir(categoria);
                    TempData["MensagemSucesso"]= $"Categoria '{categoria.Nome}', excluído com sucesso.";
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"]= $"Falha ao excluir categoria: {e.Message}.";
            }

            return RedirectToAction("Consulta");
        }

        private AuthenticationModel UsuarioAutenticado
        {
            get
            {
                //capturar o usuário autenticado (Cookie de autenticação)
                var user = User.Identity.Name;
                return JsonConvert.DeserializeObject<AuthenticationModel>(user);
            }
        }

    }

    


}


