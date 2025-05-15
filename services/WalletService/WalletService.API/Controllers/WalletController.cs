using Microsoft.AspNetCore.Mvc;
using MediatR;
using WalletService.Application.Commands;
using WalletService.Application.Commands.CreditWallet;
using WalletService.Application.Commands.DebitWallet;
using WalletService.Application.Queries;
using WalletService.Application.DTOs;
using CoreWallet.Shared.Results;

namespace WalletService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WalletController(IMediator mediator) : ControllerBase
{
    [HttpGet("{userId}")]
    public async Task<IActionResult> GetByUserId(Guid userId)
    {
        var result = await mediator.Send(new GetWalletByUserIdQuery(userId));
        return Ok(result);
    }

    [HttpPost("credit")]
    public async Task<IActionResult> Credit([FromBody] CreditWalletCommand command)
    {
        var result = await mediator.Send(command);
        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateWallet([FromBody] CreateWalletRequest request)
    {
        var command = new CreateWalletCommand(request.UserId, request.Currency);
        var result = await mediator.Send(command);

        if (!result.IsSuccess)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpPost("debit")]
    public async Task<IActionResult> Debit([FromBody] DebitWalletCommand command)
    {
        var result = await mediator.Send(command);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }

}