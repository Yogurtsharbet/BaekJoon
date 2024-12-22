#include <iostream>
#include <string>
#include <vector>
#include <unordered_map>
using namespace std;

class TrieNode {
public:
	unordered_map<char, TrieNode*> child;
};

class Trie {
	TrieNode* root;
public:
	Trie() {
		root = new TrieNode();
	}

	void Insert(string data) {
		TrieNode* current = root;
		for (char each : data) {
			if (current->child[each] == nullptr)
				current->child[each] = new TrieNode();
			current = current->child[each];
		}
	}

	bool isPrefix(string data) {
		TrieNode* current = root;
		for (char each : data) {
			current = current->child[each];
		}
		if (current->child.size() != 0)
			return true;
		else
			return false;
	}
};


bool solution(vector<string> phone_book) {
	Trie trie;
	for (auto eachNumber : phone_book) {
		trie.Insert(eachNumber);
	}

	for (auto eachNumber : phone_book) {
		if (trie.isPrefix(eachNumber))
			return false;
	}
	return true;
}

void main() {
	cout << solution({ "12","123","1235","567","88" });
}