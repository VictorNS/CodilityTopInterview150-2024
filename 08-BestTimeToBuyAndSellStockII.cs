public class BestTimeToBuyAndSellStockII
{
	public static void Run()
	{
		Run([0, 1]);
		Run([1, 0]);
		Run([1, 2, 3, 4, 5]);
		Run([5, 6, 3, 4]);
		Run([5, 6, 3, 4, 4]);
		Run([7, 6, 4, 3, 1]);
		Run([7, 1, 5, 3, 6, 4]);
	}

	private static void Run(int[] nums)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		var s = new Solution();
		var result = s.MaxProfit(nums);
		Console.WriteLine("=>");
		Console.WriteLine(result);
		Console.WriteLine();
	}

	public class Solution
	{
		public int MaxProfit(int[] prices)
		{
			int min = prices[0];
			int max = prices[0];
			int result = 0;

			for (int i = 1; i < prices.Length; i++)
			{
				if (prices[i] < max)
				{
					result += max - min;
					min = max = prices[i];
				}
				else
				{
					max = prices[i];
				}
			}

			if (max > min)
				result += max - min;

			return result;
		}
	}
}
