// PInvoke.cpp : Defines the exported functions for the DLL application.
//

#include "PInvoke.h"
#include <stdexcept>
#include <iostream>
DLLEXPORT Core::Entity * PInvoke::CreateEntity(const char * name, float xPos, float yPos)
{
	std::cout<<"Creating a new Entity object in PInvoke codes"<<std::endl;
	return new Core::Entity(name, xPos, yPos);
}

DLLEXPORT void PInvoke::DisposeEntity(Core::Entity * pObject)
{
	if (pObject != nullptr)
	{
		std::cout << "Deleting the Entity object in PInvoke codes" << std::endl;
		delete pObject;
		pObject = nullptr;
	}
}

DLLEXPORT float PInvoke::GetXPosition(Core::Entity * pObject)
{
	if (pObject == nullptr)
	{
		throw std::invalid_argument("pObject is nullprt");
	}
	return pObject->GetXPos();
}

DLLEXPORT float PInvoke::GetYPosition(Core::Entity * pObject)
{
	if (pObject == nullptr)
	{
		throw std::invalid_argument("pObject is nullprt");
	}
	return pObject->GetYPos();
}

DLLEXPORT void PInvoke::Move(Core::Entity * pObject, float deltaX, float deltaY)
{
	if (pObject == nullptr)
	{
		throw std::invalid_argument("pObject is nullprt");
	}
	pObject->Move(deltaX, deltaY);
}

DLLEXPORT const char * PInvoke::GetName(Core::Entity* pObject)
{
	if (pObject == nullptr)
	{
		throw std::invalid_argument("pObject is nullprt");
	}
	return pObject->GetName();
}
