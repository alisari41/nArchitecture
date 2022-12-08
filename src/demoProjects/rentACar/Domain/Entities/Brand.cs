using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Brand : Entity
    {
        // Arabanın Markaları
        // Çıplak Class kalmayacak implement edilcek ilerde soyutlama yapmak kolay olur

        public string Name { get; set; }
        public virtual ICollection<Model> Models { get; set; } // Bir markanın birden fazla modeli olabileceği için bu şekilde yazıldı

        public Brand()
        {

        }

        public Brand(int id, string name) : this() // this() demek parametresiz ctor'u da çalıştır demek
        {
            Id = id;
            Name = name;
        }
    }
}
