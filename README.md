# Blazor CharJS Raw
A simple sample project to show you how to implement [ChartJS](https://www.chartjs.org/) charts within a Blazor WASM project. As the name suggests we're not using any Nuget packages with this implementation, we're using the latest javascript version of ChartJS with a tiny bit of javascript interop (one function I promise).

The main advantage of this approach is you can use the ChartJS samples and ducmentation to build chart configurations using the latest features.

## Project Setup
1. Following the [ChartJS.org documentation](https://www.chartjs.org/docs/latest/getting-started/installation.html) add one of the CDN links to your Index.html 

```html
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script src="_framework/blazor.webassembly.js"></script>
    <script src="rawchart.js"></script>
```
2. You'll also note I've added my own "rawchart.js" file, this contains the following function used via JS Interop to load the config. 

```javascript
var charts = new Object();
window.setupChart = (id, config) => {
    var ctx = document.getElementById(id).getContext('2d');
    if (typeof charts[id] !== 'undefined') { charts[id].destroy(); }
    charts[id] = new Chart(ctx, config);
```
The above javascript maintains a list of instantiated charts and destroys them before reinitialising it with a fresh config, things get really weird without it. This also relies on you setting a unique id on each RawChartJS component you use.

## RawChartJS.razor
The component itself is very simple, it's a `<canvas />` where the chart will render with a `<div />` around it to make the chart somewhat responsive, see the [official documentation](https://www.chartjs.org/docs/latest/configuration/responsive.html) for more explanation about this.

The code behind is also very simple.

```c#
    public partial class RawChartJS : ComponentBase
    {
        [Inject] IJSRuntime JSRuntime { get; set; }

        [Parameter] public string Id { get; set; }

        [Parameter] public object Config { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await JSRuntime.InvokeVoidAsync("setupChart", Id, Config);
        }
    }
```
To use the component you set a unique id and and pass in an anonymous type that will serialise into the config strucutre that ChartJS expects.

> Make sure each char has a unique ID parameter set!.

## Creating a Chart Config
This is where we use an AnonymousType to bridge between the strongly typed c# code and loosey goosey world of Javascript and configure the seemingly limitless number of options within Chart.js.

The cool part is you can mostly copy off the official ChartJS documentation, below is a simple example converting the [Getting started](https://www.chartjs.org/docs/latest/getting-started/) sample code.

The follow Javascript builds the config:
```javascript
<script>
  const labels = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
  ];

  const data = {
    labels: labels,
    datasets: [{
      label: 'My First dataset',
      backgroundColor: 'rgb(255, 99, 132)',
      borderColor: 'rgb(255, 99, 132)',
      data: [0, 10, 5, 2, 20, 30, 45],
    }]
  };

  const config = {
    type: 'line',
    data: data,
    options: {}
  };
</script>
```

In c# we do the following:
```c#
public static object Config => new
{
    Type = "line",
    options = new
    {
        maintainAspectRatio = false,
    },
    Data = new
    {
        Datasets = new[]
        {
            new {
                label = "My First dataset",
                backgroundColor = "rgb(255, 99, 132)",
                borderColor = "rgb(255, 99, 132)",
                data = new [] { 0, 10, 5, 2, 20, 30, 45 },
            }

        },
        Labels = new[] 
        {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June"
        }
    }
};
```

They've created variables for the datasets and labels parameters and I've made them inline but you get the idea. 

The `maintainAspectRatio = false,` option is important for the semi responsive rendering to work, I've found a fixed height in a `<div />` surounding the component works well.

```html
<div class="row">
    <div class="col" style="height: 250px">
        <RawChartJS Id="MyFirstLine" Config="@(ChartConfigs.MyFirstLine.Config)" />
    </div>
</div>
```

A blog post on why [here](https://brownbot.com/2022/03/08/using-chart-js-within-a-blazor-wasm-project/). 

Happy charting!
