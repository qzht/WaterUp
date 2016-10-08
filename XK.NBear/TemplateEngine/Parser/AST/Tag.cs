/*****************************************************
 * EOSTemplates
 * (C) Andrew Deren 2004
 * http://www.adersoftware.com
 *
 *	This file is part of EOSTemplate
 * EOSTemplate is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 *
 * EOSTemplate is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with EOSTemplate; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 *****************************************************/

using System;
using System.Collections.Generic;
using System.Text;

namespace XK.NBear.TemplateEngine.Parser.AST
{
    /// <summary>
    /// The tag element class.
    /// </summary>
	public class Tag : Element
	{
		string name;
		List<TagAttribute> attribs;
		List<Element> innerElements;
		TagClose closeTag;
		bool isClosed;	// set to true if tag ends with />

        /// <summary>
        /// Initialize an instance of the <see cref="Tag"/> class.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
        /// <param name="name">The name.</param>
		public Tag(int line, int col, string name)
			:base(line, col)
		{
			this.name = name;
			this.attribs = new List<TagAttribute>();
			this.innerElements = new List<Element>();
		}

        /// <summary>
        /// Gets the attributes.
        /// </summary>
		public List<TagAttribute> Attributes
		{
			get { return this.attribs; }
		}

        /// <summary>
        /// Gets the attribute's value.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The value.</returns>
		public Expression AttributeValue(string name)
		{
			foreach (TagAttribute attrib in attribs)
				if (string.Compare(attrib.Name, name, true) == 0)
					return attrib.Expression;

			return null;
		}

        /// <summary>
        /// Gets the inner elements.
        /// </summary>
		public List<Element> InnerElements
		{
			get { return this.innerElements; }
		}

        /// <summary>
        /// The name.
        /// </summary>
		public string Name
		{
			get { return this.name; }
		}

        /// <summary>
        /// The close tag.
        /// </summary>
		public TagClose CloseTag
		{
			get { return this.closeTag; }
			set { this.closeTag = value; }
		}

        /// <summary>
        /// Gets the IS/NOT closed.
        /// </summary>
		public bool IsClosed
		{
			get { return this.isClosed; }
			set { this.isClosed = value; }
		}


	}
}
