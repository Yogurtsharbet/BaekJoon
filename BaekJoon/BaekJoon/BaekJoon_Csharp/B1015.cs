using System;

public class B1015 {
    public void Solution() {
        int N = int.Parse(Console.ReadLine());
        string[] input = Console.ReadLine().Split(' ');

        int[] arrA = new int[input.Length];
        int[] index = new int[input.Length];
        int[] result = new int[input.Length];

        for (int i = 0; i < input.Length; i++) {
            arrA[i] = int.Parse(input[i]);
            index[i] = i;
        }

        for (int count = 0; count < arrA.Length; count++) {
            for (int i = 0; i < arrA.Length - 1; i++) {
                int j = i + 1;
                if (arrA[i] > arrA[j]) {
                    var temp = arrA[i];
                    arrA[i] = arrA[j];
                    arrA[j] = temp;

                    temp = index[i];
                    index[i] = index[j];
                    index[j] = temp;
                }
            }
        }

        for (int i = 0; i < input.Length; i++)
            result[index[i]] = i;
        for (int i = 0; i < input.Length; i++) {
            Console.Write(result[i]);
            if (i < input.Length - 1) Console.Write(' ');
        }
    }
}
// N : 개수
// 입력 : arr[N], 요소 <= 1000
// 출력 : 입력된 배열 arr[N]의 각 요소보다 작은 arr2[N]
//        단, arr2[N]의 요소는 0 ~ N-1 이 하나씩 들어감.
