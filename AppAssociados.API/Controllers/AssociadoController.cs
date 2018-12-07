using System.Collections.Generic;
using AppAssociados.API.DTO;
using AppAssociados.Domain;
using AppAssociados.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppAssociados.API.Controllers
{
    [Route("api/[controller]")]
    public class AssociadoController : Controller
    {
        private readonly IAssociadoRepository repository;

        public AssociadoController(IAssociadoRepository repository) {
            this.repository = repository;
        }
        
        [HttpGet]
        public IEnumerable<AssociadoDTO> Get()
        {
            var assoc = this.repository.GetAll();
            var assocDTO = new List<AssociadoDTO>();
                assoc.ForEach(asoc =>{
                    assocDTO.Add(
                        new AssociadoDTO{
                            id = asoc.id,
                            nome = asoc.nome,
                            email = asoc.email,
                            cidade = asoc.cidade,
                            estado = asoc.estado
                        }
                    );
                });
                return assocDTO;
        }

        [HttpGet("{id}")]
        public Associado Get(int id)
        {
            return this.repository.GetById(id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Associado associado)
        {
            this.repository.Create(associado);
            return Ok(associado);
        }

        [HttpPut]
        public IActionResult Put([FromBody]Associado associado)
        {
            this.repository.Update(associado);
            return Ok(associado);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            this.repository.Delete(id);
            return Ok(new {
                message = "Deletado com sucesso!"
            });
        }
    }
}