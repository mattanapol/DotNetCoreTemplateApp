using System;
namespace TemplateApp.Domain.Models
{
    public class PdfGeneratorInputContent
    {
        /// <summary>
        /// Gets or sets the html.
        /// </summary>
        /// <value>The html.</value>
        public string Html { get; set; }

        /// <summary>
        /// Gets or sets the dpi of file.
        /// </summary>
        /// <value>The dpi.</value>
        public int? DPI { get; set; }

        /// <summary>
        /// Gets or sets the portrait of paper.
        /// </summary>
        /// <value>The portrait.</value>
        public bool? Portrait { get; set; }

        /// <summary>
        /// Gets or sets the width of paper.
        /// </summary>
        /// <value>The width.</value>
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the height of paper.
        /// </summary>
        /// <value>The height.</value>
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the kind of the paper.
        /// </summary>
        /// <value>The kind of the paper.</value>
        public PaperKind PaperKind { get; set; }
    }
}
