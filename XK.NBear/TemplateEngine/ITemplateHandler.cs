﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XK.NBear.TemplateEngine
{
    /// <summary>
    /// The template handler interface.
    /// </summary>
	public interface ITemplateHandler
	{
		/// <summary>
		/// this method will be called before any processing
		/// </summary>
		/// <param name="manager">manager doing the execution</param>
		void BeforeProcess(TemplateManager manager);

		/// <summary>
		/// this method will be called after all processing is done
		/// </summary>
		/// <param name="manager">manager doing the execution</param>
		void AfterProcess(TemplateManager manager);
	}
}
