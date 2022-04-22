using Xunit;

public class Challenge2_TestingSite
{
    [Fact]
    public void CreateAnInstanceOf_Outing()
    {
        Outing outing = new Outing(OutingType.Golf, 10, "January 6th", 5.99, 10*5.99);

        string expectedDate = "January 6th";
        string actualDate = outing.Date;

        int expectedAttendance = 10;
        int actualAttendance = outing.Attendance;

        double expectedPrice = 5.99;
        double actualPrice = outing.CostPerPerson;
        
        double expectedTotalPrice = 59.9;
        double actualTotalPrice = outing.TotalCost;

        Assert.Equal(expectedDate, actualDate);
        Assert.Equal(expectedAttendance, actualAttendance);
        Assert.Equal(expectedPrice, actualPrice);
        Assert.Equal(expectedTotalPrice, actualTotalPrice);
    }
}