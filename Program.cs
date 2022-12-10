using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Transactions;

namespace course
{
    internal class Program
    {
        enum SizeType {Small, Medium, Large}
        class Pizza
        {
            public SizeType size { get; set; }
            public List<string> ingredients { get; set; }
            public int price { get; set; }
            public Pizza() { }
            public Pizza(SizeType size, List<string> ingredients, int price)
            {
                this.size = size;
                this.ingredients = ingredients;
                this.price = price;
            }
        }
        class StandartPizza : Pizza
        {
            public string name;
            public StandartPizza() { }

         

            public StandartPizza(string name, SizeType size, List<string> ingredients, int price)
            {
                this.name = name;
                this.size = size;
                this.ingredients = ingredients;
                this.price = price;
            }

          
        }

        class Pizzeria
        { 
            string name;
            string adress;
            List<StandartPizza> menu;

            public Pizzeria(string name, string adress, List<StandartPizza> menu)
            {
                this.name = name;
                this.adress = adress;
                this.menu = menu;
            }

            public void AddPizza(StandartPizza pizza)
            {
                menu.Add(pizza);
            }

            public void DeletePizza(string name)
            {
                foreach (var item in menu)
                {
                    if (item.name == name)
                    {
                        menu.Remove(item);
                    }
                }
            }

            public void Show()
            {
                foreach (var item in menu)
                {
                    Console.WriteLine("--------------Pizza---------------");
                    Console.WriteLine($"Name\t {item.name}");
                    Console.WriteLine($"Price\t {item.price}");
                    Console.WriteLine($"Size\t {item.size}");//
                    Console.WriteLine("Ingredients: ");
                    List<string> ingredients = item.ingredients;
                    foreach (var i in ingredients)
                    {
                        Console.Write($"{i}  ");
                    }
                    Console.WriteLine();
                }
            }
            public void Order(string name, SizeType size)
            {
                foreach (var pizza in menu)
                {
                    if (pizza.name == name)
                    {
                        if (pizza.size == size)
                        {
                            Console.WriteLine("Your pizza");
                        }

                    }                   
                }
                
            }

            public void Order(SizeType size, List<string> ingredients)
            {
                if (ingredients == null) return;
                Console.WriteLine("Your pizza\n");
                foreach (var ingredient in ingredients)
                {                    
                    Console.Write(ingredient + "\t");
                }
                switch(size)
                {                   
                    case SizeType.Small:
                        Console.WriteLine("Price: 100$");
                        break;
                    case SizeType.Medium:
                        Console.WriteLine("Price: 160$");
                        break;
                    case SizeType.Large:
                        Console.WriteLine("Price: 200$");
                        break;
                    default:                      
                        break;
                }
            }
        }

        class Operation
        {
            public void Show()
            {
                Console.WriteLine("[1] Show menu");
                Console.WriteLine("[2] Add pizza");
                Console.WriteLine("[3] Delete pizza");
                Console.WriteLine("[4] Order standart pizza");
                
                Console.WriteLine("[0] Exit");
            }
            public int ChooseOperation()
            {
                int value;              
                do
                {

                    Console.WriteLine("Enter operation:");
                    value = int.Parse(Console.ReadLine());
                    /// (value == 0) return 0;
                    
                } while (value <0);//|| value >5

                return value;
            }
        }

        class App
        {
            Operation op;

            public App(Operation op)
            {
                this.op = op;
            }

            public void Start()
            {
                List<string> ingredients = new List<string>() { "meat", "chees", "tomatos" };
                StandartPizza standart = new StandartPizza("Four seasons", SizeType.Medium, ingredients, 100);
                List<StandartPizza> menu = new List<StandartPizza>();
                menu.Add(standart);
                Pizzeria pizzeria = new Pizzeria("Bazzikalo", "Soborna street", menu);
                int operation;
                do
                {
                    op.Show();
                     operation = op.ChooseOperation();
                    if (operation == 0) return;
                    if (operation == 1) pizzeria.Show();
                    if (operation == 2)
                    {
                        Console.WriteLine("Choose pizza you want to add:");
                        Console.WriteLine("[1] Quattro Formaggi");
                        Console.WriteLine("[2] Margherita");
                        Console.WriteLine("[3] Neapolitan");
                        Console.WriteLine("[4] Four seasons");
                        Console.WriteLine("Enter operation:");
                        int number = int.Parse(Console.ReadLine());
                        switch (number)
                        {
                            case 1:
                                StandartPizza p1 = new StandartPizza("Quattro Formaggi", SizeType.Medium, ingredients, 100);
                                pizzeria.AddPizza(p1);
                                Console.WriteLine("Pizza add");
                                break;
                            case 2:
                                StandartPizza p2 = new StandartPizza("Margherita", SizeType.Medium, ingredients, 100);
                                pizzeria.AddPizza(p2);
                                Console.WriteLine("Pizza add");
                                break;
                            case 3:
                                StandartPizza p3 = new StandartPizza("Neapolitan", SizeType.Medium, ingredients, 100);
                                pizzeria.AddPizza(p3);
                                Console.WriteLine("Pizza add");
                                break;
                            case 4:
                                StandartPizza p4 = new StandartPizza("Quattro Formaggi", SizeType.Medium, ingredients, 100);
                                pizzeria.AddPizza(p4);
                                Console.WriteLine("Pizza add");
                                break;
                            default:
                                break;

                        }

                    }
                    if (operation == 3)
                    {
                        Console.WriteLine("Choose pizza you want to delete:");
                        pizzeria.Show();
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        pizzeria.DeletePizza(name);
                    }
                    if (operation == 4)
                    {
                        Console.WriteLine("Enter pizza name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter pizza size:");
                        int size = int.Parse(Console.ReadLine());
                        switch (size)
                        {
                            case 0:
                                pizzeria.Order(name, SizeType.Small);
                                break;
                            case 1:
                                pizzeria.Order(name, SizeType.Medium);
                                break;
                            case 2:
                                pizzeria.Order(name, SizeType.Large);
                                break;
                        }
                    }
                } while (operation != 0);
                
                
            }
        }

        static void Main(string[] args)
        {
            Operation operation = new Operation();
            App app = new App(operation);
            app.Start();
        }
    }
}
