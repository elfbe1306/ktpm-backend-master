using ktpm_backend_master.DTO;
using System.Text.Json;
using Supabase.Gotrue.Exceptions;
using ktpm_backend_master.Models;

namespace ktpm_backend_master.Repositories
{
    public class UserRepository : InterfaceUserRepository
    {
        private readonly SupabaseClientService _supabaseService;

        public UserRepository(SupabaseClientService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        public async Task<LoginResponse> Login(LoginRequest request)
        {
            try
            {
                var response = await _supabaseService.GetClient().Auth.SignIn(request.Email, request.Password);

                if (response == null || response.User == null || response.User.Id == null || response.AccessToken == null)
                {
                    return new LoginResponse
                    {
                        Success = false,
                        ErrorMessage = "Invalid email or password"
                    };
                }

                var userId = Guid.Parse(response.User.Id);
                var user = await _supabaseService.GetClient().From<NewUser>().Where(u => u.Id == userId).Single();

                return new LoginResponse
                {
                    UserId = response.User.Id,
                    AccessToken = response.AccessToken,
                    Name = user?.Name ?? "",
                    Email = user?.Email ?? "",
                    CreatedAt = user?.CreatedAt ?? "",
                    Role = user?.Role ?? "",
                    Success = true,
                };
            }
            catch (GotrueException ex)
            {
                string msg = "An error occurred";

                try
                {
                    using var jsonDoc = JsonDocument.Parse(ex.Message);
                    var root = jsonDoc.RootElement;

                    if (root.TryGetProperty("msg", out var msgProp))
                        msg = msgProp.GetString() ?? msg;
                }
                catch
                {
                    msg = ex.Message;
                }

                return new LoginResponse
                {
                    Success = false,
                    ErrorMessage = msg
                };
            }
        }

        public async Task<LoginResponse> Profile(string token)
        {
            try
            {
                var user = await _supabaseService.GetClient().Auth.GetUser(token);

                if (user == null || user.Id == null)
                {
                    return new LoginResponse
                    {
                        Success = false,
                        ErrorMessage = "Invalid or expired token"
                    };
                }

                var userId = Guid.Parse(user.Id);
                var getUser = await _supabaseService.GetClient().From<NewUser>().Where(u => u.Id == userId).Single();

                return new LoginResponse
                {
                    UserId = user.Id,
                    AccessToken = token,
                    Name = getUser?.Name ?? "",
                    Email = getUser?.Email ?? "",
                    CreatedAt = getUser?.CreatedAt ?? "",
                    Role = getUser?.Role ?? "",
                    Success = true,
                };
            }
            catch (GotrueException ex)
            {
                string msg = "An error occurred";

                try
                {
                    using var jsonDoc = JsonDocument.Parse(ex.Message);
                    var root = jsonDoc.RootElement;

                    if (root.TryGetProperty("msg", out var msgProp))
                        msg = msgProp.GetString() ?? msg;
                }
                catch
                {
                    msg = ex.Message;
                }

                return new LoginResponse
                {
                    Success = false,
                    ErrorMessage = msg
                };
            }
        }
    }
}
