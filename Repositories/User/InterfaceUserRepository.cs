using ktpm_backend_master.Common;
using ktpm_backend_master.DTO;

namespace ktpm_backend_master.Repositories.User
{
    public interface IUserRepository
    {
        Task<Result<LoginResponse>> Login(LoginRequest request);
        Task<Result<LoginResponse>> Profile(string token);
    }
}