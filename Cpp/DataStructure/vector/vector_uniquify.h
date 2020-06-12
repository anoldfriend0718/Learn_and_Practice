#pragma once
#include "vectorheader.h"

template <typename T>
int Vector<T>::uniquify1()
{
    if (Disordered() != 0)
    {
        throw "The vector should be ordered for uniquify method";
    }
    int duplicated = 0;
    int i = 1;
    while (i < _size)
    {
        if (_elem[i - 1] == _elem[i])
        {
            Remove(i);
            duplicated++;
        }
        else
        {
            i++;
        }
    }
    return duplicated;
}

template <typename T>
int Vector<T>::uniquify2()
{
    if (Disordered() != 0)
    {
        throw "The vector should be ordered for uniquify method";
    }
    int i = 1;
    int hi = i;
    int duplicated = 0;
    while (i < _size)
    {
        if (_elem[hi] == _elem[i - 1])
        {
            hi++;
        }
        else
        {
            duplicated += Remove(i, hi);
            i++;
        }
    }
    return duplicated;
}

template <typename T>
int Vector<T>::uniquify3()
{
    if (Disordered() != 0)
    {
        throw "The vector should be ordered for uniquify method";
    }
    int i = 0;
    int j = 0;
    while (++j < _size)
    {
        if (_elem[i] != _elem[j])
            _elem[++i] = _elem[j];
    }
    _size = ++i;
    Shrink();
    return j - i;
}