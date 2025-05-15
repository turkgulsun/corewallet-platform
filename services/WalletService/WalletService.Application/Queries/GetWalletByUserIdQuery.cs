using MediatR;
using CoreWallet.Shared.Results;

namespace WalletService.Application.Queries;

public record GetWalletByUserIdQuery(Guid UserId) : IRequest<Result<WalletDto>>;
