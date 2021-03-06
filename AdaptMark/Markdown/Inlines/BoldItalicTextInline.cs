// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using AdaptMark.Parsers.Core;
using AdaptMark.Parsers.Markdown.Helpers;

namespace AdaptMark.Parsers.Markdown.Inlines
{
    /// <summary>
    /// Represents a span containing bold italic text.
    /// </summary>
    public class BoldItalicTextInline : MarkdownInline, IInlineContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoldItalicTextInline"/> class.
        /// </summary>
        public BoldItalicTextInline()
            : base(MarkdownInlineType.Bold)
        {
            this.Inlines = Array.Empty<MarkdownInline>();
        }

        /// <summary>
        /// Gets or sets the contents of the inline.
        /// </summary>
        public IList<MarkdownInline> Inlines { get; set; }

        IReadOnlyList<MarkdownInline> IInlineContainer.Inlines => this.Inlines.AsReadonly();
        /// <summary>
        /// Attempts to parse a bold text span.
        /// </summary>
        public class ParserUnderscore : InlineSourundParser<BoldTextInline>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ParserUnderscore "/> class.
            /// </summary>
            public ParserUnderscore()
                : base("___")
            {
            }

            /// <inheritdoc/>
            protected override BoldTextInline MakeInline(List<MarkdownInline> inlines) => new BoldTextInline
            {
                Inlines = new List<MarkdownInline>
                    {
                        new ItalicTextInline
                        {
                            Inlines = inlines,
                        },
                    },
            };
        }

        /// <summary>
        /// Attempts to parse a bold text span.
        /// </summary>
        public class ParserAsterix : InlineSourundParser<BoldTextInline>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="ParserAsterix"/> class.
            /// </summary>
            public ParserAsterix()
                : base("***")
            {
            }

            /// <inheritdoc/>
            protected override BoldTextInline MakeInline(List<MarkdownInline> inlines) => new BoldTextInline
            {
                Inlines = new List<MarkdownInline>
                    {
                        new ItalicTextInline
                        {
                            Inlines = inlines,
                        },
                    },
            };
        }

        protected override string StringRepresentation()
        {
            if (Inlines == null)
            {
                return string.Empty;
            }

            return "***" + string.Join(string.Empty, Inlines) + "***";
        }
    }
}
