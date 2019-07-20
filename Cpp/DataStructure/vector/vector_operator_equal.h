#pragma once
#include "vectorheader.h"
template<typename T>
Vector<T>& Vector<T>::operator=(const Vector<T>& v)
{
    if(_size>0) delete[] _elem;
    CopyFrom(v._elem,0,v._size);
    return *this ;
}