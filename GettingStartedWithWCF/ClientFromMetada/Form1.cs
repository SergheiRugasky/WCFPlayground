using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Homework = Homework.Homework;

namespace ClientFromMetada
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var client = new HomeworkServiceClient("BasicHttpBinding_IHomeworkService");
            global::Homework.Homework homework = new global::Homework.Homework();
            homework.Student = "Serghei";
            homework.Task = "WCF";

            textBox1.Text = client.Do(homework);
        }
    }
}
