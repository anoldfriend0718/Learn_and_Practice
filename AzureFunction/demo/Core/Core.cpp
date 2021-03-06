
// Core.cpp : Defines the exported functions for the DLL application.
//

#include "Core.h"
#include <iostream>
using std::cout;
using std::endl;


Core::Entity::~Entity()
{
		cout << "Delete a Entity object in native codes. " << endl;
}

Core::Entity::Entity(const char * name, float xPos, float yPos)
	:m_Name(name),m_XPos(xPos),m_YPos(yPos)
{
	cout << "Entity object is being instantiated in native codes. " << endl;
}

void Core::Entity::Move(float deltaX, float deltaY)
{
	m_XPos += deltaX;
	m_YPos += deltaY;
	cout<< "Moved " << m_Name << " to (" << m_XPos << ", " << m_YPos << ")." << endl;
}

inline const char * Core::Entity::GetName() const 
{ 
	cout << "1) Name pointer in core.cpp is: " << (void*)&m_Name[0] << endl;
	return m_Name;
}





