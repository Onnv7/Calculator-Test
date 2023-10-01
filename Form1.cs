using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Buoi07_TinhToan3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtSo1.Text = txtSo2.Text = "0";
            radCong.Checked = true;             //đầu tiên chọn phép cộng
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có thực sự muốn thoát không?",
                                 "Thông báo", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
                this.Close();
        }
        private string ConvertToScientificNotation(double number)
        {
            if (number == 0)
            {
                return "0";
            }
            int exponent = (int)Math.Floor(Math.Log10(Math.Abs(number)));
            double significand = number / Math.Pow(10, exponent);

            string result = $"{Math.Round(significand, 1):0.#}*1E+{exponent}";

            return result;
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            //laygiatriso
            string so1Text = txtSo1.Text;
            string so2Text = txtSo2.Text;
            //T18

            if (so1Text == "" || so2Text == "")
            {
                MessageBox.Show("Vui lòng nhập số vào ô số. Bạn đang để trống", "Lỗi", MessageBoxButtons.OK);
                txtSo1.Text = "";
                txtSo2.Text = "";
                txtSo1.Focus();
                txtSo2.Focus();

                return;
            }

            //tri _T23



            if (!IsValidDecimal(so1Text) || !IsValidDecimal(so2Text))
            {
                MessageBox.Show("Vui lòng nhập số  hợp lệ.Bạn đang nhập sai định dạng", "Lỗi", MessageBoxButtons.OK);
                txtSo1.Text = "";
                txtSo2.Text = "";

                return;
            }
            /////////////////////////////////
            ///





        
            //lấy giá trị của 2 ô số
            double so1, so2, kq = 0;
            so1 = double.Parse(txtSo1.Text);
            so2 = double.Parse(txtSo2.Text);
            //Thực hiện phép tính dựa vào phép toán được chọn
            if (radCong.Checked) kq = so1 + so2;
            else if (radTru.Checked) kq = so1 - so2;
            else if (radNhan.Checked) kq = so1 * so2;
            else if (radChia.Checked)
            {
                if (so2 != 0) kq = so1 / so2;
                else
                {
                    MessageBox.Show("Số chia không được có giá trị là 0 !!!", "Lỗi", MessageBoxButtons.OK);
                    txtSo2.Focus();
                }
            }
            //Hiển thị kết quả lên trên ô kết quả
            if(kq.ToString().Length > 10)
			{
                txtKq.Text = ConvertToScientificNotation(kq);
            }
            else
            {
                Console.WriteLine(kq.ToString());

                txtKq.Text = kq.ToString();

            }
        }

        private void txtSo1_MouseClick(object sender, MouseEventArgs e)
        {
            txtSo1.SelectAll();
        }

        private void txtSo2_MouseClick(object sender, MouseEventArgs e)
        {
            txtSo2.SelectAll();
        }

        private bool IsValidDecimal(string input)
        {
            double result;
            return double.TryParse(input, out result);
        }
    }
}
