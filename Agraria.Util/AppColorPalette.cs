using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Agraria.Util
{

    public static class AppColorPalette
    {
        // Light color scheme
        public static class Light
        {
            public static readonly Color Background = Color.FromArgb(252, 248, 252);
            public static readonly Color Error = Color.FromArgb(186, 26, 26);
            public static readonly Color ErrorContainer = Color.FromArgb(255, 218, 214);
            public static readonly Color InverseOnSurface = Color.FromArgb(244, 239, 243);
            public static readonly Color InversePrimary = Color.FromArgb(198, 192, 255);
            public static readonly Color InverseSurface = Color.FromArgb(49, 48, 51);
            public static readonly Color OnBackground = Color.FromArgb(28, 27, 30);
            public static readonly Color OnError = Color.FromArgb(255, 255, 255);
            public static readonly Color OnErrorContainer = Color.FromArgb(65, 0, 2);
            public static readonly Color OnPrimary = Color.FromArgb(255, 255, 255);
            public static readonly Color OnPrimaryContainer = Color.FromArgb(68, 63, 125);
            public static readonly Color OnSecondary = Color.FromArgb(255, 255, 255);
            public static readonly Color OnSecondaryContainer = Color.FromArgb(71, 69, 85);
            public static readonly Color OnSurface = Color.FromArgb(28, 27, 30);
            public static readonly Color OnSurfaceVariant = Color.FromArgb(72, 70, 73);
            public static readonly Color OnTertiary = Color.FromArgb(255, 255, 255);
            public static readonly Color OnTertiaryContainer = Color.FromArgb(92, 62, 77);
            public static readonly Color Outline = Color.FromArgb(120, 118, 122);
            public static readonly Color OutlineVariant = Color.FromArgb(202, 199, 210);
            public static readonly Color Primary = Color.FromArgb(92, 87, 151);
            public static readonly Color PrimaryContainer = Color.FromArgb(228, 223, 255);
            public static readonly Color Scrim = Color.FromArgb(0, 0, 0);
            public static readonly Color Secondary = Color.FromArgb(95, 92, 109);
            public static readonly Color SecondaryContainer = Color.FromArgb(228, 224, 244);
            public static readonly Color Surface = Color.FromArgb(252, 248, 252);
            public static readonly Color SurfaceTint = Color.FromArgb(92, 87, 151);
            public static readonly Color SurfaceVariant = Color.FromArgb(229, 225, 229);
            public static readonly Color Tertiary = Color.FromArgb(118, 85, 100);
            public static readonly Color TertiaryContainer = Color.FromArgb(255, 216, 232);
            public static readonly Color SurfaceBright = Color.FromArgb(252, 248, 252);
            public static readonly Color SurfaceDim = Color.FromArgb(221, 217, 220);
            public static readonly Color SurfaceContainer = Color.FromArgb(241, 237, 240);
            public static readonly Color SurfaceContainerHigh = Color.FromArgb(235, 231, 235);
            public static readonly Color SurfaceContainerHighest = Color.FromArgb(229, 225, 229);
            public static readonly Color SurfaceContainerLow = Color.FromArgb(247, 242, 246);
            public static readonly Color SurfaceContainerLowest = Color.FromArgb(255, 255, 255);
        }

        // Dark color scheme
        public static class Dark
        {
            public static readonly Color Background = Color.FromArgb(20, 19, 22);
            public static readonly Color Error = Color.FromArgb(255, 180, 171);
            public static readonly Color ErrorContainer = Color.FromArgb(147, 0, 10);
            public static readonly Color InverseOnSurface = Color.FromArgb(49, 48, 51);
            public static readonly Color InversePrimary = Color.FromArgb(92, 87, 151);
            public static readonly Color InverseSurface = Color.FromArgb(229, 225, 229);
            public static readonly Color OnBackground = Color.FromArgb(229, 225, 229);
            public static readonly Color OnError = Color.FromArgb(105, 0, 5);
            public static readonly Color OnErrorContainer = Color.FromArgb(255, 218, 214);
            public static readonly Color OnPrimary = Color.FromArgb(45, 39, 101);
            public static readonly Color OnPrimaryContainer = Color.FromArgb(228, 223, 255);
            public static readonly Color OnSecondary = Color.FromArgb(48, 47, 62);
            public static readonly Color OnSecondaryContainer = Color.FromArgb(228, 224, 244);
            public static readonly Color OnSurface = Color.FromArgb(229, 225, 229);
            public static readonly Color OnSurfaceVariant = Color.FromArgb(201, 197, 201);
            public static readonly Color OnTertiary = Color.FromArgb(68, 40, 54);
            public static readonly Color OnTertiaryContainer = Color.FromArgb(255, 216, 232);
            public static readonly Color Outline = Color.FromArgb(146, 144, 147);
            public static readonly Color OutlineVariant = Color.FromArgb(77, 74, 86);
            public static readonly Color Primary = Color.FromArgb(198, 192, 255);
            public static readonly Color PrimaryContainer = Color.FromArgb(68, 63, 125);
            public static readonly Color Scrim = Color.FromArgb(0, 0, 0);
            public static readonly Color Secondary = Color.FromArgb(200, 196, 216);
            public static readonly Color SecondaryContainer = Color.FromArgb(71, 69, 85);
            public static readonly Color Surface = Color.FromArgb(20, 19, 22);
            public static readonly Color SurfaceTint = Color.FromArgb(198, 192, 255);
            public static readonly Color SurfaceVariant = Color.FromArgb(72, 70, 73);
            public static readonly Color Tertiary = Color.FromArgb(229, 187, 205);
            public static readonly Color TertiaryContainer = Color.FromArgb(92, 62, 77);
            public static readonly Color SurfaceBright = Color.FromArgb(58, 57, 60);
            public static readonly Color SurfaceDim = Color.FromArgb(20, 19, 22);
            public static readonly Color SurfaceContainer = Color.FromArgb(32, 31, 34);
            public static readonly Color SurfaceContainerHigh = Color.FromArgb(42, 41, 44);
            public static readonly Color SurfaceContainerHighest = Color.FromArgb(53, 52, 55);
            public static readonly Color SurfaceContainerLow = Color.FromArgb(28, 27, 30);
            public static readonly Color SurfaceContainerLowest = Color.FromArgb(14, 14, 16);
        }
    }

}
