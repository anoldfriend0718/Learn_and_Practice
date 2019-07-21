#pragma once
#include "vectorheader.h"

//complexity O(n2 )
template <typename T>
Vector<T> &Vector<T>::Deduplicate()
{
    Rank r = 1;
    while (r < _size)
    {
        Rank duplicate = Find(_elem[r], 0, r);
        if (duplicate < 0)
        {
            r++;
        }
        else
        {
            Remove(r);
        }
    }
    return *this;
}