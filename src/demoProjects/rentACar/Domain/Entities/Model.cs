using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Model : Entity
    {
        // Markanın Modelleri için veri tabanı nesneleri yazılacak

        public int BrandId { get; set; } // Direk bu tabloya kayıt eklemek istediğimizde modelleme yapmak yerine direk işlem yapacağız
        public string Name { get; set; }
        public decimal DailyPrice { get; set; } // Günlük fiyatı
        public string ImageUrl { get; set; }
        public virtual Brand? Brand { get; set; } // Bir Modelin Bir Markası olur 
        // Bir çok ORM için kullanılabilinmesi için "virtual" olarak süsledik



        // Marka bir tane olduğu için Brand şeklinde kullanıldı ilerde mesela arabalar olsa List<...> şeklinde yazılır.

        public Model()
        {
        }

        public Model(int id, int brandId, string name, decimal dailyPrice, string imageUrl) : this() 
        {
            Id = id; // Biz elle ekliyoruz ctor ile otomatik gelmiyor
            BrandId = brandId;
            Name = name;
            DailyPrice = dailyPrice;
            ImageUrl = imageUrl;
        }
    }
}
