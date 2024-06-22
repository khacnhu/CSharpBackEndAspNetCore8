namespace WebApplication2.Models.Repository
{
    public class ShirtRepository
    {
        public static List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt {ShirtId = 1, Brand = "brand", Color = "blue",Gender = "men", Price = 23, Size = 23},
            new Shirt {ShirtId = 2, Brand = "brand one", Color = "red",Gender = "women", Price = 3, Size = 5},
            new Shirt {ShirtId = 3, Brand = "brand two", Color = "yellow",Gender = "men", Price = 45, Size = 2},
            new Shirt {ShirtId = 4, Brand = "brand brand", Color = "gray",Gender = "men", Price = 213, Size = 233},

        };

        public static List<Shirt> ListShirts()
        {
            return shirts;
        }

        public static bool ShirtExisted(int id)
        {
            return shirts.Any(x => x.ShirtId == id);
        }
            
        public static Shirt? getShirtById(int id)
        {
            return shirts.FirstOrDefault(x => x.ShirtId == id);

        }

        public static void AddShirt(Shirt shirt)
        {
            int maxId = shirts.Max(x => x.ShirtId);
            shirt.ShirtId = maxId + 1;
            shirts.Add(shirt);
        }

        public static Shirt? GetShirtByProperties (string? brand, string? gender, string? color, 
            int? size
            )
        {
            return shirts.FirstOrDefault(x => 
                !string.IsNullOrWhiteSpace(brand) &&
                !string.IsNullOrWhiteSpace(x.Brand) && 
                x.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(gender) &&
                !string.IsNullOrWhiteSpace(x.Gender) &&
                x.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) &&
                !string.IsNullOrWhiteSpace(color) &&
                !string.IsNullOrWhiteSpace(x.Color) && 
                x.Color.Equals(color, StringComparison.OrdinalIgnoreCase) &&
                size.HasValue &&
                x.Size.HasValue &&
                size.Value == x.Size.Value);
        }

        public static void UpdateShirt(Shirt shirt)
        {
            var shirtToUpdate = shirts.First(x => x.ShirtId == shirt.ShirtId);

            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;
        }

        internal static bool getShirtById(string shirtId)
        {
            throw new NotImplementedException();
        }

        public static void DeleteShirt(int shirtId)
        {
            var shirt = getShirtById(shirtId);
            if (shirt != null)
            {
                shirts.Remove(shirt);
            }
        }

    }
}
