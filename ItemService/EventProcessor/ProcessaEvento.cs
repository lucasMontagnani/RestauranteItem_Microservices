using AutoMapper;
using ItemService.Data;
using ItemService.Dtos;
using ItemService.Models;
using System.Text.Json;

namespace ItemService.EventProcessor
{
    public class ProcessaEvento : IProcessaEvento
    {
        private readonly IMapper _mapper;
        private readonly IServiceScopeFactory _scopeFactory;

        public ProcessaEvento(IMapper mapper, IServiceScopeFactory scopeFactory)
        {
            _mapper = mapper;
            _scopeFactory = scopeFactory;
        }

        public void Processa(string mensagem)
        {
            /* Não será possível realizar a injeção do ItemRepository dentro do ProcessaEvento, pois este é uma dependência de
             * RabbitMqSubscriber, o qual herda de BackgroundService, este que não é compativel com o tipo AddScoped do repository.
             * Para conseguirmos fazer isso, precisaremos contornar o problema, fazendo a instância através do escopo factory.
             * i.e:Instanciamos um contexto em que o BackgroundService vai conseguir fazer a injeção de dependências do ItemRepository
             */
            using var scope = _scopeFactory.CreateScope();

            IItemRepository itemRepository = scope.ServiceProvider.GetRequiredService<IItemRepository>();

            RestauranteReadDto? restauranteReadDto = JsonSerializer.Deserialize<RestauranteReadDto>(mensagem);

            Restaurante restaurante = _mapper.Map<Restaurante>(restauranteReadDto);

            if (!itemRepository.ExisteRestauranteExterno(restaurante.Id))
            {
                itemRepository.CreateRestaurante(restaurante);
                itemRepository.SaveChanges();
            }
        }
    }
}
