#pragma once
#include <string>

#ifdef LIB_CPP
#define IPSS_API __declspec(dllexport)
#else
#define IPSS_API __declspec(dllimport)
#endif

namespace IPSS
{
	class BikePlate
	{
	public:
		std::string text;
		std::string error;
		bool isValid = false;
		long elapsedMilisecond;
		bool hasPlate = false;
	};

	class IPSSbike
	{
	public:
		IPSS_API static void Init();
		//write log to file
		IPSS_API static void SetEnableLog(bool enable);
		IPSS_API static bool IsEnableLog();
		IPSS_API static void SetOutputFolder(std::string folder);
		IPSS_API static std::string GetOutputFolder();
		IPSS_API static void SetCropResultImage(bool crop);
		IPSS_API static bool IsCroppingResultImage();
		IPSS_API static void SetSaveInputImage(bool save);
		IPSS_API static bool IsSavingInputImage();
		IPSS_API static void SetOutputFileName(std::string value);
		IPSS_API static bool IsLicense();

		IPSS_API static BikePlate ReadPlate(std::string filePath);

	};
}