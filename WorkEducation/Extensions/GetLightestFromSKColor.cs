namespace WorkEducation.Extensions
{
	public static class SKColorExtension
	{
		public static float GetLightestFromSKColor(this SkiaSharp.SKColor color)
		{
			color.ToHsl(out float h1, out float s1, out float l1);

			return l1;
		}
	}
}