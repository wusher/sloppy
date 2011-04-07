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
		private Slop _slop;
		[BeforeScenario]
		public void CreateSlop()
		{
			_slop = Slop.New();
		}

		[Given(@"I have the following option")]
		public void GivenIHaveTheFollowingOption(Table table)
		{
			for (int i = 0; i < table.RowCount; i++)
			{
				TableRow currentRow = table.Rows[i];
				_slop.Option(currentRow["short"][0], currentRow["long"], currentRow["description"]);
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
			_arguments = _slop.Parse(args.ToArray());
		}

		[Then(@"the property (.*) should exist")]
		public void ThenThePropertyXShouleExist(string propertyName)
		{
			_arguments.HasProperty(propertyName).Should().Be.True();
		}

		[Then(@"the property (.*) should return (.*)")]
		public void ThenThePropertyXShouldReturnY(string propertyName, string value)
		{
			(_arguments.GetValue(propertyName)?? "<null>").ToString().Should().Equal(value);
		}

	}

}
