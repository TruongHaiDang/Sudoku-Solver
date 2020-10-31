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

namespace Sudoku_Solver
{
    public partial class main : Form
    {
        private int[,] sudoku_matrix = new int[9, 9];
        private int[] arr_tmp = new int[81];
        public main()
        {
            InitializeComponent();
        }

        private void solveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void solve_matrix_Click(object sender, EventArgs e)
        {
            init_sudoku_matrix();
            solve_sudoku_maxtrix(sudoku_matrix, sudoku_matrix.GetLength(0) -1, sudoku_matrix.GetLength(1)-1);
        }

        public void init_sudoku_matrix()
        {
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
            if (col == 9)
            {
                if (row == 8)
                {
                    MessageBox.Show(matrix_array.ToString());
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
            else
            {
                solve_sudoku_maxtrix(matrix_array, row, col + 1);
            }
        }

        private void Check_result_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sudoku_matrix.ToString());
        }

        private void new_matrix_Click(object sender, EventArgs e)
        {
            textBox81.Text = "5";
            textBox54.Text = "3";
            textBox53.Text = "7";
            textBox78.Text = "6";
            textBox77.Text = "1";
            textBox50.Text = "9";
            textBox17.Text = "5";
            textBox48.Text = "9";
            textBox74.Text = "8";
            textBox24.Text = "6";
            textBox45.Text = "8";
            textBox15.Text = "6";
            textBox23.Text = "3";
            textBox42.Text = "4";
            textBox41.Text = "8";
            textBox14.Text = "3";
            textBox22.Text = "1";
            textBox39.Text = "7";
            textBox64.Text = "2";
            textBox21.Text = "6";
            textBox62.Text = "6";
            textBox34.Text = "2";
            textBox60.Text = "8";
            textBox32.Text = "4";
            textBox58.Text = "1";
            textBox11.Text = "9";
            textBox19.Text = "5"; 
            textBox55.Text = "8";
            textBox2.Text = "7";
            textBox1.Text = "9";
        }
    }
}
