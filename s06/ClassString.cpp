#include<iostream>

using namespace std;

class MyStr
{
public:
    int m_size;
    char* m_PChars;

    MyStr() : m_size(0), m_PChars(nullptr) {};

    MyStr(const char* chars)
    {
        int i;
        for (i = 0; chars[i] != '\0'; i++);
        m_size = i + 1;
        m_PChars = (char*)malloc(sizeof(char) * (m_size));
        for (i = 0; i < m_size - 1; i++)
        {
            m_PChars[i] = chars[i];
        }
        m_PChars[m_size - 1] = '\0';
    }

    MyStr(const char* chars, int start, int count)
        : m_size(count + 1)
    {
        m_PChars = (char*)malloc(sizeof(char) * (m_size));
        for (int i = 0; i < count; i++)
        {
            m_PChars[i] = chars[start + i];
        }
        m_PChars[count] = '\0';
    }

    void printStr()
    {
        cout << m_PChars << endl;
    }

    bool checkSubstr(const char* substr)
    {
        if (substr == nullptr || m_PChars == nullptr) return false;
        int subLen = 0;
        while (substr[subLen] != '\0') subLen++;
        for (int i = 0; i < m_size - subLen; i++)
        {
            bool found = true;
            for (int j = 0; j < subLen; j++)
            {
                if (m_PChars[i + j] != substr[j])
                {
                    found = false;
                    break;
                }
            }
            if (found) return true;
        }
        return false;
    }

    int len()
    {
        if (m_PChars == nullptr) return 0;
        int length = 0;
        while (m_PChars[length] != '\0') length++;
        return length;
    }

    void add(const MyStr& other)
    {
        if (other.m_PChars == nullptr) return;
        int otherLen = other.len();
        int newSize = len() + otherLen + 1;
        char* newStr = (char*)malloc(sizeof(char) * newSize);
        for (int i = 0; i < len(); i++)
        {
            newStr[i] = m_PChars[i];
        }
        for (int i = 0; i < otherLen; i++)
        {
            newStr[len() + i] = other.m_PChars[i];
        }
        newStr[newSize - 1] = '\0';
        free(m_PChars);
        m_PChars = newStr;
        m_size = newSize;
    }
};

int main()
{
    MyStr s1;
    MyStr s2("malihe hajihosseini", 7, 12);
    s2.printStr();

    if (s2.checkSubstr("haji"))
    {
        cout << "Substring 'haji' found!" << endl;
    }
    else
    {
        cout << "Substring 'haji' not found!" << endl;
    }

    cout << "Length of s2: " << s2.len() << endl;

    MyStr s3(" is a programmer");
    s2.add(s3);
    s2.printStr();

    return 0;
}