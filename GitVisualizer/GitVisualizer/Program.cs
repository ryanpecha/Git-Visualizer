using GitVisualizer.UI.UI_Forms;
using SkiaSharp;
using System.Diagnostics;
using GithubSpace;

namespace GitVisualizer
{
    internal static class Program
    {
        
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        ///
        private static readonly Github _github = new();
        private static readonly MainForm _mainForm = new();

        /// <summary>
        /// Github API instance used for handling Github.com requests and communications with Github server.
        /// </summary>
        public static Github Github => _github;

        /// <summary>
        /// Instance for Main WindowsForm Form, where the main app window exists
        /// </summary>
        public static MainForm MainForm => _mainForm;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(_mainForm);
            if (!GVSettings.data.rememberGitHubLogin)
            {
                Debug.WriteLine("User wishes to reset authorization, deleting token...");
                _github.DeleteToken();
                Debug.WriteLine("Token removed, ending program");
            }
            Debug.WriteLine("Program finished");
        }

        private static void DrawSkiaWeb()
        {
            SKBitmap bmp = new(640, 480);
            using SKCanvas canvas = new(bmp);
            canvas.Clear(SKColor.Parse("#003366"));

            Random rand = new(0);
            SKPaint p1 = new() { Color = SKColors.FloralWhite };
            SKPaint p2 = new() { Color = SKColors.Aqua };

            SKPoint prev = new(0, 0);
            for (int i = 0; i < 100; i++)
            {
                SKPoint pot = new(rand.Next(bmp.Width), rand.Next(bmp.Height));
                canvas.DrawCircle(pot, 5, p1);
                canvas.DrawLine(prev, pot, p2);
                prev = pot;
            }

            SKFileWStream fs = new("points.jpg");
            bmp.Encode(fs, SKEncodedImageFormat.Jpeg, quality: 100);
        }
    }
}
