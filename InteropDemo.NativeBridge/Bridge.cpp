#include "stdafx.h"
#include "Bridge.h"

using namespace InteropDemo::NativeBridge;
using namespace InteropDemo::Shared;

Bridge::Bridge(IInteropCallback ^callback)
:	m_callback(callback)
{
}

Bridge::~Bridge()
{
}

int Bridge::DoNativeThing(int factor1, int factor2)
{
	HMODULE module = ::LoadLibrary(TEXT("InteropDemo.Native.dll"));

	if (module)
	{
		FARPROC fp = ::GetProcAddress(module, "DoNativeThing");

		if (fp)
		{
			PDONATIVETHING pdnt = reinterpret_cast<PDONATIVETHING>(fp);
			int result = (*pdnt)(factor1, factor2);
		}

		::FreeLibrary(module);
	}
	return 0;// ::DoNativeThing(factor1, factor2);
}

void Bridge::CallMeBack(System::String ^parameter)
{
	m_callback->CallBack(parameter);
}
