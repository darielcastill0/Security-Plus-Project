using Secuirty_Plus_Project.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Secuirty_Plus_Project
{
    public partial class Quiz : Form
    {
        string[,] quiz = null;

        int row = 0;

        string Answer = "";

        public Quiz(string[,] questions)
        {
            quiz = questions;
            InitializeComponent();

        }

        private void Quiz_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            Display();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            row++;
            if (row == quiz.GetLength(0) - 1){
                btnNext.Visible = false;
                btnPrevious.Visible = true;
            }
            else{
                btnNext.Visible = true;
                btnPrevious.Visible = true;
            }
            Display();
            Reset();
        }

        private void Display()
        {
            //updates the question display
            try{
                lblQTitle.Text = Wrap(quiz[row, 0], 200);
                radA.Text = "A) " + quiz[row, 1];
                radB.Text = "B)" + quiz[row, 2];
                radC.Text = "C)" + quiz[row, 3];
                radD.Text = "D)" + quiz[row, 4];

                Answer = quiz[row, 5];
            }
            catch(IndexOutOfRangeException){
                row--;
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            row--;
            if (row == 0){
                btnPrevious.Visible = false;
                btnNext.Visible = true;
            }
            else{
                btnPrevious.Visible = true;
                btnNext.Visible = true;
            }
            Reset();
            Display();
        }

        private static string Wrap(string e, int size)
        {
            //Wraps the question text so it is visible
            e = e.TrimStart();
            if (e.Length <= size) return e;
            var nextspace = e.LastIndexOf(' ', size);
            if (-1 == nextspace) nextspace = Math.Min(e.Length, size);
            return e.Substring(0, nextspace) + ((nextspace >= e.Length) ?
            "" : "\n" + Wrap(e.Substring(nextspace), size));
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer(Resources.Yippee);

            if (Answer == "A"){
                radA.ForeColor = Color.Green;
                if (radA.Checked){
                    player.Play();
                }
            }
            else if (Answer == "B"){
                radB.ForeColor = Color.Green;
                if (radB.Checked){
                    player.Play();
                }
            }
            else if (Answer == "C"){
                radC.ForeColor = Color.Green;
                if (radC.Checked){
                    player.Play();
                }
            }
            else if (Answer == "D"){
                radD.ForeColor = Color.Green;
                if (radD.Checked){
                    player.Play();
                }//end if
            }//end if
        }

        private void Reset()
        {
            radA.ForeColor = Color.White;
            radB.ForeColor = Color.White;
            radC.ForeColor = Color.White;
            radD.ForeColor = Color.White;

            radA.Checked = false;
            radB.Checked = false;
            radC.Checked = false;
            radD.Checked = false;

        }
        private void radA_CheckedChanged(object sender, EventArgs e)
        {
            btnCheck.Visible = true;
        }

        private void radB_CheckedChanged(object sender, EventArgs e)
        {
            btnCheck.Visible = true;
        }

        private void radC_CheckedChanged(object sender, EventArgs e)
        {
            btnCheck.Visible = true;

        }

        private void radD_CheckedChanged(object sender, EventArgs e)
        {
            btnCheck.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Form1 main = new Form1();
           // main.Show();
            //Close();
        }
    }
}
