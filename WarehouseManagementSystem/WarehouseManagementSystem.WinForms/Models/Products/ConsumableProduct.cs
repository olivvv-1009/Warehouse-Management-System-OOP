public class ConsumableProduct : Product
{
    public double ShelfLife { get; set; }

    public ConsumableProduct() : base()
    {
        this.ShelfLife = ShelfLife;
    }
}