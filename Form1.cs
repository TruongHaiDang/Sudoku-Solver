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
        private int[] tmp = new int[81];
        public main()
        {
            InitializeComponent();
        }

        private void solveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            int i = 0;
            foreach (Control element in input.Controls.OfType<TextBox>())
            {
                element.Text = (i++).ToString();
            }
        }

        private void solve_matrix_Click(object sender, EventArgs e)
        {
            init_sudoku_matrix();
        }

        public void init_sudoku_matrix()
        {
            int i = 0;
            foreach (Control element in input.Controls.OfType<TextBox>())
            {
                if(element.Text != "")
                {
                    tmp[i] = Convert.ToInt32(element.Text);
                    i++;
                }
                else
                {
                    tmp[i] = 0;
                    i++;
                }
            }
        }
    }
}
