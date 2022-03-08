using System.Drawing;
using static BlazorApp1.ChartConfigs.ChartColorMap;

namespace BlazorApp1.ChartConfigs
{
    public static class RentRoll
    {

        private static string _barBorderColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Avocado]);
        private static string _barWarningColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Copper]);
        private static string _lineFillColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Taupe]);

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
                        text = "Rent Roll"
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
                        ticks = new 
                        {
                            format = new 
                            {
                                style = "percent",
                                minimumFractionDigits = "0",
                                maximumFractionDigits = "0"
                            }
                        }
                    },
                }
            },
            Data = new
            {
                Labels = new[] { "Vacant", "2021", "2022", "2023", "2024", "2025", "2026", "2027", "2028+" },
                Datasets = new[]
                {
                    new
                    {
                        Label = "SF",
                        Data = new[] { "41808", "0", "24031", "21420", "18580", "33094", "51154", "28955", "24014" },
                        BackgroundColor = new [] { _barWarningColor, _barBorderColor, _barBorderColor, _barBorderColor, _barBorderColor, _barBorderColor, _barBorderColor, _barBorderColor, _barBorderColor },
                        BorderColor = _barBorderColor,
                        yAxisID = "y",
                        type = "bar",
                        order = "1",
                        borderWidth = 0,
                        pointRadius = 0,
                    },
                    new
                    {
                        Label = "Cum.",
                        Data = new[] { "0.172", "0.172", "0.271", "0.359", "0.435", "0.571", "0.781", "0.90", "1.0" },
                        BackgroundColor = new [] { _lineFillColor, _lineFillColor, _lineFillColor, _lineFillColor, _lineFillColor, _lineFillColor, _lineFillColor, _lineFillColor, _lineFillColor },
                        BorderColor = _lineFillColor,
                        yAxisID = "y1",
                        type = "line",
                        order = "0",
                        borderWidth = 8,
                        pointRadius = 2,
                    }
                }
            }
        };
    }
}
