using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IPSS;

namespace Example
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init class
            IPSSbike detector = new IPSSbike();

            //OPTIONs

            //đường dẫn chứa file output, nếu set null hoặc rỗng thì sẽ không save ảnh output
            //set output dir, if output dir is null or empty engine will not save output image
            detector.OutputFoler = @"D:\Result";
                        

            //engine nhận tham số là ảnh hoặc đường dẫn đến ảnh
            //you can set input pameter is bitmap or image path
            BikePlate result = detector.ReadPlate(@"8892.jpg");

            //kết quả trả về là class IPSSresult gồm nhiều thuộc tính
            //.text là các ký tự biển số (phải có key mới trả về kết quả)
            //result is a class contain some values
            //.text is plate character
            label1.Text = result.text;

            //bitmap là hình ảnh kết quả
            //bimap is image has returned
            Bitmap bmp = result.bitmap;
            pictureBox1.Image = bmp;

            //thời gian xử lý
            //elapsed time read plate
            int ms = result.elapsedMilisecond;

            //mã lỗi (nếu có)
            //error code to diagnostic
            string error = result.error;

            //nếu có biển số giá trị là true
            //.hasPlate is true when found plate in image
            bool hasPlate = result.hasPlate;

            //nếu đọc đủ các ký tự thì kết quả là true
            //.isValid is true when read enough character
            bool isValid = result.isValid;            
        }
    }
}
