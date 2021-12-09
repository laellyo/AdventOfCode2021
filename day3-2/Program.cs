// See https://aka.ms/new-console-template for more information
using day3;

List<string> content = new List<string>();

using (var stream = File.OpenText("input.txt"))
{
    var line = stream.ReadLine();
    do
    {
        if(string.IsNullOrEmpty(line))
        {
            break;
        }
        content.Add(line);
        line = stream.ReadLine();
    }
    while (!string.IsNullOrEmpty(line));

}

var oxygen = Helper.CalculateOxygen(content, 0);
Console.WriteLine("oxygen: length {0}, value {1}", oxygen.Count, oxygen[0]);

var co2 = Helper.CalculateCO2(content, 0);
Console.WriteLine("co2: length {0}, value {1}", co2.Count, co2[0]);

int oxygen10 = Convert.ToInt32(oxygen[0], 2);
int co2Base10 = Convert.ToInt32(co2[0], 2);
Console.WriteLine("oxygen (base 10): {0}", oxygen10);
Console.WriteLine("co2 (base 10): {0}", co2Base10);

var result = oxygen10 * co2Base10;
Console.WriteLine("result: {0}", result);

Console.ReadKey();