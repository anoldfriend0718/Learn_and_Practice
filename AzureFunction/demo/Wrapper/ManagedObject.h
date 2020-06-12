#pragma once
namespace Wrapper 
{
	template<class T>
	public ref class ManagedObject
	{
	public:
		ManagedObject(T* instance);
		virtual ~ManagedObject();
		!ManagedObject();
		T* GetInstance() { return m_Instance };
	protected:
		T * m_Instance;
	};

	template<class T>
	inline ManagedObject<T>::ManagedObject(T * instance)
	{
		m_Instance = instance;
	}

	template<class T>
	inline ManagedObject<T>::~ManagedObject()
	{
		if (m_Instance != nullptr)
		{
			Console::WriteLine("The object is diposed in managed codes:~ManagedObject() ");
			delete m_Instance;
		}
	}

	template<class T>
	inline ManagedObject<T>::!ManagedObject()
	{
		if (m_Instance != nullptr)
		{
			Console::WriteLine("The object is diposed in managed codes:!ManagedObject() ");
			delete m_Instance;
		}
	}

}
