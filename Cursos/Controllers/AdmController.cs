using AutoMapper;
using Cursos.Data.Entities;
using Cursos.Data.Repositories;
using Cursos.Models;
using Cursos.Models.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Cursos.Data.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace Cursos.Controllers
{
    public class AdmController : Controller
    {
        private readonly IMapper? _mapper;

        public AdmController(IMapper? mapper)
        {
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //buscar o usuário no banco de dados 
                    //através do email e senha
                    var admRepository = new AdmRepository();
                    var adm = admRepository.Obter
                        (u => u.Email.Equals(model.Email)&& u.Senha.Equals(MD5Cryptography.Hash(model.Senha)));

                    //verificando se o usuário foi encontrado..
                    if (adm != null)
                    {
                       
                            //capturando os dados do 
                            //usuário que será autenticado
                            var authenticationModel = _mapper.Map<AuthenticationModel>(adm);

                            var json = JsonConvert.SerializeObject(authenticationModel);

                            //preparando os dados para serem 
                            //gravados em um Cookie de autenticação
                            var claimsIdentity = new ClaimsIdentity(
                                new[] { new Claim(ClaimTypes.Name, json) },CookieAuthenticationDefaults.AuthenticationScheme
                                );

                            //gravando o cookie de autenticação
                            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

                            //redirecionamento para /Home/Index
                            return RedirectToAction("Index", "Home");
                       
                    }
                    else
                    {
                        TempData["MensagemErro"] = "Acesso negado. Usuário não encontrado.";
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao autenticar o usuário: { e.Message}";
                }
            }

            return View();

        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var admRepository = new AdmRepository();

                    if (admRepository.Obter(u => u.Email.Equals(model.Email)) != null)
                        ModelState.AddModelError("Email", "O email informado já está cadastrado no sistema.");
                    else
                    {
                        var usuario = _mapper.Map<Adm>(model);

                        admRepository.Adicionar(usuario);
                        ModelState.Clear(); //limpar o formulário

                        TempData["MensagemSucesso"] = $"Parabéns {usuario.Nome}, sua conta foi criada com sucesso!";
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = $"Falha ao cadastrar conta: {e.Message}";
                }
            }
            return View();
        }

        public IActionResult PasswordRecover()
        {
            return View();
        }

        [Authorize]
        public IActionResult Logout()
        {          
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Adm");
        }
    }
}
