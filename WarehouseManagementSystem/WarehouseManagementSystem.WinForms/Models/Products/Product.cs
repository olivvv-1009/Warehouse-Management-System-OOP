[Serializable]
public abstract class Product
{
    public string ProductId { get; set; }
    public string Name { get; set; }
    public double ImportPrice { get; set; }
    public double ExportPrice { get; set; }

    public abstract Product GetCategory();
}