using financas.Domain.Entities;
using financas.Infrastructure.Data;
using financas.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace financas.Infrastructure.Repositories;


public class TransactionRepository : ITransactionRepository
{
    private readonly ApplicationDbContext _context;

    public TransactionRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Transaction> CreateAsync(Transaction transaction)
    {
        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }

    public async Task<Transaction?> GetByIdAsync(Guid id)
    {
        return await _context.Transactions.Include(t => t.Person).FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<Transaction>> GetAllAsync()
    {
        return await _context.Transactions.Include(t => t.Person).ToListAsync();
    }
}