using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Reflection;
using Should.Fluent;

namespace Sloppy.Features.Steps
{
	[Binding]
	public class BasicOptionSteps
	{
		private Arguments _arguments;
		private string _callbackValue;
        private Exception _parseException;
		private bool _wasCallbackCalled;
        private Slop _slop;
		[BeforeScenario]
		public void CreateSlop()
		{
			_slop = Slop.New();
		}
[AfterScenario]
		public void ThrowParseExceptions()
		{
			if (_parseException != null)
				throw _parseException;

		}
[Given(@"I have the following option with a callback")]
public void GivenIHaveTheFollowingOptionWithACallback(Table table)
{
			for (int i = 0; i < table.RowCount; i++)
			{
				TableRow currentRow = table.Rows[i];
				_slop.Option(currentRow["short"][0], currentRow["long"], currentRow["description"], callback: (x) =>
				{
					_wasCallbackCalled = true;
					_callbackValue = x;
				});
			}
		}	[Given(@"I have the following option")]
		public void GivenIHaveTheFollowingOption(Table table)
		{
			for (int i = 0; i < table.RowCount; i++)
			{
				TableRow currentRow = table.Rows[i];
				_slop.Option(currentRow["short"][0], currentRow["long"], currentRow["description"]);
			}
		}
		[Given(@"I have the following option that is required")]
		public void GivenIHaveTheFollowingOptionThatIsRequired(Table table)
		{
			for (int i = 0; i < table.RowCount; i++)
			{
				TableRow currentRow = table.Rows[i];
				_slop.Option(currentRow["short"][0], currentRow["long"], currentRow["description"], required: true );
			}
		}

		[Given(@"I have the following option with a default param")]
		public void GivenIHaveTheFollowingOptionWithADefaultParam(Table table)
		{
			for (int i = 0; i < table.RowCount; i++)
			{
				TableRow currentRow = table.Rows[i];
				_slop.Option(currentRow["short"][0], currentRow["long"], currentRow["description"], defaultValue: currentRow["default"]);
			}
		}


		[When(@"I pass in the arguments")]
		public void WhenIPassInTheArguments(Table table)
		{
			List<string> args = new List<string>();
			for (int i = 0; i < table.RowCount; i++)
			{
				args.Add(table.Rows[i][0]);
			}
			try
			{
				_arguments = _slop.Parse(args.ToArray());
			}
			catch (Exception ex)
			{
				_parseException = ex;
			}
		}

		[Then(@"the property (.*) should exist")]
		public void ThenThePropertyXShouleExist(string propertyName)
		{
			_arguments.HasProperty(propertyName).Should().Be.True();
		}

		[Then(@"the property (.*) should return ""(.*)""")]
		public void ThenThePropertyXShouldReturnY(string propertyName, string value)
		{
			(_arguments.GetValue(propertyName) ?? "<null>").ToString().Should().Equal(value);
		}
		[Then(@"there should be an exception")]
		public void ThenThereShouldBeAnException()
		{
			(_parseException is RequiredArgumentMissingException).Should().Be.True();
			_parseException = null;
		}
		[Then(@"callback should be called")]
		public void ThenCallbackShouldBeCalled()
		{
			_wasCallbackCalled.Should().Be.True();
		}
		[Then(@"the value passed to the callback should be ""(.*)""")]
		public void ThenTheValuePassedToTheCallbackShouleBeX(string value )
		{
			(_callbackValue ?? "<null>").Should().Equal(value);
		}

	}

}
