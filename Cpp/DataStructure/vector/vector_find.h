#pragma once
#include "vectorheader.h"
template <typename T>
Rank Vector<T>::Find(const T &target, Rank lo, Rank hi) const //find target among [lo,hi)
{
    if (hi > _size || lo < 0)
    {
        throw std::range_error("The search range is invalid");
    }
    while ((lo < hi--) && (_elem[hi] != target))
        ;
    return hi;
}

template <typename T>
Rank Vector<T>::Find(const T &target) const
{
    return Find(target, 0, _size);
}