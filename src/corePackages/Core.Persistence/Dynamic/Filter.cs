namespace Core.Persistence.Dynamic;

public class Filter
{
    public string Field { get; set; } // Hangi Alana Göre
    public string Operator { get; set; } // Hangi Oparetöre göre
    public string? Value { get; set; } // Değerini
    public string? Logic { get; set; }
    public IEnumerable<Filter>? Filters { get; set; }

    public Filter()
    {
    }

    public Filter(string field, string @operator, string? value, string? logic, IEnumerable<Filter>? filters) : this()
    {
        Field = field;
        Operator = @operator;
        Value = value;
        Logic = logic;
        Filters = filters;
    }
}