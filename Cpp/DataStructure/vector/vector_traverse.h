#pragma once
#include "vectorheader.h"

template <typename T>
void Vector<T>::Traverse(void (*Visit)(T &))
{
    for (Rank r = 0; r < _size; r++)
    {
        Visit(_elem[r]);
    }
}