#pragma once
typedef int Rank;
#define DEFAULT_CAPACITY 3
#include <iostream>
template <typename T>
class Vector
{
public:
    Vector(int c = DEFAULT_CAPACITY, int s = 0, T v = 0)
    {
        _capacity = c;
        _size = s;
        _elem = new T[c];
        for (int i = 0; i < s; i++)
        {
            _elem[i] = v;
        }
    }
    Vector(const T *A, Rank n) { CopyFrom(A, 0, n); }
    Vector(const T *A, Rank lo, Rank hi) { CopyFrom(A, lo, hi); }
    Vector(const Vector<T> &v) { CopyFrom(v._elem, 0, v._size); }
    Vector(const Vector<T> &v, Rank lo, Rank hi) { CopyFrom(v._elem, lo, hi); }
    ~Vector() { delete[] _elem; }
    Rank size() const { return _size; }
    bool IsEmpty() const { return !_size; }
    void PrintOut() const
    {
        for (int i = 0; i < _size; i++)
        {
            std::cout << _elem[i] << ", ";
        }
        std::cout << std::endl;
    }
    Vector<T> &operator=(const Vector<T>& v);

protected:
    T *_elem;
    Rank _size;
    int _capacity;
    void CopyFrom(T const *A, Rank lo, Rank hi);
};