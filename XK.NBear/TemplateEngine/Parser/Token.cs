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

namespace XK.NBear.TemplateEngine.Parser
{
    /// <summary>
    /// The token kinds.
    /// </summary>
	public enum TokenKind
	{
        /// <summary>
        /// End of file.
        /// </summary>
		EOF,
        /// <summary>
        /// Comment.
        /// </summary>
		Comment,
		// common tokens
        /// <summary>
        /// Id.
        /// </summary>
		ID,				// (alpha)+

		/// <summary>
		///  text specific tokens
		/// </summary>
		TextData,

		// tag tokens
        /// <summary>
        /// Tag start.
        /// </summary>
		TagStart,		// <ad: 
        /// <summary>
        /// Tag end.
        /// </summary>
		TagEnd,			// > 
        /// <summary>
        /// Tag end and close.
        /// </summary>
		TagEndClose,	// />
        /// <summary>
        /// Tag close.
        /// </summary>
		TagClose,		// </ad:
        /// <summary>
        /// Tag equals.
        /// </summary>
		TagEquals,		// =


		// expression
        /// <summary>
        /// Expression start.
        /// </summary>
		ExpStart,		// # at the beginning
        /// <summary>
        /// Expression end.
        /// </summary>
		ExpEnd,			// # at the end
        /// <summary>
        /// Left paren.
        /// </summary>
		LParen,			// (
        /// <summary>
        /// Rigth paren.
        /// </summary>
		RParen,			// )
        /// <summary>
        /// Dot.
        /// </summary>
		Dot,			// .
        /// <summary>
        /// Comma.
        /// </summary>
		Comma,			// ,
        /// <summary>
        /// Integer.
        /// </summary>
		Integer,		// integer number
        /// <summary>
        /// Double.
        /// </summary>
		Double,			// double number
        /// <summary>
        /// Left bracket.
        /// </summary>
		LBracket,		// [
        /// <summary>
        /// Right bracket.
        /// </summary>
		RBracket,		// ]

		// operators
        /// <summary>
        /// Or.
        /// </summary>
        OpOr,           // "or" keyword
        /// <summary>
        /// And.
        /// </summary>
        OpAnd,          // "and" keyword
        /// <summary>
        /// Is.
        /// </summary>
		OpIs,			// "is" keyword
        /// <summary>
        /// IsNot.
        /// </summary>
		OpIsNot,		// "isnot" keyword
        /// <summary>
        /// Lesser than.
        /// </summary>
		OpLt,			// "lt" keyword
        /// <summary>
        /// Greater than.
        /// </summary>
		OpGt,			// "gt" keyword
        /// <summary>
        /// Lesser than and equal.
        /// </summary>
		OpLte,			// "lte" keyword
        /// <summary>
        /// Greater than and equal.
        /// </summary>
		OpGte,			// "gte" keyword

		// string tokens
        /// <summary>
        /// String start.
        /// </summary>
		StringStart,	// "
        /// <summary>
        /// String end.
        /// </summary>
		StringEnd,		// "
        /// <summary>
        /// String text.
        /// </summary>
		StringText		// text within the string
	}

    /// <summary>
    /// The token.
    /// </summary>
	public class Token
	{
		int line;
		int col;
		string data;
		TokenKind tokenKind;

        /// <summary>
        /// Initialize an instance of the <see cref="Token"/> class.
        /// </summary>
        /// <param name="kind">The kind.</param>
        /// <param name="data">The data.</param>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
		public Token(TokenKind kind, string data, int line, int col)
		{
			this.tokenKind = kind;
			this.line = line;
			this.col = col;
			this.data = data;
		}

        /// <summary>
        /// The col.
        /// </summary>
		public int Col
		{
			get { return this.col; }
		}

        /// <summary>
        /// The data.
        /// </summary>
		public string Data
		{
			get { return this.data; }
			set { this.data = value; }
		}

        /// <summary>
        /// The line.
        /// </summary>
		public int Line
		{
			get { return this.line; }
		}

        /// <summary>
        /// The token kind.
        /// </summary>
		public TokenKind TokenKind
		{
			get { return this.tokenKind; }
			set { this.tokenKind = value; }
		}
	}
}
