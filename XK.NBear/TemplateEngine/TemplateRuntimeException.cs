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

namespace XK.NBear.TemplateEngine
{
    /// <summary>
    /// The tempalte runtime exception.
    /// </summary>
	public class TemplateRuntimeException : Exception
	{
		int line;
		int col;

        /// <summary>
        /// Initialize an instance of the <see cref="TemplateRuntimeException"/> class.
        /// </summary>
        /// <param name="msg">The msg.</param>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
		public TemplateRuntimeException(string msg, int line, int col)
			:base(msg)
		{
			this.line = line;
			this.col = col;
		}

        /// <summary>
        /// Initialize an instance of the <see cref="TemplateRuntimeException"/> class.
        /// </summary>
        /// <param name="msg">The msg.</param>
        /// <param name="innerException">The inner exception.</param>
        /// <param name="line">The line.</param>
        /// <param name="col">The col.</param>
		public TemplateRuntimeException(string msg, Exception innerException, int line, int col)
			:base(msg, innerException)
		{
			this.line = line;
			this.col = col;
		}

        /// <summary>
        /// The col.
        /// </summary>
		public int Col
		{
			get { return this.col; }
		}

        /// <summary>
        /// The line.
        /// </summary>
		public int Line
		{
			get { return this.line; }
		}
	}
}
