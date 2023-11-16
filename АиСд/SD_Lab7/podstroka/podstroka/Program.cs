
using System.Diagnostics.Metrics;

public static class Lab7
{
    public static void FindPodposl(int N)
    {


        int[] nums = new int[8] {5,8,1,6,7,2,12,9};

        int[] podposllength = new int[8] { 0,0,0,0,0,0,0,0};

        int maxlengthposition = 0;

        int temp;
        for (int i = 0; i < nums.Length - 1; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] > nums[j])
                {
                    temp = nums[i];
                    nums[i] = nums[j];
                    nums[j] = temp;
                }
            }
        }

        

        for(int i=0;i< nums.Length - 1; i++)// 1 5 6 7 8
        {
            int counter = 1;

            for (int j=i;j< nums.Length -1; j++)
            {
                if (nums[j]+1 == nums[j+1])
                {
                    counter++;
                }
                else
                {
                    break;
                }
            }
            if(counter > maxlengthposition)
            {
                maxlengthposition = i;
            }


            podposllength[i] = counter;
        }

        int maxpodposl = podposllength.Max();



        foreach (var elem in nums) 
        {
            Console.WriteLine(elem);
        }

        Console.WriteLine("--------------------");

        foreach (var elem in podposllength)
        {
            Console.WriteLine(elem);
        }

        Console.WriteLine("result -------------");


        int it = maxlengthposition;

        while (maxpodposl != 0)
        {

            Console.WriteLine(nums[it-1]);
            maxpodposl--;
            it++;
        }

    }
}



class Program
{
    static void Main(string[] args)
    {
        int N = 5;

        Lab7.FindPodposl(N);

    }
}