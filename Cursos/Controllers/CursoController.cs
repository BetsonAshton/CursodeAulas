using AutoMapper;
using Cursos.Data.Entities;
using Cursos.Data.Repositories;
using Cursos.Models.Authentication;
using Cursos.Models.Curso;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace Cursos.Controllers
{
    public class CursoController : Controller
    {
        private readonly IMapper? _mapper;

        public CursoController(IMapper? mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Cadastro()
        {
            ViewBag.Professor = ObterProfessor();
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(CursoCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var curso = _mapper.Map<Curso>(model);
                    curso.IdAdm = UsuarioAutenticado.IdAdm;

                    var cursoRepository = new CursoRepository();
                    cursoRepository.Adicionar(curso);

                    TempData["MensagemSucesso"] = $"Curso '{curso.Nome}', cadastrado com sucesso.";
                    ModelState.Clear();
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }
            ViewBag.Professor = ObterProfessor();
            return View();
        }

        public IActionResult Consulta(CursoConsultaViewModel model)
        {
            try
            {
                var cursoRepository = new CursoRepository();
                var cursos = cursoRepository.ObterTodos();

                if (cursos == null || !cursos.Any())
                {
                    TempData["MensagemErro"] = "Nenhum curso encontrado.";
                    return View(new List<CursoConsultaViewModel>()); // Return an empty list
                }

                var cursosViewModel = cursos.Select(c => new CursoConsultaViewModel
                {
                    IdCurso = (Guid)c.IdCurso,
                    Nome = c.Nome,
                    Data = c.Data,
                    Valor = c.Valor,
                    IdProfessor = c.Professor?.IdProfessor ?? Guid.Empty,
                    Professor = c.Professor?.Nome ?? "N/A"
                }).ToList();

                return View(cursosViewModel); // Return the list of CursoConsultaViewModel
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Falha ao consultar cursos: {e.Message}";
                return View(new List<CursoConsultaViewModel>()); // Return an empty list
            }
        }




        public IActionResult Edicao()
        {
            return View();
        }

        public IActionResult Exclusao()
        {
            return View();
        }

        private List<SelectListItem> ObterProfessor()
        {
            var lista = new List<SelectListItem>();

            try
            {
                var professorRepository = new ProfessorRepository();
                var professor = professorRepository
                    .ObterTodos(c => c.IdAdm == UsuarioAutenticado.IdAdm)
                    .OrderBy(c => c.Nome);

                foreach (var item in professor)
                {
                    lista.Add(new SelectListItem
                    {
                        Value = item.IdProfessor.ToString(),
                        Text = $"{item.Nome}"
                    });
                }
            }
            catch (Exception e)
            {
                TempData["MensagemErro"] = $"Falha ao obter Professor: {e.Message}";
            }

            return lista;
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
