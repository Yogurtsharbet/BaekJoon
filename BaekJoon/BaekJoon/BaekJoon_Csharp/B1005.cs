using System;
using System.Collections.Generic;

/// <summary>
/// <para>Q. 각 시간이 정의된 노드에서 특정 노드에 도달하기 까지 걸리는 최소 시간</para>
/// <c>INPUT</c><br/>
/// <see cref="T"/> : Number of Test Case <br/>
/// <see cref="N"/> : Number of Buildings <br/>
/// <see cref="K"/> : Number of Paths <br/>
/// <see cref="G"/> : Goal Building <br/>
/// </summary>
public class B1005 {
    private int T;
    private int N;
    private int K;
    private int G;

    private class Node {
        public int Time;
        public List<Node> Next;
    }

    public void Solution() {
        string[] input;
        Node[] node;

        int.TryParse(Console.ReadLine(), out T);

        for (int i = 0; i < N; i++) {
            input = Console.ReadLine().Split(' ');
            int.TryParse(input[0], out N);
            int.TryParse(input[1], out K);

            node = new Node[N];
            input = Console.ReadLine().Split(' ');
            for (int n = 0; n < N; n++) 
                int.TryParse(input[n], out node[n].Time);

            for (int k = 0; k < K; k++) {
                input = Console.ReadLine().Split(' ');
                int.TryParse(input[0], out int current);
                int.TryParse(input[1], out int next);

                node[current].Next.Add(node[next]);
            }

            int.TryParse(Console.ReadLine(), out G);
            Console.WriteLine(FindPath(node, G));
        }
    }

    private int FindPath(Node[] node, int target) {
        int[] distance = new int[node.Length];
        bool[] visited = new bool[node.Length];

        for (int i = 0; i < node.Length; i++) 
            distance[i] = int.MaxValue;
        distance[0] = node[0].Time;

        for (int i = 0; i < node.Length; i++) {
            int minDistance = int.MaxValue;
            for(int j = 0; j < distance.Length; j++) {
                if (visited[j]) continue;
                minDistance = Math.Min(minDistance, node[i].Time);
            }
        }


    }
}
/*
 * 풀이
 * 다익스트라를 이용한 최단거리 구하기
 * 입력값에 대응하는 각 노드와 간선을 생성
 * 순차 탐색을 통한 다익스트라 구현
**/
