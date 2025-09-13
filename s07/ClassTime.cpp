#include <iostream>
#include <windows.h>

using namespace std;

class Time {
public:
    Time() {
        startTime = GetTickCount();
    }

    ~Time() {
        long endTime = GetTickCount();
        cout << (endTime - startTime) <<  endl;
    }

private:
    long startTime;
};

int main() {
    {
        Time timer;
        for (int i = 0; i < 1000000; ++i) {
        }
    }
    return 0;
}