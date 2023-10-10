using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitVisualizer.UI
{
    /// <summary>
    /// Preset Color themes for UI colors
    /// </summary>
    public static class UITheme
    {
        /// <summary>
        /// Theme containing app colors for backgrounds, foregrounds, elements, and text
        /// </summary>
        public struct AppTheme
        {
            public Color AppBackground;
            public Color ElementBackground;
            public Color Border;
            public Color TextSoft;
            public Color TextNormal;
            public Color TextHeader;
            public Color TextSelectable;

        }


        /// <summary>
        /// Dark mode color theme for app with dark blue greys, and light grey text
        /// </summary>
        public static AppTheme DarkTheme = new()
        {
            AppBackground = Color.FromArgb(20, 20, 22),
            ElementBackground = Color.FromArgb(38, 38, 40),
            Border = Color.FromArgb(80, 80, 84),
            TextSoft = Color.FromArgb(120, 122, 128),
            TextNormal = Color.FromArgb(180,182,188),
            TextHeader = Color.FromArgb(220,222,228),
            TextSelectable = Color.FromArgb(250,252,255)
        };
        
    }
}
