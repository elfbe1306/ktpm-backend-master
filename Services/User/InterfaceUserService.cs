using ktpm_backend_master.Common;
using ktpm_backend_master.DTO;

namespace ktpm_backend_master.Services.User
{
    public interface IUserService
    {
        Task<Result<LoginResponse>> Login(LoginRequest request);
        Task<Result<LoginResponse>> Profile(string authHeader);
    }
}