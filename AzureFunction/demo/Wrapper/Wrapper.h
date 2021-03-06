#pragma once

#include "./ManagedObject.h"
#include "../Core/Core.h"
using namespace System;
using namespace System::Runtime::InteropServices;


namespace Wrapper {
	public ref class Entity:public ManagedObject<Core::Entity>
	{
	public:
		Entity(String^ name, float xPos, float yPos);
		void Move(float deltaX, float deltaY);
		property float XPosition
		{
		public:
			float get()
			{
				return m_Instance->GetXPos();
			}
		private:
			void set(float value)
			{
			}
		}
		property float YPosition
		{
		public:
			float get()
			{
				return m_Instance->GetYPos();
			}
		private:
			void set(float value)
			{
			}
		}

	private:
		static const char* string_to_char_array(String^ str);

	};
}
