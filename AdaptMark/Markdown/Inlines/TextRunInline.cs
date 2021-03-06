// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

namespace AdaptMark.Parsers.Markdown.Inlines
{
    /// <summary>
    /// Represents a span containing plain text.
    /// </summary>
    public class TextRunInline : MarkdownInline, IInlineLeaf
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextRunInline"/> class.
        /// </summary>
        public TextRunInline()
            : base(MarkdownInlineType.TextRun)
        {
        }

        /// <summary>
        /// Gets or sets the text for this run.
        /// </summary>
        public string Text { get; set; } = string.Empty;

        /// <summary>
        /// Parses unformatted text.
        /// </summary>
        /// <returns> A parsed text span. Or <c>null</c> if no text could be parsed.</returns>
        internal static TextRunInline? Parse(LineBlock markdown, bool trimStart, bool trimEnd, MarkdownDocument document)
        {
            var output = document.ResolveEscapeSequences(markdown, trimStart, trimEnd).ToString();

            if (string.IsNullOrEmpty(output))
            {
                return null;
            }
            else
            {
                return new TextRunInline { Text = output };
            }
        }

        protected override string StringRepresentation()
        {
            if (Text == null)
            {
                return string.Empty;
            }

            return Text;
        }
    }
}