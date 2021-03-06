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

namespace XK.NBear.TemplateEngine
{
    /// <summary>
    /// The variable scope class.
    /// </summary>
	public class VariableScope
	{
		VariableScope parent;
		Dictionary<string, object> values;

        /// <summary>
        /// Initialize an instance of the <see cref="VariableScope"/> class.
        /// </summary>
		public VariableScope()
			:this(null)
		{
		}

        /// <summary>
        /// Initialize an instance of the <see cref="VariableScope"/> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
		public VariableScope(VariableScope parent)
		{
			this.parent = parent;
			this.values = new Dictionary<string, object>(StringComparer.InvariantCultureIgnoreCase);
		}

		/// <summary>
		/// clear all variables from this scope
		/// </summary>
		public void Clear()
		{
			values.Clear();
		}

		/// <summary>
		/// gets the parent scope for this scope
		/// </summary>
		public VariableScope Parent
		{
			get { return parent; }
		}

		/// <summary>
		/// returns true if variable name is defined
		/// otherwise returns parents isDefined if parent != null
		/// </summary>
		public bool IsDefined(string name)
		{
			if (values.ContainsKey(name))
				return true;
			else if (parent != null)
				return parent.IsDefined(name);
			else
				return false;
		}

		/// <summary>
		/// returns value of variable name
		/// If name is not in this scope and parent != null
		/// parents this[name] is called
		/// </summary>
		public object this[string name]
		{
			get {
				if (!values.ContainsKey(name))
				{
					if (parent != null)
						return parent[name];
					else
						return null;
				}
				else
					return values[name];
			}
			set { values[name] = value; }
		}
	}
}
