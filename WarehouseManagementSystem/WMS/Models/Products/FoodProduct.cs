using WarehouseManagementSystem.WinForms.Models.Products;

public class FoodProduct : Product
{
    public DateTime ExpiredDate{get;set;}
    public override string GetCategory()
    {
        return null;
    }
}