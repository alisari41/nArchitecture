namespace Core.Persistence.Repositories;

public interface IQuery<T>
{
    // Kendi sorgularımızı yazabileceğimiz  
    IQueryable<T> Query();
}