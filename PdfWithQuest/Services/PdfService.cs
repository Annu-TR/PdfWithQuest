using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Reflection.Metadata;
using Document = QuestPDF.Fluent.Document;

public class PdfService
{
	public byte[] GenerateSamplePdf()
	{
		var document = Document.Create(container =>
		{
			_ = container.Page(page =>
			{
				page.Size(PageSizes.A4);
				page.Margin(2, Unit.Centimetre);
				page.PageColor(Colors.White);
				page.DefaultTextStyle(x => x.FontSize(20));

				_ = page.Header()
						.Text("Sample PDF Document")
						.SemiBold().FontSize(36).FontColor(Colors.Blue.Medium);

				page.Content()
						.PaddingVertical(1, Unit.Centimetre)
						.Column(x =>
						{
							x.Spacing(20);

							x.Item().Text("Hello from Blazor!")
													.FontSize(24);

							x.Item().Text("This PDF was generated using QuestPDF.")
													.FontSize(16);

							x.Item().Text($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}")
													.FontSize(14).FontColor(Colors.Grey.Medium);

							x.Item().PaddingTop(20).Text("Sample Content:")
													.FontSize(18).SemiBold();

							x.Item().Text("Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
																	 "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. " +
																	 "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris.")
													.FontSize(12).LineHeight(1.5f);
						});

				page.Footer()
						.AlignCenter()
						.Text(x =>
						{
							x.Span("Page ");
							x.CurrentPageNumber();
						});
			});
		});

		return document.GeneratePdf();
	}
}
