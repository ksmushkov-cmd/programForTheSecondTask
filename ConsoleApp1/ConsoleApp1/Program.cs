using System;
using System.Collections.Generic;

namespace ZooProject {
  // BASIC CLASS Animal 
  abstract class Animal {

    public string Name { get; set; }            // Nickname
    public int Age { get; set; }                // Age
    public string Habitat { get; set; }         // Where it lives (forest, water, desert)
    public string FoodType { get; set; }        // What does it eat(predator, herbivore)
    public double Weight { get; set; }          // Weight in kilogram
    public string Color { get; set; }           // Color

    public Animal(string name, int age, string habitat, string foodType, double weight, string color) {
      Name = name;
      Age = age;
      Habitat = habitat;
      FoodType = foodType;
      Weight = weight;
      Color = color;
    }

    public virtual string GetInfo() {
      return $"Nickname: {Name}, Age: {Age} years, " +
             $"Habitat: {Habitat}, Nutrition: {FoodType}, " +
             $"Weight: {Weight} kg, Color: {Color}";
    }
  }

  class Mammal : Animal {
    // A unique property for mammals: do they have fur
    public bool HasFur { get; set; }

    public Mammal(string name, int age, string habitat, string foodType, double weight, string color, bool hasFur)
      : base(name, age, habitat, foodType, weight, color) {
            HasFur = hasFur;
    }

    public override string GetInfo() {
      string furInfo = HasFur ? "there is wool" : "there is no wool";
      return base.GetInfo() + $", Type: Mammal, {furInfo}";
    }
  }

  class Bird : Animal {
    
    public double WingSpan { get; set; } // in meters

    public Bird(string name, int age, string habitat, string foodType, double weight, string color, double wingSpan)
      : base(name, age, habitat, foodType, weight, color) {
      WingSpan = wingSpan;
    }

    public override string GetInfo() {
      return base.GetInfo() + $", Type: Bird, Wingspan: {WingSpan} m";
    }
  }

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

  class Amphibian : Animal {
    // Unique property -skin moisture(from 0 to 10)
    public int SkinMoisture { get; set; } // 0 - dry, 10 - very wet

    public Amphibian(string name, int age, string habitat, string foodType, double weight, string color, int skinMoisture)
      : base(name, age, habitat, foodType, weight, color) {
      SkinMoisture = skinMoisture;
    }

    public override string GetInfo() {
      string moistureLevel;
      int limitOne, limitTwo; 
      limitOne = 3;
      limitTwo = 7;
      if (SkinMoisture < limitOne) {
        moistureLevel = "dry";
      }
      else if (SkinMoisture < limitTwo) {
        moistureLevel = "normal";
      }
      else {
        moistureLevel = "wet";
      }

      return $"Moisture level: {moistureLevel}";
    }
  }

  class ZooManager {
   
    private static ZooManager _instance;
    private List<Animal> animals = new List<Animal>();
    
    private ZooManager() {
      // Let's add a few animals right away as an example.    
      AddSampleAnimals();
    }
       
    public static ZooManager Instance {
      get {
                        
        if (_instance == null) {
           _instance = new ZooManager();
        }

        return _instance;
      }
    }

    private void AddSampleAnimals() {
      animals.Add(new Mammal("Leo", 5, "savannah", "predator", 150, "golden", true));
      animals.Add(new Bird("Kesha", 2, "forest", "omnivore", 0.5, "motley", 0.3));
      animals.Add(new Fish("Nemo", 1, "ocean", "predator", 0.1, "orange", "maritime"));
      animals.Add(new Reptile("Zmeyka", 3, "desert", "predator", 2, "green", true));
      animals.Add(new Amphibian("Kvak", 2, "swamp", "insects", 0.3, "green", 8));
    }

    
    public void AddAnimal(Animal animal) {
      animals.Add(animal);
      Console.WriteLine($"Animal {animal.Name} successfully added to the zoo!");
    }

    
    public void ShowAllAnimals() {
      if (animals.Count == 0) {
        Console.WriteLine("There are no animals in the zoo yet.");
        return;
      }

      Console.WriteLine("\n========== OUR ZOO ==========");
      for (int animalCounter = 0; animalCounter < animals.Count; ++animalCounter) {
        Console.WriteLine($"\n--- Animal #{animalCounter + 1} ---");
        Console.WriteLine(animals[animalCounter].GetInfo());
      }
      Console.WriteLine($"\nTotal animals: {animals.Count}");

    }

    
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

   
    public void ShowAnimalByIndex(int animalIndex) {
      if (animalIndex < 0 || animalIndex >= animals.Count) {
        Console.WriteLine("Неправильный номер животного");
        return;
      }

      Console.WriteLine($"\nЖивотное #{animalIndex + 1}:");
      Console.WriteLine(animals[animalIndex].GetInfo());
    }
  }

  class Program {
    static void Main(string[] args) {
      Console.WriteLine(" WELCOME TO THE ELECTRONIC ZOO!");

      // We get the only zookeeper    
      ZooManager zoo = ZooManager.Instance;

      bool isRunning = true;

      while (isRunning) {
        
        Console.WriteLine("\n ZOO MANAGEMENT MENU:\n" +
                          "1. Show all animals\n" +
                          "2. Find an animal by name\n" +
                          "3. Find an animal by index\n" +
                          "4. Add a new animal\n" +
                          "5. Log out\n");
                
        Console.Write("Select an action (1-5): ");

        string choice;
        choice = Console.ReadLine();

        switch (choice) {
          case "1":
            zoo.ShowAllAnimals();
            break;

          case "2":
            Console.Write("Enter the name of the animal to search: ");
            string searchName;
            searchName = Console.ReadLine();
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

    static void AddNewAnimal(ZooManager zoo) {
      Console.WriteLine("\n ADDING A NEW ANIMAL\n" +
                        "Select animal type:\n" +
                        "1. Mammal\n" +
                        "2. Bird\n" +
                        "3. Fish\n" +
                        "4. Reptile\n" +
                        "5. Amphibian\n");
      Console.Write("Your choice (1-5):");

      string type;
      type = Console.ReadLine();

      // General information for all animals
      Console.Write("Nickname: ");
      string name;
      name = Console.ReadLine();

      Console.Write("Age (years): ");
      int age;
      age = int.Parse(Console.ReadLine());
 
      Console.Write("Habitat (forest, water, desert, etc.): ");
      string habitat;
      habitat = Console.ReadLine();

      Console.Write("Diet type (carnivore, herbivore, omnivore): ");
      string foodType;
      foodType = Console.ReadLine();

      Console.Write("Weight (kg): ");
      double weight;
      weight = double.Parse(Console.ReadLine());

      Console.Write("Color: ");
      string color;
      color = Console.ReadLine();
 
      // Create an animal of the required type with a unique property
      switch (type) {

        case "1": // Mammal
          Console.Write("Is there fur? (yes/no): ");
          string furInput = Console.ReadLine().ToLower();

          while (furInput != "yes" && furInput != "no") {
            Console.Write("Please enter 'yes' or 'no': ");
            furInput = Console.ReadLine().ToLower();
          }

          bool hasFur;
          hasFur = furInput == "yes";
          break;

        case "2": // Bird
          Console.Write("Wingspan (in meters, eg 0.5): ");
          double wingSpan;
          wingSpan = double.Parse(Console.ReadLine());
          zoo.AddAnimal(new Bird(name, age, habitat, foodType, weight, color, wingSpan));
          break;

        case "3": // Fish
          Console.Write("Water type (fresh/sea): ");
          string waterType;
          waterType = Console.ReadLine();
          zoo.AddAnimal(new Fish(name, age, habitat, foodType, weight, color, waterType));
          break;

        case "4": // Reptile
          Console.Write("Poisonous? (yes/no): ");
          string input;
          input = Console.ReadLine().ToLower();

          while (input != "yes" && input != "no") {
            Console.Write("Please enter 'yes' or 'no': ");
            input = Console.ReadLine().ToLower();
          }

          bool isVenomous;
          isVenomous = input == "yes";
          break;

      case "5": // Amphibian
        Console.Write("Skin moisture (0 - dry to 10 - very moist): ");
        int moisture;
        moisture = int.Parse(Console.ReadLine());
                    
        int limitMoistureOne, limitMoistureTwo;
        limitMoistureOne = 0;
        limitMoistureTwo = 10;
        while (moisture < limitMoistureOne || moisture > limitMoistureTwo) {
          Console.Write("Number out of range. Please enter a number between 0 and 10: ");
          moisture = int.Parse(Console.ReadLine());
        }
        break;

      default:
        Console.WriteLine("Wrong type of animal");
        break;
      }
    }
  }
}