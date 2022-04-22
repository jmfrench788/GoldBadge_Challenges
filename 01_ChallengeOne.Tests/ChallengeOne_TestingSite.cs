using Xunit;
using System.Collections.Generic;


public class Challenge1_TestingSite
{
    [Fact]
    public void CreateAnInstanceOf_MenuItem()
    {
        Menu menu = new Menu("Pizza",2.99, "Pizza description", "pepperoni, cheese, crust, red sauce");
        
        string expectedItemName="Pizza";
        string actualItemName = menu.Name;

        string expectedItemDescription="Pizza description";
        string actualItemDescription = menu.Description;

        string expectedItemIngredients="pepperoni, cheese, crust, red sauce";
        string actualItemIngredients = menu.Ingredients;

        double expectedItemPrice = 2.99;
        double actualItemPrice = menu.Price;
    
        Assert.Equal(expectedItemName, actualItemName);
        Assert.Equal(expectedItemDescription, actualItemDescription);
        Assert.Equal(expectedItemPrice, actualItemPrice);
        Assert.Equal(expectedItemIngredients, actualItemIngredients);
    }
}