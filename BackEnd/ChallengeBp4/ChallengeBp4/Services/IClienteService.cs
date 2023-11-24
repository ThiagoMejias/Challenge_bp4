using ChallengeBp4.Modelos;
using Microsoft.AspNetCore.Mvc;

namespace ChallengeBp4.Services
{
    public interface IClienteService
    {
        public Task<List<Cliente>> GetAll();

        public Task<Cliente> Get(int id);

        public Task<List<Cliente>> Search(string nombre);

        public  Task<Cliente> Insert(Cliente cliente);

        public Task<Cliente> Update(int id,Cliente cliente);



    }
}
