using ktpm_backend_master.DTO;
using Supabase.Gotrue.Exceptions;
using ktpm_backend_master.Models;
using ktpm_backend_master.Repositories.User;
using ktpm_backend_master.Common;

namespace ktpm_backend_master.Repositories.User
{
    public class UserRepository : IUserRepository
    {
        private readonly SupabaseClientService _supabaseService;

        public UserRepository(SupabaseClientService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        public async Task<Result<LoginResponse>> Login(LoginRequest request)
        {
            try
            {
                var response = await _supabaseService.GetClient().Auth.SignIn(request.Email, request.Password);

                if (response == null || response.User == null || response.User.Id == null)
                {
                    return Result<LoginResponse>.Fail("Invalid email or password");
                }

                var userId = Guid.Parse(response.User.Id);
                var getUser = await _supabaseService.GetClient().From<NewUser>().Where(u => u.Id == userId).Single();

                return Result<LoginResponse>.Ok(new LoginResponse
                {
                    UserId = response.User.Id,
                    AccessToken = response?.AccessToken ?? "",
                    Name = getUser?.Name ?? "",
                    Email = getUser?.Email ?? "",
                    CreatedAt = getUser?.CreatedAt ?? "",
                    Role = getUser?.Role ?? "",
                });
            }
            catch (GotrueException ex)
            {

                return Result<LoginResponse>.Fail(ex.Message);
            }
        }

        public async Task<Result<LoginResponse>> Profile(string token)
        {
            try
            {
                var user = await _supabaseService.GetClient().Auth.GetUser(token);

                if (user == null || user.Id == null)
                {
                    return Result<LoginResponse>.Fail("Invalid or expired token");
                }

                var userId = Guid.Parse(user.Id);
                var getUser = await _supabaseService.GetClient().From<NewUser>().Where(u => u.Id == userId).Single();

                return Result<LoginResponse>.Ok(new LoginResponse
                {
                    UserId = user.Id,
                    AccessToken = token,
                    Name = getUser?.Name ?? "",
                    Email = getUser?.Email ?? "",
                    CreatedAt = getUser?.CreatedAt ?? "",
                    Role = getUser?.Role ?? "",
                });
            }
            catch (GotrueException ex)
            {
                return Result<LoginResponse>.Fail(ex.Message);
            }
        }
    }
}
