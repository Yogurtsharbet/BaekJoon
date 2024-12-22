using System;
using System.Collections.Generic;

public class TrieNode {
    public Dictionary<char, TrieNode> child;

    public TrieNode() {
        child = new Dictionary<char, TrieNode>();
    }
}

public class Trie {
    TrieNode root;

    public Trie() {
        root = new TrieNode();
    }

    public void Insert(string data) {
        TrieNode current = root;

        foreach (char eachCharacter in data) {
            if (!current.child.ContainsKey(eachCharacter)) {
                current.child[eachCharacter] = new TrieNode();
            }
            current = current.child[eachCharacter];
        }
    }

    public bool isPrefix(string data) {
        TrieNode current = root;

        foreach (char eachCharacter in data)
            current = current.child[eachCharacter];

        return current.child.Count != 0;
    }
}

public class Program {
    public static void Main(string[] args) {
        Trie trie = new Trie();

        string[] example = {  "97674223", "1195524421" ,"119" };

        foreach (var each in example) {
            trie.Insert(each);
        }

        foreach (var each in example) {
            if (trie.isPrefix(each))
                Console.WriteLine(each + " 는 무언가의 접두어 입니다.");
        }
    }
}