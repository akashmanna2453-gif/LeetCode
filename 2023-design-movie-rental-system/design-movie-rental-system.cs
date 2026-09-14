public class MovieRentingSystem
{
    // movie -> available copies
    private Dictionary<int, SortedSet<(int price, int shop)>> available;

    // rented movies sorted by price, shop, movie
    private SortedSet<(int price, int shop, int movie)> rented;

    // shop + movie -> price
    private Dictionary<(int shop, int movie), int> prices;

    public MovieRentingSystem(int n, int[][] entries)
    {
        available = new Dictionary<int, SortedSet<(int, int)>>();
        rented = new SortedSet<(int, int, int)>();
        prices = new Dictionary<(int, int), int>();

        foreach (int[] entry in entries)
        {
            int shop = entry[0];
            int movie = entry[1];
            int price = entry[2];

            prices[(shop, movie)] = price;

            if (!available.ContainsKey(movie))
                available[movie] = new SortedSet<(int, int)>();

            available[movie].Add((price, shop));
        }
    }

    public IList<int> Search(int movie)
    {
        List<int> result = new List<int>();

        if (!available.ContainsKey(movie))
            return result;

        foreach (var item in available[movie])
        {
            result.Add(item.shop);

            if (result.Count == 5)
                break;
        }

        return result;
    }

    public void Rent(int shop, int movie)
    {
        int price = prices[(shop, movie)];

        available[movie].Remove((price, shop));

        rented.Add((price, shop, movie));
    }

    public void Drop(int shop, int movie)
    {
        int price = prices[(shop, movie)];

        rented.Remove((price, shop, movie));

        available[movie].Add((price, shop));
    }

    public IList<IList<int>> Report()
    {
        List<IList<int>> result = new List<IList<int>>();

        int count = 0;

        foreach (var item in rented)
        {
            result.Add(new List<int> { item.shop, item.movie });

            count++;

            if (count == 5)
                break;
        }

        return result;
    }
}