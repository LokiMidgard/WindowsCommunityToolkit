// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Collections.Generic;

namespace AdaptMark.Parsers.Markdown.Inlines
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IInlineContainer"/> class.
    /// </summary>
    public interface IInlineContainer
    {
        /// <summary>
        /// Gets the contents of the inline.
        /// </summary>
        IReadOnlyList<MarkdownInline> Inlines { get; }
        IReadOnlyList<MarkdownInline> IInlineContainer.Inlines => this.Inlines.AsReadonly();
    }
}