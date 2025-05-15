using MediatR;
using CoreWallet.Shared.Results;

namespace WalletService.Application.Commands.CreditWallet;
public record CreditWalletCommand(Guid WalletId, decimal Amount) : IRequest<Result<Guid>>;