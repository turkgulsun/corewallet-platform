using WalletService.Application.Abstractions;
using WalletService.Domain.Entities;
using WalletService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WalletService.Infrastructure.Repositories;

public class WalletRepository(WalletDbContext context) : IWalletService
{
    public async Task<Wallet?> GetByIdAsync(Guid walletId)
    {
        return await context.Wallets
            .FirstOrDefaultAsync(w => w.Id.Value == walletId);
    }
    
    public async Task<Wallet?> GetByUserIdAsync(Guid userId)
    {
        return await context.Wallets
            .FirstOrDefaultAsync(w => w.UserId == userId);
    }

    public async Task SaveAsync(Wallet wallet)
    {
        await context.Wallets.AddAsync(wallet);

        await context.SaveChangesAsync();
    }
}