using SkiaSharp;

namespace WorkEducation.Models
{
	public class Pixel
	{
		public int _x;
		public int _y;
		
		public SKColor _color;

		public Pixel(int x, int y, SKColor color)
		{
			_x = x;
			_y = y;
			_color = color;
		}
	}
}