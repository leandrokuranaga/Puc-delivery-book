using AutoMapper;
using deliverybook.API.ViewModel;
using deliverybook.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace deliverybook.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    [Authorize]
    public class AudiosController : MainController
    {
        private readonly IMapper _mapper;
        private readonly ISpotifySearchService _searchServices;

        public AudiosController(IMapper mapper, ISpotifySearchService searchServices)
        {
            _mapper = mapper;
            _searchServices = searchServices;
        }

        // GET: AudiosController
        [HttpGet]
        public async Task<ActionResult<AudiosViewModel>> Get(int? pagina = 0)
        {
            var audios = await _searchServices.Buscar(pagina.Value);

            return CustomResponse(_mapper.Map<AudiosViewModel>(audios));
        }
    }
}