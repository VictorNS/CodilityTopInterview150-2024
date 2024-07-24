public class RemoveElement
{
    public static void Run()
    {
		Run([], 0);
		Run([1], 1);
		Run([1, 2], 3);
		Run([3, 2, 2, 3], 3);
		Run([0, 1, 2, 2, 3, 0, 4, 2], 2);
	}

    private static void Run(int[] nums, int val)
    {
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
        Console.WriteLine(val);
        var s = new Solution();
        var result = s.RemoveElement(nums, val);
		Console.WriteLine("=>");
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		Console.WriteLine(result);
        Console.WriteLine();
    }

    public class Solution
    {
		public int RemoveElement(int[] nums, int val)
		{
			var j = 0;
			var res = new int[nums.Length];

			for (int i = 0; i < nums.Length; i++)
			{
				if (nums[i] != val)
				{
					res[j] = nums[i];
					j++;
				}
			}


			for (int i = 0; i < nums.Length; i++)
			{
				nums[i] = res[i];
			}

			return j;
        }
    }
}
