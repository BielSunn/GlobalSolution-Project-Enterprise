using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GlobalSolution.Project.Web.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        public string? Texto { get; set; }
        public string? Class { get; set; } = "alert alert-success";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!string.IsNullOrEmpty(Texto))
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", Class);
                output.Content.SetContent(Texto);
            }
        }


    }
}
