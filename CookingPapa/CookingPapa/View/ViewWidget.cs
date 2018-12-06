using System.Windows.Forms;
using System.Drawing;

namespace View
{
	public class ViewWidget
    {
		public PictureBox PictureBox { get; set; }

		public ViewWidget()
        {
			PictureBox = new PictureBox();
			PictureBox.Paint += new PaintEventHandler(this.PaintPictureBox);
        }

        /**
         * Callback when the picturebox needs to be redrawn
         */
		public void PaintPictureBox(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			// Draw a string on the PictureBox.
            g.DrawString("This is a diagonal line drawn on the control",
                null, System.Drawing.Brushes.Blue, new Point(30, 30));
			
            // Draw a line in the PictureBox.
            g.DrawLine(System.Drawing.Pens.Red, PictureBox.Left, PictureBox.Top,
                PictureBox.Right, PictureBox.Bottom);
		}
    }
}
