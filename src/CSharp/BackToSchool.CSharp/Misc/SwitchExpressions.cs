
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace BackToSchool.CSharp.Misc
{
    /// <summary>
    /// Adapted from:
    /// https://dotnettips.wordpress.com/2024/05/03/general-performance-tip-choosing-between-conditional-statements-if-switch-and-switch-expression-performance-in-c/
    /// My results did not confirm what the author stated
    /// </summary>
    public class SwitchExpressions
    {
        public static string GetDataUsingIfs(PaymentType input)
        {
            var result = string.Empty;

            if (input == PaymentType.CreditCard)
            {
                result = input.GetDescription();
            }
            else if (input == PaymentType.Currency)
            {
                result = input.GetDescription();
            }
            else if (input == PaymentType.Custom)
            {
                result = input.GetDescription();
            }

            return result;
        }

        public static string GetDataUsingSwitch(PaymentType input)
        {
            var result = string.Empty;

            switch (input)
            {
                case PaymentType.CreditCard:
                    result = input.GetDescription();
                    break;
                case PaymentType.Currency:
                    result = input.GetDescription();
                    break;
                case PaymentType.Custom:
                    result = input.GetDescription();
                    break;
                default:
                    break;
            }

            return result;
        }

        public static string GetDataUsingSwitchExpressions(PaymentType input)
        {
            var result = input switch
            {
                PaymentType.CreditCard => input.GetDescription(),
                PaymentType.Currency => input.GetDescription(),
                PaymentType.Custom => input.GetDescription(),
                _ => "UNKOWN"
            };

            return result;
        }
    }

    public enum PaymentType
    {
        CreditCard,
        Currency,
        Custom
    }

    public static class PaymentTypeExtensions
    {
        public static string GetDescription(this PaymentType paymentType)
        {
            return paymentType.ToString();
        }
    }

    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class SwitchExpressionsBenchmarks
    {
        private const int Iterations = 10000;

        [Benchmark(Baseline = true)]
        public void ViaIfs()
        {
            for (var i = 0; i < Iterations; i++)
            {
                SwitchExpressions.GetDataUsingIfs(PaymentType.CreditCard);
                SwitchExpressions.GetDataUsingIfs(PaymentType.Currency);
                SwitchExpressions.GetDataUsingIfs(PaymentType.Custom);
            }
        }

        [Benchmark]
        public void ViaSwitch()
        {
            for (var i = 0; i < Iterations; i++)
            {
                SwitchExpressions.GetDataUsingSwitch(PaymentType.CreditCard);
                SwitchExpressions.GetDataUsingSwitch(PaymentType.Currency);
                SwitchExpressions.GetDataUsingSwitch(PaymentType.Custom);
            }
        }

        [Benchmark]
        public void ViaSwitchExpression()
        {
            for (var i = 0; i < Iterations; i++)
            {
                SwitchExpressions.GetDataUsingSwitchExpressions(PaymentType.CreditCard);
                SwitchExpressions.GetDataUsingSwitchExpressions(PaymentType.Currency);
                SwitchExpressions.GetDataUsingSwitchExpressions(PaymentType.Custom);
            }
        }
    }
}