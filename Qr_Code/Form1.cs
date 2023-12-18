using QRCoder;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Qr_Code
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string metin_Code = textBox1.Text;

            // Allow the user to choose an image file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.bmp|All files|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedImagePath = openFileDialog.FileName;

                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(metin_Code, QRCodeGenerator.ECCLevel.Q);
                QRCode qrCode = new QRCode(qrCodeData);

                // Use the selected image dynamically
                Bitmap selectedImage = (Bitmap)Bitmap.FromFile(selectedImagePath);
                Bitmap qrCodeImage = qrCode.GetGraphic(20, Color.Black, Color.White, selectedImage);

                pictureBox1.Image = qrCodeImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string metin_Code = textBox1.Text;

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(metin_Code, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);

            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            pictureBox1.Image = qrCodeImage;

        }
            }
        }
    