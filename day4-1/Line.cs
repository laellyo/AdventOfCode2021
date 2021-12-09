using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day4_1
{
    internal class Line
    {
        public int? Case1 { get; internal set; }
        public int? Case2 { get; internal set; }
        public int? Case3 { get; internal set; }
        public int? Case4 { get; internal set; }
        public int? Case5 { get; internal set; }

        public Line(string raw_line)
        {
            if (string.IsNullOrEmpty(raw_line))
                throw new ArgumentNullException("raw_line");
            var numbers = raw_line.Split(' ');
            if (numbers.Length < 5)
                throw new ArgumentException("raw_line");

            int index= 0;
            foreach (var number in numbers)
            {
                if (string.IsNullOrEmpty(number))
                    continue;
                switch (index)
                {
                    case 0:
                        Case1 = int.Parse(number);
                        break;
                    case 1:
                        Case2 = int.Parse(number);
                        break;
                    case 2:
                        Case3 = int.Parse(number);
                        break;
                    case 3:
                        Case4 = int.Parse(number);
                        break;
                    case 4:
                        Case5 = int.Parse(number);
                        break;
                    default:
                        break;
                }

                index++;
            }
        }

        public int SumUnmarkedNumbers()
        {
            return (Case1.HasValue ? Case1.Value : 0)
                + (Case2.HasValue ? Case2.Value : 0)
                + (Case3.HasValue ? Case3.Value : 0)
                + (Case4.HasValue ? Case4.Value : 0)
                + (Case5.HasValue ? Case5.Value : 0);
        }

        public bool FlagNumber(int number)
        {
            if(Case1 == number) 
                Case1 = null;
            if (Case2 == number)
                Case2 = null;
            if (Case3 == number)
                Case3 = null;
            if (Case4 == number)
                Case4 = null;
            if (Case5 == number)
                Case5 = null;

            if(Case1 == null && Case2 == null && Case3 == null && Case4 == null && Case5 == null)
            {
                return true;
            }

            return false;
        }

    }
}
