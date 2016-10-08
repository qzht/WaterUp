using System;

namespace XK.NBear.TemplateEngine
{
	/// <summary>
	/// StaticTypeReference is used by TemplateManager to hold references to types.
	/// When invoking methods, or accessing properties of this object, it will actually
	/// do static methods of the type
	/// </summary>
	public class StaticTypeReference
	{
		readonly Type type;

        /// <summary>
        /// Initialize an instance of the <see cref="StaticTypeReference"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
		public StaticTypeReference(Type type)
		{
			this.type = type;
		}

        /// <summary>
        /// The type.
        /// </summary>
		public Type Type
		{
			get { return type; }
		}
	}
}
