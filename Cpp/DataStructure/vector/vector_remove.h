#pragma once
#include "vectorheader.h"

template <typename T>
int Vector<T>::Remove(Rank lo, Rank hi)
{
    if (lo < 0 || hi > _size)
    {
        throw std::range_error("The removed range is invalid");
    }
    int oldsize = _size;
    while (hi < _size)
    {
        _elem[lo++] = _elem[hi++];
    }
    _size = lo;
    Shrink();
    return oldsize - _size;
}

template <typename T>
T Vector<T>::Remove(Rank r)
{
    T element=_elem[r];
    Remove(r,r+1);
    return element;
}