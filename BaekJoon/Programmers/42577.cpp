#include <iostream>
#include <string>
#include <vector>
#include <algorithm>
#include <unordered_map>
using namespace std;

bool compareByLength(const string& a, const string& b) {
	return a.size() < b.size();  // 길이가 작은 것부터 오름차순 정렬
}

bool solution_42577(vector<string> phone_book) {
	sort(phone_book.begin(), phone_book.end(), compareByLength);
	unordered_map<int, int> sortIndex;

	for (int i = 0; i < phone_book.size(); i++)
		sortIndex[phone_book[i].size()] = i;

	auto totalLength = phone_book.size();
	for(int i = 0 ; i < totalLength; i++) {
		auto each = phone_book[i];
		auto eachLength = each.size();

		for (int j = sortIndex[eachLength] + 1; j < totalLength; j++) {
			int k;
			for (k = 0; k < eachLength; k++)
				if (each[k] != phone_book[j][k])
					break;
			if (k == eachLength) return false;
		}
	}
	return true;
}

int main() {
	cout << solution_42577({ "123","1003","1010","1004","1234" });
}