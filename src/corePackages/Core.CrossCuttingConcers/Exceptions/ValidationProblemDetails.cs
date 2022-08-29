using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ValidationProblemDetails : ProblemDetails
{
    // Hem hata türlülerini ayırmak için hemde kendi istedğimiz ekstra alanları koymak için bu sınıf kullanılıyor.
    public object Errors { get; set; }

    public override string ToString() => JsonConvert.SerializeObject(this);
}