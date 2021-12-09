using System;

public static class Helper
{
	public static List<string> CalculateOxygen(List<string> list, int index)
	{
        if(index >= 11)
        {
            return list;
        }

        bool is1TheMajorityBit = Is1TheMajorityBit(list, index);

        List<string> filteredList = new List<string>();
        foreach (var line in list)
        {
            var character = line[i].ToString();
            if((is1TheMajorityBit && character == '1') || (!is1TheMajorityBit && character == '0'))
            {
                filteredList.Add(line);
            }
        }

        var result = CalculateOxygen(filteredList, index++);
    }

	public static bool Is1TheMajorityBit(List<string> list, int index)
    {
        int bit_1 = 0;
        int bit_0 = 0;
        foreach (var line in list)
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
        }
        return bit_1 >= bit_0;
    }
}
