#pragma once

namespace InteropDemo
{
	namespace NativeBridge
	{
		public ref class Bridge sealed
		{
		private:
			const Shared::IInteropCallback ^m_callback;

		public:
			Bridge(Shared::IInteropCallback ^callback);
			virtual ~Bridge();
		};
	}
}
