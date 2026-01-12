using Microsoft.AspNetCore.Components;

namespace PodoTama.UI.Models
{
    public class TableModel<TItem>
    {
        public string Title { get; set; } = string.Empty;

        public RenderFragment<TItem> Template { get; set; } = default!;
    }
}
