using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Dtos
{
    public class ModelListDto
    {
        // Join İşlemi için kullanacağım sınıf. Hangi Dataları koymak istiyorsak onları yazıyoruz
        public int Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; } // Marka adı ( Diğer Tablodan Alacağız)   İstediklerimi verebiliriz.
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }  

    }
}
