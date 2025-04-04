//  Program: Security Plus Csv Reader
//  Date: December 10, 2024
//  Author: Dariel Castillo
//  Purpose: This program reads the csv file sent by Asend Education containing the quiz questions. 

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;
using Microsoft.VisualBasic.FileIO;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Reflection.Emit;
using System.Diagnostics;


namespace Secuirty_Plus_Project
{
    public partial class Form1 : Form
    {
        string file = "";
        public Form1(string file)
        {
            InitializeComponent();
            this.file = file;
        }

        //csv file format: Question, Answer A, Answer B, Answer C, Answer D, Right Answer Choice

        //Every question is 6 elements (question, 4 options, correct answer)

        int row = 0;
        string[] quizes = null; //stores the entire file

        string[,] questions = new string[30, 6]; //stores the generated questions

        List<int> quizStart = new List<int>(); //the beginning of each quiz

        List<int> qNum = new List<int>(); //stores the quiz number

        HashSet<int> exclude = new HashSet<int>(); //numbers already generated

        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            try
            { //reads the csv file
                string temp = null;
                //string file = "C:\\Users\\DarCas816\\OneDrive - Berks Career & Technology Center\\Level 3\\Security Plus Project\\Security-Plus-Project-master\\Security_701_Question_Bank_1.csv";
                string ext = Path.GetExtension(file); //file extension

                //checks the extenstion of the file
                if (ext == ".xlsx")
                {
                    file = Path.ChangeExtension(file, ".csv"); //changes excel spreadsheet to .csv
                }
                else if (ext != ".csv")
                {
                    throw new IndexOutOfRangeException("\"Invalid file \\n Only .xlsx and .csv files are supported\"");
                }//end if

                btnGenerate.Visible = true;

                TextFieldParser csvParser = new TextFieldParser(file);

                //csv settings
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = true;

                //Skips the row with the column names and Quiz identifier 
                csvParser.ReadLine();
                temp = csvParser.ReadLine();


                qNum.Add(temp[5] - '0');
                quizStart.Add(0);
                cboQuiz.Items.Add("Module 1");
                cboQuiz.Items.Add("Quiz " + qNum[(temp[5] - '0') - 1]);

                List<string> data = new List<string>();

                while (!csvParser.EndOfData)
                {
                    string[] records = new string[6];
                    records = csvParser.ReadFields();


                    if (records[1] == "")
                    {  //Skips the row with the column names and Quiz identifier 
                        csvParser.ReadLine();
                        temp = csvParser.ReadLine();

                        qNum.Add(temp[5] - '0'); //gets the quiz number

                        int num = 0;

                        if (Char.IsNumber(temp[6])) //checks if the quiz is a double digit 
                        {
                            qNum.RemoveAt(qNum.Count - 1);

                            num = (temp[5] - '0') * 10 + (temp[6] - '0');

                            qNum.Add(num);
                            cboQuiz.Items.Add("Quiz " + qNum[num - 1]);
                        }
                        else
                        {
                            cboQuiz.Items.Add("Quiz " + qNum[(temp[5] - '0') - 1]);
                            num = qNum[((temp[5] - '0')) - 1];
                        }

                        switch (qNum[num - 1])
                        {
                            case 2: cboQuiz.Items.Add("Module 2"); break;
                            case 4: cboQuiz.Items.Add("Module 3"); break;
                            case 6: cboQuiz.Items.Add("Module 4"); break;
                            case 8: cboQuiz.Items.Add("Module 5"); break;
                            case 11: cboQuiz.Items.Add("Module 6"); break;
                            case 14: cboQuiz.Items.Add(" Module 7"); break;
                            case 16: cboQuiz.Items.Add("Module 8"); break;
                            case 19: cboQuiz.Items.Add("Module 9"); break;

                        }
                        quizStart.Add(data.Count);
                    }
                    else
                    {
                        string[] filtered = new string[6];

                        for (int i = 0; i <= 5; i++)
                        { //filters out the commas
                            data.Add(records[i]);  //Every question is 6 elements (question, 4 options, correct answer)
                        }//end while
                    }//end if
                }//end while


                quizes = data.ToArray();
                csvParser.Close();

                Show();
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Invalid file \n Only .xlsx and .csv files are supported");
            }//end try
        }

        private void btnGenerate_Click(object sender, EventArgs e) //Generates the questions
        {
            exclude.Clear();
            int start = 0;
            int end = 0;

            int quiz = 0;

            int questionTotal = 0;
            try
            {
                string q = cboQuiz.Text;
                if (q[0] == 'Q') { //gets the quiz number from the combo box

                    if (q.Length == 6) {
                        quiz = q[q.Length - 1] - '0';
                    }
                    else {
                        quiz = (q[5] - '0') * 10 + (q[6] - '0');
                    }//end if

                    switch (quiz)
                    { //gets the range of the desired quiz

                        case 1:

                            start = 0;
                            end = quizStart[1] - 1;

                            questionTotal = (end + 1) / 6;

                            break;

                        default:

                            start = quizStart[quiz - 1];

                            if (quiz == quizStart.Count) //if the last quiz is selected
                            {
                                end = quizes.Length;
                                questionTotal = (end - start) / 6;
                            }
                            else
                            {
                                end = quizStart[quiz] - 1;
                                questionTotal = (quizStart[quiz] - start) / 6;

                            }//end if
                            break;
                    }//end switch
                }
                else { //if the user selects a module instead

                    if (q.Length == 8) {
                        quiz = q[q.Length - 1] - '0';
                    }
                    else {
                        quiz = (q[7] - '0') * 10 + (q[8] - '0');
                    }//end if


                    int ogPos = int.Parse(cboQuiz.SelectedIndex.ToString()); //current position 

                    int i = ogPos;

                    string message = "We";

                    while (message[0] != 'M') {

                        i++;

                        if (i > cboQuiz.Items.Count - 1){
                            message = "M";
                        }
                        else{
                            cboQuiz.SelectedIndex = i;
                            message = cboQuiz.SelectedItem.ToString();
                        }
                    }

                    i--;
                    int moduleSize = i - ogPos;

                    cboQuiz.SelectedIndex = ogPos + 1;

                    string temp = "E";

                    temp = cboQuiz.SelectedItem.ToString();

                    int s = 0;

                    if (temp.Length == 6){ //checks if the quiz contains a double digit number
                         s = temp[temp.Length - 1] - '0';
                    }
                    else{
                        s = ((temp[temp.Length - 2] - '0') * 10) + (temp[temp.Length - 1] - '0'); 
                    }
                    
                    if (moduleSize == 2){
                      
                        start = quizStart[s - 1];

                        end = quizStart[s + 1] - 1;

                        questionTotal = (quizStart[s + 1] - start) / 6;
                    }
                    else{ //if module size is 3

                        if (temp == "Quiz 20"){ //if the last module is selected
                            start = quizStart[s - 1];
                            end = quizes.Length;

                            questionTotal = (end - start) / 6;
                        }
                        else{
                            start = quizStart[s - 1];

                            end = quizStart[s + 2] - 1;

                            questionTotal = (quizStart[s + 2] - start) / 6;
                        } //end if
                    }
                }//end if

                int amount = int.Parse(txtQuestions.Text);


                int counter = 0; //loop counter

                if (amount > questionTotal){
                    amount = questionTotal;
                }//end if

                questions = new string[amount, 6];

                while (counter < amount){

                    int rad = 0;

                    do{
                        rad = GiveMeANumber(start, end);

                        if (rad >= end){
                            rad = 1;
                        }//end if
                        exclude.Add(rad);
                    } while (rad % 6 != 0); //end loop

           
                    for (int i = 0; i < 6; i++)
                    { //adds the question to the "questions" 2d array
                        questions[row, i] = quizes[rad + i];
                    }//end for

                    counter++;
                    row++;
                }//end while

                Quiz Form2 = new Quiz(questions, file);

                Form2.ShowDialog();
                exclude.Clear();
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter a valid number");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Number is too large");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Maximum reached");
            }
            catch (IndexOutOfRangeException){
                MessageBox.Show("Please select a quiz");

            }
            catch (Exception)
            {
                MessageBox.Show("Unexpected error");
            }
        } 


        private int GiveMeANumber(int start, int end)
        {
            //generates a random number
            var range = Enumerable.Range(start, end).Where(i => !exclude.Contains(i)); //checks for any duplicates

            var rand = new Random();
            int max = end - start;

            int index = rand.Next(0, max - exclude.Count);

            return range.ElementAt(index);
        }
    }
}
