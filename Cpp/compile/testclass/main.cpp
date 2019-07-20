#include <iostream>
#include"test.h"
int main ( int argc, char* argv[] ) {
    auto test=new Test();
    std::cout<<test->func()<<std::endl;
};