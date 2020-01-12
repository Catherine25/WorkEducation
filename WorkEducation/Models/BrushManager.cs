using SkiaSharp;
using System.Collections.Generic;

namespace WorkEducation.Models
{
	public class BrushManager
	{
		private ImageAnalyzer _imageAnalyzer;
		private ColorTree _colorTree;

		public BrushManager(SKPixmap image)
		{
			_imageAnalyzer = new ImageAnalyzer(image);

			_colorTree = _imageAnalyzer.SortColors();
		}

		public List<Pixel> GetBrushes() => _colorTree.CurrentBrushSet;
	}
}