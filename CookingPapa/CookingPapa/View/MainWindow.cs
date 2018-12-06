using System;
using System.Windows.Forms;
using System.Drawing;

namespace View
{
    public class MainWindow : Form
    {
        protected ViewWidget ViewWidget;
		protected NumericUpDown TimeSlider;

        public MainWindow()
        {
            ViewWidget = new ViewWidget();
            TimeSlider = new NumericUpDown
            {
                Maximum = 5,
                Minimum = 0
            };

			this.Size = new Size(1000, 600);
			ViewWidget.PictureBox.Size = new Size(800, 600);
			TimeSlider.Location = new Point(800, 0);
			TimeSlider.Value = 1;


            this.Controls.Add(ViewWidget.PictureBox);
            this.Controls.Add(TimeSlider);
        }
    }
}
