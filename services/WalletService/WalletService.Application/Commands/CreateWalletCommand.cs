using CoreWallet.Shared.Results;
using MediatR;

namespace WalletService.Application.Commands;

public record CreateWalletCommand(Guid UserId, string Currency) : IRequest<Result<Guid>>;
