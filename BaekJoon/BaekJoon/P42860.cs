using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;


public class P42860 {
    public void Main() {
        P42860 p42860 = new P42860();
        Console.WriteLine(p42860.solution("BBABAAAAAAB"));
    }

    public int solution(string name) {
        int answer = 0;
        answer += GetChangeCount(name);
        answer += GetMoveCount(name);

        return answer;
    }

    public int GetChangeCount(string name) {
        var splitedName = name.ToList();
        splitedName.RemoveAll(ch => ch == 'A');
        int[] count = new int[splitedName.Count];

        for (int i = 0; i < count.Length; i++)
            count[i] = splitedName[i] - 'A';

        int result = 0;
        foreach (var each in count)
            result += each > 13 ? 26 - each : each;
        return result;
    }

    public int GetMoveCount(string name) {
        //CircleList<char> circleList = new CircleList<char>();
        //foreach(var each in name) 
        //    circleList.Insert(each);

        //for(int i = 0; i < name.Length; i++) {
        //    if(circleList.Current == 'A') 
        //}
        return 0;
    }
}

public class CircleNode<T> {
    public T item;
    public CircleNode<T> next;
    public CircleNode<T> prev;

    public CircleNode(T item, CircleNode<T> next, CircleNode<T> prev) {
        this.item = item;
        this.next = next;
        this.prev = prev;
    }
}


public class CircleList<T> {
    private CircleNode<T> root;
    private CircleNode<T> current;

    public CircleList() {
        current = root;
    }

    public void Insert(T item) {
        if (root == null) {
            root = new CircleNode<T>(
                item, root, root);
            current = root;
        } 
        else {
            CircleNode<T> node = new CircleNode<T>(
                item, root, current);
            current.next = node;
            root.prev = node;
            current = node;
        }
    }

    public void MoveNext() {
        current = current.next;
    }

    public void MovePrev() {
        current = current.next;
    }

    public T Current { get { return current.item; } }

}