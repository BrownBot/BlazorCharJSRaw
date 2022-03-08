using System.Drawing;

namespace BlazorApp1.ChartConfigs
{
    public static class ChartColorMap
    {
        public enum ChartColor
        {
            Colorless = 0,
            Avocado,
            Emerald,
            Cobalt,
            Slate,
            Taupe,
            Chartreuse,
            Crimson,
            Copper
        }

        public static string ToHex(Color col)
        {
            return $"#{col.R:X2}{col.G:X2}{col.B:X2}{col.A:X2}";
        }

        public static readonly Dictionary<ChartColor, Color> FillColorDictionary =
            new Dictionary<ChartColor, Color>
            {
                [ChartColor.Colorless] = Color.Transparent,
                [ChartColor.Avocado] = Color.FromArgb(76, 159, 139),
                [ChartColor.Emerald] = Color.FromArgb(27, 94, 92),
                [ChartColor.Cobalt] = Color.FromArgb(0, 100, 146),
                [ChartColor.Slate] = Color.FromArgb(202, 206, 215),
                [ChartColor.Taupe] = Color.FromArgb(195, 157, 120),
                [ChartColor.Chartreuse] = Color.FromArgb(165, 205, 36),
                [ChartColor.Crimson] = Color.FromArgb(193, 45, 39),
                [ChartColor.Copper] = Color.FromArgb(169, 82, 40),
            };

        public static readonly Dictionary<ChartColor, Color> FontColorDictionary =
            new Dictionary<ChartColor, Color>
            {
                [ChartColor.Colorless] = Color.Transparent,
                [ChartColor.Avocado] = Color.White,
                [ChartColor.Emerald] = Color.White,
                [ChartColor.Cobalt] = Color.White,
                [ChartColor.Slate] = Color.Black,
                [ChartColor.Taupe] = Color.White,
                [ChartColor.Chartreuse] = Color.Black,
                [ChartColor.Crimson] = Color.White,
                [ChartColor.Copper] = Color.White,
            };
    }
}
