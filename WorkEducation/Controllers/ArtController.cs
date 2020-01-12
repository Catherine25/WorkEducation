using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Web.Mvc;
using WorkEducation.Models;

namespace WorkEducation.Controllers
{
	public class ArtController
	{
		[HttpGet]
		public void LoadImage() {

			WebClient client = new WebClient();
			Stream stream = client.OpenRead("https://interactive-examples.mdn.mozilla.net/media/examples/grapefruit-slice-332-332.jpg");
			Bitmap bitmap; bitmap = new Bitmap(stream);

			if (bitmap != null)
				bitmap.Save("test", ImageFormat.Png);

			stream.Flush();
			stream.Close();
			client.Dispose();

			IntPtr handle = bitmap.GetHbitmap();
			SkiaSharp.SKImageInfo info = new SkiaSharp.SKImageInfo(bitmap.Width, bitmap.Height);
			SkiaSharp.SKPixmap image = new SkiaSharp.SKPixmap(info, handle);

			BrushManager brushManager = new BrushManager(image);
			brushManager.GetBrushes();
		}
	}
}