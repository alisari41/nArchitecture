using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Rules
{
    public class BrandBusinessRules
    {
        private readonly IBrandRepository _brandRepository;

        public BrandBusinessRules(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task BrandNameCanNotBeDuplicatedWhenInserted(string name)
        {
            // Metod geriye hiç bir şey dönmüyor. Hiçbir şey dönmüyorsa geçiyor demektir. Kuralldan geçmediği her durumda hata fırlatıyor demektir.
            // Tablo Adı ( Marka ) isimleri tekrar edemez
            IPaginate<Brand> result = await _brandRepository.GetListAsync(b => b.Name == name); // IPaginate sayfalama yapmak için yazıldı
            if (result.Items.Any()) throw new BusinessException("Brand name exists."); // BusinessException için "Core.CrossCuttingConcerns" dan Referans almak gerekir
        }
    }
}
