using System.Windows.Forms;
using System.Drawing;
using Controller;
using System;

namespace View
{
    public class ViewWidget
    {
		private int TileSize;
		private const int ViewWidth = 800;
		private const int ViewHeight = 600;
		private Size WorldDimensions;
		private Brush TileBrush;
		private RestaurantMaps _Model;

        public PictureBox PictureBox { get; set; }      
		public RestaurantMaps Model 
		{
			get { return _Model; }
			set {
				_Model = value;
				WorldDimensions = _Model.MapSize;
				TileSize = Math.Min(
					ViewWidth / _Model.MapSize.Width,
					ViewHeight / _Model.MapSize.Height
				);
				TextureFactory.TileDimension = TileSize;
			}
		}

        public ViewWidget()
        {
            PictureBox = new PictureBox();
			PictureBox.Size = new Size(ViewWidth, ViewHeight);
            PictureBox.Paint += new PaintEventHandler(this.PaintPictureBox);

        }

        /**
         * Callback when the picturebox needs to be redrawn
         */
        public void PaintPictureBox(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

			if (Model == null) {
				// Draw a line in the PictureBox.
                g.DrawLine(System.Drawing.Pens.Red, PictureBox.Left, PictureBox.Top,
                    PictureBox.Right, PictureBox.Bottom);

				return;
			}

			for (int i = 0; i < WorldDimensions.Width; i++) {
				for (int j = 0; j < WorldDimensions.Height; j++) {
					TileBrush = TextureFactory.CreateBrush("tile");
					g.FillRectangle(TileBrush, new Rectangle(i * TileSize, j * TileSize, TileSize, TileSize));
				}
			}


        }
    }
}