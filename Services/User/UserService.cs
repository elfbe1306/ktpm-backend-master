using System.Text.Json;
using ktpm_backend_master.Common;
using ktpm_backend_master.DTO;
using ktpm_backend_master.Repositories;
using ktpm_backend_master.Repositories.User;
using ktpm_backend_master.Services.User;

namespace ktpm_backend_master.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Result<LoginResponse>> Login(LoginRequest request)
        {
            var response = await _userRepository.Login(request);

            if (!response.Success)
            {
                string msg = "An error occurred";

                try
                {
                    using var jsonDoc = JsonDocument.Parse(response.Error);
                    var root = jsonDoc.RootElement;

                    if (root.TryGetProperty("msg", out var msgProp))
                        msg = msgProp.GetString() ?? msg;
                }
                catch
                {
                    msg = response.Error;
                }

                return Result<LoginResponse>.Fail(msg);
            }

            return response;
        }

        public async Task<Result<LoginResponse>> Profile(string authHeader)
        {
            if (string.IsNullOrEmpty(authHeader))
                return Result<LoginResponse>.Fail("Missing Authorization header");

            var token = authHeader.Replace("Bearer ", "").Trim();

            var response = await _userRepository.Profile(token);

            if (!response.Success)
            {
                string msg = "An error occurred";

                try
                {
                    using var jsonDoc = JsonDocument.Parse(response.Error);
                    var root = jsonDoc.RootElement;

                    if (root.TryGetProperty("msg", out var msgProp))
                        msg = msgProp.GetString() ?? msg;
                }
                catch
                {
                    msg = response.Error;
                }

                return Result<LoginResponse>.Fail(msg);
            }
            
            return response;
        }
    }
}