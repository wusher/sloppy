using System;
using NUnit.Framework;
using Should.Fluent;

namespace Sloppy.Tests
{
	[TestFixture]
	public class SlopBuilderTests
	{
		/// <summary>
		/// Option
		/// Given TwoOptions
		/// Expect TwoOptionsAreCreated
		/// </summary>
		[Test]
		public void Option_TwoOptions_TwoOptionsAreCreated()
		{
			//arrange
			//act
			Slop result = Slop.New()
								.Option('a', "apple", "apple description")
								.Option('b', "bat", "bat description");
			//assert
			result.Options.Count.Should().Equal(2);
		}

		/// <summary>
		/// Option
		/// Given Required
		/// Expect RequiredTrue
		/// </summary>
		[Test]
		public void Option_Required_RequiredTrue()
		{
			//arrange
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose", required: true);
			//assert
			result.Options[0].IsRequired.Should().Be.True();
		}

		/// <summary>
		/// Option
		/// Given NotSettingRequired
		/// Expect RequiredFalse
		/// </summary>
		[Test]
		public void Option_NotSettingRequired_RequiredFalse()
		{
			//arrange
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose");
			//assert
			result.Options[0].IsRequired.Should().Be.False();
		}

		/// <summary>
		/// Option
		/// Given Default
		/// Expect DefaultValueIsSet
		/// </summary>
		[Test]
		public void Option_Default_DefaultValueIsSet()
		{
			//arrange
			string defaultValue = "testvalue";
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose", defaultValue: defaultValue);
			//assert
			result.Options[0].Default.Should().Equal(defaultValue);
		}

		/// <summary>
		/// Option
		/// Given NoDefault
		/// Expect EmptyString
		/// </summary>
		[Test]
		public void Option_NoDefault_EmptyString()
		{
			//arrange
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose");
			//assert
			result.Options[0].Default.Should().Be.Null();
		}

		/// <summary>
		/// Option
		/// Given NoCallback
		/// Expect CallbackNull
		/// </summary>
		[Test]
		public void Option_NoCallback_CallbackNull()
		{
			//arrange
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose");
			//assert
			result.Options[0].Callback.Should().Be.Null();
		}

		/// <summary>
		/// Option
		/// Given Callback
		/// Expect CallbackNotNull
		/// </summary>
		[Test]
		public void Option_Callback_CallbackNotNull()
		{
			//arrange
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose", callback: x => Console.WriteLine(x));
			//assert
			result.Options[0].Callback.Should().Not.Be.Null();
		}

		/// <summary>
		/// Option
		/// Given Description
		/// Expect OneOptionWithDescription
		/// </summary>
		[Test]
		public void Option_Description_OneOptionWithDescription()
		{
			//arrange
			string description = "enable verbose mode";
			//act
			Slop result = Slop.New().Option('v', "verbose", description);
			//assert
			result.Options.Count.Should().Equal(1);
			result.Options[0].Description.Should().Equal(description);
		}

		/// <summary>
		/// Option
		/// Given LongName
		/// Expect OneOptionWithLongName
		/// </summary>
		[Test]
		public void Option_LongName_OneOptionWithLongName()
		{
			//arrange
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose mode");
			//assert
			result.Options.Count.Should().Equal(1);
			result.Options[0].LongName.Should().Equal("verbose");
		}

		/// <summary>
		/// Option
		/// Given ShortName
		/// Expect OneOptionWithShortName
		/// </summary>
		[Test]
		public void Option_ShortName_OneOptionWithShortName()
		{
			//arrange
			//act
			Slop result = Slop.New().Option('v', "verbose", "enable verbose mode");
			//assert
			result.Options.Count.Should().Equal(1);
			result.Options[0].ShortName.Should().Equal('v');
		}
	}
}