#include <iostream>
#include <vector>
#include <unordered_map>
using namespace std;

int solution(vector<int> nums)
{
    unordered_map<int, bool> isExist;
    for (int i = 0; i < nums.size(); i++) {
        isExist[nums[i]] = true;
    }           
    return min(isExist.size(), nums.size() / 2);
}

int main() {
    vector<int> input = { 3, 1, 2, 3 };
    solution(input);
}
