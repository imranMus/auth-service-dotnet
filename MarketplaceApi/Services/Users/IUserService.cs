namespace MarketplaceApi.Services.Users
{
    public interface IUserService
    {
        Task<bool> UpdateNameAsync(int userId, string name);
    }
}
