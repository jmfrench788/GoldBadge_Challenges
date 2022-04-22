
public class Menu
{
    public Menu(){}
    public Menu(string name, double price, string description, string ingredients)
    {
        Price = price;
        Description = description;
        Name = name;
        Ingredients = ingredients;
    }
    public int ID{get; set;}
    public double Price{get; set;}
    public string Description{get; set;}
    public string Name{get; set;}
    public string Ingredients{get; set;}
}
