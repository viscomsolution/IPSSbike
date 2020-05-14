#include <tchar.h>
#include <windows.h>
#include <iostream>
#include "IPSSinclude.h"


using namespace IPSS;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int _tmain(int argc, _TCHAR* argv[])
{
	//Init class
	IPSSbike::Init();

	//set write log to txt file in same dir with dll file
	IPSSbike::SetEnableLog(false);

	//you can set input pameter is image path
	BikePlate result = IPSSbike::ReadPlate("8892.jpg");


	//result is a class contain some values
	//.text is plate character
	std::cout<< result.text << "\n";


	//elapsed time read plate
	int ms = result.elapsedMilisecond;


	//error code to diagnostic
	std::cout << result.error << "\n";


	//.hasPlate is true when found plate in image
	bool hasPlate = result.hasPlate;

	//.isValid is true when read enough character
	bool isValid = result.isValid;


	std::cout << result.text;
	getchar();
	return 0;
}
