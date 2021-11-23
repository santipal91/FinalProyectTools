using System;
using System.Collections.Generic;
using System.Text;


namespace WinFormsApp1
{
    class Appointment
    {
        public Student student;
        public Teacher teacher;
        public DateTime date;
        public int time;
        public string details;

        public Appointment(Student student, Teacher teacher, DateTime date, int time, string details)
        {
            this.student = student;
            this.teacher = teacher;
            this.date = date;
            this.time = time;
            this.details = details;
        }
    }
}
