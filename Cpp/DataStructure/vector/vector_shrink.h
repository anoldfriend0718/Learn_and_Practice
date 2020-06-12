#pragma once
#include "vectorheader.h"

template <typename T>
void Vector<T>::Shrink()
{
    if (_capacity < DEFAULT_CAPACITY << 1)
        return;
    if (_size > _capacity >> 2) //take 25% as the threshold 
        return;
    T *oldElem = _elem;
    _capacity >>= 1;
    _elem = new T[_capacity];
    for (size_t i = 0; i < _size; i++)
    {
        _elem[i] = oldElem[i];
    }
    delete[] oldElem;
}