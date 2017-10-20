using Bridge.Html5;
using Bridge.React;

namespace Demo
{
	public static class Program
	{
		private static void Main()
		{
			var container = Document.CreateElement("div");
			Document.Body.AppendChild(container);
			React.Render(
				DOM.Div("This was rendered by React!"),
				container
			);
		}
	}
}
