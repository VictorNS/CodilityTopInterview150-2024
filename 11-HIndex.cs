public class HIndex
{
	public static void Run()
	{
		Run([3, 2, 1]);
		Run([1, 0, 0, 9, 9, 9]);
		Run([1, 3, 1]);
		Run([3, 0, 6, 1, 5]);
	}

	private static void Run(int[] nums)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		var s = new Solution();
		var result = s.HIndex(nums);
		Console.WriteLine("=>");
		Console.WriteLine(result);
		Console.WriteLine();
	}

	public class Solution
	{
		public int HIndex(int[] nums)
		{
			int h = 0;
			int min;
			int cnt = 0;

			Array.Sort(nums);

			for (int i = nums.Length - 1; i >=0 ; i--)
			{
				cnt++;
				min = Math.Min(nums[i], cnt);

				if (min < h)
					return h;

				h = min;
			}

			return h;
		}
	}
}
