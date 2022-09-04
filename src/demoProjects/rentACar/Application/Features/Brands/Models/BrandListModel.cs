using Application.Features.Brands.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Models
{
    public class BrandListModel : BasePageableModel
    {
        // Sayfalama için kullanılan sınıf olarak diyebiliriz. Hem Sayfalama verilerini hemde Dto verilerini kullacağız
        public IList<BrandListDto> Items { get; set; } // İsimlendirmeler aynı olması gerekirki mapperda bir daha configuraiton yapmamak için 
    }
}
