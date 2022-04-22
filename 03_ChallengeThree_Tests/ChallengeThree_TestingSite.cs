using Xunit;

namespace _02_ChallengeTwo_Tests;

public class ChallengeThree_TestingSite
{
    [Fact]
    public void CreateAnInstanceOf_Customer()
    {
        Customers customer = new Customers("Jack", "Harris", CustomerType.Potential, "email");

        string expectedFirstName = "Jack";
        string actualFirstName = customer.FirstName;

        string expectedLastName = "Harris";
        string actualLastName = customer.LastName;

        string expectedEmail = "email";
        string actualEmail = customer.Email;

        Assert.Equal(expectedFirstName, actualFirstName);
        Assert.Equal(expectedLastName, actualLastName);
        Assert.Equal(expectedEmail, actualEmail);
    }
}