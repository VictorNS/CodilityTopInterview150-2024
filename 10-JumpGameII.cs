public class JumpGameII
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
		Run([2, 9, 1, 0, 0, 0, 0, 0, 0, 0, 0]);
		Run([2, 3, 1, 1, 4]);
		Run([2, 3, 0, 1, 4]);
		Run([3, 2, 1, 0, 4]);
		Run([5, 9, 3, 2, 1, 0, 2, 3, 3, 1, 0, 0]);
		Run([2, 0, 2, 0, 2, 0, 0]);
		Run([2, 4, 1, 1, 1, 0]);
	}

	private static void Run(int[] nums)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		var s = new Solution();
		var result = s.Jump(nums);
		Console.WriteLine("=>");
		Console.WriteLine(result);
		Console.WriteLine();
	}

	public class Solution
	{
		public int Jump(int[] nums)
		{
			if (nums.Length == 1)
				return 0;

			var desiredIndex = nums.Length - 1;
			int minIndex;
			int steps = 1;

			while (true)
			{
				minIndex = desiredIndex;

				for (int i = 0; i < desiredIndex; i++)
				{
					if (i + nums[i] >= desiredIndex)
					{
						minIndex = i;
						break;
					}
				}

				if (minIndex == 0)
					return steps;
				else if (minIndex == desiredIndex)
					return 0;

				desiredIndex = minIndex;
				steps++;
			}
		}
	}
}
