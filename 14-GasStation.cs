public class GasStation
{

	public static void Run()
	{
		Run([2, 3, 4], [3, 4, 3]);
		Run([1, 2, 3, 4, 5], [3, 4, 5, 1, 2]);
		Run([5, 1, 2, 3, 4], [4, 4, 1, 5, 1]);
	}

	private static void Run(int[] gas, int[] cost)
	{
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(gas));
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(cost));
		var s = new Solution();
		var result = s.CanCompleteCircuit(gas, cost);
		Console.WriteLine("=>");
		Console.WriteLine(result);
		Console.WriteLine();
	}

	public class Solution
	{
		public int CanCompleteCircuit(int[] gas, int[] cost)
		{
			var startIndex = 0;
			var tank = 0;
			var sum = 0;

			for (int i = 0; i < gas.Length; i++)
			{
				tank = tank + gas[i] - cost[i];
				sum = sum + gas[i] - cost[i];

				Console.Write($"index: {i} sum: {sum} tank: {tank}");
				if (tank < 0)
				{
					startIndex = i + 1;
					tank = 0;
					Console.WriteLine($"    -> start: {startIndex} tank: {tank}");
				}
				else
				{
					Console.WriteLine();
				}
			}

			if (sum < 0 || startIndex == gas.Length)
				return -1;

			return startIndex;
		}
	}
}
