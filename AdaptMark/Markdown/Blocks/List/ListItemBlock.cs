// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using AdaptMark.Markdown.Blocks;
using System;
using System.Collections.Generic;

namespace AdaptMark.Parsers.Markdown.Blocks
{
    /// <summary>
    /// This specifies the Content of the List element.
    /// </summary>
    public class ListItemBlock : IBlockContainer
    {
        /// <summary>
        /// Gets or sets the contents of the list item.
        /// </summary>
        public IList<MarkdownBlock> Blocks { get; set; } = Array.Empty<MarkdownBlock>();

        IReadOnlyList<MarkdownBlock> IBlockContainer.Blocks => this.Blocks.AsReadonly();

        /// <summary>
        /// Initializes a new instance of the <see cref="ListItemBlock"/> class.
        /// </summary>
        public ListItemBlock()
        {
        }
    }
}