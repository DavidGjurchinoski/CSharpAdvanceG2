using Entities;

DogShelter.PrintAll();

DogShelter.ListOfDogs.ForEach(dog => Console.WriteLine(Dog.Validate(dog) ? "Dog Entered" : "Dog Not Entered"));