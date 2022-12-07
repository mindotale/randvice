namespace Randvice.Core.Identity;

public interface IIdentityService
{
    public Task<AuthenticationCredentials> LoginAsync(
        LoginUserCommand command,
        CancellationToken cancellationToken = default);
}
