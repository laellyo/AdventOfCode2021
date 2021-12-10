// See https://aka.ms/new-console-template for more information


Dictionary<double, double> crabePositions = new Dictionary<double, double>();
using (var stream = File.OpenText("input.txt"))
{
    string currentTextLine = stream.ReadLine();
    var crabs = currentTextLine.Split(',');
    // Calculate the crab position statistics
    foreach (var crab in crabs)
    {
        var crabPosition = double.Parse(crab);
        if (crabePositions.ContainsKey(crabPosition))
        {
            crabePositions[crabPosition]++;
        }
        else
            crabePositions.Add(crabPosition, 1);
    }

    Console.WriteLine("Number of positions: {0}", crabePositions.Count);

    // Dictionary<position,fuel consumption>
    Dictionary<double, double> fuelConsumptionPerPosition = new Dictionary<double, double>();
    double fuelConsumption = 0;
    for (int p = 0; p < crabePositions.Sum(c => c.Value); p++)
    {
        fuelConsumptionPerPosition[p] =  crabePositions.Sum(c => Math.Abs((int)c.Key - p) * c.Value);
        if (fuelConsumption == 0 || fuelConsumption > fuelConsumptionPerPosition[p])
            fuelConsumption = fuelConsumptionPerPosition[p];
    }
    var result = fuelConsumptionPerPosition.First(f => f.Value == fuelConsumption);
    Console.WriteLine("The best position is {0}, total fuel {1}", result.Key, result.Value) ;
    Console.ReadKey();
}
