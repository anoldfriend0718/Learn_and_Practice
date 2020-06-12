#pragma once
#include "vectorheader.h"

template <typename T>
int Vector<T>::Disordered() const
{
    int disordered = 0;
    for (Rank r = 0; r < _size - 1; r++)
    {
        if (_elem[r] > _elem[r + 1])
        {
            disordered++;
        }
    }
    return disordered;
}
