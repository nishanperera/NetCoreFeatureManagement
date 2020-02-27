namespace FeatureToggle
{
    public interface ICalculateDiscount
    {
        double ApplyDiscount();
    }

    public class CalculateDiscount : ICalculateDiscount
    {
        public double Discount { get; set; }
        public CalculateDiscount()
        {
            Discount = .1;
        }

        public double ApplyDiscount()
        {
            return .1;
        }
    }
}