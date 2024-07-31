using System;
using System.Linq;

public class Program
{
    //Coin
    public static int GetMinCoins(int[] coins, int amount)
    {
        // Sort max -> min
        Array.Sort(coins, (x, y) => y.CompareTo(x));
        int coinCount = 0;

        foreach (var coin in coins)
        {
            if (amount == 0)
                break;
            coinCount += amount / coin;
            amount %= coin;
        }

        return amount == 0 ? coinCount : -1; // return -1 if can't change
    }

    //Activity
    public class Activity
    {
        public int Start { get; set; }
        public int Finish { get; set; }
    }

    public class ActivitySelection
    {
        public static List<Activity> SelectActivities(List<Activity> activities)
        {
            // Sort with finish times
            activities.Sort((x, y) => x.Finish.CompareTo(y.Finish));

            List<Activity> selectedActivities = new List<Activity>();

            selectedActivities.Add(activities[0]);
            int lastFinishTime = activities[0].Finish;

            for (int i = 1; i < activities.Count; i++)
            {
                if (activities[i].Start >= lastFinishTime)
                {
                    selectedActivities.Add(activities[i]);
                    lastFinishTime = activities[i].Finish;
                }
            }

            return selectedActivities;
        }
        public static void Main(string[] args)
        {
            int option = 0;
            do
            {
                Console.WriteLine("Select Greedy Algorithm method (1 for Coin Change, 2 for Activity Selection): ");
                option = Convert.ToInt32(Console.ReadLine());
                if (option != 1 && option != 2)
                {
                    Console.WriteLine("Wrong!! Choose again.");
                }
            } while (option != 1 && option != 2);


            //Coin
            if (option == 1)
            {
                int[] coins = { 1, 5, 10, 25 };
                int amount = 63;

                int result = GetMinCoins(coins, amount);

                if (result != -1)
                {
                    Console.WriteLine($"Minimum number of coins required to change {amount} is: {result}");
                }
                else
                {
                    Console.WriteLine($"The amount of coins given cannot be redeemed {amount}.");
                }
            }


            //Activity
            else
            {
                List<Activity> activities = new List<Activity>
                {
                    new Activity { Start = 1, Finish = 3 },
                    new Activity { Start = 2, Finish = 4 },
                    new Activity { Start = 3, Finish = 5 },
                    new Activity { Start = 0, Finish = 6 },
                    new Activity { Start = 5, Finish = 7 },
                    new Activity { Start = 8, Finish = 9 },
                    new Activity { Start = 5, Finish = 9 },
                    new Activity { Start = 6, Finish = 10 },
                    new Activity { Start = 8, Finish = 11 },
                    new Activity { Start = 2, Finish = 14 },
                    new Activity { Start = 12, Finish = 16 }
                };

                List<Activity> selectedActivities = SelectActivities(activities);

                Console.WriteLine("The Activities selected are:");
                foreach (var activity in selectedActivities)
                {
                    Console.WriteLine($"Start: {activity.Start}, Finish: {activity.Finish}");
                }
            }
        }
    }
}
