#include <iostream> 
using namespace std;
 
class Shape {
   protected:
      double width, height;
      
   public:
      Shape( int a = 0, int b = 0){
         width = a;
         height = b;
      }
      virtual double area() {
         cout << "Parent class area :" <<endl;
         return 0;
      }
};
class Rectangle: public Shape {
   public:
      Rectangle( double a = 0, double b = 0):Shape(a, b) { }
      
      double area () { 
         cout << "Rectangle class area :" <<endl;
         return (width * height); 
      }
};

class Triangle: public Shape {
   public:
      Triangle( double a = 0, double b = 0):Shape(a, b) { }
      
      double area () { 
         cout << "Triangle class area :" <<endl;
         return (width * height / 2); 
      }
};

class Trapeze: public Shape {
    protected:
        double shorts;

    public:
        Trapeze (double a = 0, double b = 0, double c = 0):Shape(a,b) { 
            shorts = c;
        }
    
    double area () {
        cout << "Trapeze class area :" << endl;
        return ((shorts + width) * height / 2);
    }
};

// Main function for the program
int main() {
   Shape *shape;
   Rectangle rec(10,7);
   Triangle  tri(10,5);
   Trapeze tra(10,5,7);

   // store the address of Rectangle
   shape = &rec;
   
   // call rectangle area.
   cout << shape->area() << endl;

   // store the address of Triangle
   shape = &tri;
   
   // call triangle area.
   cout << shape->area() << endl;

   // store the address of Trapeze
   shape = &tra;

   // call trapeze area.
   cout << shape->area() << endl;
   
   return 0;
}