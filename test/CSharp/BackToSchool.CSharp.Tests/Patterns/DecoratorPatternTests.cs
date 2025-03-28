using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using static BackToSchool.CSharp.Patterns.DecoratorPattern;

namespace BackToSchool.CSharp.Tests.Patterns
{
    public class DecoratorPatternTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public DecoratorPatternTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void Test()
        {
            // Usage
            ICoffee coffee = new SimpleCoffee();
            coffee = new MilkDecorator(coffee);
            coffee = new SugarDecorator(coffee);

            _outputHelper.WriteLine($"{coffee.GetDescription()} costs ${coffee.GetCost()}");
            // Output: "Simple coffee, milk, sugar costs $1.7"
        }
    }
}
