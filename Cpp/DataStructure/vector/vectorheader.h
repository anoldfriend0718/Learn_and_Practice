#pragma once
typedef int Rank;
#define DEFAULT_CAPACITY 3
#include <iostream>
#include <exception>
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
    Rank Size() const { return _size; }
    bool IsEmpty() const { return !_size; }
    void PrintOut() const
    {
        for (int i = 0; i < _size; i++)
        {
            std::cout << _elem[i] << ", ";
        }
        std::cout << std::endl;
    }
    Vector<T> &operator=(const Vector<T> &v);
    T &operator[](Rank r) const { return _elem[r]; };
    Vector<T> &Permute();
    Vector<T> &Permute(Rank lo, Rank hi);
    Rank Find(const T &target, Rank lo, Rank hi) const;
    Rank Find(const T &target) const;
    Rank Insert(const T &value, Rank r); //insert value at Rank r
    Rank PushBack(const T &value);       //insert value at the end and return the rank
    int Remove(Rank lo, Rank hi);        //Remove the element among [lo,hi) and return the removed number
    T Remove(Rank r);                    //remove the elemnt at rank r and return the removed element value
    Vector<T> &Deduplicate();            //remove the duplicate elements in this vector
    void Traverse(void (*Visit)(T &));
    int Disordered() const;

protected:
    T *_elem;
    Rank _size;
    int _capacity;
    void CopyFrom(T const *A, Rank lo, Rank hi);
    void Expand();
    void Shrink();
    void Permute(Vector<T> &v, Rank lo, Rank hi);

private:
    void Swap(T &a, T &b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
};