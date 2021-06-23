using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RallyDakar.Dominio.Entidades;
using RallyDakar.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RallyDakar.Api.Controllers
{
    [ApiController]
    [Route("api/Pilotos")]
    public class PilotoController : ControllerBase
    {
        IPilotoRepositorio _pilotoRepositorio;

        public PilotoController(IPilotoRepositorio pilotoRepositorio)
        {
            _pilotoRepositorio = pilotoRepositorio;
        }

        [HttpGet]
        public ActionResult ObterTodos()
        {
            //var pilotos = new List<Piloto>();
            //var piloto = new Piloto();
            //piloto.Id = 1;
            //piloto.Nome = "pilotoTeste";
            //pilotos.Add(piloto);
            ////return Ok(_pilotoRepositorio.ObterTodos());
            ///
            try
            {
                var listaPilotos = new List<Piloto>();
                listaPilotos = _pilotoRepositorio.ObterTodos().ToList();

                if (!listaPilotos.Any())
                {
                    return NotFound();
                }
                return Ok(listaPilotos);
            }
            catch (Exception)
            {
                //return BadRequest(ex.Message.ToString());
                //_logger.info(ex.ToString());
                //return BadRequest("Ocorreu um erro interno no sistema, Por favor entrar em contato com suporte.");
                return StatusCode(500, "Ocorreu um erro interno no sistema, Por favor entrar em contato com suporte.");
            }

        }
        //Rota informada no retorno do metodo AdicionarPiloto
        [HttpGet("{id}", Name = "Obter")]
        public IActionResult Obter(int id)
        {
            try
            {
                var piloto = _pilotoRepositorio.Obter(id);
                if (piloto == null)
                {
                    return NotFound();
                }

                return Ok(piloto);
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocorreu um erro interno no sistema, Por favor entrar em contato com suporte.");
            }
        }

        [HttpPost]
        public ActionResult AdicionarPiloto([FromBody] Piloto piloto)
        {
            try
            {
                if (_pilotoRepositorio.Existe(piloto.Id))
                {
                    return StatusCode(409, "Já existe o piloto com a mesma identificação");
                }
                _pilotoRepositorio.Adicionar(piloto);

                return CreatedAtRoute("Obter", new { id = piloto.Id }, piloto);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Piloto piloto)
        {
            try
            {
                if (!_pilotoRepositorio.Existe(piloto.Id))
                    return NotFound();

                _pilotoRepositorio.Atualizar(piloto);
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro interno no sistema, Por favor entrar em contato com suporte.");
            }

        }
        [HttpPatch]
        public IActionResult AtualizarParcialmentePiloto(int id,JsonPatchDocument<Piloto> patchPiloto)
        {
            try
            {
                var piloto = _pilotoRepositorio.Obter(id);

                if (piloto == null)
                    return NotFound();

                //Atualizar parcialmente um json
                patchPiloto.ApplyTo(piloto);

                _pilotoRepositorio.Atualizar(piloto);

                return NoContent();

            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro interno no sistema, Por favor entrar em contato com suporte.");
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPiloto(int id)
        {
            try
            {
                //if (!_pilotoRepositorio.Existe(id))
                    
                var piloto = _pilotoRepositorio.Obter(id);

                if(piloto == null)
                    return NotFound();


                _pilotoRepositorio.Deletar(piloto);

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Ocorreu um erro interno no sistema, Por favor entrar em contato com suporte.");
            }

        }
    }
}
