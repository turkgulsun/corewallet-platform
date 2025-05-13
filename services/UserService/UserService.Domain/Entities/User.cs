using CoreWallet.Shared.Domain;
using UserService.Domain.Enums;
using UserService.Domain.ValueObjects;

namespace UserService.Domain.Entities;

public class User : IAggregateRoot
{
    public UserId Id { get; private set; }
    public Email Email { get; private set; }
    public string FullName { get; private set; }
    public UserStatus Status { get; private set; }

    private User() { }

    public User(UserId id, Email email, string fullName)
    {
        Id = id;
        Email = email;
        FullName = fullName;
        Status = UserStatus.Registered;
    }

    public void MarkKycVerified()
    {
        Status = UserStatus.KycVerified;
    }
}