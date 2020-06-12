#pragma once
#include "vectorheader.h"
template <typename T>
void Vector<T>::Permute(Vector<T> &v, Rank lo, Rank hi) //permute v among [lo,hi)
{
    T *temp = v._elem + lo;
    for (size_t i = hi - lo; i > 0; i--)
    {
        Swap(temp[i - 1], temp[rand() % i]);
    }
}

template <typename T>
Vector<T> &Vector<T>::Permute()
{
    Permute(*this, 0, this->Size());
    return *this;
}

template <typename T>
Vector<T> &Vector<T>::Permute(Rank lo, Rank hi)
{
    Permute(*this, lo, hi);
    return *this;
}
