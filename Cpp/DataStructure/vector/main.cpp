#include<iostream>
#include "vector.h"
int main ( int argc, char* argv[] ) {
   Vector<int> v1(10,5,1);
   std::cout<<"Construnction by specifing the size and const element "<<std::endl;
   v1.PrintOut();
   std::cout<<"Size: "<<v1.size()<<std::endl;
   std::cout<<"IsEmpty: "<<v1.IsEmpty()<<std::endl;

   int arr[]={1,2,3};
   Vector<int> v2(arr,3);
   std::cout<<"Copy from built-in array"<<std::endl;
   v2.PrintOut();
   std::cout<<"Size: "<<v2.size()<<std::endl;
   std::cout<<"IsEmpty: "<<v2.IsEmpty()<<std::endl;
   
   auto v3=v2;
   std::cout<<"copy from other vector, v2"<<std::endl;
   v3.PrintOut();

   return 0;
};