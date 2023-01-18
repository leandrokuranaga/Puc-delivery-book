using AutoMapper;
using deliverybook.API.ViewModel;
using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]

    public class LocalizacoesController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ILocalServices _localServices;
        private readonly IProdutoService _livroServices;
        private readonly IReservaServices _reservaServices;
        

        public LocalizacoesController(IMapper mapper, ILocalServices localServices, IProdutoService livroServices, IReservaServices reservaServices)
        {
            _mapper = mapper;
            _localServices = localServices;
            _livroServices = livroServices;
            _reservaServices = reservaServices;
        }

        // GET: api/<LocalizacoesController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocalizacaoViewModel>>> Get()
        {
            var locais = await _localServices.ObterTodos();

            return CustomResponse(_mapper.Map<IEnumerable<LocalizacaoViewModel>>(locais));
        }

        // GET api/<LocalizacoesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<LivroTrocaViewModel>>> Get(Guid id)
        {
            var livros = await _livroServices.PesquisarPorLocalId(id);

            return CustomResponse(_mapper.Map<IEnumerable<LivroTrocaViewModel>>(livros));
        }

        // POST api/<LocalizacoesController>
        [HttpPost("AdicionarReferencia")]
        public async Task<ActionResult<bool>> Post([FromBody] LocalizacaoViewModel value)
        {
            var local = await _localServices.Adicionar(_mapper.Map<Local>(value));

            return CustomResponse(local);
        }

        // POST api/<LocalizacoesController>
        [HttpPost("DeixarLivro")]
        public async Task<ActionResult<bool>> Post([FromBody] LivroTrocaViewModel value)
        {
            var livro = await _livroServices.Adicionar(_mapper.Map<Produto>(value));

            return CustomResponse(livro);
        }

        // PUT api/<LocalizacoesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Guid id, [FromBody] LocalizacaoViewModel value)
        {
            var local = await _localServices.Atualizar(_mapper.Map<Local>(value));

            return CustomResponse(local);
        }

        // DELETE api/<LocalizacoesController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            return CustomResponse("Em construção");
        }

        // POST api/<LocalizacoesController>/ReservarLivro
        [HttpPost("ReservarLivro")]
        public async Task<ActionResult<bool>> Reservar(Guid produtoId, Guid localId)
        {
            var reserva = await _reservaServices.Adicionar(produtoId, localId);

            return CustomResponse(reserva);
        }

        // POST api/<LocalizacoesController>/CancelarReserva?id=
        [HttpPut("CancelarReserva")]
        public async Task<ActionResult<bool>> Cancelar(Guid id)
        {
            var reserva = await _reservaServices.Cancelar(id);

            return CustomResponse(reserva);
        }

        // GET: api/<LocalizacoesController>/Reservas
        [HttpGet("Reservas")]
        public async Task<ActionResult<IEnumerable<ReservaViewModel>>> GetReservas()
        {
            var reservas = await _reservaServices.PesquisarPorUser();

            return CustomResponse(_mapper.Map<IEnumerable<ReservaViewModel>>(reservas));
        }
    }
}