
public class Menu
{
    public Menu(){}

    public Menu(string name, double price, string description, List<Ingredients> ingredients)
    {
       
        Price = price;
        Desctiption = description;
        Name = name;
        Ingredients = ingredients;

    }
    public int ID{get; set;}
    public double Price{get; set;}
    public string Desctiption{get; set;}
    public string Name{get; set;}
    public List<Ingredients> Ingredients {get; set;} = new List<Ingredients>();
    

    //Komodo Challenge 1: Menu
}
