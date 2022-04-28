using CleanArchitecture.Blazor.Infrastructure.Extensions;
namespace CleanArchitecture.Blazor.Infrastructure.Services.Authentication;

public class ProfileService
{
    public Func<UserModel, Task>? OnChange;
    public UserModel Profile { get; private set; } = default!;
    public async Task<UserModel> Get(ClaimsPrincipal principal)
    {
        var user = principal;
        Profile = new UserModel()
        {
            Avatar = user.GetProfilePictureDataUrl(),
            DisplayName = user.GetDisplayName(),
            Email = user.GetEmail(),
            PhoneNumber = user.GetPhoneNumber(),
            Site = user.GetSite(),
            Role = user.GetRoles().FirstOrDefault(),
            UserId = user.GetUserId(),
            UserName = user.GetUserName(),
            ReferralCode = user.GetReferralCode(),
            ReferredBy = user.GetReferredBy(),
    public event Action? OnChange;
    public UserModel Profile { get; private set; } = new();
    public Task Set(ClaimsPrincipal principal)
    {
        Profile =  new UserModel()
        {
            Avatar = principal.GetProfilePictureDataUrl(),
            DisplayName = principal.GetDisplayName(),
            Email = principal.GetEmail(),
            PhoneNumber = principal.GetPhoneNumber(),
            Site= principal.GetSite(),
            Role = principal.GetRoles().FirstOrDefault(),
            UserId = principal.GetUserId(),
            UserName = principal.GetUserName(),
        };
        OnChange?.Invoke();
        return Task.CompletedTask;
    }
    public Task Update(UserModel profile)
    {
        Profile = profile;
        OnChange?.Invoke();
        return Task.CompletedTask;
    }


}
