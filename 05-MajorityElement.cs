public class MajorityElement
{

	public static void Run()
    {
		Run([1]);
		Run([3, 2, 3]);
		Run([3, 2, 1, 1]);
	}

	private static void Run(int[] nums)
    {
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
        var s = new Solution();
        var result = s.MajorityElement(nums);
		Console.WriteLine("=>");
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		Console.WriteLine(result);
        Console.WriteLine();
    }

    public class Solution
    {
		public int MajorityElement(int[] nums)
		{
			var dict = new Dictionary<int, int>();

			for (int i = 0; i < nums.Length; i++)
			{
				if (dict.TryGetValue(nums[i], out int value))
				{
					dict[nums[i]] = ++value;
				}
				else
				{
					dict[nums[i]] = 1;
				}
			}

			var n = 0;
			var max = 0;

			foreach (var item in dict)
			{
				if (item.Value > max)
				{
					max = item.Value;
					n = item.Key;
				}
			}

			return n;
		}
    }
}
