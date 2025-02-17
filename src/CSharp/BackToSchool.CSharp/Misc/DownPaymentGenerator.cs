using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackToSchool.CSharp.Misc
{
    public enum IncrementType
    {
        Dynamic = 0,
        Static = 1,
        Predefined = 2,
    }

    public class GenerateDownPaymentCommand()
    {
        public IncrementType Type { get; set; }

        public decimal? Ceiling { get; set; }

        public int? TierCount { get; set; }

        public decimal InitialDownpayment { get; set; }

        public decimal PurchasePrice { get; set; }

        public List<double> Steps { get; set; }

    }

    public class DownPaymentGenerator
    {
        public List<decimal> GenerateDownPayments(GenerateDownPaymentCommand command)
        {
            switch (command.Type)
            {
                
                case IncrementType.Dynamic:
                    return GenerateDownPaymentsDynamic(command);
                case IncrementType.Static:
                    return GenerateDownPaymentsStatic(command);
                case IncrementType.Predefined:
                    return GenerateDownPaymentsPredefined(command);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private List<decimal> GenerateDownPaymentsDynamic(GenerateDownPaymentCommand command)
        {
            var results = new List<decimal>();

            foreach (var step in command.Steps)
            {
                //results.Add((decimal)(command.InitialDownpayment * step));
            }

            return results;
        }

        private List<decimal> GenerateDownPaymentsStatic(GenerateDownPaymentCommand command)
        {
            var results = new List<decimal>();

            return results;
        }

        private List<decimal> GenerateDownPaymentsPredefined(GenerateDownPaymentCommand command)
        {
            var results = new List<decimal>();

            return results;
        }
    }
}
