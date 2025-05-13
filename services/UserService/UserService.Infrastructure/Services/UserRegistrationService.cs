using UserService.Application.Abstractions;
using UserService.Application.DTOs;
using UserService.Domain.Entities;
using UserService.Domain.ValueObjects;
using UserService.Infrastructure.Persistence;

namespace UserService.Infrastructure.Services;

public class UserRegistrationService(UserDbContext _db) : IUserRegistrationService
{
    public async Task<UserId> RegisterUserAsync(RegisterUserRequest request)
    {
        var user = new User(UserId.New(), new Email(request.Email), request.FullName);

        _db.Users.Add(user);

        await _db.SaveChangesAsync();

        return user.Id;
    }
}