// See https://aka.ms/new-console-template for more information
int count = 0;
using (var stream = File.OpenText("input.txt"))
{
    var line = stream.ReadLine();
    int previousNumber = int.Parse(line);
    do
    {
        line = stream.ReadLine();
        if (string.IsNullOrEmpty(line))
            break;
        int currentNumber = int.Parse(line);
        if (currentNumber > previousNumber)
        {
            count++;
        }

        previousNumber = currentNumber;
    }
    while (!string.IsNullOrEmpty(line));
}
Console.WriteLine("result: {0}", count);
Console.ReadKey();
