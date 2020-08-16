using System;
using System.Runtime.InteropServices;
using EmptyCLIWrapper;

namespace MixedWrapper
{
    public class Entity : IDisposable
    {
        #region PInvokes
        //The modifier is static extern. extern means that the function is imported from C/C++.
        //The name of the function should match the name of C/C++ function.
        //The attribute [DllImport] specifies the name of DLL file from which we import the function. Note: DllImport allows you to control almost every aspect of the import, like providing a different .NET method name or specifying the calling convention.
        //The type of parameter name is a .NET type (here: string). P/Invoke automatically converts (also called: marshals) data types from .NET to C/C++ and the other way around.
        [DllImport("PInvoke.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateEntity(IntPtr name, float xPos, float yPos);

        [DllImport("PInvoke.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern void DisposeEntity(IntPtr pObject);

        [DllImport("PInvoke.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern float GetXPosition(IntPtr pObject);

        [DllImport("PInvoke.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern float GetYPosition(IntPtr pObject);

        [DllImport("PInvoke.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern void Move(IntPtr pObject, float deltaX, float deltaY);

        [DllImport("PInvoke.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GetName(IntPtr pObject);
        #endregion PInvokes

        #region DisposePattern
        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool bDisposing)
        {
            if (this.m_Instance != IntPtr.Zero)
            {
                DisposeEntity(this.m_Instance);
                //you must free the unmanaged meomry  as appropriate.
                Marshal.FreeHGlobal(m_Name);
            }
            if (bDisposing)
            {
                GC.SuppressFinalize(this);
            }
        }

        ~Entity()
        {
            Dispose(false);
        }
        #endregion DisposePattern


        public Entity(string name, float xPos, float yPos)
        {
            Console.WriteLine($"Input Name: {name} with the Length:{name.Length}");
            // Copies the contents of a managed String into unmanaged memory, converting into ANSI format as it copies.
            m_Name = Marshal.StringToHGlobalAnsi(name);
            Console.WriteLine($"0) m_Name in PInvokeWrapper ctor is： {m_Name.ToString()}");
            m_Instance = CreateEntity(m_Name, xPos, yPos);
        }

        public float GetXPosition()
        {
            return GetXPosition(this.m_Instance);
        }

        public float GetYPosition()
        {
            return GetYPosition(this.m_Instance);
        }

        public void Move(float deltaX, float deltaY)
        {
            Move(this.m_Instance, deltaX, deltaY);
            if (false)
            {
                var engine = new Engine();
                engine.Run("input");
            }

        }

        public string GetName()
        {
            IntPtr stringPointer = GetName(this.m_Instance);
            Console.WriteLine($"2) stringPointer in GetName() method is： {stringPointer.ToString()}");
            String retrivedString = Marshal.PtrToStringAnsi(stringPointer);
            return retrivedString;
        }
        private IntPtr m_Instance;
        private IntPtr m_Name;
    }
}
