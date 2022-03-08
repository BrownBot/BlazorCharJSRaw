using System.Drawing;
using static BlazorApp1.ChartConfigs.ChartColorMap;

namespace BlazorApp1.ChartConfigs
{
    public static class CashFlowM
    {
        private static string _inPlaceColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Avocado]);
        private static string _occupancyColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Taupe]);

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
                        display = true,
                        text = "M - Cash Flows"
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
                        position = "left",
                        beginAtZero = true,
                        ticks = new
                        {
                            format = new
                            {
                                style = "percent",
                                minimumFractionDigits = "1",
                                maximumFractionDigits = "1"
                            },
                            count = "4"
                        }
                    },
                    y1 = new
                    {
                        type = "linear",
                        display = true,
                        position = "right",
                        beginAtZero = true,
                        max = "1.0",
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
                            },
                        }
                    },
                }
            },
            Data = new
            {
                Labels = new[] { "Dec-19", "Mar-20", "Jun-20", "Sep-20", "Dec-20", "Mar-21", "Jun-21", "Sep-21" },
                Datasets = new[]
                {
                    new
                    {
                        Label = "In-Place DY",
                        Data = new[] { "0.012", "0.011", "0.006", "0.006", "0.015", "0.016", "0.013", "0.004" },
                        BackgroundColor = _inPlaceColor,
                        BorderColor = _inPlaceColor,
                        yAxisID = "y",
                        type = "line",
                        order = "0",
                        borderWidth = 6,
                        pointRadius = 2,
                    },
                    new
                    {
                        Label = "Occupancy",
                        Data = new[] { "0.8", "0.83", "0.85", "0.84", "0.845", "0.81", "0.85", "0.90" },
                        BackgroundColor = _occupancyColor,
                        BorderColor = _occupancyColor,
                        yAxisID = "y1",
                        type = "line",
                        order = "1",
                        borderWidth = 6,
                        pointRadius = 2,
                    }
                }
            }
        };
    }
}
