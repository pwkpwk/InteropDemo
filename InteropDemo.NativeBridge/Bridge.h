#pragma once

namespace InteropDemo
{
	namespace NativeBridge
	{
		public ref class Bridge sealed
		{
		private:
			Shared::IInteropCallback ^ const m_callback;

		public:
			Bridge(Shared::IInteropCallback ^callback);
			virtual ~Bridge();

			int DoNativeThing(int factor1, int factor2);
			void CallMeBack(System::String ^parameter);
		};
	}
}
