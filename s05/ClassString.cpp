#include <iostream>
using namespace std;

class String {
private:
    static const int MAX_SIZE = 100;
    char data[MAX_SIZE];
    int length;

public:
    String(const char* str = "") {
        length = 0;
        while (str[length] != '\0' && length < MAX_SIZE - 1) {
            data[length] = str[length];
            length++;
        }
        data[length] = '\0';
    }

    int Size() const {
        return length;
    }

    void Print_string() const {
        for (int i = 0; i < length; i++) {
            cout << data[i];
        }
        cout << endl;
    }

    void append(char c) {
        if (length < MAX_SIZE - 1) {
            data[length] = c;
            length++;
            data[length] = '\0';
        } else {
            cout << "Error" << endl;
        }
    }

    void append(const String other) {
        for (int i = 0; i < other.length && length < MAX_SIZE - 1; i++) {
            data[length] = other.data[i];
            length++;
        }
        data[length] = '\0';
        if (length >= MAX_SIZE - 1) {
            cout << "Error" << endl;
        }
    }

    char* C_str() const {
        return data;
    }
};

int main() {
    String str1("Hello");
    String str2(" World");

    str1.Print_string();
    cout << "Size: " << str1.Size() << endl;

    str1.append('!');
    str1.Print_string();

    str1.append(str2);
    str1.Print_string();

    cout << "C_str: " << str1.C_str() << endl;

    return 0;
}