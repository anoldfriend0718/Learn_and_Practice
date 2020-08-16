#pragma once
#define DLLEXPORT _declspec(dllexport)

namespace Core
{
	class DLLEXPORT Entity
	{
	public:
		const char* m_Name;
		~Entity();
	private:
		float m_XPos, m_YPos;
	public:
		Entity(const char* name, float xPos, float yPos);
		void Move(float deltaX, float deltaY);
		float GetXPos() const { return m_XPos; }
		float GetYPos() const { return m_YPos; }
		const char* GetName() const;
	};
}
