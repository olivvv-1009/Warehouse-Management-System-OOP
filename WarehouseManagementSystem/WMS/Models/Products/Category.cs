public class Category
{
    public string CategoryId { get; set; }
    public string CategoryName { get; set; }
    public Category GetCategory(FoodProduct foodProduct)
    {
        this.CategoryName = "Food";
        return this.CategoryName;
    }
    public Category GetCategory(ConsumableProduct consumableProduct)
    {
        this.CategoryName = "Consumable";
        return this.CategoryName;
    }
    public Category GetCategory(ElectronicProduct eProduct)
    {
        this.CategoryName = "Electronic";
        return this.CategoryName;
    }
}