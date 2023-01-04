using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;

namespace Application.Features.Auths.Rules;

public class AuthBusinessRules
{
    private readonly IUserRepository _userRepository;

    public AuthBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task EmailCanNotBeDuplicatedWhenRegşstered(string email)
    {
        var result = await _userRepository.GetAsync(x => x.Email == email);
        if (result != null) throw new BusinessException("Mail already existst");
    }
}
