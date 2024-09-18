namespace MinimumDistanceCouple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime[] dates = {
                new DateTime(2014, 6, 14, 6, 32, 0),
                new DateTime(2014, 7, 10, 23, 49, 0),
                new DateTime(2015, 1, 10, 1, 16, 0),
                new DateTime(2014, 12, 20, 21, 45, 0),
                new DateTime(2014, 6, 2, 15, 14, 0)
            };
            (int firstIndex, int secondIndex) bestIndexes = (0,0);
            Double bestDistance = double.MaxValue;

            for (int i = 0; i < dates.Length; i++)
            {
                for (int j = 0; j < dates.Length; j++)
                {
                    if (i == j) continue;

                    TimeSpan distance = dates[i] - dates[j];
                    if (distance.TotalSeconds < bestDistance)
                    {
                        bestIndexes = (i,j);
                        bestDistance = distance.TotalSeconds;
                    }
                }
            }

            Console.WriteLine($"Indexes {bestIndexes.firstIndex} and {bestIndexes.secondIndex} have the minimum distance between them.");
           }
        }
    }
