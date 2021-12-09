using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_2
{
    internal class Board
    {
        public int Index { get; set; }

        public Line[] Rows { get; set; }

        public Line[] Columns { get; set; }

        public event EventHandler<Bingo> OnBingoEvent;

        public Board(Game game, string[] raw_data, int index)
        {
            if(raw_data == null)   
                throw new ArgumentNullException(nameof(raw_data));

            Index = index;
            Rows = new Line[5];
            Columns = new Line[5];

            // build rows
            for (int i = 0; i < 5; i++)
            {
                var row = new Line(raw_data[i]);
                Rows[i] = row;
            }


            var raw_column1 = string.Format("{0} {1} {2} {3} {4}", Rows[0].Case1, Rows[1].Case1, Rows[2].Case1, Rows[3].Case1, Rows[4].Case1);
            var raw_column2 = string.Format("{0} {1} {2} {3} {4}", Rows[0].Case2, Rows[1].Case2, Rows[2].Case2, Rows[3].Case2, Rows[4].Case2);
            var raw_column3 = string.Format("{0} {1} {2} {3} {4}", Rows[0].Case3, Rows[1].Case3, Rows[2].Case3, Rows[3].Case3, Rows[4].Case3);
            var raw_column4 = string.Format("{0} {1} {2} {3} {4}", Rows[0].Case4, Rows[1].Case4, Rows[2].Case4, Rows[3].Case4, Rows[4].Case4);
            var raw_column5 = string.Format("{0} {1} {2} {3} {4}", Rows[0].Case5, Rows[1].Case5, Rows[2].Case5, Rows[3].Case5, Rows[4].Case5);

            Columns[0] = new Line(raw_column1);
            Columns[1] = new Line(raw_column2);
            Columns[2] = new Line(raw_column3);
            Columns[3] = new Line(raw_column4);
            Columns[4] = new Line(raw_column5);

            game.OnRandomDrawEvent += OnRandomDrawEvent;
        }

        public int SumUnmarkedNumbers()
        {
            int sum = 0;
            foreach (var row in Rows)
            {
                sum += row.SumUnmarkedNumbers();
            }

            return sum;
        }

        private void OnRandomDrawEvent(object? sender, RandomDraw e)
        {
            //flag
            foreach (var row in Rows)
            {
                var bingo = row.FlagNumber(e.Number);
                if(bingo & OnBingoEvent != null)
                {
                    OnBingoEvent(this, new Bingo(e.Number));
                }
            }
            foreach (var column in Columns)
            {
                var bingo = column.FlagNumber(e.Number);
                if (bingo & OnBingoEvent != null)
                {
                    OnBingoEvent(this, new Bingo(e.Number));
                }
            }
        }
    }
}
