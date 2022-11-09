using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.GlobalSolution.TagHelpers
{
	public class PassageiroTableTagHelper : TagHelper
	{
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
            output.TagName = "tr";
            output.Content.AppendHtml($"<th>Nome</th>");
            output.Content.AppendHtml($"<th>Cpf</th>");
            output.Content.AppendHtml($"<th>Rg</th>");
            output.Content.AppendHtml($"<th>Email</th>");
            output.Content.AppendHtml($"<th></th>");
        }
	}
}
