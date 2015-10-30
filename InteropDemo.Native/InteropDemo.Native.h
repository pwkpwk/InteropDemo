#pragma once

extern "C"
{
	INT32 WINAPI DoNativeThing(INT32 factor1, INT32 factor2);
	typedef INT32(WINAPI *PDONATIVETHING)(INT32 factor1, INT32 factor2);
}