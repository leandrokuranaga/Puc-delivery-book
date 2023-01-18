using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class ReservaServices : IReservaServices
    {
        private readonly IProdutoService _produtoService;
        private readonly IReservaRepository _reservaRepository;
        private readonly string _user;

        public ReservaServices(IProdutoService produtoService, IReservaRepository reservaRepository, IUser user)
        {
            _produtoService = produtoService;
            _user = user.GetUserId();
            _reservaRepository = reservaRepository;
        }

        public async Task<IEnumerable<Reserva>> PesquisarPorUser()
        {
            return await _reservaRepository.ObterReservasPorUser(_user);
        }

        public async Task<bool> Adicionar(Guid produtoId, Guid localId)
        {
            var produto = await _produtoService.ObterPorLocalEProdutoId(produtoId, localId);

            if (produto == null)
            {
                return false;
            }

            var reserva = MakeReserva(produto);

            await _reservaRepository.Adicionar(reserva);
            await _produtoService.Inativar(produto);
            return true;
        }

        public async Task<bool> Cancelar(Guid id)
        {
            var reserva = _reservaRepository.Buscar(x => x.Id.Equals(id)).Result.First();
            if (reserva == null)
            {
                return false;
            }
            var prod = reserva.ProdutoId;
            var local = reserva.LocalId;

            var produto = await _produtoService.ObterPorLocalEProdutoId(prod, local);

            await _reservaRepository.Remover(reserva.Id);
            await _produtoService.Ativar(produto);
            return true;
        }

        private Reserva MakeReserva(Produto produto)
        {
            var local = produto.LocalProdutos.FirstOrDefault();
            return new Reserva
            {
                UserId = _user,
                DataReserva = DateTime.Now.Date,
                ProdutoId = produto.Id,
                Titulo = produto.Titulo,
                LocalId = local.LocalId,
                DescricaoLocal = local.Local.Descricao
            };
        }
    }
}
