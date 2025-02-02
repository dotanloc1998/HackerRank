using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //Code to test below this line
            Console.WriteLine();
            List<string> result = cavityMap(new List<string> { "1112", "1912", "1892", "1234" });
            foreach (var item in result)
            {
                System.Console.WriteLine(item);
            }
            //Code to test above this line

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }

        #region Method
        private static void DebugSaveThePrisoner()
        {
            StreamReader readCase = new StreamReader(@"C:\Users\thuyl\Desktop\HackerRank\case.txt");
            StreamReader readResult = new StreamReader(@"C:\Users\thuyl\Desktop\HackerRank\result.txt");
            StreamWriter writeResult = new StreamWriter(@"C:\Users\thuyl\Desktop\HackerRank\wrong.txt");
            string? lineCase = "";
            string? lineResult = "";
            while ((lineCase = readCase.ReadLine()) != null && (lineResult = readResult.ReadLine()) != null)
            {
                string[] lineCase1 = lineCase.Split(' ');
                int n = Convert.ToInt32(lineCase1[0]);
                int m = Convert.ToInt32(lineCase1[1]);
                int s = Convert.ToInt32(lineCase1[2]);
                int seatWarn = saveThePrisoner(n, m, s);
                int result = Convert.ToInt32(lineResult);
                if (seatWarn != result)
                {
                    writeResult.WriteLine("prisoners: {0}, candies: {1}, start: {2} , output: {3}, result: {4}", n, m,
                        s,
                        seatWarn, result);
                }
            }

            readCase.Close();
            readResult.Close();
            writeResult.Close();
        }

        static void FindRatios(int[] arr)
        {
            List<double> ratios = new List<double>();
            double pos = 0, neg = 0, zero = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    neg++;
                }
                else if (arr[i] > 0)
                {
                    pos++;
                }
                else
                {
                    zero++;
                }
            }

            double posRatio = Convert.ToDouble(pos / arr.Length);
            ratios.Add(Math.Round(posRatio, 5));
            double negRatio = Convert.ToDouble(neg / arr.Length);
            ratios.Add(Math.Round(negRatio, 5));
            double zeroRatio = Convert.ToDouble(zero / arr.Length);
            ratios.Add(Math.Round(zeroRatio, 5));
            foreach (var VARIABLE in ratios)
            {
                Console.WriteLine("{0:N6}", VARIABLE);
            }

        }

        static void PrintStars(int n)
        {
            List<string> pyramid = new List<string>();
            for (int i = n; i > 0; i--)
            {
                string line = "";
                int space = n - i;
                for (int j = 0; j < n; j++)
                {
                    if (space > 0)
                    {
                        line += " ";
                        space--;
                    }
                    else
                    {
                        line += "#";
                    }
                }

                pyramid.Add(line);
            }

            pyramid.Reverse();
            foreach (var VARIABLE in pyramid)
            {
                Console.WriteLine(VARIABLE);
            }
        }

        static void FindMinMaxSum(long[] arr)
        {
            List<long> arrSort = arr.ToList();
            arrSort.Sort();
            long maxSum = arrSort[1] + arrSort[2] + arrSort[3] + arrSort[4];
            long minSum = arrSort[0] + arrSort[1] + arrSort[2] + arrSort[3];
            Console.WriteLine("{0} {1}", minSum, maxSum);
        }

        static int CountCandles(List<int> candles)
        {
            int count = 0;
            candles.Sort();
            candles.Reverse();
            int longestCandle = candles[0];
            for (int i = 0; i < candles.Count; i++)
            {
                if (candles[i] < longestCandle)
                {
                    break;
                }

                count++;
            }

            return count;
        }

        static string ConvertTime(string timeIn12)
        {
            string timeIn24 = "";
            string[] splitTime = timeIn12.Split(':');
            string timeFormat = splitTime[2].Substring(2);
            switch (timeFormat)
            {
                case "AM":
                    if (splitTime[0] == "12")
                    {
                        timeIn24 = "00:" + splitTime[1] + ":" + splitTime[2].Substring(0, 2);
                    }
                    else
                    {
                        timeIn24 = splitTime[0] + ":" + splitTime[1] + ":" + splitTime[2].Substring(0, 2);
                    }

                    break;
                case "PM":
                    if (splitTime[0] == "12")
                    {
                        timeIn24 = splitTime[0] + ":" + splitTime[1] + ":" + splitTime[2].Substring(0, 2);
                    }
                    else
                    {
                        int hourIn24 = int.Parse(splitTime[0]) + 12;
                        splitTime[0] = hourIn24.ToString();
                        timeIn24 = splitTime[0] + ":" + splitTime[1] + ":" + splitTime[2].Substring(0, 2);
                    }

                    break;
                default:
                    Console.WriteLine("Something's wrong!!");
                    break;
            }

            return timeIn24;
        }

        static List<int> GradingStudents(List<int> grades)
        {
            List<int> roundGrades = new List<int>();
            foreach (var grade in grades)
            {
                if (grade < 38)
                {
                    roundGrades.Add(grade);
                }
                else
                {
                    double divBy5 = Math.Ceiling(grade / 5.0);
                    int multipleOfFive = (int)divBy5 * 5;
                    int condition = multipleOfFive - grade;
                    if (condition < 3)
                    {
                        roundGrades.Add(multipleOfFive);
                    }
                    else
                    {
                        roundGrades.Add(grade);
                    }
                }
            }

            return roundGrades;
        }

        static void countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            //s,t Area Distance
            //a,b Tree's location
            int countApple = 0;
            int countOrange = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                int condition = a + apples[i];
                if (s <= condition && condition <= t)
                {
                    countApple++;
                }
            }

            for (int i = 0; i < oranges.Length; i++)
            {
                int condition = b + oranges[i];
                if (s <= condition && condition <= t)
                {
                    countOrange++;
                }
            }

            Console.WriteLine(countApple);
            Console.WriteLine(countOrange);
        }

        public static int diagonalDifference(List<List<int>> arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Count; i++)
            {
                result += arr[i][i];
            }

            int j = arr.Count - 1;
            for (int i = 0; i < arr.Count; i++)
            {
                result -= arr[i][j];
                j--;
            }

            return (int)Math.Abs(result);
        }

        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v2 >= v1)
            {
                return "NO";
            }
            else
            {
                int kangaroo1Location = x1 + v1, kangaroo2Location = x2 + v2;
                while (true)
                {
                    if (kangaroo1Location == kangaroo2Location)
                    {
                        return "YES";
                    }
                    else if (kangaroo1Location > kangaroo2Location)
                    {
                        return "NO";
                    }

                    kangaroo1Location += v1;
                    kangaroo2Location += v2;
                }
            }
        }

        static int[] breakingRecords(int[] scores)
        {
            int[] times = new int[2];
            int highScore = scores[0], lowScore = scores[0];
            int breakHigh = 0, breakLow = 0;
            for (int i = 0; i < scores.Length; i++)
            {
                if (scores[i] > highScore)
                {
                    breakHigh++;
                    highScore = scores[i];
                }
                else if (scores[i] < lowScore)
                {
                    breakLow++;
                    lowScore = scores[i];
                }
            }

            times[0] = breakHigh;
            times[1] = breakLow;
            return times;
        }

        static int birthday(List<int> s, int d, int m)
        {
            int result = 0;
            int condition = m - 1;
            int sum;
            for (int i = 0; i < s.Count; i++)
            {
                sum = 0;
                if (i + condition <= s.Count - 1)
                {
                    int temp = i;
                    for (int j = 0; j <= condition; j++)
                    {
                        sum += s[temp];
                        temp++;
                    }
                }

                if (sum == d)
                {
                    result++;
                }
            }

            return result;
        }

        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            int result = 0;
            int sum = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    sum = ar[i] + ar[j];
                    if (sum % k == 0)
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        static int migratoryBirds(List<int> arr)
        {
            int result = 0;
            int[] count = new int[5];
            foreach (var VARIABLE in arr)
            {
                switch (VARIABLE)
                {
                    case 1:
                        count[VARIABLE - 1]++;
                        break;
                    case 2:
                        count[VARIABLE - 1]++;
                        break;
                    case 3:
                        count[VARIABLE - 1]++;
                        break;
                    case 4:
                        count[VARIABLE - 1]++;
                        break;
                    case 5:
                        count[VARIABLE - 1]++;
                        break;
                }
            }

            int max = 0;
            for (int i = 0; i < count.Length; i++)
            {
                if (count[i] > max)
                {
                    max = count[i];
                    result = i;
                }
            }

            return result + 1;
        }

        static void bonAppetit(List<int> bill, int k, int b)
        {
            int chargs = bill.Sum() / 2;
            bill.RemoveAt(k);
            int actual = bill.Sum() / 2;
            if (b == actual)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                Console.WriteLine(chargs - actual);
            }
        }

        static int sockMerchant(int n, int[] ar)
        {
            int count = 0;
            List<int> arr = ar.ToList();
            arr.Sort();
            int i = 0;
            while (i + 2 <= arr.Count)
            {
                if (arr[i] == arr[i + 1])
                {
                    count++;
                    i += 2;
                }
                else
                {
                    i += 1;
                }
            }

            return count;
        }

        static int pageCount(int n, int p)
        {
            if (n % 2 == 0)
            {
                n++;
            }

            if (p % 2 == 0)
            {
                return Math.Min((p - 0) / 2, (n - 1 - p) / 2);
            }
            else
            {
                return Math.Min((p - 1) / 2, (n - p) / 2);
            }
        }

        public static int countingValleys(int steps, string path)
        {
            int valleys = 0;
            int levels = 0;
            for (int i = 0; i < path.Length; i++)
            {
                if (path[i] == 'U')
                {
                    levels++;
                }
                else
                {
                    if (levels == 0)
                    {
                        valleys++;
                    }

                    levels--;
                }
            }

            return valleys;
        }

        static string angryProfessor(int k, int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] <= 0)
                {
                    count++;
                }

                if (count >= k)
                {
                    return "NO";
                }
            }

            return "YES";
        }

        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            int max = -1;
            for (int i = 0; i < keyboards.Length; i++)
            {
                for (int j = 0; j < drives.Length; j++)
                {
                    int sum = keyboards[i] + drives[j];
                    if (sum > max && sum <= b)
                    {
                        max = sum;
                    }
                }
            }

            return max;
        }

        static string catAndMouse(int x, int y, int z)
        {
            int catADis = (int)Math.Abs(x - z);
            int catBDis = (int)Math.Abs(y - z);
            if (catADis < catBDis)
            {
                return "Cat A";
            }
            else if (catADis > catBDis)
            {
                return "Cat B";
            }
            else
            {
                return "Mouse C";
            }

        }

        static int[] reverseArray(int[] a)
        {
            int[] reversed = new int[a.Length];
            for (int i = 0; i < reversed.Length; i++)
            {
                reversed[i] = a[a.Length - i - 1];
            }

            return reversed;
        }

        static int hourglassSum(int[][] arr)
        {
            int max = Int32.MinValue;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    int sum = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] +
                              arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }

            return max;
        }

        public static List<int> rotateLeft(int d, List<int> arr)
        {
            for (int i = 0; i < d; i++)
            {
                arr.Add(arr[0]);
                arr.RemoveAt(0);
            }

            return arr;
        }

        public static int pickingNumbers(List<int> a)
        {
            List<int> result = new List<int>();
            int max = 2;
            a.Sort();
            for (int i = 0; i < a.Count - 1; i++)
            {
                result.Clear();
                result.Add(a[i]);
                for (int j = i + 1; j < a.Count; j++)
                {
                    int abs = (int)Math.Abs(a[i] - a[j]);
                    if (abs <= 1)
                    {
                        result.Add(a[j]);
                    }
                    else
                    {
                        break;
                    }
                }

                if (max < result.Count)
                {
                    max = result.Count;
                }
            }

            return max;
        }

        static int[] matchingStrings(string[] strings, string[] queries)
        {
            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++)
            {
                int count = 0;
                for (int j = 0; j < strings.Length; j++)
                {
                    if (queries[i] == strings[j])
                    {
                        count++;
                    }
                }

                result[i] = count;
            }

            return result;
        }

        public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
        {
            List<int> result = new List<int>();
            List<int> distinct = ranked.Distinct().ToList();
            distinct.Sort();
            int index = 0;
            foreach (var score in player)
            {
                for (int i = index; i < distinct.Count; i++)
                {
                    if (score < distinct[0])
                    {
                        result.Add(distinct.Count + 1);
                        break;
                    }

                    if (score < distinct[i])
                    {
                        int pos = i - 1;
                        int rank = distinct.Count - pos;
                        result.Add(rank);
                        index = i;
                        break;
                    }

                    if (score >= distinct[distinct.Count - 1])
                    {
                        result.Add(1);
                        break;
                    }
                }
            }

            return result;
        }

        static int designerPdfViewer(int[] h, string word)
        {
            int max = 1;
            int result = 0;
            for (int i = 0; i < word.Length; i++)
            {
                int pos = word[i] - 97;
                if (h[pos] > max)
                {
                    max = h[pos];
                }
            }

            result = word.Length * max;
            return result;

        }

        static int hurdleRace(int k, int[] height)
        {
            List<int> listHeight = height.ToList();
            listHeight.Sort();
            int max = listHeight[listHeight.Count - 1];
            if (max <= k)
            {
                return 0;
            }
            else
            {
                return max - k;
            }
        }

        static int saveThePrisoner(int n, int m, int s)
        {
            if (n == m)
            {
                if (s == 1)
                {
                    return n;
                }

                return s - 1;
            }
            else
            {
                double leftOver = Math.Ceiling(Convert.ToDouble(m / n));
                int leftOverCandies = Convert.ToInt32(m - (n * leftOver));
                int a = leftOverCandies - 1 + s;
                if (a == 0)
                {
                    return n;
                }

                if (a <= n)
                {
                    return a;
                }
                else
                {
                    return a - n;
                }
            }
        }

        static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            int[] result = new int[queries.Length];
            List<int> toRotate = a.ToList();
            for (int i = 0; i < k; i++)
            {
                int lastValue = toRotate[toRotate.Count - 1];
                toRotate.Insert(0, lastValue);
                toRotate.RemoveAt(toRotate.Count - 1);
            }

            for (int i = 0; i < queries.Length; i++)
            {
                result[i] = toRotate[queries[i]];
            }

            return result;
        }

        public static int getTotalX(List<int> a, List<int> b)
        {
            a.Sort();
            b.Sort();
            int f = lcm(a);
            int l = gcd(b);
            int count = 0;
            for (int i = f, j = 2; i <= l; i = f * j, j++)
            {
                if (l % i == 0)
                {
                    count++;
                }
            }

            return count;
        }

        private static int gcd(int a, int b)
        {
            while (b > 0)
            {
                int temp = b;
                b = a % b; // % is remainder
                a = temp;
            }

            return a;
        }

        private static int gcd(List<int> input)
        {
            int result = input[0];
            for (int i = 1; i < input.Count; i++)
            {
                result = gcd(result, input[i]);
            }

            return result;
        }

        private static int lcm(int a, int b)
        {
            return a * (b / gcd(a, b));
        }

        private static int lcm(List<int> input)
        {
            int result = input[0];
            for (int i = 1; i < input.Count; i++)
            {
                result = lcm(result, input[i]);
            }

            return result;
        }

        static string dayOfProgrammer(int year)
        {
            if (year % 4 == 0 && year < 1918 || year % 4 == 0 && year % 400 == 0 || year % 4 == 0 && year % 100 != 0)
            {
                return "12.09." + year;
            }
            else if (year == 1918)
            {
                return "26.09.1918";
            }

            return "13.09." + year;
        }

        static int utopianTree(int n)
        {
            return (int)Math.Pow(2, (n + 3) / 2) + ((int)Math.Pow(-1, n) - 3) / 2;
        }

        static int findDigits(int n)
        {
            int count = 0;
            string stringNumber = n.ToString();
            for (int i = 0; i < stringNumber.Length; i++)
            {
                int number = Convert.ToInt32(stringNumber[i].ToString());
                if (number != 0)
                {
                    if (n % number == 0)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        static int beautifulDays(int i, int j, int k)
        {
            int count = 0;
            for (; i <= j; i++)
            {
                int dif = i - ReverseNumber(i);
                if (dif % k == 0)
                {
                    count++;
                }
            }

            return count;
        }

        static int ReverseNumber(int number)
        {
            StringBuilder reversedNum = new StringBuilder();
            string stringNum = number.ToString();
            for (int i = stringNum.Length - 1; i >= 0; i--)
            {
                reversedNum.Append(stringNum[i]);
            }

            return Convert.ToInt32(reversedNum.ToString());
        }

        static int viralAdvertising(int n)
        {
            int sum = 0;
            int shared = 5;
            for (int i = 0; i < n; i++)
            {
                int liked = (int)(shared / 2.0);
                sum += liked;
                shared = liked * 3;
                //Console.WriteLine(sum);
            }

            return sum;
        }

        static int[] permutationEquation(int[] p)
        {
            int[] result = new int[p.Length];
            for (int i = 0; i < p.Length; i++)
            {
                int firstPos = findX(p, i + 1);
                int secPos = findX(p, firstPos + 1);
                result[i] = secPos + 1;
            }

            return result;
        }

        static int findX(int[] arr, int a)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == a)
                {
                    return i;
                }
            }

            return -1;
        }

        static int jumpingOnClouds(int[] c, int k)
        {
            int energy = 100;
            int i = 0;
            do
            {
                i += k;
                if (i > c.Length - 1)
                {
                    i = i - c.Length;
                }

                if (c[i] == 1)
                {
                    energy -= 3;
                }
                else
                {
                    energy--;
                }

            } while (energy > 0 && i != 0);

            return energy;
        }
        static string appendAndDelete(string s, string t, int k)
        {
            int commonLength = 0;
            int minLength = (int)Math.Min(s.Length, t.Length);
            for (int i = 0; i < minLength; i++)
            {
                if (s[i] == t[i])
                {
                    commonLength++;
                }
                else
                {
                    break;
                }
            }

            if ((s.Length + t.Length - 2 * commonLength) > k)
            {

                return "No";
            }
            else if ((s.Length + t.Length - 2 * commonLength) % 2 == k % 2)
            {
                return "Yes";
            }
            else if ((s.Length + t.Length - k) < 0)
            {
                return "Yes";
            }
            else
            {
                return "No";
            }

        }
        static int squares(int a, int b)
        {
            int numOfSquares = 0;
            int x = 1;
            while (x * x < a) x++;
            while (x * x <= b)
            {
                numOfSquares++;
                x++;
            }


            return numOfSquares;
        }
        static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
        {
            int day, month, year;
            day = d1 - d2;
            month = m1 - m2;
            year = y1 - y2;
            if (year > 0)
            {
                return 10000;
            }
            else
            {
                if (month > 0 && year >= 0)
                {
                    return 500 * month;
                }
                else
                {
                    if (day > 0 && month >= 0 && year >= 0)
                    {
                        return 15 * day;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
        }

        static int[] cutTheSticks(int[] arr)
        {
            List<int> resultHolder = new List<int>();
            List<int> arrToList = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                arrToList.Add(arr[i]);
            }
            arrToList.Sort();
            int min;
            int minIndex = 0;
            int count;
            while (arrToList[arrToList.Count - 1] != 0)
            {
                count = 0;
                min = arrToList[minIndex];
                for (int i = minIndex; i < arrToList.Count; i++)
                {
                    count++;
                    arrToList[i] -= min;
                    if (arrToList[i] == 0)
                    {
                        minIndex = i;
                        minIndex++;
                    }
                }
                resultHolder.Add(count);
            }

            int[] result = new int[resultHolder.Count];
            for (int i = 0; i < resultHolder.Count; i++)
            {
                result[i] = resultHolder[i];
            }

            return result;
        }
        static int chocolateFeast(int n, int c, int m)
        {
            int candies = n / c;
            int wrap = n / c;
            while (wrap >= m)
            {
                int temp = wrap / m;
                candies += temp;
                wrap = wrap - (temp * m) + temp;
            }
            return candies;
        }
        static long repeatedString(string s, long n)
        {
            long count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    count++;
                }
            }
            long temp = n / s.Length;
            long totalA = temp * count;
            long leftOver = n - temp * s.Length;
            for (int i = 0; i < leftOver; i++)
            {
                if (s[i] == 'a')
                {
                    totalA++;
                }
            }

            return totalA;
        }
        static int jumpingOnClouds(int[] c)
        {
            int count = 0;
            int i = 0;
            while (i < c.Length - 1)
            {
                if (i + 2 <= c.Length - 1)
                {
                    if (c[i + 2] == 0)
                    {
                        i += 2;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                }
                count++;
            }

            return count;
        }
        static int equalizeArray(int[] arr)
        {
            int mostAppear = mostFrequent(arr, arr.Length);
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != mostAppear)
                {
                    count++;
                }
            }

            return count;
        }
        static int mostFrequent(int[] arr, int n)
        {

            // Sort the array 
            Array.Sort(arr);

            // find the max frequency using  
            // linear traversal 
            int max_count = 1, res = arr[0];
            int curr_count = 1;

            for (int i = 1; i < n; i++)
            {
                if (arr[i] == arr[i - 1])
                    curr_count++;
                else
                {
                    if (curr_count > max_count)
                    {
                        max_count = curr_count;
                        res = arr[i - 1];
                    }
                    curr_count = 1;
                }
            }

            // If last element is most frequent 
            if (curr_count > max_count)
            {
                max_count = curr_count;
                res = arr[n - 1];
            }

            return res;
        }

        public static long taumBday(int b, int w, int bc, int wc, int z)
        {
            long money = 0;
            long bLong = b;
            long wLong = w;
            long bcLong = bc;
            long wcLong = wc;
            long zLong = z;
            if (wcLong + zLong < bcLong)
            {
                money += (wcLong + zLong) * bLong;
            }
            else
            {
                money += bcLong * bLong;
            }

            if (bcLong + zLong < wcLong)
            {
                money += (bcLong + zLong) * wLong;
            }
            else
            {
                money += wcLong * wLong;
            }
            return money;
        }

        static void kaprekarNumbers(int p, int q)
        {
            List<int> result = new List<int>();
            if (p == 1)
            {
                result.Add(1);
            }
            for (int i = p; i <= q; i++)
            {
                long temp = (long)i * i;
                if (IsEqualOrigin(temp, i))
                {
                    result.Add(i);
                }
            }

            if (result.Count != 0)
            {
                foreach (var VARIABLE in result)
                {
                    Console.Write("{0} ", VARIABLE);
                }
            }
            else
            {
                Console.WriteLine("INVALID RANGE");
            }
        }

        static bool IsEqualOrigin(long num, int original)
        {
            int temp = num.ToString().Length / 2;
            if (temp >= 1)
            {
                int num1 = Convert.ToInt32(num.ToString().Substring(0, temp));
                int num2 = Convert.ToInt32(num.ToString().Substring(temp));
                if (num1 + num2 == original)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        static int binarySearch(int[] arr, int l, int r, int x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;

                // If the element is present at the 
                // middle itself 
                if (arr[mid] == x)
                    return mid;

                // If element is smaller than mid, then 
                // it can only be present in left subarray 
                if (arr[mid] > x)
                    return binarySearch(arr, l, mid - 1, x);

                // Else the element can only be present 
                // in right subarray 
                return binarySearch(arr, mid + 1, r, x);
            }

            // We reach here when element is not present 
            // in array 
            return -1;
        }

        static int beautifulTriplets(int d, int[] arr)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                int num1 = arr[i];
                int num2 = num1 + d;
                int num3 = num2 + d;
                if (num2 > num3 || num3 > arr[arr.Length - 1])
                {
                    break;
                }

                if (binarySearch(arr, 0, arr.Length - 1, num2) == -1)
                {
                    continue;
                }
                if (binarySearch(arr, 0, arr.Length - 1, num3) == -1)
                {
                    continue;
                }

                count++;
            }

            return count;
        }
        static int[] acmTeam(string[] topic)
        {
            int count = 1, max = Int32.MinValue;
            for (int i = 0; i < topic.Length - 1; i++)
            {
                for (int j = i + 1; j < topic.Length; j++)
                {
                    int temp = 0;
                    for (int k = 0; k < topic[i].Length; k++)
                        if (topic[i][k] == '1' || topic[j][k] == '1')
                            temp++;
                    if (temp > max)
                    {
                        max = temp;
                        count = 1;
                    }
                    else if (temp == max)
                        count++;
                }

            }
            int[] ar = { max, count };
            return ar;
        }

        static int minimumDistances(int[] a)
        {
            List<int> sorted = a.ToList();
            List<int> result = new List<int>();
            sorted.Sort();
            for (int i = 0; i < sorted.Count - 1; i++)
            {
                if (sorted[i] == sorted[i + 1])
                {
                    List<int> saveIndex = new List<int>();
                    for (int j = 0; j < a.Length; j++)
                    {
                        if (a[j] == sorted[i])
                        {
                            saveIndex.Add(j);
                        }
                    }
                    result.Add(saveIndex[1] - saveIndex[0]);
                }
            }

            if (result.Count == 0)
            {
                return -1;
            }
            else
            {
                return result.Min();
            }
        }
        static int howManyGames(int p, int d, int m, int s)
        {
            int sum = 0;
            int count = 0;
            while (sum <= s && p < s)
            {
                count++;
                sum += p;
                int temp = p - d;
                if (temp >= m)
                {
                    p = temp;
                }
                else
                {
                    p = m;
                }

                if (sum + p > s)
                {
                    break;
                }
            }
            return count;
        }

        static string pangrams(string s)
        {
            string result = "not pangram";
            int[] alphabet = new int[26];
            int aValue = 97;
            int sum = 0;
            string lowerS = s.ToLower();
            lowerS = Regex.Replace(lowerS, @"\s+", "");
            foreach (var character in lowerS)
            {
                int characterValue = (int)character - aValue;
                int characterData = alphabet[characterValue];
                if (characterData == 0)
                {
                    alphabet[characterValue]++;
                }
            }

            for (int i = 0; i < alphabet.Length; i++)
            {
                sum += alphabet[i];
            }

            if (sum == 26)
            {
                result = "pangram";
            }
            return result;

        }

        public static int workbook(int n, int k, List<int> arr)
        {
            int specialProblem = 0;
            int page = 1;
            bool isNewPage = false;
            for (int i = 0; i < n; i++)
            {
                int problemPerPage = 0;
                int chapterProblem = arr[i];
                for (int j = 1; j <= chapterProblem; j++)
                {
                    problemPerPage++;
                    isNewPage = false;
                    if (j == page)
                    {
                        specialProblem++;
                    }
                    if (problemPerPage == k)
                    {
                        page++;
                        isNewPage = true;
                        problemPerPage = 0;
                    }
                }
                if (!isNewPage)
                {
                    page++;
                }
            }
            return specialProblem;
        }

        public static string fairRations(List<int> B)
        {
            int totalBread = 0;
            int sum = 0;
            foreach (int bread in B)
            {
                sum += bread;
            }
            if (sum % 2 != 0)
            {
                return "NO";
            }
            bool isFair = false;
            do
            {
                for (int i = 0; i < B.Count; i++)
                {
                    if (B[i] % 2 == 0)
                    {
                        continue;
                    }
                    B[i]++;
                    if (i + 1 > B.Count)
                    {
                        B[i - 1]++;
                    }
                    else
                    {
                        B[i + 1]++;
                    }
                    totalBread += 2;
                }
                isFair = true;
                for (int i = 0; i < B.Count; i++)
                {
                    if (B[i] % 2 != 0)
                    {
                        isFair = false;
                        break;
                    }
                }
            } while (!isFair);
            return Convert.ToString(totalBread);
        }

        static int flatlandSpaceStations(int n, int[] c)
        {
            if (n == c.Length) return 0;
            List<int> distances = new List<int>();
            for (int i = 0; i < n; i++)
            {
                int minDistance = int.MaxValue;
                foreach (int station in c)
                {
                    int distance = Math.Abs(station - i);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                    }
                }
                distances.Add(minDistance);
            }
            return distances.Max();
        }

        static List<string> cavityMap(List<string> grid)
        {
            List<string> result = grid;
            if (grid.Count >= 3)
            {
                result = [grid[0]];
                for (int i = 1; i < grid.Count - 1; i++)
                {
                    char[] top = grid[i - 1].ToCharArray();
                    char[] current = grid[i].ToCharArray();
                    char[] bottom = grid[i + 1].ToCharArray();
                    string newLine = string.Empty;
                    for (int j = 0; j < current.Length; j++)
                    {
                        if (j != 0 && j != current.Length - 1)
                        {
                            int topNumber;
                            int currNumber;
                            int bottomNumber;
                            int leftNumber;
                            int rightNumber;
                            if (int.TryParse(current[j].ToString(), out currNumber)
                             && int.TryParse(top[j].ToString(), out topNumber)
                             && int.TryParse(bottom[j].ToString(), out bottomNumber)
                             && int.TryParse(current[j - 1].ToString(), out leftNumber)
                             && int.TryParse(current[j + 1].ToString(), out rightNumber))
                            {
                                if (currNumber > topNumber
                                && currNumber > bottomNumber
                                && currNumber > leftNumber
                                && currNumber > rightNumber)
                                {
                                    current[j] = 'X';
                                }
                            }
                        }
                        newLine += current[j];
                    }
                    result.Add(newLine);
                }
                result.Add(grid[grid.Count - 1]);
            }
            return result;
        }
        #endregion
    }
}
