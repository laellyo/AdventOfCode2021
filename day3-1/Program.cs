// See https://aka.ms/new-console-template for more information
string gamma = string.Empty;
string epsilon = string.Empty;

for (int i = 0; i < 12; i++)
{
    using (var stream = File.OpenText("input.txt"))
    {
        var line = stream.ReadLine();
        if (string.IsNullOrEmpty(line))
            return;
        int bit_1 = 0;
        int bit_0 = 0;
        do
        {
            var character = line[i].ToString();
            int bit = int.Parse(character);
            switch (bit)
            {
                case 0:
                    bit_0++;
                    break;
                case 1:
                    bit_1++;
                    break;
                default:
                    break;
            }
            line = stream.ReadLine();

        }
        while (!string.IsNullOrEmpty(line));

        if(bit_0 > bit_1)
        {
            gamma = gamma + '0';
        }
        else
        {
            gamma = gamma + '1';
        }
    }
}

Console.WriteLine("gamma (string): {0}", gamma);
foreach(var character in gamma)
{
    char bit = character == '0' ? '1' : '0';
    epsilon = epsilon + bit;
}
Console.WriteLine("epsilon (string): {0}", epsilon);

//string gammaBase2 = Convert.ToString(gamma, toBase: 2);
//string epsilonBase2 = Convert.ToString(epsilon, toBase: 2);
//Console.WriteLine("gamma (binary): {0}", gammaBase2);
//Console.WriteLine("epsilon (binary): {0}", epsilonBase2);

int gammaBase10 = Convert.ToInt32(gamma, 2);
int epsilonBase10 = Convert.ToInt32(epsilon, 2);
Console.WriteLine("gamma (base 10): {0}", gammaBase10);
Console.WriteLine("epsilon (base 10): {0}", epsilonBase10);

var result = gammaBase10 * epsilonBase10;
Console.WriteLine("result: {0}", result);

Console.ReadKey();
