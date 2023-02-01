#include "pch.h"
#include "CppUnitTest.h"
#include "..\SystemInterface\SystemInterface.h"

using namespace Microsoft::VisualStudio::CppUnitTestFramework;

namespace SystemInterfaceTest
{
	TEST_CLASS(SystemInterfaceTest)
	{
	public:
		
        TEST_METHOD(BasicTest)
        {
            Assert::AreEqual(
                // Expected value:
                0.0,
                // Actual value:
                Test(0.0),
                // Tolerance:
                0.01,
                // Message:
                L"Basic test failed",
                // Line number - used if there is no PDB file:
                LINE_INFO());
        }
	};
}
