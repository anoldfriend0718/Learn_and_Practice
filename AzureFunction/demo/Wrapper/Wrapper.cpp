#include "stdafx.h"

#include "Wrapper.h"

Wrapper::Entity::Entity(String^name, float xPos, float yPos) :
	ManagedObject(new Core::Entity(Wrapper::Entity::string_to_char_array(name)
				 , xPos, yPos))
{
	Console::WriteLine("Creating a new Entity-wrapper object in wrapper codes!");
}
void Wrapper::Entity::Move(float deltaX, float deltaY)
{
	return m_Instance->Move(deltaX, deltaY);
}

const char * Wrapper::Entity::string_to_char_array(String ^ str)
{
	const char* cstr = (const char*)(Marshal::StringToHGlobalAnsi(str)).ToPointer();
	return cstr;
}