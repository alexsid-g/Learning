namespace ClassLibrary.Tests;

public class CalcItemsInInventoryFacts
{
    [Fact]
    public void Test_Indecies()
    {
        var calc = new CalcItemsInInventory();
        
        var result1 = calc.CaclulateItems("**|**|*", [1], [1]);
        Assert.Equal(1, result1.Count);

        var result2 = calc.CaclulateItems("**|**|*", [1, 3], [3, 6]);
        Assert.Equal(2, result2.Count);

        var result3 = calc.CaclulateItems("**|**|*", [1, 2, 3], [3, 5, 6]);
        Assert.Equal(3, result3.Count);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("***", 0)]
    [InlineData("***|**", 0)]
    [InlineData("***|**|*", 1)]
    [InlineData("***|**|*|", 2)]
    public void Test_Calculate_Rooms(string inventory, int roomsCount)
    {
        var calc = new CalcItemsInInventory();
        var result = calc.CaclulateRooms(inventory);

        Assert.Equal(result, roomsCount);
    }

    [Theory]
    [InlineData("", 0)]
    [InlineData("***", 0)]
    [InlineData("***|**", 0)]
    [InlineData("***|**|*", 2)]
    [InlineData("***|**|*|", 3)]
    public void Test_Calculate_Items(string inventory, int itemsCount)
    {
        var calc = new CalcItemsInInventory();
        var result = calc.CaclulateItems(inventory, [1], [inventory.Length]);

        Assert.Equal(result.Sum(), itemsCount);
    }
}