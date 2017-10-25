Project này hướng dẫn cách sử dụng các API của IPSS, include IPSSbridge.dll để sử dụng.
	- Ngôn ngữ: C#
	- .NET 4.5
	- Dùng Visual Studio 2015 để build

Hàm ReadPlate() sẽ trả về 1 class BikePlate, trong đó chứa:
	- text: ký tự biển số
	- hasPlate: giá trị là true nếu tìm thấy biển số trong ảnh. Mục đích để biết bằng tìm được biển số nhưng không đọc được ký tự
	- error: thông báo lỗi
	- isValid: giá trị là true khi tìm được đầy đủ ký tự biển số
	- bitmap: ảnh bitmap đã vẽ hình chữ nhật lên biển số