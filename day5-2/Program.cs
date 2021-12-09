// See https://aka.ms/new-console-template for more information
using day5_2;
using System.Text.RegularExpressions;

Diagram diagram = new Diagram(1000,1000);
Regex regex = new Regex(@"^(?<x1>[0-9]+),(?<y1>[0-9]+)\s->\s(?<x2>[0-9]+),(?<y2>[0-9]+)$");
List<Line> lines = new List<Line>();

using (var stream = File.OpenText("input.txt"))
{
    string currentTextLine = stream.ReadLine();
    while(!string.IsNullOrEmpty(currentTextLine))
    {

        var match = regex.Match(currentTextLine);
        if (match.Success)
        {
            string x1 = match.Groups["x1"].Value;
            string y1 = match.Groups["y1"].Value;
            string x2 = match.Groups["x2"].Value;
            string y2 = match.Groups["y2"].Value;

            Line line = new Line(diagram, int.Parse(x1), int.Parse(y1), int.Parse(x2), int.Parse(y2));
            lines.Add(line);
        }
        else
        {
            Console.WriteLine("Impossible to parse the line {0}", currentTextLine);
        }
        currentTextLine = stream.ReadLine();
    }

    diagram.AnalyzeDiagram(lines);

    int result = diagram.CalculateDangerousArea();

    Console.WriteLine("The dangerous area weight is {0}", result);
    Console.ReadKey();
}


