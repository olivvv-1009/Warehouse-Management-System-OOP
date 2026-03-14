public class FoodProduct : Product
{
    public DateTime ExpiredDate { get; set; }

    public FoodProduct() : base()
    {
        this.ExpiredDate = ExpiredDate;
    }
    public override Product GetCategory()
    {
        throw new System.NotImplementedException();
    }
}