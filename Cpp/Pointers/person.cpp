#include "person.h"
#include <iostream>

Person::Person(string firstName, string lastName, int age) : mFirstName(firstName),
                                                             mLastName(lastName), mAge(age),
                                                             ptrResource(nullptr)
{
    std::cout << firstName + " is constructing...." << std::endl;
}

Person::Person(const Person &p)
{
    std::cout << p.mFirstName + " is constructing...." << std::endl;
    mFirstName=p.mFirstName;
    mLastName=p.mLastName;
    ptrResource = new Resource("Resource for " + p.GetName());
}

Person &Person::operator=(const Person &p)
{
    delete ptrResource;
    ptrResource = new Resource("Resource for " + p.GetName());
    return *this;
}

Person::~Person()
{
     std::cout << this->mFirstName + " is deconstructing...." << std::endl;
    delete ptrResource;
}

void Person::AddResource()
{
   
    delete ptrResource;
    ptrResource = new Resource("Resource for " + this->GetName());
}