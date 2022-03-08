using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorApp1.Components
{
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
}
