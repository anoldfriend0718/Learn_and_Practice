#include <iostream>
#include <exception>
#include "vector.h"
int main(int argc, char *argv[])
{
   Vector<int> v1(10, 5, 1);
   std::cout << "Construnction by specifing the size and const element " << std::endl;
   v1.PrintOut();
   std::cout << "Size: " << v1.Size() << std::endl;
   std::cout << "IsEmpty: " << v1.IsEmpty() << std::endl;

   int arr[] = {1, 2, 3};
   Vector<int> v2(arr, 3);
   std::cout << "Copy from built-in array" << std::endl;
   v2.PrintOut();
   std::cout << "Size: " << v2.Size() << std::endl;
   std::cout << "IsEmpty: " << v2.IsEmpty() << std::endl;

   auto v3 = v2;
   std::cout << "copy from other vector, v2" << std::endl;
   v3.PrintOut();
   std::cout << "value indexing 2: " << v3[2] << std::endl;

   int order[] = {1, 2, 3, 4, 5, 6, 7, 8};
   auto v4 = Vector<int>(order, 8);
   std::cout << "Permute v4: ";
   v4.Permute().PrintOut();
   std::cout << "Permuate v4 again from 2 to 7: ";
   v4.Permute(2, 7).PrintOut();
   std::cout << "Find 8 index from the unsorted v4: " << v4.Find(8) << std::endl;
   std::cout << "Insert 9 at 8: ";
   v4.Insert(9, 8);
   v4.PrintOut();
   std::cout << "Inser 10 at 2: ";
   v4.Insert(10, 2);
   v4.PrintOut();
   std::cout << "Insert value in invalid rank will throw exception: ";
   try
   {
      v4.Insert(10, 11);
   }
   catch (const std::range_error &e)
   {
      std::cerr << e.what() << '\n';
   }
   std::cout << "Remove the element at Rank 9: " << v4.Remove(9) << std::endl;
   std::cout << "v4: ";
   v4.PrintOut();
   std::cout << "Remove the elements among [2,5): ";
   v4.Remove(2, 5);
   v4.PrintOut();

   int duplicatedArr[] = {1, 2, 2, 1, 3, 4, 5, 4};
   Vector<int> v5(duplicatedArr, 8);
   std::cout << "Duplicate vector v5: ";
   v5.PrintOut();
   std::cout << "DeDuplicate v5: ";
   v5.Deduplicate().PrintOut();

   //function pointer
   void (*increase)(int &a) = [](int &a) { a++; };
   std::cout << "Traverse v5 by increasing element value by 1: ";
   v5.Traverse(increase);
   v5.PrintOut();
   std::cout << "v5 disorder is : " << v5.Disordered() << std::endl;
   std::cout << "v5 pushback 1: ";
   v5.PushBack(1);
   v5.PrintOut();
   std::cout << "new v5 disorder is : " << v5.Disordered() << std::endl;

   int orderedArray[] = {1, 2, 3, 3, 4, 4, 5};
   Vector<int> v6(orderedArray, 7);
   auto duplicatedNum = v6.uniquify3();
   std::cout << "Depulicated num in v6 is " << duplicatedNum << std::endl; //should be 2

   return 0;
};