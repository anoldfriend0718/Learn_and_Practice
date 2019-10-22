#include <iostream>
#pragma once
#include <string>
#include "Resource.h"
using namespace std;
class Person
{
public:
    Person(string firstName, string lastName, int age);
    Person(const Person &p);
    Person &operator = (const Person &p);
    ~Person();
    void AddResource();
    std::string GetName() const { return mFirstName + " " + mLastName; }

private:
    string mFirstName;
    string mLastName;
    int mAge;
    Resource *ptrResource;

};