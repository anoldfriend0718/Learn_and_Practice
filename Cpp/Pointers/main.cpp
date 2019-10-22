#include"person.h"
int main(int argc,char* argv[])
{
    auto kate=Person("Kate","Chen",11);
    kate.AddResource();
    auto kate2=kate;
    return 0;
}