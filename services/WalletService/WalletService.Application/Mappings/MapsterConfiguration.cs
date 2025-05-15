using WalletService.Application.DTOs;
using WalletService.Domain.Entities;
using Mapster;

namespace WalletService.Application.Mappings;

public static class MapsterConfiguration
{
    public static void RegisterMappings()
    {
        TypeAdapterConfig<Wallet, WalletDto>.NewConfig()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.UserId, src => src.UserId)
            .Map(dest => dest.Currency, src => src.Balance.Currency.ToString())
            .Map(dest => dest.Balance, src => src.Balance.Amount)
            .Map(dest => dest.CreatedAt, src => src.CreatedAt)
            .Map(dest => dest.IsActive, src => src.IsActive);

        // Diğer configler buraya
    }
}
