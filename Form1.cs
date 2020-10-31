using System;
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
        private bool[,] sudoku_col_matrix = new bool[9, 9];
        private bool[,] sudoku_row_matrix = new bool[9, 9]; 
        private bool[,] sudoku_area_matrix = new bool[9, 9];
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
            //solve_sudoku_maxtrix();
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

        public void check_valid()
        {
            for(int i = 0; i < sudoku_matrix.GetLength(0); i++)
            {
                for (int j = 0; j < sudoku_matrix.GetLength(1); j++)
                {
                    if(sudoku_matrix[i, j] != 0)
                    {
                        sudoku_row_matrix[i, j] = true;
                        sudoku_col_matrix[j, j] = true;
                    }    
                }
            }    
        }

        public void solve_sudoku_maxtrix(int i, int j)
        {
            if(i < 9 && j < 9)
            {
                if(sudoku_matrix[i, j] == 0)
                {
                    for(int k = 1; k <= 9; k++)
                    {

                    }    
                }    
            }  
            else if(i < 9 && j >= 9)
            {

            }    
            else
            {

            }    
        }

        private void Check_result_Click(object sender, EventArgs e)
        {
            MessageBox.Show(sudoku_matrix.ToString());
        }

        private void new_matrix_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Control element in input.Controls.OfType<TextBox>())
            {
                element.Text = (i++).ToString();
            }
        }
    }
}
