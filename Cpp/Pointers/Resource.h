#pragma once
#include <string>
class Resource
{
public:
    Resource(std::string res) : resource(res) {}

private:
    std::string resource;
};