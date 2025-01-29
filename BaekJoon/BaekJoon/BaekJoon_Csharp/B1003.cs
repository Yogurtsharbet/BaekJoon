using System;
using System.Collections.Generic;

/// <summary>
/// <para> Q. fibonacci(N) 을 호출했을 때 0과 1이 각 몇 번 출력되는지 </para>
/// <c>INPUT</c> <br/>
/// <see cref="T"/> : Number of Test Case <br/>
/// <see cref="N"/> : Number of Fibonacci <br/>
/// </summary>
public class B1003 {
    private Dictionary<int, int> fiboTable;
    private int T;
    private int N;

    public void Solution() {
        fiboTable = new Dictionary<int, int>();
        fiboTable[0] = 0;
        fiboTable[1] = 1;
        Fibo(40);

        T = int.Parse(Console.ReadLine());
        for (int i = 0; i < T; i++) {
            N = int.Parse(Console.ReadLine());
            Console.WriteLine($"{(N == 0 ? 1 : fiboTable[N - 1])} {fiboTable[N]}");
        }
    }

    private int Fibo(int n) {
        if (n == 0) return 0;
        else if (n == 1) return 1;
        else if (!fiboTable.ContainsKey(n))
            fiboTable[n] = Fibo(n - 1) + Fibo(n - 2);
        return fiboTable[n];
    }
}

/* 
 * 풀이
 * N -> 0 ~ 9 까지의 output은 아래와 같다
 * ------------------
 * 1 0
 * 0 1
 * 1 1
 * 1 2
 * 2 3
 * 3 5
 * 5 8
 * 8 13
 * 13 21
 * 21 34
 * ------------------
 * countZero    : Fibo(n-1) 의 값과 동일, n=0일 때 1
 * countOne     : Fibo(n) 의 값과 동일
 * 
 * 문제의 시간제한이 0.25ms 이므로,
 * N의 최대값인 Fibo(40)을 구해서 값을 저장한 뒤
 * 각 input N에 맞는 count 값을 출력
**/
