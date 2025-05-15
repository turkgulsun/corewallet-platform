using MediatR;
using WalletService.Application.DTOs;
using WalletService.Application.Queries;
using WalletService.Application.Abstractions;
using WalletService.Domain.Constants.Messages;
using CoreWallet.Shared.Results;
using Mapster;

namespace WalletService.Application.Handlers;

public class GetWalletByUserIdQueryHandler(IWalletService walletService) : IRequestHandler<GetWalletByUserIdQuery, Result<WalletDto>>
{
    public async Task<Result<WalletDto>> Handle(GetWalletByUserIdQuery query, CancellationToken cancellationToken)
    {
        var wallet = await walletService.GetByUserIdAsync(query.UserId);

        if (wallet == null)
            return Result<WalletDto>.Failure(WalletMessages.NotFound);

        var dto = wallet.Adapt<WalletDto>();

        return Result<WalletDto>.Success(dto);
    }
}
