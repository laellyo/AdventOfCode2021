using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_2
{
    internal class Game
    {
        private Dictionary<Board, int> winners;
        public event EventHandler<RandomDraw> OnRandomDrawEvent;

        public List<Board> Boards { get; set; }

        public List<int> RandowDraws { get; set; }

        public Game(string randomDraws)
        {
            winners = new Dictionary<Board, int>();    
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
                if(OnRandomDrawEvent != null)
                {
                    OnRandomDrawEvent(this, new RandomDraw(number));
                }
            }

            foreach (var winner in winners)
            {
                Console.WriteLine("We have a winner with score {0}!", winner.Value);
            }

        }

        private void Board_OnBingoEvent(object? sender, Bingo e)
        {
            Board winner = sender as Board;
            int score = winner.SumUnmarkedNumbers() * e.LastNumber;
            winners.Add(winner, score);
            // unsubsribe
            winner.OnBingoEvent -= Board_OnBingoEvent;
        }
    }
}
