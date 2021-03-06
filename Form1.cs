﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Sudoku_Solver
{
    public partial class main : Form
    {
        private int[,] sudoku_matrix = new int[9, 9];
        private int[] arr_tmp = new int[81];
        private bool flag = true;
        public main()
        {
            InitializeComponent();
        }

        private void solveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void solve_matrix_Click(object sender, EventArgs e)
        {
            //backgroundWorker1.RunWorkerAsync();
            init_sudoku_matrix();
            for(int i = 0; i < sudoku_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < sudoku_matrix.GetLength(1); j++)
                {
                    solve_sudoku_maxtrix(sudoku_matrix, i, j);
                }
            }           
        }

        public void init_sudoku_matrix()
        {
            flag = true;
            int i = 0, index = 0;
            foreach (Control element in input.Controls.OfType<TextBox>())
            {
                if(element.Text != "" && element.Text != "0")
                {
                    arr_tmp[i] = Convert.ToInt32(element.Text);
                    i++;
                }
                else
                {
                    arr_tmp[i] = 0;
                    i++;
                }
            }
            for(int j = 0; j < 9; j++)
            {         
                for (int k = 0; k < 9; k++)
                {
                    sudoku_matrix[j, k] = arr_tmp[index];
                    index++;
                    if (index == 81) index = 0;
                }
            }    
        }

        public bool check_valid(int[,] matrix_array, int row, int col, int value)
        {
            for(int i = 0; i < 9; i++)
            {
                if (matrix_array[row, i] == value) return false;
            }
            for (int j = 0; j < 9; j++)
            {
                if (matrix_array[j, col] == value) return false;
            }
            int a = row / 3, b = col / 3;
            for (int i = 3 * a; i < 3 * a + 3; i++)
            {
                for (int j = 3 * b; j < 3 * b + 3; j++)
                {
                    if (matrix_array[i, j] == value) return false;
                }
            }
            return true;
        }

        public void solve_sudoku_maxtrix(int[,] matrix_array, int row, int col)
        {
            int z = 0, index = 0;
            if (col == 9)
            {
                if (row == 8)
                {
                    for (int m = 0; m < 9; m++)
                    {
                        for (int n = 0; n < 9; n++)
                        {
                            arr_tmp[index] = matrix_array[m, n];
                            index++;
                        }
                    }
                    if(index == 81)
                    {
                        foreach (Control element in input.Controls.OfType<TextBox>())
                        {
                            element.Text = arr_tmp[z].ToString();
                            ProcessBar.Value = z;
                            z++;
                        }
                    }      
                    flag = false;  
                }
                else
                {
                    solve_sudoku_maxtrix(matrix_array, row + 1, 0);
                }               
            }
            else if (matrix_array[row, col] == 0)
            {
                for (int k = 1; k <= 9; k++)
                {
                    if (check_valid(matrix_array, row, col, k))
                    {
                        matrix_array[row, col] = k;
                        solve_sudoku_maxtrix(matrix_array, row, col+1);
                        matrix_array[row, col] = 0;
                    }
                }
            }
            else if (col < 9 && flag == true)
            {
                solve_sudoku_maxtrix(matrix_array, row, col + 1);
            }
        }
        
        private void Check_result_Click(object sender, EventArgs e)
        {
            load_sudoku_matrix_from_file();
        }

        private void new_matrix_Click(object sender, EventArgs e)
        {
            load_sudoku_matrix_from_file();
        }

        private void load_sudoku_matrix_from_file()
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            string[] arr_read_file_tmp = new string[81];
            int index = 0;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "./";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.CheckFileExists = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                    arr_read_file_tmp = fileContent.Split(' ');
                    foreach (Control element in input.Controls.OfType<TextBox>())
                    {
                        if (arr_read_file_tmp[index].Trim('\r', '\n') != "0")
                        {
                            element.Text = arr_read_file_tmp[index].Trim('\r', '\n');
                            index++;
                        }
                        else if (arr_read_file_tmp[index].Trim('\r', '\n') == "0")
                        {
                            element.Text = "";
                            index++;
                        }
                    }
                }
            }
        }

        private void checkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            load_sudoku_matrix_from_file();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void speed_ValueChanged(object sender, EventArgs e)
        {
            speed_indicator.Text = speed.Value.ToString();
        }
    }
}
