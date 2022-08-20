namespace Core.Persistence.Repositories;

public class Entity
{
    //Bütün Tablolarda bu Id lazım olduğu için genel şekilde tanımlanadı.
    public int Id { get; set; }

    public Entity()
    {
    }

    public Entity(int id) : this()
    {
        Id = id;
    }
}