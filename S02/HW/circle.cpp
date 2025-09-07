//circle with radius and center coordinates
//calculate the surface area and mohit
//calculate the distance between the two circles
//calculate the distance of a point and the circle's center
//check if the point is in the circle

#include <iostream>
#include <math.h>

using namespace std;

class Point{
    public:
    double x;
    double y;

    Point(double xx, double yy){
        x = xx;
        y = yy;
    }
};

class Circle{
    public:
    double rad;
    double cx;
    double cy;

    Circle(double x, double y, double r){
        cx = x;
        cy = y;
        rad = r;
    }

    double calc_surface(){
        double s = M_PI*rad*rad;
        return s;
    }

    double calc_mohit(){
        double m = M_PI*2*rad;
        return m;
    }

    double dist_circle(Circle c){
        double dist = sqrt((c.cx - cx)*(c.cx - cx) + (c.cy - cy)*(c.cy - cy));
        return dist;
    }

    double dist_point(Point p){
        double dist = sqrt((p.x - cx)*(p.x - cx) + (p.y - cy)*(p.y - cy));
        return dist;
    }

    bool in_circle(Point p){
        if (dist_point(p) <= rad){
            return true;
        }
        return false;
    }

};

int main(){
    Circle c1(-5,5,4);
    Circle c2(3.5,-3,3);
    Point p(10,10);

    cout << "surface area: " << c1.calc_surface() << endl;
    cout << "mohit: " << c1.calc_mohit() << endl;
    cout << "dist to circle2: " << c1.dist_circle(c2) << endl;
    cout << "distance to point: " << c1.dist_point(p) << endl;
    cout << "in circle: " << c1.in_circle(p) << endl;

    return 0;
}