using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Xml;

namespace ZooProject {
  // BASIC CLASS Animal 
  abstract class Animal {
    // Properties are information about an animal.
    public string Name { get; set; }           // Nickname
    public int Age { get; set; }                // Age
    public string Habitat { get; set; }         // Where it lives (forest, water, desert)
    public string FoodType { get; set; }        // What does it eat(predator, herbivore)
    public double Weight { get; set; }          // Weight in kilogram
    public string Color { get; set; }           // Color

    // Constructor - creates a new animal
    public Animal(string name, int age, string habitat, string foodType, double weight, string color) {
      Name = name;
      Age = age;
      Habitat = habitat;
      FoodType = foodType;
      Weight = weight;
      Color = color;
    }

    // The virtual method can be supplemented in children's classes
    public virtual string GetInfo() {
      return $"Nickname: {Name}, Age: {Age} years, " +
             $"Habitat: {Habitat}, Nutrition: {FoodType}, " +
             $"Weight: {Weight} kg, Color: {Color}";
    }
  }

  // SUCCESSOR CLASSES
  // Each class adds its own feature
  // Mammal
  class Mammal : Animal {
  // A unique property for mammals: do they have fur
    public bool HasFur { get; set; }

    public Mammal(string name, int age, string habitat, string foodType, double weight, string color, bool hasFur)
      : base(name, age, habitat, foodType, weight, color) {
            HasFur = hasFur;
    }

    // Overriding the method to add unique information
    public override string GetInfo() {
      string furInfo = HasFur ? "there is wool" : "there is no wool";
      return base.GetInfo() + $", Type: Mammal, {furInfo}";
    }
  }

  // Bird
  class Bird : Animal {
    // A unique property for birds is their wingspan.
    public double WingSpan { get; set; } // in meters

    public Bird(string name, int age, string habitat, string foodType, double weight, string color, double wingSpan)
      : base(name, age, habitat, foodType, weight, color) {
      WingSpan = wingSpan;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Bird, Wingspan: {WingSpan} m";
    }
  }

  // Fish
  class Fish : Animal {
    // A unique property for fish is the type of water    
    public string WaterType { get; set; } // "fresh" or "sea"

    public Fish(string name, int age, string habitat, string foodType, double weight, string color, string waterType)
      : base(name, age, habitat, foodType, weight, color) {
      WaterType = waterType;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Fish, Water: {WaterType}";
    }
  }

  // Reptile
  class Reptile : Animal {
    // Unique property - toxicity
    public bool IsVenomous { get; set; }

    public Reptile(string name, int age, string habitat, string foodType, double weight, string color, bool isVenomous)
      : base(name, age, habitat, foodType, weight, color) {
      IsVenomous = isVenomous;
    }

    public override string GetInfo() {
      string venomInfo = IsVenomous ? "poisonous" : "non-poisonous";
      return base.GetInfo() + $", Type: Reptile, {venomInfo}";
    }
  }

  // Amphibian
  class Amphibian : Animal {
    // Unique property -skin moisture(from 0 to 10)
    public int SkinMoisture { get; set; } // 0 - dry, 10 - very wet

    public Amphibian(string name, int age, string habitat, string foodType, double weight, string color, int skinMoisture)
      : base(name, age, habitat, foodType, weight, color) {
      SkinMoisture = skinMoisture;
    }

    public override string GetInfo() {
      string moistureLevel;
        if (SkinMoisture < 3) moistureLevel = "dry";
        else if (SkinMoisture < 7) moistureLevel = "normal";
        else moistureLevel = "wet";

        return base.GetInfo() + $", Type: Amphibian, Skin: {moistureLevel} (level {SkinMoisture}/10)";
    }
  }

  // SINGLETON MANAGER
  class ZooManager {
    // A static variable stores a single caretaker
    private static ZooManager _instance;

    // List of all animals in the zoo
    private List<Animal> animals = new List<Animal>();

    // Private constructor - cannot create a new overseer
    private ZooManager() {
      // Let's add a few animals right away as an example.    
      AddSampleAnimals();
    }
    // Property for obtaining a single caretaker   
    public static ZooManager Instance {
      get {
        // If the caretaker has not yet been created, create it
                
        if (_instance == null) {
           _instance = new ZooManager();
        }
        return _instance;
      }
    }

    // Adding examples of animals 
    private void AddSampleAnimals() {
      animals.Add(new Mammal("Лео", 5, "саванна", "хищник", 150, "золотистый", true));
      animals.Add(new Bird("Кеша", 2, "лес", "всеядное", 0.5, "пёстрый", 0.3));
      animals.Add(new Fish("Немо", 1, "океан", "хищник", 0.1, "оранжевый", "морская"));
      animals.Add(new Reptile("Змейка", 3, "пустыня", "хищник", 2, "зелёный", true));
      animals.Add(new Amphibian("Квак", 2, "болото", "насекомые", 0.3, "зелёный", 8));
    }

    // Method for adding a new animal
    public void AddAnimal(Animal animal) {
      animals.Add(animal);
      Console.WriteLine($" Animal {animal.Name} successfully added to the zoo!");
    }

    // Method for showing all animals
    public void ShowAllAnimals() {
      if (animals.Count == 0) {
        Console.WriteLine(" There are no animals in the zoo yet.");
        return;
      }

      Console.WriteLine("\n========== OUR ZOO ==========");
      for (int animalCounter = 0; animalCounter < animals.Count; ++animalCounter) {
        Console.WriteLine($"\n--- Animal #{animalCounter + 1} ---");
        Console.WriteLine(animals[animalCounter].GetInfo());
      }
      Console.WriteLine($"\nTotal animals: {animals.Count}");
    }

    // Method for searching an animal by name
    public void FindAnimalByName(string name) {
      bool found = false;
      foreach (var animal in animals) {
        if (animal.Name.ToLower().Contains(name.ToLower())) {
          Console.WriteLine("\nAnimal found:");
          Console.WriteLine(animal.GetInfo());
          found = true;
        }
      }

      if (!found) {
        Console.WriteLine("No animal with this name was found.");
      }
    }

    // Method for showing an animal by number
    public void ShowAnimalByIndex(int animalPosition) {
      if (animalPosition < 0 || animalPosition >= animals.Count) {
        Console.WriteLine("❌ Неправильный номер животного");
        return;
      }

      Console.WriteLine($"\n🐾 Животное #{animalPosition + 1}:");
      Console.WriteLine(animals[animalPosition].GetInfo());
    }
  }

  // MAIN PROGRAM
  class Program {
    static void Main(string[] args) {
      Console.WriteLine(" WELCOME TO THE ELECTRONIC ZOO!");

      // We get the only zookeeper    
      ZooManager zoo = ZooManager.Instance;

      bool isRunning = true;

      while (isRunning) {
        // Показываем меню
        Console.WriteLine("\n ZOO MANAGEMENT MENU:\n" +
                              "1. Show all animals\n" +
                              "2. Find an animal by name\n" +
                              "3. Find an animal by name\n" +
                              "4. Add a new animal\n" +
                              "5. Log out\n");
                
        Console.Write("Select an action (1-5): ");

        string choice = Console.ReadLine();

        switch (choice) {
          case "1":
            zoo.ShowAllAnimals();
            break;

          case "2":
            Console.Write("Enter the name of the animal to search: ");
            string searchName = Console.ReadLine();
            zoo.FindAnimalByName(searchName);
            break;

          case "3":
            Console.Write("Enter animal number (1, 2, 3...): ");
            if (int.TryParse(Console.ReadLine(), out int animalNumber)) {
              zoo.ShowAnimalByIndex(animalNumber - 1); 
            }
            else {
              Console.WriteLine("Enter a number!");
            }
            break;

          case "4":
            AddNewAnimal(zoo);
            break;

          case "5":
            isRunning = false;
            Console.WriteLine("Goodbye! Come to the zoo again!");
            break;

          default:
            Console.WriteLine("Incorrect choice. Try again.");
            break;
        }

        if (isRunning) {
          Console.WriteLine("\nPress any key to continue...");
          Console.ReadKey();
          Console.Clear();
        }
      }
    }

    // Method for adding a new animal
    static void AddNewAnimal(ZooManager zoo) {
      Console.WriteLine("\n ADDING A NEW ANIMAL" +
                        "Select animal type:\n" +
                        "1. Mammal\n" +
                        "2. Bird\n" +
                        "3. Fish\n" +
                        "4. Reptile\n" +
                        "5. Amphibian\n");
      Console.WriteLine("Ваш выбор (1-5):\n");

      string type = Console.ReadLine();

      // General information for all animals
      Console.Write("Nickname: ");
      string name = Console.ReadLine();

      Console.Write("Age (years): ");
      int age = int.Parse(Console.ReadLine());

      Console.Write("Habitat (forest, water, desert, etc.): ");
      string habitat = Console.ReadLine();

      Console.Write("Diet type (carnivore, herbivore, omnivore): ");
      string foodType = Console.ReadLine();

      Console.Write("Weight (kg): ");
      double weight = double.Parse(Console.ReadLine());

      Console.Write("Color: ");
      string color = Console.ReadLine();
 
      // Create an animal of the required type with a unique property
      switch (type) {
        case "1": // Mammal
          Console.Write("Is there fur? (yes/no): ");
          bool hasFur = Console.ReadLine().ToLower() == "yes";
          zoo.AddAnimal(new Mammal(name, age, habitat, foodType, weight, color, hasFur));
          break;

        case "2": // Bird
          Console.Write("Wingspan (in meters, eg 0.5): ");
          double wingSpan = double.Parse(Console.ReadLine());
          zoo.AddAnimal(new Bird(name, age, habitat, foodType, weight, color, wingSpan));
          break;

        case "3": // Fish
          Console.Write("Water type (fresh/sea): ");
          string waterType = Console.ReadLine();
          zoo.AddAnimal(new Fish(name, age, habitat, foodType, weight, color, waterType));
          break;

        case "4": // Reptile
          Console.Write("Poisonous? (yes/no): ");
          bool isVenomous = Console.ReadLine().ToLower() == "yes";
          zoo.AddAnimal(new Reptile(name, age, habitat, foodType, weight, color, isVenomous));
          break;

        case "5": // Amphibian
          Console.Write("Skin moisture (0 - dry to 10 - very moist): ");
          int moisture = int.Parse(Console.ReadLine());
          zoo.AddAnimal(new Amphibian(name, age, habitat, foodType, weight, color, moisture));
          break;

        default:
          Console.WriteLine("Wrong type of animal");
          break;
      }
    }
  }
}