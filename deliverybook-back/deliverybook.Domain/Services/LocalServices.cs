using deliverybook.Domain.Interfaces;
using deliverybook.Domain.Model.Localizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace deliverybook.Domain.Services
{
    public class LocalServices : ILocalServices
    {
        private readonly ILocalRepository _localRepository;

        public LocalServices(ILocalRepository localRepository)
        {
            _localRepository = localRepository;
        }

        public async Task<IEnumerable<Local>> ObterTodos()
        {
            return await _localRepository.ObterTodos();
        }

        public async Task<IEnumerable<Local>> PesquisarPorProdutoId(Guid produtoId)
        {
            return await _localRepository.ObterLocaisPorProdutoId(produtoId);
        }

        public async Task<bool> Adicionar(Local local)
        {
            if (_localRepository.Buscar(f => f.Latitude == local.Latitude && f.Longitude == local.Longitude).Result.Any())
            {
                return false;
            }

            await _localRepository.Adicionar(local);
            return true;
        }

        public async Task<bool> Atualizar(Local local)
        {
            if (_localRepository.Buscar(f => f.Descricao == local.Descricao && f.Id != local.Id).Result.Any())
            {
                return false;
            }

            await _localRepository.Atualizar(local);
            return true;
        }

        public void Dispose()
        {
            _localRepository?.Dispose();
        }
    }
}