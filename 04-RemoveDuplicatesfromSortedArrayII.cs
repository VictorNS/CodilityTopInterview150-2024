public class RemoveDuplicatesfromSortedArrayII
{

	public static void Run()
    {
		Run([]);
		Run([1]);
		Run([1, 1, 2]);
		Run([1, 2, 2]);
		Run([1, 2, 3]);
		Run([1, 1, 1, 2, 2, 3]);
		Run([1, 1, 1, 2, 2, 3, 3]);
		Run([0, 0, 1, 1, 1, 1, 2, 3, 3]);
	}

	private static void Run(int[] nums)
    {
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
        var s = new Solution();
        var result = s.RemoveDuplicates(nums);
		Console.WriteLine("=>");
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		Console.WriteLine(result);
        Console.WriteLine();
    }

    public class Solution
    {
		public int RemoveDuplicates(int[] nums)
		{
			int i = 0;
			int j = 0;
			int shift;
			int current;

			while (i < nums.Length)
			{
				current = nums[i];
				shift = 1;

				while (i + shift < nums.Length && nums[i + shift] == current)
					shift++;

				if (shift == 1)
				{
					nums[j] = current;
					j++;
					i++;
					continue;
				}

				nums[j] = current;
				nums[j+1] = current;
				j += 2;
				i += shift;
			}

			return j;
		}
    }
}
