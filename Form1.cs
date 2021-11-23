using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Newtonsoft.Json;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Schedule schedule;

        public Form1()
        {
            InitializeComponent();
            LoadJson();
        }
        public void LoadJson()
        {
            string filePath = @"appointments.json";
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                schedule = JsonConvert.DeserializeObject<Schedule>(json);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRest.Visible = false;
            btnMax.Visible = true;
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMax.Visible = false;
            btnRest.Visible = true;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();


        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HourDate_Tick(object sender, EventArgs e)
        {
            lblHour.Text = DateTime.Now.ToLongTimeString();
            lblDate.Text = DateTime.Now.ToString("dd MMMM yyy");
        }

        private void Render(object formContainer)
        {
            while (this.ContainerFirst.Controls.Count > 0)
                this.ContainerFirst.Controls.RemoveAt(0);
            Form containerData = formContainer as Form;
            containerData.TopLevel = false;
            containerData.Dock = DockStyle.Fill;
            this.ContainerFirst.Controls.Add(containerData);
            this.ContainerFirst.Tag = containerData;
            containerData.Show();
        }

        private void btnTeacherDate_Click(object sender, EventArgs e)
        {
            Render(new TeacherDate ());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Render(new ConsultTeacherDate());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Render(new ConsultTeacher());
        }
    }
}
