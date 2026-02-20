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
      return $"Кличка: {Name}, Возраст: {Age} лет, " +
             $"Среда: {Habitat}, Питание: {FoodType}, " +
             $"Вес: {Weight} кг, Окрас: {Color}";
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