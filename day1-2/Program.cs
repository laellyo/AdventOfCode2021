// See https://aka.ms/new-console-template for more information
int count = 0;
using (var stream = File.OpenText("input.txt"))
{
    var line1 = stream.ReadLine();
    if (string.IsNullOrEmpty(line1))
        return;
    int line1Number = int.Parse(line1);

    var line2 = stream.ReadLine();
    if (string.IsNullOrEmpty(line2))
        return;
    int line2Number = int.Parse(line2);

    var line3 = stream.ReadLine();
    if (string.IsNullOrEmpty(line3))
        return;
    int line3Number = int.Parse(line3);

    int previousSum = line1Number + line2Number + line3Number;

    var line4 = string.Empty;
    do
    {

        line4 = stream.ReadLine();
        if (string.IsNullOrEmpty(line4))
            break; ;
        int line4Number = int.Parse(line4);

        int currentSum = line2Number + line3Number + line4Number;

        if (currentSum > previousSum)
        {
            count++;
        }

        line1Number = line2Number;
        line2Number = line3Number;
        line3Number = line4Number;
        previousSum = currentSum;
    }
    while (!string.IsNullOrEmpty(line4));
}
Console.WriteLine("result: {0}", count);
Console.ReadKey();
