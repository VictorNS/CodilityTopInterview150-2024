public class MergeSortedArray
{
    public static void Run()
    {
        Run(0, [], []);
        Run(1, [1], []);
        Run(0, [0], [2]);
        Run(3, [1, 2, 3, 0, 0, 0], []);
        Run(3, [1, 2, 3, 0, 0, 0], [2, 5, 6]);
    }

    private static void Run(int m, int[] nums1, int[] nums2)
    {
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums1));
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums2));
        var s = new Solution();
        s.Merge(nums1, m, nums2, nums2.Length);
		Console.WriteLine("=>");
		Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums1));
        Console.WriteLine();
    }

    public class Solution
    {
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            var i1 = 0;
            var i2 = 0;
            var res = new int[m + n];

            for (int i = 0; i < m + n; i++)
            {
                if (i1 < m && i2 == n)
                {
                    res[i] = nums1[i1];
                    i1++;
                }
                else if (i1 == m && i2 < n)
                {
                    res[i] = nums2[i2];
                    i2++;
                }
                else if (nums1[i1] < nums2[i2])
                {
                    res[i] = nums1[i1];
                    i1++;
                }
                else
                {
                    res[i] = nums2[i2];
                    i2++;
                }
            }

            for (int i = 0; i < m + n; i++)
            {
                nums1[i] = res[i];
            }
        }
    }
}
