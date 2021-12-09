using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_1
{
    internal class Game
    {
        private bool has_winner = false;
        public event EventHandler<RandomDraw> OnRandomDrawEvent;

        public List<Board> Boards { get; set; }

        public List<int> RandowDraws { get; set; }

        public Game(string randomDraws)
        {
            var order_numbers = randomDraws.Split(',');
            RandowDraws = new List<int>();
            foreach (var order in order_numbers)
            {
                RandowDraws.Add(int.Parse(order));
            }
        }

        public void LaunchGame(List<Board> boards)
        {
            foreach (var board in boards)
            {
                board.OnBingoEvent += Board_OnBingoEvent;
            }

            foreach (var number in RandowDraws)
            {
                if (has_winner)
                    break;
                if(OnRandomDrawEvent != null)
                {
                    OnRandomDrawEvent(this, new RandomDraw(number));
                }
            }

        }

        private void Board_OnBingoEvent(object? sender, Bingo e)
        {
            has_winner = true;
            Board winner = sender as Board;
            int score = winner.SumUnmarkedNumbers() * e.LastNumber;
            Console.WriteLine("We have a winner with score {0}!", score);
        }
    }
}
