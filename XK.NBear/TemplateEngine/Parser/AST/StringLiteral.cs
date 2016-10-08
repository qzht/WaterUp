﻿/*****************************************************
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
    /// The string literal expression.
    /// </summary>
	public class StringLiteral : Expression
	{
		string content;

        /// <summary>
        /// Initialize an instance of the <see cref="StringLiteral"/> class.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
        /// <param name="content">The content.</param>
		public StringLiteral(int line, int col, string content)
			:base(line, col)
		{
			this.content = content;
		}

        /// <summary>
        /// The content.
        /// </summary>
		public string Content
		{
			get { return this.content; }
		}
	}
}
