using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fun_With_Line_Patterns
{
    public partial class frmMain : Form
    {
        // Variables
        Pen myPen = new Pen(Color.Black);
        Graphics g;

        // Static Variables
        static int start_x, start_y;
        static int end_x, end_y;
        static int my_angle = 0;
        static int my_length = 0;
        static int my_increment = 0;

        public frmMain()
        {
            InitializeComponent();

            // Get starting point
            start_x = pnlCanvas.Width / 2;
            start_y = pnlCanvas.Height / 2;
        }

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Prepare for drawing
            myPen.Width = 1;
            my_length = Int32.Parse(txtLength.Text);
            g = pnlCanvas.CreateGraphics();

            // Paint canvas
            for (int i = 0; i < Int32.Parse(txtNumberOfLines.Text); i++)
                drawLine();           
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            // Get values from Form
            my_length = Int32.Parse(txtLength.Text);
            my_increment = Int32.Parse(txtIncrement.Text);
            my_angle = Int32.Parse(txtAngle.Text);

            // Get starting point
            start_x = pnlCanvas.Width / 2;
            start_y = pnlCanvas.Height / 2;

            // Refresh canvas
            pnlCanvas.Refresh();
        }

        private void drawLine()
        {
            // Random pen color
            Random randomGen = new Random();
            myPen.Color = Color.FromArgb(randomGen.Next(255), randomGen.Next(255), randomGen.Next(255));

            // Calculate new angle
            my_angle = my_angle + Int32.Parse(txtAngle.Text);

            // Calculate new length
            my_length = my_length + Int32.Parse(txtIncrement.Text);

            // calculate end positions
            end_x = (int)(start_x + Math.Cos(my_angle * .017453292519) * my_length);
            end_y = (int)(start_y + Math.Sin(my_angle * .017453292519) * my_length);

            // Set points to draw
            Point[] points = 
            {
                new Point(start_x, start_y),
                new Point(end_x, end_y)
            };

            // Set new start positions
            start_x = end_x;
            start_y = end_y;

            // Draw
            g.DrawLines(myPen, points);
        }
    }
}
