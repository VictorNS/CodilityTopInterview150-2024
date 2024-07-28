public class RotateArray
{
	public static void Run()
	{
		Run([1, 2], 1);
		Run([1, 2], 2);
		Run([1, 2], 3);
		Run([1, 2, 3], 0);
		Run([1, 2, 3], 1);
		Run([1, 2, 3], 2);
		Run([1, 2, 3], 3);
		Run([1, 2, 3], 4);
		Run([1, 2, 3, 4, 5], 2);
		Run([1, 2, 3, 4], 2);
		Run([], 0);
		Run([1], 1);
		Run([1, 2, 3, 4, 5, 6, 7], 3);
		Run([-1, -100, 3, 99], 2);
	}

	private static void Run(int[] nums, int val)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		Console.WriteLine(val);
		var s = new Solution();
		s.Rotate(nums, val);
		Console.WriteLine("=>");
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		Console.WriteLine();
	}

	public class Solution
	{
		public void Rotate(int[] nums, int k)
		{
			if (nums.Length < 2)
				return;

			k = k % nums.Length;
			var buffer = new int[k];

			for (int i = 0; i < k; i++)
				buffer[i] = nums[nums.Length - k + i];

			for (int i = nums.Length - k - 1; i >= 0; i--)
				nums[i + k] = nums[i];

			for (int i = 0; i < k; i++)
				nums[i] = buffer[i];
		}
	}
}
