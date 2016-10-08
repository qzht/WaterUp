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
    /// The binary expression class.
    /// </summary>
    public class BinaryExpression : Expression
    {
        Expression lhs;
        Expression rhs;

        TokenKind op;

        /// <summary>
        /// Initialize an instance of the <see cref="BinaryExpression"/> class.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
        /// <param name="lhs">The left expression.</param>
        /// <param name="op">The token kind.</param>
        /// <param name="rhs">The right expression.</param>
        public BinaryExpression(int line, int col, Expression lhs, TokenKind op, Expression rhs)
            : base(line, col)
        {
            this.lhs = lhs;
            this.rhs = rhs;
            this.op = op;
        }

        /// <summary>
        /// The left expression.
        /// </summary>
        public Expression Lhs
        {
            get { return this.lhs; }
        }

        /// <summary>
        /// The right expression.
        /// </summary>
        public Expression Rhs
        {
            get { return this.rhs; }
        }

        /// <summary>
        /// The token kind.
        /// </summary>
        public TokenKind Operator
        {
            get { return this.op; }
        }

    }
}
