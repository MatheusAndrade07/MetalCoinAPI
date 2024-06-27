using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;

namespace MetalCoin.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository repository) 
        {
            _categoriaRepository = repository;
        }

        public async Task<CategoriaResponse> AtualizarCategoria(CategoriaAtualizarRequest categoria)
        {
            var categoriaDb = await _categoriaRepository.ObterPorId(categoria.Id);
                       
            categoriaDb.Status = categoria.Status;
            categoriaDb.Nome = categoria.Nome.ToUpper();
            categoriaDb.DataAlteracao = DateTime.Now;

            await _categoriaRepository.Atualizar(categoriaDb);

            var response = new CategoriaResponse
            {
                Id = categoriaDb.Id,
                Nome = categoriaDb.Nome,
                Status = categoriaDb.Status,
                DataAlteracao = categoriaDb.DataAlteracao,
                DataCadastro = categoriaDb.DataCadastro
            };

            return response;
        }

        public async Task<CategoriaResponse> CadastrarCategoria(CategoriaCadastrarRequest categoria)
        {

            var categoriaExistente = await _categoriaRepository.BuscarPorNome(categoria.Nome);
            
            if (categoriaExistente != null) return null;

            var categoriaEntidade = new Categoria 
            {
                Nome = categoria.Nome.ToUpper(),
                Status = categoria.Status,
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now
            };

            await _categoriaRepository.Adicionar(categoriaEntidade);

            var response = new CategoriaResponse
            {
                Id = categoriaEntidade.Id,
                Nome = categoriaEntidade.Nome,
                Status = categoriaEntidade.Status,
                DataCadastro = categoriaEntidade.DataCadastro,
                DataAlteracao = categoriaEntidade.DataAlteracao
            };

            return response;
        }

        public async Task<bool> DeletarCategoria(Guid id)
        {
            var categoria = await _categoriaRepository.ObterPorId(id);
            if(categoria == null) return false;   


            await _categoriaRepository.Remover(id);
            return true;
        }

        public async Task<List<CategoriaResponse>> ObterTodasAsCategoriasAtivas()
        {
            var categoriaEntidade = await _categoriaRepository.ObterTodos();

            var ativas = categoriaEntidade.Where(c => c.Status == true);

            var response = ativas.Select(c => new CategoriaResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                Status = c.Status,
                DataAlteracao = c.DataAlteracao,
                DataCadastro = c.DataCadastro,                
            });

            return response.ToList();


        }
    }
}
