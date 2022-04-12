using Entities;

DogShelter.PrintAll();

if (Dog.Validate(DogShelter.ListOfDogs[0])) Console.WriteLine("Dog Entered");
if (Dog.Validate(DogShelter.ListOfDogs[1])) Console.WriteLine("Dog Entered");
if (Dog.Validate(DogShelter.ListOfDogs[2])) Console.WriteLine("Dog Entered");
