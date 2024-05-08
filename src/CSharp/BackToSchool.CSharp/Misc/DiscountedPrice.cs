
using System;

namespace BackToSchool.CSharp.Misc
{
    public class DiscountedPrice
    {
        public double GetDiscountedPrice(double cartWeight,
            double totalPrice,
            DiscountType discountType)
        {
            double discount;

            switch (discountType)
            {
                case DiscountType.Standard:
                    discount = ((100 - 6) / (double)100);
                    break;
                case DiscountType.Seasonal:
                    discount = ((100 - 12) / (double)100);
                    break;
                case DiscountType.Weight:
                    if (cartWeight <= 10)
                    {
                        discount = ((100 - 6) / (double)100);
                    }
                    else
                    {
                        discount = ((100 - 18) / (double)100);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(discountType), discountType, null);
            }

            return discount * totalPrice;
        }
    }

    public enum DiscountType
    {
        Standard,
        Seasonal,
        Weight
    }
}
