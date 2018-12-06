using System;
using System.Windows.Forms;
using System.Drawing;
using Controller;

namespace View
{
    public class MainWindow : Form
    {
        protected ViewWidget ViewWidget;
		protected NumericUpDown TimeSlider;

		public MainWindow(Universe model)
        {
            ViewWidget = new ViewWidget();
            TimeSlider = new NumericUpDown
            {
                Maximum = 10,
                Minimum = 0
            };

			ViewWidget.Model = model.Map;
			this.Size = new Size(1000, 600);
			TimeSlider.Location = new Point(800, 0);
			TimeSlider.Value = 1;


            this.Controls.Add(ViewWidget.PictureBox);
            this.Controls.Add(TimeSlider);
        }
    }
}
