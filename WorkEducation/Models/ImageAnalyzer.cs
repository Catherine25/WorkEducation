using SkiaSharp;
using System;
using System.Collections.Generic;
using WorkEducation.Extensions;

namespace WorkEducation.Models
{
	public class ImageAnalyzer
	{
		private SKPixmap _image;
		public Pixel[][] _pixels;
		public ColorTree _colorsByHue;

		private int _width;
		private int _height;

		public ImageAnalyzer(SKPixmap image)
		{
			_image = image;

			_width = _image.Width;
			_height = _image.Height;

			for (int x = 0; x < _width; x++)
			{
				_pixels[x] = new Pixel[_height];

				for (int y = 0; y < _height; y++)
					_pixels[x][y] = new Pixel(x, y, _image.GetPixelColor(x, y));
			}
		}

		public Pixel[][] GetPixels() => _pixels;

		public ColorTree SortColors()
		{
			Console.WriteLine("Running SortColors()");

			for (int x = 0; x < _width; x++)
				for (int y = 0; y < _height; y++)
				{
					Pixel pixel = _pixels[x][y];
					Console.WriteLine("color at [{0},{1}] is {2}", x, y, pixel);

					float hue = pixel._color.Hue;
					Console.WriteLine("color's hue is {0}", hue);

					Console.WriteLine("_colorsByHue.ContainsKey(hue)?");
					if (_colorsByHue.pixelTree.ContainsKey(hue))
					{
						Console.WriteLine("true");

						Console.WriteLine("_colorsByHue[hue].Contains(color)?");
						if(_colorsByHue.pixelTree[hue].Contains(pixel))
						{
							Console.WriteLine("true");

							Console.WriteLine("skipping the color");
						}
						else
						{
							Console.WriteLine("false");

							_colorsByHue.pixelTree[hue].Add(pixel);

							Console.WriteLine("[color {0}] was added to dictionary", pixel);
						}
					}
					else
					{
						Console.WriteLine("false");

						_colorsByHue.pixelTree.Add(hue, new List<Pixel> { pixel });

						Console.WriteLine("[hue {0}, color {1}] were added to dictionary", hue, pixel);
					}
				}

			return _colorsByHue;
		}

		public SKColor GetLightestColor()
		{
			SKColor lightest = SKColor.Empty;
			float l = 0;
			float l2 = 0;

			for (int x = 0; x < _width; x++)
				for (int y = 0; y < _height; y++)
				{
					l2 = SKColorExtension.GetLightestFromSKColor(_pixels[x][y]._color);

					if (l < l2)
					{
						l = l2;
						lightest = _pixels[x][y]._color;
					}
				}

			return lightest;
		}
	}
}