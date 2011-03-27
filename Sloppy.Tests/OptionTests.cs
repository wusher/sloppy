using NUnit.Framework;

namespace Sloppy.Tests
{
	[TestFixture]
	public class OptionTests
	{
		private Option _unitUnderTest;

		[SetUp]
		public void SetUp()
		{
			_unitUnderTest = new Option();
		}

		[TearDown]
		public void TearDown()
		{
			_unitUnderTest = null;
		}
	}
}