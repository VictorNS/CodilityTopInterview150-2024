public class JumpGame
{
	public static void Run()
	{
		Run([0]);
		Run([0, 1]);
		Run([1, 0]);
		Run([2, 0]);
		Run([7, 0, 0]);
		Run([1, 1, 0]);
		Run([2, 2, 0]);
		Run([1, 2, 0]);
		Run([2, 9, 1, 0, 0, 1]);
		Run([2, 3, 1, 1, 4]);
		Run([3, 2, 1, 0, 4]);
		Run([5, 9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0]);
		Run([2, 0, 2, 0, 2, 0, 0]);
	}

	private static void Run(int[] nums)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		var s = new Solution();
		var result = s.CanJump(nums);
		Console.WriteLine("=>");
		Console.WriteLine(result);
		Console.WriteLine();
	}

	public class Solution
	{
		public bool CanJump(int[] prices)
		{
			var desiredIndex = prices.Length - 1;

			for (int i = prices.Length - 1; i >= 0; i--)
			{
				if (i + prices[i] >= desiredIndex)
				{
					desiredIndex = i;
				}
			}

			return desiredIndex == 0;
		}

		/// <summary>
		/// Good enough, but not the best solution.
		/// </summary>
		public bool CanJumpV1(int[] prices)
		{
			var desiredIndex = prices.Length - 1;
			int minIndex;

			while (true)
			{
				minIndex = desiredIndex;

				for (int i = 0; i < desiredIndex; i++)
					if (i + prices[i] >= desiredIndex && i < minIndex)
						minIndex = i;

				if (minIndex == 0)
					return true;
				else if (minIndex == desiredIndex)
					return false;

				desiredIndex = minIndex;
			}
		}
	}
}
