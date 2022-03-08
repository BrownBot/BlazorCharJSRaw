using System.Drawing;
using static BlazorApp1.ChartConfigs.ChartColorMap;

namespace BlazorApp1.ChartConfigs
{
    public static class MultiAxis
    {
        private static string _barBorderColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Avocado]);
        private static string _barFillColor = ToHex(Color.FromArgb(180, ChartColorMap.FillColorDictionary[ChartColor.Avocado]));
        private static string _bar2FillColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Copper]);

        public static object Config => new
        {
            type = "line",
            options = new
            {
                maintainAspectRatio = false,
                interaction = new
                {
                    mode = "index",
                    intersect = false
                },
                stacked = false,
                plugins = new
                {
                    title = new
                    {
                        display = false,
                        text = "Rent Roll - Office"
                    },
                    tooltip = new
                    {
                        position = "nearest"
                    },
                    legend = new
                    {
                        display = false
                    }
                },
                scales = new
                {
                    y = new
                    {
                        type = "linear",
                        display = true,
                        position = "left"
                    },
                    y1 = new
                    {
                        type = "linear",
                        display = true,
                        position = "right",
                        // grid line settings
                        grid = new
                        {
                            drawOnChartArea = false, // only want the grid lines for one axis to show up
                        },
                    },
                }
            },
            Data = new
            {
                Labels = new[] { "P1", "P2", "P3" },
                Datasets = new[]
                {
                    new
                    {
                        Label = "Rent PSF",
                        Data = new[] { "10", "5", "20" },
                        BackgroundColor = _barFillColor,
                        BorderColor = _barFillColor,
                        yAxisID = "y",
                        type = "bar",
                        order = "10",
                        pointStyle = "rectRounded",
                        pointRadius = 10,
                        pointHoverRadius = 15,
                        //borderWidth = 2,
                        //borderRadius = 5,
                        //borderSkipped = false,
                    },
                    new
                    {
                        Label = "SF",
                        Data = new[] { "150", "320", "209" },
                        BackgroundColor = _bar2FillColor,
                        BorderColor = "#00000000",
                        yAxisID = "y1",
                        type = "line",
                        order = "0",
                        pointStyle = "rectRounded",
                        pointRadius = 15,
                        pointHoverRadius = 20,
                        //borderWidth = 0,
                        //borderRadius = 0,
                        //borderSkipped = true,

                    }
                }
            }
        };
    }
}
