using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class Program_UI
    {
        public void Run()
        {
            SeedData();
            RunApplication();
        }

    private void RunApplication()
    {
        throw new NotImplementedException();
    }

    private void SeedData()
    {
        var tomato = new Ingredients("Tomato");
        var lettuce = new Ingredients("Lettuce");
        var hamburger = new Ingredients("Hamburger");
        var ketchup = new Ingredients("Ketchup");
        var cheese = new Ingredients("Cheese");
        var penne = new Ingredients("Penne noodles");
        var mustard = new Ingredients("Mustard");
        var ceasar = new Ingredients("Ceasar Dressing");
        var bread = new Ingredients("Whole wheat bread");
        var pepper = new Ingredients("Pepper");

        var burger = new Menu("Burger", 4, "The classic hamburger.",
        new List<Ingredients>
        {
            tomato,
            ketchup,
            hamburger,
            lettuce,
            cheese

        } );

        var macNCheese = new Menu("Mac & Cheese", 2, "Noodles and cheese, everyone's favorite.",
        new List<Ingredients>
        {
            penne,
            cheese
        }
        
        );

        var ceasarSalad = new Menu("Ceasar Salad", 3.50, "Classic Ceasar", 
        new List<Ingredients>
        {
            ceasar,
            cheese,
            tomato
        });

    }
}
