namespace CSD_268_Final_Part_1;

public class DriverTests
{

	Driver driver;

	[SetUp]
    public void Setup()
    {
		driver = new Driver ();
    }

	[Test]
	public void TestMinInt ()
	{
		Assert.AreEqual (driver.CanDrive (int.MinValue), false);
	}

	[Test]
	public void TestMinIntPlusOne ()
	{
		Assert.AreEqual (driver.CanDrive (int.MinValue + 1), false);
	}

	[Test]
    public void Test15()
    {
        Assert.AreEqual(driver.CanDrive(15),false);
    }

	[Test]
	public void Test16 ()
	{
		Assert.AreEqual (driver.CanDrive (16), true);
	}

	[Test]
	public void Test17 ()
	{
		Assert.AreEqual (driver.CanDrive (17), true);
	}

	[Test]
	public void TestMaxIntMinusOne ()
	{
		Assert.AreEqual (driver.CanDrive (int.MaxValue - 1), true);
	}

	[Test]
	public void TestMaxInt ()
	{
		Assert.AreEqual (driver.CanDrive (int.MaxValue), true);
	}

}
