// See https://aka.ms/new-console-template for more information
int x = 0;
int y = 0;
int aim = 0;


using (var stream = File.OpenText("input.txt"))
{
    var line = stream.ReadLine();
    if (string.IsNullOrEmpty(line))
        return;

    do
    {
        var move = line.Split(" ");
        if (move.Length < 2)
            break;
        int length = int.Parse(move[1]);
        switch (move[0])
        {
            case "up":
                aim = (aim - length) < 0 ? 0 : aim - length;
                break;
            case "down":
                aim = aim + length;
                break;
            case "forward":
                x = x + length;
                y = y + (aim * length);
                break;
            default:
                break;
        }
        line = stream.ReadLine();

    }
    while (!string.IsNullOrEmpty(line));
}

Console.WriteLine("result: {0}", x * y);
Console.ReadKey();
