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
    public partial class ConsultTeacherDate : Form
    {
        Schedule schedule;
        Appointment appointment;
        public ConsultTeacherDate()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
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
            dataGridView1.Visible = true;
            consultDate(appointment);
        }

        void consultDate(Appointment appointment) {
            foreach (var item in schedule.appointments )
            {
                if (dateTimePicker1.Value.Date == item.date.Date)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    row.CreateCells(dataGridView1);
                    row.Cells[0].Value = item.student.name;
                    row.Cells[1].Value = item.teacher.name;
                    row.Cells[2].Value = item.time;
                    dataGridView1.Rows.Add(row);
                }
            }
        }
    }
}
