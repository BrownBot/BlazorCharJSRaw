using System.Drawing;
using static BlazorApp1.ChartConfigs.ChartColorMap;

namespace BlazorApp1.ChartConfigs
{
    public static class CashFlowH
    {

        private static string _occupancyColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Avocado]);
        private static string _adrColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Taupe]);
        private static string _revPARColor = ToHex(ChartColorMap.FillColorDictionary[ChartColor.Emerald]);

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
                        text = "H - Cash Flows"
                    },
                    tooltip = new
                    {
                        position = "nearest"
                    },
                    legend = new
                    {
                        display = true
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
                }
            },
            Data = new
            {
                Labels = new[] { "Dec-19", "Mar-20", "Jun-20", "Sep-20", "Dec-20", "Mar-21", "Jun-21", "Sep-21" },
                Datasets = new[]
                {
                    new
                    {
                        Label = "Occupancy",
                        Data = new[] { "80", "80", "100", "100", "70", "90", "105", "95" },
                        BackgroundColor = _occupancyColor,
                        BorderColor = _occupancyColor,
                        type = "line",
                        order = "2",
                        borderWidth = 6,
                        pointRadius = 2,
                    },
                    new
                    {
                        Label = "ADR",
                        Data = new[] { "115", "115", "100", "100", "145", "135", "145", "150" },
                        BackgroundColor = _adrColor,
                        BorderColor = _adrColor,
                        type = "line",
                        order = "1",
                        borderWidth = 6,
                        pointRadius = 2,
                    },
                    new
                    {
                        Label = "RevPAR",
                        Data = new[] { "90", "90", "100", "100", "100", "125", "155", "140" },
                        BackgroundColor = _revPARColor,
                        BorderColor = _revPARColor,
                        type = "line",
                        order = "0",
                        borderWidth = 6,
                        pointRadius = 2,
                    },
                }
            }
        };
    }
}
