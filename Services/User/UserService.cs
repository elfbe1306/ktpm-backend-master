using ktpm_backend_master.DTO;
using ktpm_backend_master.Repositories;

namespace ktpm_backend_master.Services
{
    public class UserService : InterfaceUserService
    {
        private readonly InterfaceUserRepository _userRepository;

        public UserService(InterfaceUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            var response = await _userRepository.Login(request);
            return response;
        }
    }
}