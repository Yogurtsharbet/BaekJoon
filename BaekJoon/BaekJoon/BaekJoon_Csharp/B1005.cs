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
        public bool IsVisited;
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

        // 탐색 시작 Node 설정
        int[] distance = new int[node.Length];
        distance[G] = node[G].Time;

        // 아직 방문하지 않은 노드 중, distance 가 최대인 노드를 방문한다.
        // 방문한 노드의 prev를 탐색하여, current + prev.time 을 distance 에 반영한다.
        for (int i = 0; i < node.Length; i++) {

            // 최대 distance Node 탐색
            int visitIndex = 0;
            int maxDistance = int.MinValue;
            for (int j = 0; j < distance.Length; j++) {
                if (node[j].IsVisited) continue;
                if (maxDistance < distance[j]) {
                    maxDistance = distance[j];
                    visitIndex = j;
                }
            }
            if (maxDistance == int.MinValue) break;

            // 최대 distance Node 방문
            node[visitIndex].IsVisited = true;

            // 최대 distance Node의 Prev 탐색
            int maxTime = int.MinValue;
            foreach (var each in node[visitIndex].Prev) {
                // 이미 방문한 Node의 경우, 방문한 Node Distance의 최대 값을 visit Node에 더해줘야 함
                if (each.IsVisited)
                    maxTime = Math.Max(maxTime, distance[each.Index]);

                // 방문하지 않은 Node의 경우, visit Node + each Node를 distance에 갱신
                else
                    distance[each.Index] =
                        Math.Max(distance[each.Index], each.Time + distance[visitIndex]);
            }
            distance[visitIndex] = Math.Max(distance[visitIndex], node[visitIndex].Time + maxTime);

        }

        // 최대 distance 탐색
        int result = int.MinValue;
        foreach(var each in node[G].Prev) 
            result = Math.Max(result, distance[each.Index]);
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
