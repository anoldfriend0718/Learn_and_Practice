test.o:	test.cpp test.h
	g++ -c test.cpp
main.o:	main.cpp 
	g++ -c main.cpp
main:	test.o main.o
	g++ test.o main.o -o main

#makefile has a very stupid relation with tabs, all actions of every rule are identified by tabs