// CPP.cpp : Defines the entry point for the console application.
//

#include"stdafx.h"
#include <iostream>
using namespace::std;

int main()
{
	int i = 1;
	int*p = &i;
	cout << p << endl;
	const char* str = "Genius";
	cout << (void*)&str[0] << endl;

	system("pause");
	return 0;
}

