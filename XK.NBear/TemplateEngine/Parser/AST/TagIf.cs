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
    /// The tag if tag class.
    /// </summary>
	public class TagIf : Tag
	{
		Tag falseBranch;
		Expression test;

        /// <summary>
        /// Initialize an instance of the <see cref="TagIf"/> class.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
        /// <param name="test">The test expression.</param>
		public TagIf(int line, int col, Expression test)
			:base(line, col, "if")
		{
			this.test = test;
		}

        /// <summary>
        /// Gets the false branch tag.
        /// </summary>
		public Tag FalseBranch
		{
			get { return this.falseBranch; }
			set { this.falseBranch = value; }
		}

        /// <summary>
        /// Gets the test expression.
        /// </summary>
		public Expression Test
		{
			get { return test; }
		}
	}
}
