using NUnit.Framework;
using Should.Fluent;

namespace Sloppy.Tests
{
	[TestFixture]
	public class CommandStringExtensionsTests
	{
		/// <summary>
		/// IsLongCommand
		/// Given StringStartsWithTwoDashes
		/// Expect True
		/// </summary>
		[Test]
		public void IsLongCommand_StringStartsWithTwoDashes_True()
		{
			//arrange
			//act
			bool isLongCommand = "--longCommand".IsLongCommand();
			//assert
			isLongCommand.Should().Be.True();
		}

		/// <summary>
		/// IsLongCommand
		/// Given OneDash
		/// Expect False
		/// </summary>
		[Test]
		public void IsLongCommand_OneDash_False()
		{
			//arrange
			//act
			bool isLongCommand = "-notacommand".IsLongCommand();
			//assert
			isLongCommand.Should().Be.False();
		}

		/// <summary>
		/// IsLongCommand
		/// Given NoDashes
		/// Expect False
		/// </summary>
		[Test]
		public void IsLongCommand_NoDashes_False()
		{
			//arrange
			//act
			bool isLongCommand = "notacommand".IsLongCommand();
			//assert
			isLongCommand.Should().Be.False();
		}

		/// <summary>
		/// IsLongCommand
		/// Given EmptyString
		/// Expect False
		/// </summary>
		[Test]
		public void IsLongCommand_EmptyString_False()
		{
			//arrange
			//act
			bool isLongCommand = "".IsLongCommand();
			//assert
			isLongCommand.Should().Be.False();
		}

		/// <summary>
		/// IsShortCommand
		/// Given StringStartedWithTwoDashes
		/// Expect False
		/// </summary>
		[Test]
		public void IsShortCommand_StringStartedWithTwoDashes_False()
		{
			//arrange
			//act
			bool isShortCommand = "--longcommand".IsShortCommand();
			//assert
			isShortCommand.Should().Be.False();
		}

		/// <summary>
		/// IsShortCommand
		/// Given StringThatStartsWithOneDash
		/// Expect True
		/// </summary>
		[Test]
		public void IsShortCommand_StringThatStartsWithOneDash_True()
		{
			//arrange
			//act
			bool isShortCommand = "-s".IsShortCommand();
			//assert
			isShortCommand.Should().Be.True();
		}

		/// <summary>
		/// IsShortCommand
		/// Given EmptyString
		/// Expect False
		/// </summary>
		[Test]
		public void IsShortCommand_EmptyString_False()
		{
			//arrange
			//act
			bool isShortCommand = "".IsShortCommand();
			//assert
			isShortCommand.Should().Be.False();
		}
	}
}