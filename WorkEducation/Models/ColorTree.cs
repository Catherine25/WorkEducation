using System;
using System.Collections.Generic;
using WorkEducation.Extensions;

namespace WorkEducation.Models
{
	public class ColorTree
	{
		public Dictionary<float, List<Pixel>> pixelTree;
		private List<Pixel> brushSet;

		public ColorTree()
		{
			Dictionary<float, List<Pixel>>.KeyCollection keys = pixelTree.Keys;
			List<Pixel> pixels = new List<Pixel>();

			foreach (float key in keys)
				pixels.Add(pixelTree[key][0]);

			brushSet = pixels;
		}

		public List<Pixel> CurrentBrushSet => brushSet;

		public void RemoveColor(Pixel pixel)
		{
			float lightest = SKColorExtension.GetLightestFromSKColor(pixel._color);
			List<Pixel> pixels = pixelTree[lightest];

			Console.WriteLine("current branch is {0} length", pixels.Count);
			if (pixels.Count == 1)
			{
				brushSet.Remove(pixel);
				pixelTree.Remove(lightest);

				Console.WriteLine("current branch ended");
			}
			else
			{
				int index = brushSet.IndexOf(pixel);
				brushSet[index] = pixels[1];
				pixels.Remove(pixel);
			}
		}
	}
}