using SkiaSharp;

namespace GitVisualizer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            // ApplicationConfiguration.Initialize();
            // Application.Run(new Form1());

            SKBitmap bmp = new(640, 480);
            using SKCanvas canvas = new(bmp);
            canvas.Clear(SKColor.Parse("#003366"));

            Random rand = new(0);
            SKPaint p1 = new() { Color = SKColors.FloralWhite };

            for (int i = 0; i < 10000; i++)
            {
                SKPoint pot = new(rand.Next(bmp.Width), rand.Next(bmp.Height));
                canvas.DrawPoint(pot, p1);
            }

            SKFileWStream fs = new("points.jpg");
            bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 100);
        }
    }
}