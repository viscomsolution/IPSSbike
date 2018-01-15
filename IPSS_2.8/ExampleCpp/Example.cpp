#include <tchar.h>
#include <windows.h>
#include <iostream>
#include "IPSSinclude.h"


using namespace IPSS;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int _tmain(int argc, _TCHAR* argv[])
{
	IPSSbike::Init();
	IPSSbike::SetEnableLog(false);


	BikePlate result = IPSSbike::ReadPlate("8892.jpg");


	std::cout << result.text;
	getchar();
	return 0;
}
