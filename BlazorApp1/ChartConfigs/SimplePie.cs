namespace BlazorApp1.ChartConfigs
{
    public static class SimplePie
    {
        public static object Config => new
        {
            Type = "pie",
            Options = new
            {
                Responsive = true,
                Scales = new
                {
                    YAxes = new[]
                    {
                        new 
                        { 
                            Ticks = new 
                            {
                                BeginAtZero=true
                            }
                        }   
                    }
                }
            },
            Data = new
            {
                Datasets = new[]
                    {
                        new {
                            Data = new[] { "1", "2" },
                            BackgroundColor = new[] { "blue", "green" }
                        }
                    },
                Labels = new[] { "Fail", "Ok" }
            }
        };
    }
}
