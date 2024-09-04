using System;
using System.Collections.Generic;

public class Pet
{
    public string Kind { get; set; }
    public string Name { get; set; }
    public string Gender { get; set; }
    public string Owner { get; set; }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"* {Kind} - {Name} ({(Gender == "M" ? "Male" : "Female")}), Owner: {Owner}");
    }
}

public class Dog : Pet
{
    public string Breed { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($", Breed: {Breed}");
    }
}

public class Cat : Pet
{
    public bool IsLonghaired { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($", Hair Type: {(IsLonghaired ? "Longhaired" : "Shorthair")}");
    }
}

public class Lizard : Pet
{
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($", Has 4 legs, Is cold-blooded");
    }
}

public class Bird : Pet
{
    public bool CanFly { get; set; }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($", Can fly: {(CanFly ? "Yes" : "No")}");
    }
}

public class Program
{
    static List<Pet> petInventory = new List<Pet>();

    public static void Main()
    {
        string addMore;
        do
        {
            AddPet();
            Console.WriteLine("\nAdd another pet? (y/n): ");
            addMore = Console.ReadLine().ToLower();
        } while (addMore == "y");

        Console.WriteLine("\nWhich type of animal would you like to list? (Dog, Cat, Lizard, Bird, or 'All'): ");
        string typeToDisplay = Console.ReadLine();

        DisplayPets(typeToDisplay);
    }

    static void AddPet()
    {
        Console.WriteLine("\nKind (Dog, Cat, Lizard, Bird): ");
        string kind = Console.ReadLine();

        Console.WriteLine("Name: ");
        string name = Console.ReadLine();

        Console.WriteLine("Gender (M/F): ");
        string gender = Console.ReadLine();

        Console.WriteLine("Owner: ");
        string owner = Console.ReadLine();

        switch (kind.ToLower())
        {
            case "dog":
                Console.WriteLine("Breed: ");
                string breed = Console.ReadLine();
                petInventory.Add(new Dog { Kind = "Dog", Name = name, Gender = gender, Owner = owner, Breed = breed });
                break;

            case "cat":
                Console.WriteLine("Is Longhaired? (y/n): ");
                bool isLonghaired = Console.ReadLine().ToLower() == "y";
                petInventory.Add(new Cat { Kind = "Cat", Name = name, Gender = gender, Owner = owner, IsLonghaired = isLonghaired });
                break;

            case "lizard":
                petInventory.Add(new Lizard { Kind = "Lizard", Name = name, Gender = gender, Owner = owner });
                break;

            case "bird":
                Console.WriteLine("Can Fly? (y/n): ");
                bool canFly = Console.ReadLine().ToLower() == "y";
                petInventory.Add(new Bird { Kind = "Bird", Name = name, Gender = gender, Owner = owner, CanFly = canFly });
                break;

            default:
                Console.WriteLine("Invalid pet kind!");
                break;
        }
    }

    static void DisplayPets(string typeToDisplay)
    {
        Console.WriteLine("\nAll pets in the inventory:");

        foreach (var pet in petInventory)
        {
            if (typeToDisplay.ToLower() == "all" || pet.Kind.ToLower() == typeToDisplay.ToLower())
            {
                pet.DisplayInfo();
            }
        }
    }
}