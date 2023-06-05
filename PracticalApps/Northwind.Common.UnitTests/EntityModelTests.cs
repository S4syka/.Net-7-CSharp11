using Packt.Shared;

namespace Northwind.Common.UnitTests;

public class EntityModelTests
{
    [Fact]
    public void DatabaseConnectTest()
    {
        using(NorthwindContext db = new())
        {
            Assert.True(db.Database.CanConnect());
        }
    }

    [Fact]
    public void CategoryUnitTest()
    {
        using(NorthwindContext db = new())
        {
            int expected = 8;
            int actual = db.Categories.Count();

            Assert.Equal(expected, actual);
        }
    }
}