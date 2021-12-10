// See https://aka.ms/new-console-template for more information
using day6_1;

using (var stream = File.OpenText("input.txt"))
{
    int numberOfDays = 80;
    string currentTextLine = stream.ReadLine();
    var fishes = currentTextLine.Split(',');

    World world = new World();
    List<Fish> initFishes = new List<Fish>();
    foreach (var f in fishes)
    {
        var fish = new Fish(world, int.Parse(f));
        initFishes.Add(fish);
    }
    Console.WriteLine("The number of fishes at the beginning of the world is {0}.", initFishes.Count);
    var result = world.CreateLife(numberOfDays, initFishes);

    Console.WriteLine("The number of fishes after {0} days is {1}.", numberOfDays, result);
    Console.ReadKey();
}


