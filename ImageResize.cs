using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Library.Helpers
{
	public class ImageResize
	{
		public void Resize(string sourcePath, string targetPath, int width, int height)
		{
			Size newImageSize = new Size(width, height);

			System.Drawing.Image image = Image.FromFile(sourcePath);

			float ratio = 0, ratioWidth = (float)newImageSize.Width / image.Width, ratioHeight = (float)newImageSize.Height / image.Height;

			if (ratioHeight < ratioWidth)
				ratio = ratioHeight;
			else
				ratio = ratioWidth;

			Bitmap newImage = new Bitmap((int)(image.Width * ratio), (int)(image.Height * ratio));

			Graphics g = Graphics.FromImage((System.Drawing.Image)newImage);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
			g.DrawImage(image, 0, 0, (int)(image.Width * ratio), (int)(image.Height * ratio));

			newImage.Save(targetPath);
		}
	}
}
