#pragma once
#include"vectorheader.h"
template<typename T>
void Vector<T>::CopyFrom(const T* A,Rank lo,Rank hi)
{
    _capacity=2*(hi-lo);
    _size=hi-lo;
    _elem=new T[_capacity];   
    int i=0;
    while (lo<hi)
    {      
        _elem[i++]=A[lo++];
    }  
}