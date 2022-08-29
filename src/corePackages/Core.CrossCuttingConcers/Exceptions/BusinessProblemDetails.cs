using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class BusinessProblemDetails : ProblemDetails
{
    // Hem hata türlülerini ayırmak için hemde kendi istedğimiz ekstra alanları koymak için bu sınıf kullanılıyor.
    public override string ToString() => JsonConvert.SerializeObject(this);
}