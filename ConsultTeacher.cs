using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class ConsultTeacher : Form
    {
        Schedule schedule;
        Appointment appointment;
        public ConsultTeacher()
        {
            InitializeComponent();
            dataGridView2.Visible = false;
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

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            consultTeacher(appointment);

        }
        void consultTeacher(Appointment appointment)
            {
                foreach (var item in schedule.appointments)
                {
                    if (comboBox1.Text == item.teacher.name)
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(dataGridView2);
                        row.Cells[0].Value = item.student.name;
                        row.Cells[1].Value = item.date.ToString("dd-MM-yyyy");
                        row.Cells[2].Value = item.time;
                        row.Cells[3].Value = item.details;
                        dataGridView2.Rows.Add(row);
                    }
                }
            }
    }
}
