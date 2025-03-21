using System;

namespace ClassLibrary.Tests;

public class AutocompleteSuggesterFacts
{
    [Fact]
    public void Should_Be_Min_Two_Chars()
    {
        var repository = new List<string> { "a", "ab", "abc", "abe", "abcd", "abcde", "fff" };
        var service = new AutocompleteSuggester();
        
        var result = service.Suggests(repository, "a");
        Assert.Empty(result);

        var result2 = service.Suggests(repository, "ab");
        Assert.NotEmpty(result2);
    }

    [Fact]
    public void Should_Be_Max_Three_Words()
    {
        var repository = new List<string> { "a", "ab", "abc", "abe", "abcd", "abcde", "fff" };
        var service = new AutocompleteSuggester();
        
        // Min 2 chars in result
        var result = service.Suggests(repository, "a");
        Assert.Empty(result);
    }

    [Fact]
    public void Should_Work()
    {
        var repository = new List<string> { "a", "ab", "abc", "abe", "abcd", "abcde", "fff" };
        var service = new AutocompleteSuggester();
        
        var result = service.Suggests(repository, "abcdef");
        Assert.Equal(4, result.Count);

        Assert.Equal<string>(result[0], ["ab", "abc", "abcd",]);
        Assert.Equal<string>(result[1], ["abc", "abcd", "abcde"]);
        Assert.Equal<string>(result[2], ["abcd", "abcde"]);
        Assert.Equal<string>(result[3], ["abcde"]);
    }

    [Fact]
    public void Should_Work_Case_Insencitive()
    {
        var repository = new List<string> { "Abc", "abCd",  "abe", "ABcde", "fff" };
        var service = new AutocompleteSuggester();
        
        var result = service.Suggests(repository, "aBcDef");
        Assert.Equal(4, result.Count);

        Assert.Equal<string>(result[0], ["abc", "abcd", "abcde"]);
        Assert.Equal<string>(result[1], ["abc", "abcd", "abcde"]);
        Assert.Equal<string>(result[2], ["abcd", "abcde"]);
        Assert.Equal<string>(result[3], ["abcde"]);
    }
}
