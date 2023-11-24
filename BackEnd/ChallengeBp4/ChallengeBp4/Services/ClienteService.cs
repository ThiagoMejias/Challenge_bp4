using ChallengeBp4.Conexion;
using ChallengeBp4.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace ChallengeBp4.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;

        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }

       

        public async Task<Cliente> Get(int id)
        {
            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);
            if (cliente is null)
                return null;
            return cliente;
        }   

        public async Task<List<Cliente>> GetAll()
        { 
            return await _context.Clientes.ToListAsync();
        }

        public async Task<List<Cliente>> Search(string nombre)
        {
            var clientes = await _context.Clientes
                                         .Where<Cliente>(c => c.Nombre.Contains(nombre))
                                         .ToListAsync();
            return clientes;
        }

        public async Task<Cliente> Insert(Cliente cliente)
        {
            try
            { 
                _context.Clientes.Add(cliente);

                await _context.SaveChangesAsync();

                return cliente;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Cliente> Update(int idClienteAModificar ,Cliente clienteModificado)
        {
            var clienteExistente = await _context.Clientes.FindAsync(idClienteAModificar);

            if (clienteExistente != null)
            {
                clienteExistente.Nombre = clienteModificado.Nombre;
                clienteExistente.Apellido = clienteModificado.Apellido;
                clienteExistente.FechaDeNacimiento = clienteModificado.FechaDeNacimiento;
                clienteExistente.Cuit = clienteModificado.Cuit;
                clienteExistente.Domicilio = clienteModificado.Domicilio;
                clienteExistente.TelefonoCelular = clienteModificado.TelefonoCelular;
                clienteExistente.Email = clienteModificado.Email;
                
                await _context.SaveChangesAsync();
            
            }
            
            return clienteExistente;    

        }
    }
}
