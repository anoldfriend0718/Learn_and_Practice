#pragma once
#include "../Core/Core.h"

namespace PInvoke
{
	extern "C" DLLEXPORT Core::Entity* CreateEntity(const char * name, float xPos, float yPos);

	extern "C" DLLEXPORT void DisposeEntity(Core::Entity* pObject);

	extern "C" DLLEXPORT float GetXPosition(Core::Entity* pObject);

	extern "C" DLLEXPORT float GetYPosition(Core::Entity* pObject);

	extern "C" DLLEXPORT void Move(Core::Entity* pObject, float deltaX, float deltaY);

	extern "C" DLLEXPORT const char * GetName(Core::Entity* pObject);



}