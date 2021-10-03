using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<LighteningParameters>(
				"Осветление/затемнение", 
				(pixel, parameters) => pixel * parameters.Coefficient
				));
			window.AddFilter(new PixelFilter<EmptyParameters>(
				"Ч\\Б эффект",
				(pixel, parameters) => new Pixel((pixel.R + pixel.G + pixel.B) / 3)));
			
			window.AddFilter(new TransformFilter(
				"Отразить по горизонтали",
				size => size,
				(point, size) => new Point(size.Width - point.X - 1, point.Y)));
			window.AddFilter(new TransformFilter(
				"Поворот на 90 градусов",
				size => new Size(size.Height, size.Width),
				(point, size) => new Point(point.Y, point.X)));
			
			window.AddFilter(new TransformFilter<RotationParameters>(
				"Поворот", new RotateTransformer()));
			
			Application.Run (window);
		}
	}
}
