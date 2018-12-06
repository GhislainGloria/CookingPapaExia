using System;
using System.Windows.Forms;

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

            this.Controls.Add(ViewWidget.PictureBox);
            this.Controls.Add(TimeSlider);
        }
    }
}
