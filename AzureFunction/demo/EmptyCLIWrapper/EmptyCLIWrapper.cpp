#include "stdafx.h"

#include "EmptyCLIWrapper.h"

String ^ EmptyCLIWrapper::Engine::Run(String ^ input)
{
	Console::WriteLine("Hello world");
	return "Hello world";
}
