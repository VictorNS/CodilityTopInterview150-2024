public class ProductOfArrayExceptSelf
{

	public static void Run()
	{
		Run([1, 2, 3, 4, 5]);
		Run([-1, 1, 0, -3, 3]);
	}

	private static void Run(int[] nums)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		var s = new Solution();
		var result = s.ProductExceptSelf(nums);
		Console.WriteLine("=>");
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(result));
		Console.WriteLine();
	}

	public class Solution
	{
		// with using the division operation
		public int[] ProductExceptSelfV1(int[] nums)
		{
			var product = 1;

			for (int i = 0; i < nums.Length; i++)
				product *= nums[i];

			var res = new int[nums.Length];

			for (int i = 0; i < nums.Length; i++)
				res[i] = product / nums[i];

			return res;
		}

		public int[] ProductExceptSelf(int[] nums)
		{
			var res = new int[nums.Length];
			int length = nums.Length;
			var prefixProd = new int[length + 1];
			prefixProd[0] = 1;
			var suffixProd = new int[length + 1];
			suffixProd[length] = 1;

			for (int i = 0; i < length; i++)
			{
				prefixProd[i + 1] = prefixProd[i] * nums[i];
				suffixProd[length - i - 1] = suffixProd[length - i] * nums[length - i - 1];
			}

			//Console.WriteLine("prefixProd: " + System.Text.Json.JsonSerializer.Serialize(prefixProd));
			//Console.WriteLine("suffixProd: " + System.Text.Json.JsonSerializer.Serialize(suffixProd));

			for (int i = 0; i < length; i++)
				res[i] = prefixProd[i] * suffixProd[i + 1];

			return res;
		}
	}
}
