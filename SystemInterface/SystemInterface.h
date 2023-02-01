// SystemIterface.h - Contains declarations of math functions
#pragma once

#ifdef SYSTEMINTERFACE_EXPORTS
#define SYSTEMINTERFACE_API __declspec(dllexport)
#else
#define SYSTEMINTERFACE_API __declspec(dllimport)
#endif

extern "C" SYSTEMINTERFACE_API double Test(double v);