public class BestTimeToBuyAndSellStock
{
	public static void Run()
	{
		Run([0, 1]);
		Run([1, 0]);
		Run([1, 2, 3, 4]);
		Run([6, 9, 1, 2]);
		Run([6, 9, 1, 2, 5]);
		Run([6, 9, 1, 5, 2]);
		Run([6, 9, 1, 5, 2, 0, 7]);
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
			int diff = 0;

			for (int i = 1; i < prices.Length; i++)
			{
				if (prices[i] < min)
				{
					diff = max - min;
					min = max = prices[i];
				}
				else if (prices[i] > max)
				{
					max = prices[i];
					diff = max - min;
				}

				if (diff > result)
					result = diff;
			}

			return result;
		}
	}
}
