using CoreFoundation.CQRS;
using MothService.API.Models;

namespace MothService.API.Users.CreateUser;

public record CreateUserCommand(string FirstName, string LastName, string Email, string PasswordHash, string PassCode) : ICommand<CreateUserResult>;

public record CreateUserResult(Guid Id);

internal class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, CreateUserResult>
{
    public async Task<CreateUserResult> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            PasswordHash = command.PasswordHash,
            PassCode = command.PassCode,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.MinValue,
            ExpiresAt = DateTime.UtcNow.AddYears(1),
        };


        // save to db

        return new CreateUserResult(Guid.NewGuid());
    }
}
