using ktpm_backend_master.DTO;

namespace ktpm_backend_master.Repositories
{
    public interface InterfaceUserRepository
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}