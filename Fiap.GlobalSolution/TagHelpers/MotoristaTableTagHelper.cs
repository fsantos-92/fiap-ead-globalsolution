using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Fiap.GlobalSolution.TagHelpers
{
	public class MotoristaTableTagHelper : TagHelper
	{
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "tr";
            output.Content.AppendHtml($"<th>Nome</th>");
            output.Content.AppendHtml($"<th>Email</th>");
            output.Content.AppendHtml($"<th>Data de cadastro</th>");
            output.Content.AppendHtml($"<th>Cadastro ativo</th>");
            output.Content.AppendHtml($"<th>Telefone</th>");
            output.Content.AppendHtml($"<th></th>");
        }
    }
}
