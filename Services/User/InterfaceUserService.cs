using ktpm_backend_master.DTO;

namespace ktpm_backend_master.Services
{
    public interface InterfaceUserService
    {
        Task<LoginResponse> Login(LoginRequest request);
    }
}