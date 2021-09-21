using System;
using Faust.PetShopApp.Core.IServices;
using Faust.PetShopApp.Core.Models;
using Faust.PetShopApp.Domain.Services;

namespace Faust.PetShopApp.UI
{
    public class Menu : IMenu
    {
        private IPetService _petService;
        private IPetTypeService _petTypeService;

        public Menu(IPetService petService, IPetTypeService petTypeService)
        {
            _petService = petService;
            _petTypeService = petTypeService;
        }

        public void StartUI()
        {
            ShowGreeting();
            DisplayMainMenu();
        }

        public string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }


        public void Print(string value)
        {
            Console.WriteLine(value);
        }

        public void PrintNewLine()
        {
            Console.WriteLine();
        }

        public void ShowGreeting()
        {
            Print(StringConstants.ShowWelcomeToAppText);
            PrintNewLine();
        }

        public void DisplayMainMenu()
        {
            ShowMainMenu();
            int choice;
            while ((choice = GetNumberSelection()) != 0)
            {
                if (choice == 1)
                {
                    Clear();
                    PrintShowAllPets();
                }

                if (choice == 2)
                {
                    PrintSearchPets();
                }

                if (choice == 3)
                {
                    PrintCreatePet();
                }

                if (choice == 4)
                {
                    PrintDeletePet();
                }

                if (choice == 5)
                {
                    PrintUpdatePet();
                }

                if (choice == 6)
                {
                    PrintSortedByPrice();
                }
                if (choice == 7)
                {
                    PrintTopFiveCheapestPets();
                }
                if (choice == -1)
                {
                    Print("Try again! ");
                }

                Console.ReadLine();
                Clear();
                ShowMainMenu();
            }
        }

        private void PrintTopFiveCheapestPets()
        {
            Print("Top Five Cheapest Pets: ");
            PrintNewLine();
            foreach (var pet in _petService.GetCheapestFivePets())
            {
                Print($"ID: {pet.Id} Name: {pet.Name} Type: {pet.Type.Name} Price: {pet.Price}");
            }
        }

        private void PrintSortedByPrice()
        {
            Print("Showing all pets sorted by price: ");
            PrintNewLine();
            foreach (var pet in _petService.GetPetsByPrice())
            {
                Print($"ID: {pet.Id} Name: {pet.Name} Type: {pet.Type.Name} Price: {pet.Price}");
            }
        }

        public int GetNumberSelection()
        {
            var choiceString = Console.ReadLine();
            int choice;
            if (int.TryParse(choiceString, out choice))
            {
                return choice;
            }

            return -1;
        }

        public void ShowMainMenu()
        {
            Print(StringConstants.ShowAllPetsMenuText);
            Print(StringConstants.SearchPetsMenuText);
            Print(StringConstants.CreateNewPetMenuText);
            Print(StringConstants.DeletePetMenuText);
            Print(StringConstants.UpdatePetMenuText);
            Print(StringConstants.SortedByPetsPriceTest);
            Print(StringConstants.ShowTopFiveCheapestPets);
            Print(StringConstants.ExitAppMenuText);
        }

        public void PrintShowAllPets()
        {
            Print("Showing all pets: ");
            PrintNewLine();
            foreach (var pet in _petService.GetPets())
            {
                Print($"ID: {pet.Id} Name: {pet.Name} Type: {pet.Type.Name}");
            }
        }

        public void PrintSearchPets()
        {
            string selection = AskQuestion("Search for pets, \nAvailable Options: type");
            Clear();
            if (selection == "type")
            {
                string availablePetTypes = _petTypeService.GetAvailableTypesString();
                string type = AskQuestion($"Enter Type: {availablePetTypes}");
                var foundPets = _petService.GetPetsByType(type);
                PrintNewLine();
                if (foundPets.Count > 0)
                {
                    PrintNewLine();
                    foreach (var pet in foundPets)
                    {
                        Print($"ID: {pet.Id} Name: {pet.Name} Type: {pet.Type.Name}");
                    }
                }
            }
        }

        public double AskForDouble(String displayQuestion)
        {
            double value;
            while (!Double.TryParse(AskQuestion(displayQuestion), out value))
            {
                Print("Wrong input, please enter double value");
            }

            return value;
        }

        public int AskForInt(String displayQuestion)
        {
            int value;
            while (!int.TryParse(AskQuestion(displayQuestion), out value))
            {
                Print("Wrong input, please enter int value");
            }

            return value;
        }

        public void PrintCreatePet()
        {
            Print("Create a new Pet");
            string name = AskQuestion("Enter pet name:");
            string availablePetTypes = _petTypeService.GetAvailableTypesString();
            PetType petType;
            while ((petType = _petTypeService.Find(AskQuestion($"Enter pet type: {availablePetTypes}"))) == null)
            {
                Print("Could not find the type!");
            }

            string color = AskQuestion("Enter pet color:");
            double price = AskForDouble("Enter Price:");
            var birthDate = new DateTime(AskForInt("Enter birth year:"), AskForInt("Enter birth month:"),
                AskForInt("Enter birth day:"));
            var soldDate = new DateTime(AskForInt("Enter sold year:"), AskForInt("Enter sold month:"),
                AskForInt("Enter sold day:"));
            //Pet pet = _petService.CreatePet(name, petType, birthDate, soldDate, color, price);
            //Print($"Pet was created with ID {pet.Id}Name {pet.Name} Type {pet.Type} Birth Date {pet.BirthDate} Sold Date {pet.SoldTime} Color {pet.Color} Price {pet.Price}");
        }

        public void PrintDeletePet()
        {
            int id = AskForInt("Type an ID of the pet you want to delete: ");
            Pet pet = _petService.DeletePet(id);
            if (pet != null)
            {
                Print($"Pet with ID: {pet.Id} has been deleted!");
            }
            else
            {
                Print($"Could not find a pet with ID: {id}");
            }
        }

        public void PrintUpdatePet()
        {
            int id = AskForInt("Type ID of the pet you want to update");
            Pet pet = _petService.Find(id);
            if (pet != null)
            {
                string selection =
                    AskQuestion(
                        "Which parameter do you want to update? \nAvailable Options: name, type, birth date, sold date, color, price");

                if (selection == "name")
                {
                    string name = AskQuestion("Enter pet name:");
                    pet.Name = name;
                    if (_petService.UpdatePet(pet) != null)
                    {
                        Print($"Pet with an ID: {pet.Id} has been updated!");
                    }
                }

                if (selection == "type")
                {
                    string availablePetTypes = _petTypeService.GetAvailableTypesString();
                    PetType petType;
                    while ((petType = _petTypeService.Find(AskQuestion($"Enter pet type: {availablePetTypes}"))) == null)
                    {
                        Print("Could not find the type!");
                    }

                    pet.Type = petType;
                    if (_petService.UpdatePet(pet) != null)
                    {
                        Print($"Pet with an ID: {pet.Id} has been updated!");
                    }
                }

                if (selection == "birth date")
                {
                    var birthDate = new DateTime(AskForInt("Enter birth year:"), AskForInt("Enter birth month:"),
                        AskForInt("Enter birth day:"));
                    pet.BirthDate = birthDate;
                    if (_petService.UpdatePet(pet) != null)
                    {
                        Print($"Pet with an ID: {pet.Id} has been updated!");
                    }
                }

                if (selection == "sold date")
                {
                    var soldDate = new DateTime(AskForInt("Enter sold year:"), AskForInt("Enter sold month:"),
                        AskForInt("Enter sold day:"));
                    pet.SoldTime = soldDate;
                    if (_petService.UpdatePet(pet) != null)
                    {
                        Print($"Pet with an ID: {pet.Id} has been updated!");
                    }
                }

                if (selection == "color")
                {
                    string color = AskQuestion("Enter pet color:");
                    //pet.Color = color;
                    if (_petService.UpdatePet(pet) != null)
                    {
                        Print($"Pet with an ID: {pet.Id} has been updated!");
                    }
                }

                if (selection == "price")
                {
                    double price = AskForDouble("Enter Price:");
                    pet.Price = price;
                    if (_petService.UpdatePet(pet) != null)
                    {
                        Print($"Pet with an ID: {pet.Id} has been updated!");
                    }
                }
            }

            else
            {
                Print("Could not find the pet");
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}