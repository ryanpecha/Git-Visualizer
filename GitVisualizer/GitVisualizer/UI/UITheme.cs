using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            public Color ElementSelected;
            public Color PanelBackground;
            public Color Border;
            public Color TextSoft;
            public Color TextNormal;
            public Color TextHeader;
            public Color TextBright;
            public Color TextSelectable;


        }

        /// <summary>
        /// Dark mode color theme for app with dark blue greys, and light grey text
        /// </summary>
        public static readonly AppTheme DarkTheme = new()
        {
            AppBackground = Color.FromArgb(20, 20, 22),
            ElementBackground = Color.FromArgb(38, 38, 40),
            ElementSelected = Color.FromArgb(150, 115, 255),
            PanelBackground = Color.FromArgb(60,60,62),
            Border = Color.FromArgb(80, 80, 84),
            TextSoft = Color.FromArgb(120, 122, 128),
            TextNormal = Color.FromArgb(180, 182, 188),
            TextHeader = Color.FromArgb(220, 222, 228),
            TextBright = Color.FromArgb(200, 202, 255),
            TextSelectable = Color.FromArgb(250, 252, 255)
        };

        /// <summary>
        /// Blue Dark mode color theme for app with dark blue greys, and light grey text
        /// </summary>
        public static readonly AppTheme BlueThemeDark = new()
        {
            AppBackground = Color.FromArgb(20, 20, 32),
            ElementBackground = Color.FromArgb(38, 38, 50),
            ElementSelected = Color.FromArgb(180, 182, 200),
            PanelBackground = Color.FromArgb(60, 60, 72),
            Border = Color.FromArgb(80, 80, 94),
            TextSoft = Color.FromArgb(120, 122, 138),
            TextNormal = Color.FromArgb(180, 182, 198),
            TextHeader = Color.FromArgb(220, 222, 238),
            TextBright = Color.FromArgb(200, 202, 255),
            TextSelectable = Color.FromArgb(250, 252, 255)
        };

        /// <summary>
        /// Blue Dark mode color theme for app with dark blue greys, and light grey text
        /// </summary>
        public static readonly AppTheme BlueThemeLight = new()
        {
            AppBackground = Color.FromArgb(220, 220, 232),
            ElementBackground = Color.FromArgb(238, 238, 250),
            ElementSelected = Color.FromArgb(100, 100, 200),
            PanelBackground = Color.FromArgb(60, 60, 72),
            Border = Color.FromArgb(80, 80, 94),
            TextSoft = Color.FromArgb(20, 22, 38),
            TextNormal = Color.FromArgb(80, 82, 98),
            TextHeader = Color.FromArgb(120, 122, 138),
            TextBright = Color.FromArgb(200, 202, 255),
            TextSelectable = Color.FromArgb(50, 52, 55)
        };
    }
}
