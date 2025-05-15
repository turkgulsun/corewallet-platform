using MediatR;
using CoreWallet.Shared.Results;

namespace WalletService.Application.Commands.DebitWallet;
public record DebitWalletCommand(Guid WalletId, decimal Amount) : IRequest<Result<Guid>>;