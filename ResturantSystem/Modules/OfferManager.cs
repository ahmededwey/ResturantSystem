namespace ResturantSystem.Modules
{
    public class OfferManager
    {
        public static double ApplyOffer(Dictionary<MenuItem, int> items, out string message)
        {
            message = string.Empty;
            double total = items.Sum(i => i.Key.Price * i.Value);
            if (total >= 300)
            {
                message = "🎉 Offer Applied: 10% discount for orders over 300!";
                return total * 0.10;
            }
            return 0;
        }
    }
}

