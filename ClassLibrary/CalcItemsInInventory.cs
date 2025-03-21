namespace ClassLibrary;

public class CalcItemsInInventory
{
    /// <summary>
    /// Calcs count of rooms in inventory
    /// </summary>
    /// <param name="s">String descriptor of inventory like "**|*|**|*"</param>
    /// <returns>Count of rooms</returns>
    public int CaclulateRooms(string s)
    {
        var result = 0;
        for (var i=0; i < s.Length; i++)
        {
            if (s[i] == '|') result++;
        }
        return result > 0 ? result-1 : 0;
    }

    /// <summary>
    /// Calcs count of items in inventory
    /// </summary>
    /// <param name="s">String descriptor of inventory like "**|*|**|*"</param>
    /// <param name="startIndecies"></param>
    /// <param name="endIndecies"></param>
    /// <returns>List of items</returns>
    public List<int> CaclulateItems(string s, List<int> startIndecies, List<int> endIndecies)
    {
        var result = new List<int>();
        for (var i=0; i < startIndecies.Count; i++)
        {
            var start = startIndecies[i];
            var end = endIndecies[i];

            var sum = 0;
            var tempSum = 0;
            var isStarted = false;
            for (var idx = start; idx < end; idx++)
            {
                if (s[idx] == '|')
                {
                    isStarted = true;
                    sum += tempSum;
                    tempSum = 0;
                    continue;
                }

                if (s[idx] == '*' && isStarted)
                    tempSum++;

            }
            result.Add(sum);
        }
        return result;
    }

}
