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
