using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Dev.UI.Site.Extensions
{
    public class EmailTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            
            var content = await output.GetChildContentAsync();
            if (content.GetContent().ToString().Equals("contato"))
            {
                var target = "contato-joao@gmail.com";
                output.Attributes.SetAttribute("href", "mailto:" + target);
                output.Content.SetContent(target);
            }
            else
            {
                var target = "suporte-joao@gmail.com";
                output.Attributes.SetAttribute("href", "mailto:" + target);
                output.Content.SetContent(target);
            }
        }
    }
}
