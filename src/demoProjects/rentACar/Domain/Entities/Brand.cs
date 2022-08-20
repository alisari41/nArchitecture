using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Brand : Entity
    {
        // Arabanın Markaları
        // Çıplak Class kalmayacak implement edilcek ilerde soyutlama yapmak kolay olur

        public string Name { get; set; }

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
