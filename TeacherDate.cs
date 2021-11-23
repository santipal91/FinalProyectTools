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
    public partial class TeacherDate : Form
    {
        RadioButton selectedrb;
        Schedule schedule;
        
        
        public TeacherDate()
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
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentName = textBox1.Text;
            string teacherName = comboBox1.Text;
            DateTime date = dateTimePicker1.Value;
            int time = Int32.Parse(selectedrb.Text);
            string details = textBox2.Text;
         
            Student student = new Student();
            student.name = studentName;
            Teacher teacher = new Teacher();
            teacher.name = teacherName;
            Appointment appointment = new Appointment(student, teacher, date, time, details);
            saveAppointment(appointment);        
        }

        void saveAppointment(Appointment appointment)
        {
            if (isAvailable(appointment))
            {
                schedule.appointments.Add(appointment);
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;

                using (StreamWriter sw = new StreamWriter(@"appointments.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, schedule);
                }
                MessageBox.Show("Cita Guardada");
            }


            else {
                MessageBox.Show("No disponible");
            }
        }

        private Boolean isAvailable(Appointment appointment) {
            foreach (var item in schedule.appointments)
            {
                if (item.time == appointment.time && item.date.Date == appointment.date.Date && item.teacher.name == appointment.teacher.name)
                {
                    return false;
                }     
            }
            return true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            saveSelectedRadioButton(sender);
        }
        private void saveSelectedRadioButton(object sender)
        {
            RadioButton rb = sender as RadioButton;

            if (rb == null)
            {
                MessageBox.Show("Debes seleccionar una Hora");
                return;
            }

            if (rb.Checked)
            {
                selectedrb = rb;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            saveSelectedRadioButton(sender);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            saveSelectedRadioButton(sender);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            saveSelectedRadioButton(sender);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            selectedrb.Checked = false;
            textBox2.Text = "";
        }
    }
}
