using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Loja.Models;
using Loja.Data;
namespace Loja.Services{
    public class VendaService{
         public readonly LojaDbContext _dbContext;

        public VendaService(LojaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Venda>> GetAllVendasAsync(){
            return await _dbContext.Vendas.ToListAsync();
        }

        public async Task<Venda> GetVendaByIdAsync(int id){
            
        }
    }
}