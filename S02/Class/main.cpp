#include <iostream>
#include <math.h>

using namespace std;

class Point{
    public:
        double x;
        double y;

        Point(double t, double r){
            x = t;
            y = r;
        }

        Point (double w){
            x = w;
            y = w;
        }

        Point(){

        }

        // Point(Point* a){
        //     x = a->x;
        //     y = a->y;
        // }

        Point(Point& a){
            x = a.x;
            y = a.y;
        }
    
        double calc_dist (Point a){
            double dist = sqrt((a.x - x)*(a.x - x) + (a.y - y)*(a.y - y));
            return dist;
        }

        void print_p (){
            cout << x << ",";
            cout << y << endl;
        }

        ~Point(){
            cout << "destroyed!" << endl;
        }
};

int main(){
    Point p0(9); 

    // Point p1;
    // p1.x = 5;
    // p1.y = 10;
    Point p1(4,5);

    // Point p2;
    // p2.x = 10;
    // p2.y = 35;
    Point p2(10,5);

    Point p3;

    Point p4(p2);

    p1.print_p();
    p0.print_p();
    p3.print_p();
    p4.print_p();
    cout << p1.calc_dist(p2) << endl;

    return 0;
}