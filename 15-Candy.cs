public class Candy
{

	public static void Run()
	{
		Run([10, 10, 10, 10, 10, 10]);
		Run([0, 1, 5]);
		Run([1, 0, 2]);
		Run([1, 2, 2]);
		Run([1, 3, 2, 2, 1]); // 7 done
		Run([1, 3, 2, 1, 0]); // done
		Run([1, 3, 9, 7, 1]);
		Run([1, 9, 8, 7, 7, 1]);
		Run([1, 2, 4, 4, 3]); // 9
	}

	private static void Run(int[] nums)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums));
		var s = new Solution();
		var result = s.Candy(nums);
		Console.WriteLine("=>");
		Console.WriteLine(result);
		Console.WriteLine();
	}

	public class Solution
	{
		public int Candy(int[] nums)
		{
			var cands = new int[nums.Length];
			var total = 0;
			var unknown = 0;

			for (int i = 0; i < nums.Length; i++)
			{
				var vL = i == 0 ? int.MaxValue : nums[i - 1];
				var vI = nums[i];
				var vR = i == nums.Length - 1 ? int.MaxValue : nums[i + 1];

				if (vL >= vI && vI <= vR)
				{
					cands[i] = 1;
				}
				else
				{
					cands[i] = -1;
					unknown++;
				}
			}

			if (unknown == 0)
				return nums.Length;

			while (unknown != 0)
			{
				total = 0;
				unknown = 0;

				for (int i = 0; i < nums.Length; i++)
				{
					if (cands[i] == -1)
					{
						var vL = i == 0 ? 0 : nums[i - 1];
						var vI = nums[i];
						var vR = i == nums.Length - 1 ? 0 : nums[i + 1];

						var cL = i == 0 ? 0 : cands[i - 1];
						var cR = i == nums.Length - 1 ? 0 : cands[i + 1];

						if (cL != -1 && cR != -1)
						{
							if (vL < vI && vI > vR)
								cands[i] = Math.Max(cL + 1, cR + 1);
							else if (vL == vI && vI > vR)
								cands[i] = cR + 1;
							else if (vL < vI && vI == vR)
								cands[i] = cL + 1;
						}
						else if (cL == -1 && cR != -1 && vL >= vI && vI > vR)
						{
							cands[i] = cR + 1;
						}
						else if (cL != -1 && cR == -1 && vL < vI && vI <= vR)
						{
							cands[i] = cL + 1;
						}
						else
						{
							cands[i] = -1;
							unknown++;
						}
					}

					total += cands[i];
				}
				Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(cands));

				if (unknown == 0)
					continue;

				total = 0;
				unknown = 0;

				for (int i = nums.Length - 1; i >= 0; i--)
				{
					if (cands[i] == -1)
					{
						var vL = i == 0 ? 0 : nums[i - 1];
						var vI = nums[i];
						var vR = i == nums.Length - 1 ? 0 : nums[i + 1];

						var cL = i == 0 ? 0 : cands[i - 1];
						var cR = i == nums.Length - 1 ? 0 : cands[i + 1];

						if (cL != -1 && cR != -1)
						{
							if (vL < vI && vI > vR)
								cands[i] = Math.Max(cL + 1, cR + 1);
							else if (vL == vI && vI > vR)
								cands[i] = cR + 1;
							else if (vL < vI && vI == vR)
								cands[i] = cL + 1;
						}
						else if (cL == -1 && cR != -1 && vL >= vI && vI > vR)
						{
							cands[i] = cR + 1;
						}
						else if (cL != -1 && cR == -1 && vL < vI && vI <= vR)
						{
							cands[i] = cL + 1;
						}
						else
						{
							cands[i] = -1;
							unknown++;
						}
					}

					total += cands[i];
				}
			}

			return total;
		}
	}
}
