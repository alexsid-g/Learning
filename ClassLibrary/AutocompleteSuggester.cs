using System;

namespace ClassLibrary.Tests;

public class AutocompleteSuggester
{
    public const int MinValueLength = 2;        
    public const int MaxSuggestCount = 3;
    
    public List<List<string>> Suggests(List<string> repository, string value)
    {
        var lowerValue = value.ToLower();
        var data = repository.Where(x => x.Length >= MinValueLength)
            .Select(x => x.ToLowerInvariant())
            .Order()
            .ToList();

        var result = new List<List<string>>();
        for (var i = MinValueLength; i <= lowerValue.Length; i++)
        {
            var start = lowerValue.Substring(0, i);
            var oneStepResult = new List<string>();
            foreach (var item in data)
            {
                if (oneStepResult.Count < MaxSuggestCount)
                    if (item.StartsWith(start))
                        oneStepResult.Add(item);
            }

            if (oneStepResult.Count == 0) break;
            result.Add(oneStepResult);
        }
        return result;
    }

}
