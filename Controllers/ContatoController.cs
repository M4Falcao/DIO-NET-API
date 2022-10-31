using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIO_NET_API.Context;
using DIO_NET_API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DIO_NET_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly AgendaContext _context;
        public ContatoController(AgendaContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult Create(Contato contato)
        {
            _context.Add(contato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ObterPorId), new { id = contato.Id }, contato);
        }

        [HttpPost("CreateMany")]
        public IActionResult CreateMany(List<Contato> contatos)
        {

            contatos.ForEach(x => _context.Add(x));

            _context.SaveChanges();
            return Ok(contatos);
        }

        [HttpGet("{id}")]
        public IActionResult ObterPorId(int id)
        {
            var contato = _context.Contatos.Find(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }

        [HttpGet("ObterPorNome")]
        public IActionResult ObterPorNome(string nome)
        {
            var contatos = _context.Contatos.Where(x => x.Nome.Contains(nome));

            if (contatos == null)
                return NotFound();

            return Ok(contatos);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Contato contato)
        {

            var contatoBanco = _context.Contatos.Find(id);
            if (contatoBanco == null)
                return NotFound();

            contatoBanco.Nome = contato.Nome;
            contatoBanco.Telefone = contato.Telefone;
            contatoBanco.Ativo = contato.Ativo;

            _context.Contatos.Update(contatoBanco);
            _context.SaveChanges();

            return Ok(contatoBanco);

        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var contato = _context.Contatos.Find(id);
            if (contato == null)
                return NotFound();

            _context.Contatos.Remove(contato);
            _context.SaveChanges();

            return NoContent();
        }



    }
}