using System;

namespace JurassicPark
{
    class Dinosaur
    {
        public string Name { get; set; }
        public string DietType { get; set; }
        public DateTime WhenAcquired { get; set; }
        public double Weight { get; set; }
        public int EnclosureNumber { get; set; }

        public void Description()
        {
            Console.WriteLine($"{Name}: {DietType}, {Weight} pounds, enclosure #{EnclosureNumber}. Acquired on {WhenAcquired}");
        }

    }
}
