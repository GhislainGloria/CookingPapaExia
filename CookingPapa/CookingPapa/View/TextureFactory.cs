using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;

namespace View
{
    public static class TextureFactory
    {
		private static Dictionary<string, TextureBrush> Brushes = null;
		private static bool initialized = false;      
		private static TextureBrush MissingBrush;
		public static int TileDimension = 30;

		private static void Init()
		{
			Brushes = new Dictionary<string, TextureBrush>();

			DirectoryInfo d = new DirectoryInfo(Directory.GetCurrentDirectory() + "/../../../../resources/images/");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.jpg"); //Getting Text files

			string tmp = "";
			foreach (FileInfo file in Files)
			{
				// Remove the .jpg at the end
				tmp = file.Name.Substring(0, file.Name.Length - 4);
				Image txture = new Bitmap(Image.FromFile(file.FullName), TileDimension, TileDimension);
				TextureBrush brush = new TextureBrush(txture);
				Brushes.Add(tmp, brush);            
			}

            // Initialize missing texture brush 

			Bitmap bmp = new Bitmap(TileDimension, TileDimension);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Green);
			MissingBrush = new TextureBrush(bmp);

			initialized = true;
		}

        public static TextureBrush CreateBrush(String BrushName)
        {
			if (initialized == false) Init();
            
			if(Brushes.ContainsKey(BrushName))
			{
				return Brushes[BrushName];
			}

			return MissingBrush;         
        }
    }
}
