Author 
Kirill Smushkov (variant: none) 
"Electronic Zoo" Program

A C# console app for zoo management that lets you create and manage different animals through an interactive menu.

Animal Classes
Animal (base abstract class) - common properties for all animals:
· Name, Age, Habitat, FoodType, Weight, Color
Animal types:
· Mammal - adds HasFur (fur presence)
· Bird - adds WingSpan (wingspan in meters)
· Fish - adds WaterType (fresh/sea water)
· Reptile - adds IsVenomous (poisonous or not)
· Amphibian - adds SkinMoisture (0-dry to 10-wet)

GetInfo() Method
Each animal displays its info:
· Base class shows common info
· Each type adds its specific properties

ZooManager (Singleton)
Only one instance exists. Manages a List<Animal> with methods:
· AddAnimal() - add new animal
· ShowAllAnimals() - display all animals
· FindAnimalByName() - search by name
· ShowAnimalByIndex() - show by number
· ShowMenu() - display menu options

Starts with 5 sample animals.

Program Class (User Interface)
Main() method runs the program loop:
Menu options:
1. Show all animals
2. Find animal by name
3. Find animal by index
4. Add new animal
5. Exit
Adding New Animals
Process:
1. Select animal type (1-5)
2. Enter common data: name, age, habitat, diet, weight, color
3. Enter type-specific data:
   · Mammals: has fur? (yes/no)
   · Birds: wingspan (meters)
   · Fish: water type (fresh/sea)
   · Reptiles: poisonous? (yes/no)
   · Amphibians: skin moisture (0-10)
4. Animal is created and added to zoo

Program Flow
Start → Menu → User selects option → Action performed → Press key to continue → Back to menu → Exit (option 5)
This app demonstrates OOP concepts: inheritance, polymorphism, encapsulation, and Singleton pattern.
