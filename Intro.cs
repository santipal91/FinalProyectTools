using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1;

namespace ProyectoHerramientas
{
    public partial class Intro : Form
    {
        public Intro()
        {
            InitializeComponent();
            timer1.Enabled = true;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Hide();
            Form next = new Form1();
            next.Show();
            timer1.Enabled = false;
            
            
            
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
