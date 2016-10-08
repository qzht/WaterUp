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
    /// The string exprssion class.
    /// </summary>
	public class StringExpression : Expression
	{
		List<Expression> exps;

        /// <summary>
        /// Initialize an instance of the <see cref="StringExpression"/> class.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
		public StringExpression(int line, int col)
			:base(line, col)
		{
			exps = new List<Expression>();
		}

        /// <summary>
        /// The expression's count.
        /// </summary>
		public int ExpCount
		{
			get { return exps.Count; }
		}

        /// <summary>
        /// Add an expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
		public void Add(Expression exp)
		{
			exps.Add(exp);
		}

        /// <summary>
        /// Gets The expression by index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The expression.</returns>
		public Expression this[int index]
		{
			get { return exps[index]; }
		}

        /// <summary>
        /// Gets the IEnumerable interface of expressions.
        /// </summary>
		public IEnumerable<Expression> Expressions
		{
			get
			{
				for (int i = 0; i < exps.Count; i++)
					yield return exps[i];
			}
		}
	}
}
