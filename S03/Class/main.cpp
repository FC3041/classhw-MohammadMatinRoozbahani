#include <iostream>
#include <string.h>
#include <stdlib.h>

using namespace std;

class Student{
    public:
    int m_stdNum;
    char m_firstName[20];
    char m_lastName[20];
    int m_coursesPassed;
    int m_credtis[40];
    double m_grades[40];
    char* m_courseNames[40];

    Student(int stdnum, const char* fname, const char* lname) {
        m_stdNum = stdnum;
        strcpy(m_firstName, fname);
        strcpy(m_lastName, lname);
        m_coursesPassed = 0;
    }
    

    double calc_GPA(){
        double sumGrade = 0;
        int sumCredit = 0;
        for (int i = 0; i < m_coursesPassed; i++){
            sumGrade += m_credtis[i] * m_grades[i];
            sumCredit += m_credtis[i];
        }
        return sumGrade/sumCredit;
    }

    void list_courses(){
        for (int i = 0; i < m_coursesPassed; i++){
            cout << m_courseNames[i] << ":" << m_credtis[i] << ":" << m_grades[i] << endl;
        }
    }

    void reg_course(int credit, const char* name, double grade){
        m_credtis[m_coursesPassed] = credit;
        m_grades[m_coursesPassed] = grade;
        char* name_copy = new char[strlen(name)+1]; //(char*)malloc(strlen(name)+1);
        strcpy(name_copy, name);
        m_courseNames[m_coursesPassed] = name_copy;
        m_coursesPassed++;
        
    }

    ~Student(){
        for (int i = 0; i < m_coursesPassed; i++){
            delete[] m_courseNames[i];
        }
    }
};

int main(){
    Student s(1,"Hami","jafari");
    s.m_coursesPassed = 0;
    char bufc[20];
    double grade;
    int creds;
    while (true){
        cout << "course name: ";
        cin >> bufc;
        if (*bufc == 'A'){
            break;
        }
        cout << "course credtis: ";
        cin >> creds;
        cout << "course grade: ";
        cin >> grade;
        s.reg_course(creds, bufc, grade);
    }
    s.list_courses();
    cout << s.calc_GPA() << endl;

    return 0;
}
