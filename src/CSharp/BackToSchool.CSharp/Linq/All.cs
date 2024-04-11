using System.Linq;

namespace BackToSchool.CSharp.Linq
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.all?view=net-8.0
    /// </summary>
    public class All
    {
        public bool AllPets()
        {
            // Create an array of Pets.
            Pet[] pets = { new Pet { Name="Barley", Age=10 },
                new Pet { Name="Boots", Age=4 },
                new Pet { Name="Whiskers", Age=6 } };

            // Determine whether all pet names
            // in the array start with 'B'.
            bool allStartWithB = pets.All(pet =>
                pet.Name.StartsWith("B"));

            return allStartWithB;
        }

        class Pet
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
