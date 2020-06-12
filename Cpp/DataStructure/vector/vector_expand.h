#pragma once
#include "vectorheader.h"
template <typename T>
void Vector<T>::Expand()
{
    if (_size < _capacity)
        return;
    if (_capacity < DEFAULT_CAPACITY)
    {
        _capacity = DEFAULT_CAPACITY;
    }
    int *oldElem = _elem;
    delete[] _elem;
    _capacity <<= 1; //expand 2 times of the previous capacity
    _elem = new T[_capacity];
    for (int i = 0; i < _size; i++)
    {
        _elem[i] = oldElem[i];
    }
    delete[] oldElem;
}