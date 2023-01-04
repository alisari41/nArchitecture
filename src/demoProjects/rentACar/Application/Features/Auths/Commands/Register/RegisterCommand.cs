using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;

namespace Application.Features.Auths.Commands.Register;

public class RegisterCommand : IRequest<RegisteredDto>
{
    public UserForRegisterDto UserForRegisterDto { get; set; } // Register olacak kişinin bilgileri - yanş kullanıcı bilgileri
    public string IpAddress { get; set; } // RefreshToken da ip bazlı doğrulama süreçleri vardır.


    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredDto>
    {
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public RegisterCommandHandler(AuthBusinessRules authBusinessRules, IUserRepository userRepository, IAuthService authService)
        {
            _authBusinessRules = authBusinessRules;
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<RegisteredDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.EmailCanNotBeDuplicatedWhenRegşstered(request.UserForRegisterDto.Email);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

            #region Manuel Mapleme
            User newUser = new()
            {
                Email = request.UserForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                FirstName = request.UserForRegisterDto.FirstName,
                LastName = request.UserForRegisterDto.LastName,
                Status = true
            };
            #endregion

            User createdUser = await _userRepository.AddAsync(newUser); // Kullanıcıyı oluşturduk

            AccessToken createdAccessToken = await _authService.CreateAccessToken(createdUser); // Bir Tane accesssToken oluşturduk
            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(createdUser, request.IpAddress); // Bir tane de RefreshToken oluşturduk
            RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken); // Veri tabanına yollamamız lazım (veri tabanına eklenen refresh token)

            RegisteredDto registeredDto = new()
            { // Birleştirme işlemi
                RefreshToken = addedRefreshToken,
                AccessToken = createdAccessToken
            };

            return registeredDto;
        }
    }
}
