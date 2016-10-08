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
    /// The tag attribute class.
    /// </summary>
	public class TagAttribute
	{
		string name;
		Expression expression;

        /// <summary>
        /// Initialize an instance of the <see cref="TagAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="expression">The expression.</param>
		public TagAttribute(string name, Expression expression)
		{
			this.name = name;
			this.expression = expression;
		}

        /// <summary>
        /// The expression.
        /// </summary>
		public Expression Expression
		{
			get { return this.expression; }
		}

        /// <summary>
        /// The name.
        /// </summary>
		public string Name
		{
			get { return this.name; }
		}
	}
}
