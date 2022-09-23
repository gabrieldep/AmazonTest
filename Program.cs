namespace AmazonTest
{
    public class Result
    {
        public static void Main()
        {
            Console.WriteLine(GetMinimumDays(new List<int> { 4, 2, 3, 4 }));
            Console.WriteLine(FindTotalImbalance(new List<int> { 4, 1, 3, 2 }));
        }

        public static int GetMinimumDays(List<int> parcels)
        {
            int days = 0;
            parcels = parcels.Where(p => p != 0).OrderBy(p => p).ToList();
            while (true)
            {
                if (parcels.Count == 0)
                    break;
                int valueToRemove = parcels[0];
                if (valueToRemove == 0)
                    break;
                parcels.RemoveAt(0);
                for (int j = 0; j < parcels.Count; j++)
                {
                    parcels[j] -= valueToRemove;
                }
                days++;
                parcels = parcels.Where(p => p != 0).ToList();
                if (parcels.Count == 0)
                    break;
            }
            return days;
        }

        internal static long FindTotalImbalance(List<int> rank)
        {
            return GetImbalanceRecursive(ref rank, 2);
        }

        internal static long GetImbalanceRecursive(ref List<int> rank, int size)
        {
            if (size > rank.Count)
                return 0;

            var rankAux = rank.ToArray();
            long count = 0;
            int skipAux = 0;
            while (true)
            {
                if (rankAux.Length == 0)
                    break;
                var aux = rankAux.Skip(skipAux).Take(size).ToArray();
                if (aux.Length != size)
                    break;
                count += GetImbalanceGroup(aux);
                skipAux++;
            }
            return count + GetImbalanceRecursive(ref rank, size + 1);
        }

        internal static long GetImbalanceGroup(int[] rank)
        {
            rank = rank.OrderBy(r => r).ToArray();
            long imbalance = 0;
            for (int i = 0; i < rank.Length - 1; i++)
                if (rank[i + 1] - rank[i] > 1)
                    imbalance++;
            return imbalance;
        }
    }
}