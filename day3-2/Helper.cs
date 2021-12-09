using System;

namespace day3
{
    public static class Helper
    {
        public static List<string> CalculateOxygen(List<string> list, int index)
        {
            if (index >= 12 || list.Count == 1)
            {
                return list;
            } 

            bool is1TheMajorityBit = Is1TheMajorityBit(list, index);

            List<string> filteredList = new List<string>();
            foreach (var line in list)
            {
                var character = line[index].ToString();
                if ((is1TheMajorityBit && character == "1") || (!is1TheMajorityBit && character == "0"))
                {
                    filteredList.Add(line);
                }
            }

            return CalculateOxygen(filteredList, ++index);
        }


        public static List<string> CalculateCO2(List<string> list, int index)
        {
            if (index >= 12 || list.Count == 1)
            {
                return list;
            }

            bool is1TheMajorityBit = Is1TheMajorityBit(list, index);

            List<string> filteredList = new List<string>();
            foreach (var line in list)
            {
                var character = line[index].ToString();
                if ((is1TheMajorityBit && character == "0") || (!is1TheMajorityBit && character == "1"))
                {
                    filteredList.Add(line);
                }
            }

            return CalculateCO2(filteredList, ++index);
        }

        public static bool Is1TheMajorityBit(List<string> list, int index)
        {
            int bit_1 = 0;
            int bit_0 = 0;
            foreach (var line in list)
            {
                var character = line[index].ToString();
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
            }
            return bit_1 >= bit_0;
        }
    }
}
