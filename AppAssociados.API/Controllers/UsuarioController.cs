using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AppAssociados.API.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository) {
            this.repository = repository;
        }
        [Authorize]
        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return this.repository.GetAll();
        }
        
        [HttpGet("{id}")]
        public Usuario Get(int id)
        {
            return this.repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                this.repository.Create(usuario);
                return Ok(usuario);
            }else{
                var erros = new List<string>();
                foreach(var state in ModelState){
                    foreach(var error in state.Value.Errors){
                        erros.Add(error.ErrorMessage);
                    }
                }
                return BadRequest(new{
                    message = erros
                });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody]Usuario usuario)
        {
            this.repository.Update(usuario);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso!"
            });
        }
         [HttpPost("auth")]
        public IActionResult Authentication([FromBody]Usuario user)
        {
            var usuario = this.repository.AuthUser(user);
            if(usuario == null)
                return BadRequest(new{
                    message = "Login e/ou senha incorreto(s)."
                });
                return Ok(new{
                    token = BuildToken()
                });
        }
        public string BuildToken(){
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("UsuarioLoginTeste"));
            var creed = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: "user",
                issuer: "user",
                signingCredentials: creed
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}