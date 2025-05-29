namespace CSD_268_Final_Part_1;

public class DriverTests
{

	DMV dmv;

	[SetUp]
    public void Setup()
    {
		dmv = new DMV ();
    }

	[Test]
	public void TestMinInt ()
	{
		Assert.AreEqual (dmv.CanDrive (int.MinValue), false);
	}

	[Test]
	public void TestMinIntPlusOne ()
	{
		Assert.AreEqual (dmv.CanDrive (int.MinValue + 1), false);
	}

	[Test]
    public void Test15()
    {
        Assert.AreEqual(dmv.CanDrive(15),false);
    }

	[Test]
	public void Test16 ()
	{
		Assert.AreEqual (dmv.CanDrive (16), true);
	}

	[Test]
	public void Test17 ()
	{
		Assert.AreEqual (dmv.CanDrive (17), true);
	}

	[Test]
	public void TestMaxIntMinusOne ()
	{
		Assert.AreEqual (dmv.CanDrive (int.MaxValue - 1), true);
	}

	[Test]
	public void TestMaxInt ()
	{
		Assert.AreEqual (dmv.CanDrive (int.MaxValue), true);
	}

}
