using NUnit.Framework;
using Should.Fluent;

namespace Sloppy.Tests
{
	[TestFixture]
	public class ArgumentsTests
	{
		/// <summary>
		/// GetProperty
		/// Given ValueIsBoolean
		/// Expect True
		/// </summary>
		[Test]
		public void GetProperty_ValueIsBoolean_True()
		{
			//arrange
			_unitUnderTest.Add("key", true);
			//act
			bool value = _unitUnderTest.Key;
			//assert
			value.Should().Be.True();
		}

		/// <summary>
		/// HasPropertyName
		/// Given PropertyNameBeginsWithHas
		/// Expect True
		/// </summary>
		[Test]
		public void HasPropertyName_PropertyNameBeginsWithHas_True()
		{
			//arrange
			_unitUnderTest.Add("hassle", "value");
			//act
			object value = _unitUnderTest.HasHassle;
			//assert
			value.Should().Equal(true);
		}

		/// <summary>
		/// PropertyGet
		/// Given PropertyNameBeginsWithHas
		/// Expect Value
		/// </summary>
		[Test]
		public void PropertyGet_PropertyNameBeginsWithHas_Value()
		{
			//arrange
			_unitUnderTest.Add("hassle", "value");
			//act
			object value = _unitUnderTest.Hassle;

			//assert
			value.ToString().Should().Equal("value");
		}

		/// <summary>
		/// HasPropertyName
		/// Given PropertyNotAdded
		/// Expect False
		/// </summary>
		[Test]
		public void HasPropertyName_PropertyNotAdded_False()
		{
			//arrange
			_unitUnderTest.Add("key", "value");
			//act
			bool exisits = _unitUnderTest.HasNope;
			//assert
			exisits.Should().Be.False();
		}

		/// <summary>
		/// HasPropertyName
		/// Given PropertyAdded
		/// Expect True
		/// </summary>
		[Test]
		public void HasPropertyName_PropertyAdded_True()
		{
			//arrange
			_unitUnderTest.Add("key", "value");
			//act
			bool exisits = _unitUnderTest.HasKey;
			//assert
			exisits.Should().Be.True();
		}

		/// <summary>
		/// HasProperty
		/// Given PropertyNotAdded
		/// Expect False
		/// </summary>
		[Test]
		public void HasProperty_PropertyNotAdded_False()
		{
			//arrange
			_unitUnderTest.Add("key", "value");
			//act
			bool exisits = _unitUnderTest.HasProperty("notkey");
			//assert
			exisits.Should().Be.False();
		}

		/// <summary>
		/// HasProperty
		/// Given PropertyAdded
		/// Expect ReturnsTrue
		/// </summary>
		[Test]
		public void HasProperty_PropertyAdded_ReturnsTrue()
		{
			//arrange
			_unitUnderTest.Add("key", "value");
			//act
			bool exisits = _unitUnderTest.HasProperty("key");
			//assert
			exisits.Should().Be.True();
		}

		/// <summary>
		/// Add
		/// Given PropertyAndValue
		/// Expect PropertyReturnsValue
		/// </summary>
		[Test]
		public void Add_PropertyAndValue_PropertyReturnsValue()
		{
			//arrange
			//act
			_unitUnderTest.Add("key", "value");
			//assert
			string key = _unitUnderTest.Key;
			key.Should().Equal("value");
		}

		private dynamic _unitUnderTest;
		private Option _option1;
		private Option _option2;

		[SetUp]
		public void SetUp()
		{
			_option1 = new Option() { ShortName = 'a', LongName = "apple", Description = "description 1" };
			_option2 = new Option() { ShortName = 'b', LongName = "bat", Description = "description 2" };
			_unitUnderTest = new Arguments();
		}

		[TearDown]
		public void TearDown()
		{
			_unitUnderTest = null;
		}
	}
}