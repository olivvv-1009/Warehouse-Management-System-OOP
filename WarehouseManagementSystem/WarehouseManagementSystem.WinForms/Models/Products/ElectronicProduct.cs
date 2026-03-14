public class ElectornicProduct : Product
{
    public string Specification { get; set; }
    public int WarrantyPeriod { get; set; }
    public ElectornicProduct() : base()
    {
        this.Specification = Specification;
        this.WarrantyPeriod = WarrantyPeriod;
    }
}