#include "stdafx.h"
#include "InteropDemo.Native.h"

BOOL APIENTRY DllMain( HMODULE hModule, DWORD  reason, LPVOID )
{
	switch (reason)
	{
	case DLL_PROCESS_ATTACH:
	case DLL_THREAD_ATTACH:
	case DLL_THREAD_DETACH:
	case DLL_PROCESS_DETACH:
		break;
	}

	return TRUE;
}

extern "C"
{
	INT32 WINAPI DoNativeThing(INT32 factor1, INT32 factor2)
	{
		return factor1 * factor2;
	}
}
