#include<iostream>
#include<exception>
#include "vector.h"
int main ( int argc, char* argv[] ) {
   Vector<int> v1(10,5,1);
   std::cout<<"Construnction by specifing the size and const element "<<std::endl;
   v1.PrintOut();
   std::cout<<"Size: "<<v1.Size()<<std::endl;
   std::cout<<"IsEmpty: "<<v1.IsEmpty()<<std::endl;

   int arr[]={1,2,3};
   Vector<int> v2(arr,3);
   std::cout<<"Copy from built-in array"<<std::endl;
   v2.PrintOut();
   std::cout<<"Size: "<<v2.Size()<<std::endl;
   std::cout<<"IsEmpty: "<<v2.IsEmpty()<<std::endl;
   
   auto v3=v2;
   std::cout<<"copy from other vector, v2"<<std::endl;
   v3.PrintOut();
   std::cout<<"value indexing 2: "<<v3[2]<<std::endl;

   int order[]={1,2,3,4,5,6,7,8};
   auto v4=Vector<int>(order,8);
   std::cout<<"Permute v4: ";
   v4.Permute().PrintOut();
   std::cout<<"Permuate v4 again from 2 to 7: ";
   v4.Permute(2,7).PrintOut();
   std::cout<<"Find 8 index from the unsorted v4: "<<v4.Find(8)<<std::endl;
   std::cout<<"Insert 9 at 8: ";
   v4.Insert(9,8);
   v4.PrintOut();
   std::cout<<"Inser 10 at 2: ";
   v4.Insert(10,2);
   v4.PrintOut();
   std::cout<<"Insert value in invalid rank will throw exception: ";
   try
   {
      v4.Insert(10,11);
   }
   catch(const std::range_error& e)
   {
      std::cerr << e.what() << '\n';
   }
   






   return 0;
};