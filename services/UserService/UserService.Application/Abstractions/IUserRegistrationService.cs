
using UserService.Application.DTOs;
using UserService.Domain.ValueObjects;

namespace UserService.Application.Abstractions;

public interface IUserRegistrationService
{
    Task<UserId> RegisterUserAsync(RegisterUserRequest request);
}