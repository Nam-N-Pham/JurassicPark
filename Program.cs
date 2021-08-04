using System;
using System.Collections.Generic;
using System.Linq;

namespace JurassicPark
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Jurassic Park!");
            List<Dinosaur> dinosaurs = new List<Dinosaur>();

            bool runApp = true;
            while (runApp)
            {
                Console.WriteLine("What would you like to do? Type one of the following options: View, Add, Remove, Transfer, Summary, or Quit.");
                string option = Console.ReadLine().ToLower();

                switch (option)
                {
                    case "quit":
                        runApp = false;
                        break;

                    case "view":
                        if (dinosaurs.Count == 0)
                        {
                            Console.WriteLine("There are no dinosaurs.");
                        }
                        else
                        {
                            var dinosaursSorted = dinosaurs.OrderBy(dinosaur => dinosaur.WhenAcquired);
                            foreach (Dinosaur dinosaur in dinosaursSorted)
                            {
                                dinosaur.Description();
                            }
                        }
                        break;

                    case "add":
                        Console.WriteLine("Enter the information of the dinosaur you want to add.");
                        Dinosaur newDinosaur = new Dinosaur();

                        Console.Write("Name: ");
                        newDinosaur.Name = Console.ReadLine();
                        Console.Write("Diet Type: ");
                        newDinosaur.DietType = Console.ReadLine();
                        Console.Write("Weight: ");
                        newDinosaur.Weight = double.Parse(Console.ReadLine());
                        Console.Write("Enclosure number: ");
                        newDinosaur.EnclosureNumber = int.Parse(Console.ReadLine());

                        newDinosaur.WhenAcquired = DateTime.Now;

                        dinosaurs.Add(newDinosaur);
                        break;

                    case "remove":
                        Console.Write("Enter the name of the dinosaur you want to remove: ");
                        string nameOfDinoToRemove = Console.ReadLine();

                        Console.Write($"Are you sure you want to remove {nameOfDinoToRemove}? Enter yes or no: ");
                        string confirmRemove = Console.ReadLine().ToLower();

                        if (confirmRemove == "no")
                        {
                            break;
                        }
                        else
                        {
                            int indexOfDinoToRemove = dinosaurs.FindIndex(dinosaur => dinosaur.Name == nameOfDinoToRemove);
                            dinosaurs.RemoveAt(indexOfDinoToRemove);
                            break;
                        }

                    case "transfer":
                        Console.WriteLine("Enter the name of the dinosaur you want to transfer and the enclosure number you want to transfer it to.");
                        Console.Write("Name: ");
                        string transferName = Console.ReadLine();
                        Console.Write("Enclosure number: ");
                        int transferEnclosureNum = int.Parse(Console.ReadLine());

                        for (int index = 0; index < dinosaurs.Count(); index++)
                        {
                            if (dinosaurs[index].Name == transferName)
                            {
                                dinosaurs[index].EnclosureNumber = transferEnclosureNum;
                            }
                        }
                        break;

                    case "summary":
                        int numCarnivores = dinosaurs.Count(dinosaur => dinosaur.DietType == "carnivore");
                        int numHerbivores = dinosaurs.Count(dinosaur => dinosaur.DietType == "herbivore");

                        Console.WriteLine($"There are {numCarnivores} carnivore(s) and {numHerbivores} herbivore(s).");
                        break;

                    default:
                        Console.WriteLine("Only enter the provided options spelled correctly.");
                        break;
                }
            }
        }
    }
}
