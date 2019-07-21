#pragma once
#include "vectorheader.h"

template <typename T>
Rank Vector<T>::Insert(const T &value, Rank r)
{
    if (r > _size)
    {
        throw std::range_error("The specified insert rank is greater than the vector size");
    }
    _size++;
    Expand();
    for (Rank i = _size - 1; i > r; i--)
    {
        _elem[i] = _elem[i - 1];
    }
    _elem[r] = value;
    return r;
}

template <typename T>
Rank Vector<T>::PushBack(const T &v)
{
    return Insert(v, _size);
}
