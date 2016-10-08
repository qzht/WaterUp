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
    /// The field access expression.
    /// </summary>
	public class FieldAccess : Expression
	{
		Expression exp;
		string field;

        /// <summary>
        /// Initialize an instance of the <see cref="FieldAccess"/> class.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
        /// <param name="exp">The expression.</param>
        /// <param name="field">The field.</param>
		public FieldAccess(int line, int col, Expression exp, string field)
			:base(line, col)
		{
			this.exp = exp;
			this.field = field;
		}

        /// <summary>
        /// The expression.
        /// </summary>
		public Expression Exp
		{
			get { return this.exp; }
		}

        /// <summary>
        /// The field.
        /// </summary>
		public string Field
		{
			get { return this.field; }
		}

	}
}
