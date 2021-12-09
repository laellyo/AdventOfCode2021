// See https://aka.ms/new-console-template for more information
using day4_1;

List<Board> boards = new List<Board>();

using (var stream = File.OpenText("input.txt"))
{
    var randowDraws = stream.ReadLine();

    // skip empty line
    var line = stream.ReadLine();

    var game = new Game(randowDraws);
    int index = 1;
    bool allBoardsCreated = false;
    // create boards
    do
    {
        var row_values = new string[5];  
        // A board contains 5 rows
        for (int i = 0; i < 5; i++)
        {
            line = stream.ReadLine();
            if (string.IsNullOrEmpty(line))
            {
                allBoardsCreated = true;
                break;
            }
            row_values[i] = line;
        }
        if (allBoardsCreated)
            break;

        var board = new Board(game, row_values, index);
        boards.Add(board);

        // skip empty line
        line = stream.ReadLine();
    }
    while (true);

    game.LaunchGame(boards);

    Console.ReadKey();

}