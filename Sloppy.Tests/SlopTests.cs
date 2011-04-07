using NUnit.Framework;
using Should.Fluent;

namespace Sloppy.Tests
{
	[TestFixture]
	public class SlopTests
	{
		/// <summary>
		/// Parse
		/// Given RequiredOptionPassed
		/// Expect OptionInArguments
		/// </summary>
		[Test]
		public void Parse_RequiredOptionPassed_OptionInArguments()
		{
			//arrange
			_option1.IsRequired = true;
			_unitUnderTest.AddOption(_option1);
			//act
			dynamic args = _unitUnderTest.Parse(new string[2] { "--" + _option1.LongName, "value" });
			//assert
			((string)args.Apple).Should().Equal("value");
		}

		/// <summary>
		/// Parse
		/// Given IsRequiredButNotPassed
		/// Expect Exception
		/// </summary>
		[Test]
		[ExpectedException(typeof(RequiredArgumentMissingException))]
		public void Parse_IsRequiredButNotPassed_Exception()
		{
			//arrange
			_option1.IsRequired = true;
			_unitUnderTest.AddOption(_option1);
			//act
			_unitUnderTest.Parse(new string[0] { });
			//assert
		}

		/// <summary>
		/// Parse
		/// Given OptionHasDefaultButNoValue
		/// Expect DefaultIsSet
		/// </summary>
		[Test]
		public void Parse_OptionHasDefaultButNoValue_DefaultIsSet()
		{
			//arrange
			string defaultValue = "default";
			_option1.Default = defaultValue;
			_unitUnderTest.AddOption(_option1);
			//act
			dynamic parse = _unitUnderTest.Parse(new string[0] { });
			//assert
			string value = parse.Apple;
			value.Should().Equal(defaultValue);
		}

		/// <summary> 
		/// Parse 
		/// Given CallbackButNoValue 
		/// Expect CallBackCalled 
		/// </summary>
		[Test]
		public void Parse_CallbackButNoValue_CallBackCalled()
		{
			//arrange
			bool isCalledbackCalled = false;
			_option1.Callback = (x) => isCalledbackCalled = true;
			_unitUnderTest.AddOption(_option1);
			//act
			 _unitUnderTest.Parse(new string[1] { "-" + _option1.ShortName });
			//assert
			isCalledbackCalled.Should().Be.True();
		}
		/// <summary>
		/// Parse
		/// Given Callback
		/// Expect CallbackCalled
		/// </summary>
		[Test]
		public void Parse_Callback_CallbackCalled()
		{
			//arrange
			bool isCalledbackCalled = false;
			_option1.Callback = (x) => isCalledbackCalled = true;
			_unitUnderTest.AddOption(_option1);
			//act
			dynamic args = _unitUnderTest.Parse(new string[2] { "-" + _option1.ShortName, "value1" });
			//assert
			isCalledbackCalled.Should().Be.True();
		}

		/// <summary>
		/// Parse
		/// Given ShortKeyAndValueAndLongKeyAndValue
		/// Expect BothValuesAreAdded
		/// </summary>
		[Test]
		public void Parse_ShortKeyAndValueAndLongKeyAndValue_BothValuesAreAdded()
		{
			//arrange
			_unitUnderTest.AddOption(_option1);
			_unitUnderTest.AddOption(_option2);
			//act
			dynamic args = _unitUnderTest.Parse(new string[4] { "-" + _option1.ShortName, "value1", "--" + _option2.LongName, "value2" });
			//assert
			((string)args.Apple).Should().Equal("value1");
			((string)args.Bat).Should().Equal("value2");
		}

		/// <summary>
		/// Parse
		/// Given ShortKeyWIthValue
		/// Expect ValueAdded
		/// </summary>
		[Test]
		public void Parse_ShortKeyWIthValue_ValueAdded()
		{
			//arrange
			_unitUnderTest.AddOption(_option1);
			//act
			dynamic args = _unitUnderTest.Parse(new string[2] { "-" + _option1.ShortName, "value" });
			//assert
			((string)args.Apple).Should().Equal("value");
		}

		/// <summary>
		/// Parse
		/// Given ShortKeyFollowingShortKey
		/// Expect BothAreAdded
		/// </summary>
		[Test]
		public void Parse_ShortKeyFollowingShortKey_BothAreAdded()
		{
			//arrange
			_unitUnderTest.AddOption(_option1);
			_unitUnderTest.AddOption(_option2);
			//act
			dynamic args = _unitUnderTest.Parse(new string[2] { "-" + _option1.ShortName, "-" + _option2.ShortName });
			//assert
			((bool)args.HasApple).Should().Be.True();
			((bool)args.HasBat).Should().Be.True();
		}

		/// <summary>
		/// Parse
		/// Given ShortKeyDoesNotExist
		/// Expect Exception
		/// </summary>
		[Test]
		[ExpectedException(typeof(InvalidArgumentException))]
		public void Parse_ShortKeyDoesNotExist_Exception()
		{
			//arrange
			//act
			dynamic args = _unitUnderTest.Parse(new string[1] { "-z" });
			//assert
		}

		/// <summary>
		/// Parse
		/// Given ShortKey
		/// Expect ShortKeyAdded
		/// </summary>
		[Test]
		public void Parse_ShortKey_ShortKeyAdded()
		{
			//arrange
			_unitUnderTest.AddOption(_option1);
			//act
			dynamic args = _unitUnderTest.Parse(new string[1] { "-" + _option1.ShortName });
			//assert
			((bool)args.HasApple).Should().Be.True();
		}

		/// <summary>
		/// Parse
		/// Given LongKeyFollowedByLongKey
		/// Expect BothPropertiesAreCreated
		/// </summary>
		[Test]
		public void Parse_LongKeyFollowedByLongKey_BothPropertiesAreCreated()
		{
			//arrange
			_unitUnderTest.AddOption(_option1);
			_unitUnderTest.AddOption(_option2);
			//act
			dynamic args = _unitUnderTest.Parse(new string[2] { "--" + _option1.LongName, "--" + _option2.LongName });
			//assert
			((bool)args.HasApple).Should().Be.True();
			((bool)args.HasBat).Should().Be.True();
		}

		/// <summary>
		/// Parse
		/// Given LongKeyNoValue
		/// Expect ValueIsTrue
		/// </summary>
		[Test]
		public void Parse_LongKeyNoValue_ValueIsNull()
		{
			//arrange
			_unitUnderTest.AddOption(_option1);
			//act
			dynamic args = _unitUnderTest.Parse(new string[1] { "--" + _option1.LongName });
			//assert
			object value = args.Apple;
			value.Should().Be.Null();
		}

		/// <summary>
		/// Parse
		/// Given LongKeyAndValue
		/// Expect ArgsHasValue
		/// </summary>
		[Test]
		public void Parse_LongKeyAndValue_ArgsHasValue()
		{
			//arrange
			_unitUnderTest.AddOption(_option1);
			//act
			dynamic args = _unitUnderTest.Parse(new string[2] { "--" + _option1.LongName, "value" });
			//assert
			string value = args.Apple;
			value.Should().Equal("value");
		}

		/// <summary>
		/// Parse
		/// Given EmptyArray
		/// Expect ResultObject
		/// </summary>
		[Test]
		public void Parse_EmptyArray_Arguments()
		{
			//arrange
			//act
			Arguments args = _unitUnderTest.Parse(new string[0] { });
			//assert
			Assert.IsNotNull(args);
		}

		/// <summary>
		/// AddOption
		/// Given OptionsWithDuplicateLongName
		/// Expect Exception
		/// </summary>
		[Test, ExpectedException(typeof(DuplicateOptionException))]
		public void AddOption_OptionsWithDuplicateLongName_Exception()
		{
			_option2.LongName = _option1.LongName;
			_unitUnderTest.AddOption(_option1);
			//act
			_unitUnderTest.AddOption(_option2);
		}

		/// <summary>
		/// AddOption
		/// Given OptionWithDuplicateShortName
		/// Expect Exception </summary>
		[Test, ExpectedException(typeof(DuplicateOptionException))]
		public void AddOption_OptionWithDuplicateShortName_Exception()
		{
			//arrange
			_option2.ShortName = _option1.ShortName;
			_unitUnderTest.AddOption(_option1);
			//act
			_unitUnderTest.AddOption(_option2);
			//assert
		}

		/// <summary>
		/// AddOption
		/// Given UniqueOption
		/// Expect OptionAdded
		/// </summary>
		[Test]
		public void AddOption_UniqueOption_OptionAdded()
		{
			//arrange
			//act
			_unitUnderTest.AddOption(_option1);
			//assert
			_unitUnderTest.Options[0].Should().Equal(_option1);
		}

		private Slop _unitUnderTest;
		private Option _option1;
		private Option _option2;

		[SetUp]
		public void SetUp()
		{
			_option1 = new Option() { ShortName = 'a', LongName = "apple", Description = "description 1" };
			_option2 = new Option() { ShortName = 'b', LongName = "bat", Description = "description 2" };
			_unitUnderTest = Slop.New();
		}

		[TearDown]
		public void TearDown()
		{
			_unitUnderTest = null;
		}
	}
}