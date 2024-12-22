using System;

namespace BaekJoon {
    public class Q1003 {
        public void Main() {
            int testCase = int.Parse(Console.ReadLine());

            for (int i = 0; i < testCase; i++) {
                int fiboN = int.Parse(Console.ReadLine());
                int countOne = 0;
                int countZero = 0;

                if (fiboN != 1) countZero = 1;
                for (int j = 0; j < fiboN; j++) countOne++;

                Console.WriteLine($"{countZero} {countOne}");
            }
        }
    }
    public class Q1002 {
        private static Q1002 Ins;

        public void Main() {
            Ins = new Q1002();

            int testCase = int.Parse(Console.ReadLine());
            int[] result = new int[testCase];

            for (int i = 0; i < testCase; i++) {
                string[] inputPositions = Console.ReadLine().Split(' ');
                int[] parsed = new int[inputPositions.Length];
                for (int j = 0; j < parsed.Length; j++)
                    parsed[j] = int.Parse(inputPositions[j]);

                result[i] = Ins.CheckContact(parsed);
            }

            foreach (int each in result)
                Console.WriteLine(each);
        }

        public int CheckContact(int[] points) {
            int distance = (int)GetDistance((points[0], points[1]), (points[3], points[4]));
            int r1 = points[2];
            int r2 = points[5];

            int sum = r1 + r2;
            int dif = r1 > r2 ? r1 - r2 : r2 - r1;

            if (distance == 0) {
                if (r1 == r2) return -1;
                else return 0;
            }
            else if (sum < distance || distance < dif) return 0;
            else if (dif < distance && distance < sum) return 2;
            else return 1;
        }

        public double GetDistance((int x, int y) pos1, (int x, int y) pos2) {
            return Math.Sqrt(Math.Pow(pos2.x - pos1.x, 2) + Math.Pow(pos2.y - pos1.y, 2));
        }
    }
}
