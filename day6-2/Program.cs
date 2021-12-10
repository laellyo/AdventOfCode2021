// See https://aka.ms/new-console-template for more information
using day6_2;

using (var stream = File.OpenText("input.txt"))
{
    int numberOfDays = 256;
    string currentTextLine = stream.ReadLine();
    var fishes = currentTextLine.Split(',');

    // Size of 7 because age start at 6 and finish at 0
    int[] numberOfFish = new int[9];
    for (int i = 0; i < 9; i++)
    {
        numberOfFish[i] = fishes.Count(x => int.Parse(x) == i);
    }
    FishGeneration generation = new FishGeneration(numberOfFish);


    Console.WriteLine("The number of fishes at the beginning of the world is {0}.", generation.TotalFish);

    for (int i = 1; i <= numberOfDays; i++)
    {
        generation.NewDayComing();
    }

    Console.WriteLine("The number of fishes after {0} days is {1}.", numberOfDays, generation.TotalFish);
    Console.ReadKey();
}


