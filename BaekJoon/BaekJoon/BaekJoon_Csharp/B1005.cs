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
        public int Index;
        public int Time;
        public List<Node> Prev;
    }

    public void Solution() {
        string[] input;
        Node[] node;

        int.TryParse(Console.ReadLine(), out T);

        for (int i = 0; i < T; i++) {
            input = Console.ReadLine().Split(' ');
            int.TryParse(input[0], out N);
            int.TryParse(input[1], out K);

            node = new Node[N];
            input = Console.ReadLine().Split(' ');
            for (int n = 0; n < N; n++) {
                node[n] = new Node();
                node[n].Prev = new List<Node>();

                node[n].Index = n;
                int.TryParse(input[n], out node[n].Time);
            }

            for (int k = 0; k < K; k++) {
                input = Console.ReadLine().Split(' ');
                int.TryParse(input[0], out int current);
                int.TryParse(input[1], out int next);

                node[next - 1].Prev.Add(node[current - 1]);
            }

            int.TryParse(Console.ReadLine(), out G);
            Console.WriteLine(FindPath(node, --G));
        }
    }

    private int FindPath(Node[] node, int target) {
        // target Building이 단독으로 건설할 수 있는 경우
        if (node[target].Prev.Count == 0)
            return node[target].Time;
        
        int[] distance = new int[node.Length];
        bool[] visited = new bool[node.Length];
        List<int> firstNodeIndex = new List<int>();

        for (int i = 0; i < node.Length; i++) {
            distance[i] = int.MinValue;
            if (node[i].Prev.Count == 0)
                firstNodeIndex.Add(i);
        }
        distance[G] = node[G].Time;

        // 아직 방문하지 않은 노드 중, distance 가 최소인 노드를 방문한다.
        // 방문한 노드의 prev를 탐색하여, current + prev.time 을 distance 에 반영한다.
        for (int i = 0; i < node.Length; i++) {

            // 최소 distance Node 탐색
            int visitIndex = 0;
            int minDistance = int.MinValue;
            for (int j = 0; j < distance.Length; j++) {
                if (visited[j]) continue;
                if (minDistance < distance[j]) {
                    minDistance = distance[j];
                    visitIndex = j;
                }
            }
            if (minDistance == int.MinValue) break;

            // 최소 distance Node 방문
            visited[visitIndex] = true;
            // 최소 distance Node의 Prev 탐색
            foreach (var each in node[visitIndex].Prev) {
                // distance 갱신
                    distance[each.Index] =
                        Math.Max(distance[each.Index], each.Time + distance[visitIndex]);
            }

        }

        // 종단 노드 중 최소 distance 탐색
        int result = int.MaxValue;
        foreach (var index in firstNodeIndex) {
            if (result > distance[index])
                result = distance[index];
        }
        return result;
    }
}

/*
 * 풀이
 * 다익스트라를 이용한 최단거리 구하기
 * 입력값에 대응하는 각 노드와 간선을 생성
 * 순차 탐색을 통한 다익스트라 구현
 * 
 * 다익스트라의 시작점은 Goal Building 으로 한다.
 * Node 의 Prev가 없는 종단 노드까지의 최단 거리를 구한다.
 * 
**/
