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
		public delegate void VoidIntDel(int NewMultiplier);   
		public event VoidIntDel TimeScaleChanged; 

		public MainWindow(Universe model)
        {
            ViewWidget = new ViewWidget();
            TimeSlider = new NumericUpDown
            {
                Maximum = 10,
                Minimum = 1
            };

			ViewWidget.Model = model.Map;
			this.Size = new Size(1000, 600);
			this.Text = "CookingPapa EXIA";
			TimeSlider.Location = new Point(800, 0);
			TimeSlider.Value = 1;

			TimeSlider.ValueChanged += TriggerTimeScaleChangedEvent;


            this.Controls.Add(ViewWidget.PictureBox);
            this.Controls.Add(TimeSlider);
        }

		private void TriggerTimeScaleChangedEvent(object sender, EventArgs e)
		{
			Console.WriteLine("Scale changed to {0}", (int)TimeSlider.Value);
			TimeScaleChanged((int)TimeSlider.Value);
		}

		public void RedrawView()
		{
			ViewWidget.PictureBox.Refresh();
		}
    }
}
