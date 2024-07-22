public class MergeSortedArray
{
    public static void Run()
    {
        var s = new Solution();
        int[] nums1 = [1, 2, 3, 0, 0, 0];
        int[] nums2 = [2, 5, 6];

        s.Merge(nums1, 3, nums2, 3);
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(nums1));
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
