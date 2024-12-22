#include <iostream>
#include <vector>
#include <string>
#include <unordered_set>
using namespace std;

string solution(vector<string> participant, vector<string> completion) {
	unordered_multiset<string> allParticipant(participant.begin(), participant.end());
	for (auto each : completion)
		allParticipant.erase(allParticipant.find(each));
	return *allParticipant.begin();
}

int main() {
	vector<string> participant = { "mislav", "stanko", "mislav", "ana" };
	vector<string> completion = { "stanko", "ana", "mislav" };
	cout << solution(participant, completion);
}
