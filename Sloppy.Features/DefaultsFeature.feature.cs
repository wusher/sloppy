// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.6.0.0
//      SpecFlow Generator Version:1.6.0.0
//      Runtime Version:4.0.30319.1
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace Sloppy.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.6.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Option defualts")]
    public partial class OptionDefualtsFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "DefaultsFeature.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Option defualts", "In order to have default values if nothing was passed in \r\nAs a developer\r\nI want" +
                    " to be sure defaults are being set for missing values", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("option with value returns values")]
        public virtual void OptionWithValueReturnsValues()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("option with value returns values", ((string[])(null)));
#line 6
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "short",
                        "long",
                        "description",
                        "default"});
            table1.AddRow(new string[] {
                        "m",
                        "message",
                        "message",
                        "god loves ugly"});
#line 7
 testRunner.Given("I have the following option with a default param", ((string)(null)), table1);
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "args"});
            table2.AddRow(new string[] {
                        "--message"});
            table2.AddRow(new string[] {
                        "bad clown, sad summmer"});
#line 10
 testRunner.When("I pass in the arguments", ((string)(null)), table2);
#line 14
 testRunner.Then("the property message should return \"bad clown, sad summmer\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("option without a value returns the default")]
        public virtual void OptionWithoutAValueReturnsTheDefault()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("option without a value returns the default", ((string[])(null)));
#line 16
this.ScenarioSetup(scenarioInfo);
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "short",
                        "long",
                        "description",
                        "default"});
            table3.AddRow(new string[] {
                        "m",
                        "message",
                        "message",
                        "god loves ugly"});
            table3.AddRow(new string[] {
                        "v",
                        "verbose",
                        "verbose",
                        "true"});
#line 17
 testRunner.Given("I have the following option with a default param", ((string)(null)), table3);
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "args"});
            table4.AddRow(new string[] {
                        "--verbose"});
#line 21
 testRunner.When("I pass in the arguments", ((string)(null)), table4);
#line 24
 testRunner.Then("the property message should return \"god loves ugly\"");
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion