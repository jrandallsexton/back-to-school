using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static BackToSchool.CSharp.Patterns.DecoratorPattern;

namespace BackToSchool.CSharp.Patterns
{
    public class DecoratorPattern
    {
        // Component interface
        public interface ICoffee
        {
            string GetDescription();
            double GetCost();
        }

        // Concrete component
        public class SimpleCoffee : ICoffee
        {
            public string GetDescription() => "Simple coffee";
            public double GetCost() => 1.0;
        }

        // Decorator base
        public abstract class CoffeeDecorator : ICoffee
        {
            protected ICoffee _coffee;
            public CoffeeDecorator(ICoffee coffee) => _coffee = coffee;
            public virtual string GetDescription() => _coffee.GetDescription();
            public virtual double GetCost() => _coffee.GetCost();
        }

        // Concrete decorators
        public class MilkDecorator : CoffeeDecorator
        {
            public MilkDecorator(ICoffee coffee) : base(coffee) { }
            public override string GetDescription() => _coffee.GetDescription() + ", milk";
            public override double GetCost() => _coffee.GetCost() + 0.5;
        }

        public class SugarDecorator : CoffeeDecorator
        {
            public SugarDecorator(ICoffee coffee) : base(coffee) { }
            public override string GetDescription() => _coffee.GetDescription() + ", sugar";
            public override double GetCost() => _coffee.GetCost() + 0.2;
        }
    }
}
