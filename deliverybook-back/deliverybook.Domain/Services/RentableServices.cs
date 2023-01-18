using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Aluguel;
using deliverybook.Domain.Model.ItBook;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class RentableServices : IRentableServices
    {
        private readonly IItBookBooksServices _booksService;
        private readonly IAluguelRepository _aluguelRepository;
        private readonly string _user;

        public RentableServices(IItBookBooksServices booksService, IAluguelRepository aluguelRepository, IUser user)
        {
            _booksService = booksService;
            _user = user.GetUserId();
            _aluguelRepository = aluguelRepository;
        }

        public async Task<IEnumerable<Aluguel>> PesquisarPorUser()
        {
            return await _aluguelRepository.ObterAlugueisPorUser(_user);
        }

        public async Task<bool> Adicionar(string id, int dias)
        {
            var livro = await _booksService.BuscarPorId(id);

            if (_aluguelRepository.Buscar(f => f.Isbn13.ToLower().Equals(livro.Isbn13.ToLower()) && f.UserId.Equals(_user)).Result.Any())
            {
                return false;
            }

            var aluguel = MakeAluguel(livro, dias);

            await _aluguelRepository.Adicionar(aluguel);
            return true;
        }

        private Aluguel MakeAluguel(Detalhes detalhes, int dias)
        {
            return new Aluguel
            {
                UserId = _user,
                DataInicio = DateTime.Now.Date,
                DataFim = DateTime.Now.Date.AddDays(dias),
                Isbn13 = detalhes.Isbn13,
                Titulo = detalhes.Titulo,
                Autores = detalhes.Autores,
                LivroDigital = detalhes.Capitulos.Values.ToList().FindAll(x => x.EndsWith(".pdf")).FirstOrDefault()
            };
        }
    }
}
