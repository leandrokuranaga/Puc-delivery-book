using AutoMapper;
using deliverybook.API.ViewModel;
using deliverybook.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class LivrosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IItBookNewServices _newServices;
        private readonly IItBookBooksServices _booksServices;
        private readonly IItBookSearchServices _searchServices;
        private readonly IRentableServices _rentableServices;

        public LivrosController(IMapper mapper, IItBookNewServices newServices, IItBookBooksServices booksServices, IItBookSearchServices searchServices, IRentableServices rentableServices)
        {
            _mapper = mapper;
            _newServices = newServices;
            _booksServices = booksServices;
            _searchServices = searchServices;
            _rentableServices = rentableServices;
        }

        // GET: api/<LivrosController>
        [HttpGet]
        public async Task<ActionResult<PaginacaoViewModel>> Get()
        {
            var livros = await _newServices.Buscar();

            return CustomResponse(_mapper.Map<PaginacaoViewModel>(livros));
        }

        // GET api/<LivrosController>/1001590483252
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalhesViewModel>> Get(string id)
        {
            var livro = await _booksServices.BuscarPorId(id);

            return CustomResponse(_mapper.Map<DetalhesViewModel>(livro));
        }

        // GET api/<LivrosController>/filtro?parametro=Handbook&pagina=3
        [HttpGet("filtro")]
        public async Task<ActionResult<PaginacaoViewModel>> GetFiltro(string parametro, int? pagina = 0)
        {
            var livros = await _searchServices.BuscarPorFiltro(parametro, pagina.Value);

            return CustomResponse(_mapper.Map<PaginacaoViewModel>(livros));
        }

        // GET api/<LivrosController>/alugueis
        [HttpGet("alugueis")]
        public async Task<ActionResult<IEnumerable<AluguelViewModel>>> GetAluguel()
        {
            var alugueis = await _rentableServices.PesquisarPorUser();

            return CustomResponse(_mapper.Map<IEnumerable<AluguelViewModel>>(alugueis));
        }

        [HttpPost("alugarLivro")]
        public async Task<ActionResult<bool>> Post(string isbn, int dias)
        {
            var livro = await _rentableServices.Adicionar(isbn, dias);

            return CustomResponse(livro);
        }
    }
}