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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using XK.NBear.TemplateEngine.Parser.AST;
using XK.NBear.TemplateEngine;

namespace XK.NBear.TemplateEngine
{
    /// <summary>
    /// The template function delegate.
    /// </summary>
    /// <param name="args">The args.</param>
    /// <returns>The object.</returns>
	public delegate object TemplateFunction(object[] args);

    /// <summary>
    /// The template manager.
    /// </summary>
	public class TemplateManager
	{
		bool silentErrors;

		Dictionary<string, TemplateFunction> functions;

		Dictionary<string, ITagHandler> customTags;

		VariableScope variables;		// current variable scope
		Expression currentExpression;	// current expression being evaluated

		TextWriter writer;				// all output is sent here

		Template mainTemplate;			// main template to execute
		Template currentTemplate;		// current template being executed

		ITemplateHandler handler;		// handler will be set as "this" object

		/// <summary>
		/// create template manager using a template
		/// </summary>
		public TemplateManager(Template template)
		{
			this.mainTemplate = template;
			this.currentTemplate = template;
			this.silentErrors = false;

			Init();
		}

        /// <summary>
        /// Initialize an instance of the <see cref="TemplateManager"/> class.
        /// </summary>
        /// <param name="template">The template text.</param>
        /// <returns>The template manager.</returns>
		public static TemplateManager FromString(string template)
		{
			Template itemplate = Template.FromString("", template);
			return new TemplateManager(itemplate);
		}

        /// <summary>
        /// Initialize an instance of the <see cref="TemplateManager"/> class.
        /// </summary>
        /// <param name="filename">The filename.</param>
        /// <returns>The template manager.</returns>
		public static TemplateManager FromFile(string filename)
		{
			Template template = Template.FromFile("", filename);
			return new TemplateManager(template);
		}

		/// <summary>
		/// handler is used as "this" object, and will receive
		/// before after process message
		/// </summary>
		public ITemplateHandler Handler
		{
			get { return this.handler; }
			set { this.handler = value; }
		}

		/// <summary>
		/// if silet errors is set to true, then any exceptions will not show in the output
		/// If set to false, all exceptions will be displayed.
		/// </summary>
		public bool SilentErrors
		{
			get { return this.silentErrors; }
			set { this.silentErrors = value; }
		}

		private Dictionary<string, ITagHandler> CustomTags
		{
			get
			{
				if (customTags == null)
					customTags = new Dictionary<string, ITagHandler>(StringComparer.CurrentCultureIgnoreCase);
				return customTags;
			}
		}

		/// <summary>
		/// registers custom tag processor
		/// </summary>
		public void RegisterCustomTag(string tagName, ITagHandler handler)
		{
			CustomTags.Add(tagName, handler);
		}

		/// <summary>
		/// checks whether there is a handler for tagName
		/// </summary>
		public bool IsCustomTagRegistered(string tagName)
		{
			return CustomTags.ContainsKey(tagName);
		}

		/// <summary>
		/// unregistered tagName from custom tags
		/// </summary>
		public void UnRegisterCustomTag(string tagName)
		{
			CustomTags.Remove(tagName);
		}

		/// <summary>
		/// adds template that can be used within execution 
		/// </summary>
		/// <param name="template"></param>
		public void AddTemplate(Template template)
		{
			mainTemplate.Templates.Add(template.Name, template);
		}

		void Init()
		{
			this.functions = new Dictionary<string, TemplateFunction>(StringComparer.InvariantCultureIgnoreCase);

			this.variables = new VariableScope();

			functions.Add("equals", new TemplateFunction(FuncEquals));
			functions.Add("notequals", new TemplateFunction(FuncNotEquals));
			functions.Add("iseven", new TemplateFunction(FuncIsEven));
			functions.Add("isodd", new TemplateFunction(FuncIsOdd));
			functions.Add("isempty", new TemplateFunction(FuncIsEmpty));
			functions.Add("isnotempty", new TemplateFunction(FuncIsNotEmpty));
			functions.Add("isnumber", new TemplateFunction(FuncIsNumber));
			functions.Add("toupper", new TemplateFunction(FuncToUpper));
			functions.Add("tolower", new TemplateFunction(FuncToLower));
			functions.Add("isdefined", new TemplateFunction(FuncIsDefined));
			functions.Add("ifdefined", new TemplateFunction(FuncIfDefined));
			functions.Add("len", new TemplateFunction(FuncLen));
			functions.Add("tolist", new TemplateFunction(FuncToList));
			functions.Add("isnull", new TemplateFunction(FuncIsNull));
			functions.Add("not", new TemplateFunction(FuncNot));
			functions.Add("iif", new TemplateFunction(FuncIif));
			functions.Add("format", new TemplateFunction(FuncFormat));
			functions.Add("trim", new TemplateFunction(FuncTrim));
			functions.Add("filter", new TemplateFunction(FuncFilter));
			functions.Add("gt", new TemplateFunction(FuncGt));
			functions.Add("lt", new TemplateFunction(FuncLt));
			functions.Add("compare", new TemplateFunction(FuncCompare));
			functions.Add("or", new TemplateFunction(FuncOr));
			functions.Add("and", new TemplateFunction(FuncAnd));
			functions.Add("comparenocase", new TemplateFunction(FuncCompareNoCase));
			functions.Add("stripnewlines", new TemplateFunction(FuncStripNewLines));
			functions.Add("typeof", new TemplateFunction(FuncTypeOf));
			functions.Add("cint", new TemplateFunction(FuncCInt));
			functions.Add("cdouble", new TemplateFunction(FuncCDouble));
			functions.Add("cdate", new TemplateFunction(FuncCDate));
			functions.Add("now", new TemplateFunction(FuncNow));
			functions.Add("createtypereference", new TemplateFunction(FuncCreateTypeReference));

            // add#1.begin on 2007-04-14 23:52 for sum a and b.
            functions.Add("sum", new TemplateFunction(FuncSum));
            functions.Add("sub", new TemplateFunction(FuncSub));
            // add#1.end
		}

		#region Functions
		bool CheckArgCount(int count, string funcName, object[] args)
		{
			if (count != args.Length)
			{
				DisplayError(string.Format("Function {0} requires {1} arguments and {2} were passed", funcName, count, args.Length), currentExpression.Line, currentExpression.Col);
				return false;
			}
			else
				return true;
		}

		bool CheckArgCount(int count1, int count2, string funcName, object[] args)
		{
			if (args.Length < count1 || args.Length > count2)
			{
				string msg = string.Format("Function {0} requires between {1} and {2} arguments and {3} were passed", funcName, count1, count2, args.Length);
				DisplayError(msg, currentExpression.Line, currentExpression.Col);
				return false;
			}
			else
				return true;
		}

		object FuncIsEven(object[] args)
		{
			if (!CheckArgCount(1, "iseven", args))
				return null;

			try
			{
				int value = Convert.ToInt32(args[0]);
				return value % 2 == 0;
			}
			catch (FormatException)
			{
				throw new TemplateRuntimeException("IsEven cannot convert parameter to int", currentExpression.Line, currentExpression.Col);
			}
		}

		object FuncIsOdd(object[] args)
		{
			if (!CheckArgCount(1, "isdd", args))
				return null;

			try
			{
				int value = Convert.ToInt32(args[0]);
				return value % 2 == 1;
			}
			catch (FormatException)
			{
				throw new TemplateRuntimeException("IsOdd cannot convert parameter to int", currentExpression.Line, currentExpression.Col);
			}
		}

		object FuncIsEmpty(object[] args)
		{
			if (!CheckArgCount(1, "isempty", args))
				return null;

			string value = args[0].ToString();
			return value.Length == 0;
		}

		object FuncIsNotEmpty(object[] args)
		{
			if (!CheckArgCount(1, "isnotempty", args))
				return null;

			if (args[0] == null)
				return false;

			string value = args[0].ToString();
			return value.Length > 0;
		}


		object FuncEquals(object[] args)
		{
			if (!CheckArgCount(2, "equals", args))
				return null;

			return args[0].Equals(args[1]);
		}


		object FuncNotEquals(object[] args)
		{
			if (!CheckArgCount(2, "notequals", args))
				return null;

			return !args[0].Equals(args[1]);
		}


		object FuncIsNumber(object[] args)
		{
			if (!CheckArgCount(1, "isnumber", args))
				return null;

			try
			{
				int value = Convert.ToInt32(args[0]);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}

		object FuncToUpper(object[] args)
		{
			if (!CheckArgCount(1, "toupper", args))
				return null;

			return args[0].ToString().ToUpper();
		}

		object FuncToLower(object[] args)
		{
			if (!CheckArgCount(1, "toupper", args))
				return null;

			return args[0].ToString().ToLower();
		}

		object FuncLen(object[] args)
		{
			if (!CheckArgCount(1, "len", args))
				return null;

			return args[0].ToString().Length;
		}


		object FuncIsDefined(object[] args)
		{
			if (!CheckArgCount(1, "isdefined", args))
				return null;

			return variables.IsDefined(args[0].ToString());
		}

		object FuncIfDefined(object[] args)
		{
			if (!CheckArgCount(2, "ifdefined", args))
				return null; 

			if (variables.IsDefined(args[0].ToString()))
			{
				return args[1];
			}
			else
				return string.Empty;
		}

		object FuncToList(object[] args)
		{
			if (!CheckArgCount(2, 3, "tolist", args))
				return null;

			object list = args[0];

			string property;
			string delim;

			if (args.Length == 3)
			{
				property = args[1].ToString();
				delim = args[2].ToString();
			}
			else
			{
				property = string.Empty;
				delim = args[1].ToString();
			}

			if (!(list is IEnumerable))
			{
				throw new TemplateRuntimeException("argument 1 of tolist has to be IEnumerable", currentExpression.Line, currentExpression.Col);
			}

			IEnumerator ienum = ((IEnumerable)list).GetEnumerator();
			StringBuilder sb = new StringBuilder();
			int index = 0;
			while (ienum.MoveNext())
			{
				if (index > 0)
					sb.Append(delim);

				if (args.Length == 2) // do not evalulate property
					sb.Append(ienum.Current);
				else
				{
					sb.Append(EvalProperty(ienum.Current, property));
				}
				index++;
			}

			return sb.ToString();

		}

		object FuncIsNull(object[] args)
		{
			if (!CheckArgCount(1, "isnull", args))
				return null;

			return args[0] == null;
		}

		object FuncNot(object[] args)
		{
			if (!CheckArgCount(1, "not", args))
				return null;

			if (args[0] is bool)
				return !(bool)args[0];
			else
			{
				throw new TemplateRuntimeException("Parameter 1 of function 'not' is not boolean", currentExpression.Line, currentExpression.Col);
			}

		}

		object FuncIif(object[] args)
		{
			if (!CheckArgCount(3, "iif", args))
				return null;

			if (args[0] is bool)
			{
				bool test = (bool)args[0];
				return test ? args[1] : args[2];
			}
			else
			{
				throw new TemplateRuntimeException("Parameter 1 of function 'iif' is not boolean", currentExpression.Line, currentExpression.Col);
			}
		}

		object FuncFormat(object[] args)
		{
			if (!CheckArgCount(2, "format", args))
				return null;

			string format = args[1].ToString();

			if (args[0] is IFormattable)
				return ((IFormattable)args[0]).ToString(format, null);
			else
				return args[0].ToString();
		}

		object FuncTrim(object[] args)
		{
			if (!CheckArgCount(1, "trim", args))
				return null;

			return args[0].ToString().Trim();
		}

		object FuncFilter(object[] args)
		{
			if (!CheckArgCount(2, "filter", args))
				return null;

			object list = args[0];

			string property;
			property = args[1].ToString();

			if (!(list is IEnumerable))
			{
				throw new TemplateRuntimeException("argument 1 of filter has to be IEnumerable", currentExpression.Line, currentExpression.Col);
			}

			IEnumerator ienum = ((IEnumerable)list).GetEnumerator();
			List<object> newList = new List<object>();
			
			while (ienum.MoveNext())
			{
				object val = EvalProperty(ienum.Current, property);
				if (val is bool && (bool)val)
					newList.Add(ienum.Current);
			}

			return newList;

		}

		object FuncGt(object[] args)
		{
			if (!CheckArgCount(2, "gt", args))
				return null;

			IComparable c1 = args[0] as IComparable;
			IComparable c2 = args[1] as IComparable;
			if (c1 == null || c2 == null)
				return false;
			else
				return c1.CompareTo(c2) == 1;
		}

		object FuncLt(object[] args)
		{
			if (!CheckArgCount(2, "lt", args))
				return null;

			IComparable c1 = args[0] as IComparable;
			IComparable c2 = args[1] as IComparable;
			if (c1 == null || c2 == null)
				return false;
			else
				return c1.CompareTo(c2) == -1;
		}

		object FuncCompare(object[] args)
		{
			if (!CheckArgCount(2, "compare", args))
				return null;

			IComparable c1 = args[0] as IComparable;
			IComparable c2 = args[1] as IComparable;
			if (c1 == null || c2 == null)
				return false;
			else
				return c1.CompareTo(c2);
		}

		object FuncOr(object[] args)
		{
			if (!CheckArgCount(2, "or", args))
				return null;

			if (args[0] is bool && args[1] is bool)
				return (bool)args[0] || (bool)args[1];
			else
				return false;
		}

		object FuncAnd(object[] args)
		{
			if (!CheckArgCount(2, "add", args))
				return null;

			if (args[0] is bool && args[1] is bool)
				return (bool)args[0] && (bool)args[1];
			else
				return false;
		}

		object FuncCompareNoCase(object[] args)
		{
			if (!CheckArgCount(2, "compareNoCase", args))
				return null;

			string s1 = args[0].ToString();
			string s2 = args[1].ToString();

			return string.Compare(s1, s2, true)==0;
		}

		object FuncStripNewLines(object[] args)
		{
			if (!CheckArgCount(1, "StripNewLines", args))
				return null;

			string s1 = args[0].ToString();
			return s1.Replace(Environment.NewLine, " ");

		}

		object FuncTypeOf(object[] args)
		{
			if (!CheckArgCount(1, "TypeOf", args))
				return null;

			return args[0].GetType().Name;

		}

		object FuncCInt(object[] args)
		{
			if (!CheckArgCount(1, "cint", args))
				return null;

			return Convert.ToInt32(args[0]);
		}

		object FuncCDouble(object[] args)
		{
			if (!CheckArgCount(1, "cdouble", args))
				return null;

			return Convert.ToDouble(args[0]);
		}

		object FuncCDate(object[] args)
		{
			if (!CheckArgCount(1, "cdate", args))
				return null;

			return Convert.ToDateTime(args[0]);
		}

		object FuncNow(object[] args)
		{
			if (!CheckArgCount(0, "now", args))
				return null;

			return DateTime.Now;
		}

		object FuncCreateTypeReference(object[] args)
		{
			if (!CheckArgCount(1, "createtypereference", args))
				return null;

			string typeName = args[0].ToString();


			Type type = System.Type.GetType(typeName, false, true);
			if (type != null)
				return new StaticTypeReference(type);

			Assembly[] asms = AppDomain.CurrentDomain.GetAssemblies();
			foreach (Assembly asm in asms)
			{
				type = asm.GetType(typeName, false, true);
				if (type != null)
					return new StaticTypeReference(type);
			}

			throw new TemplateRuntimeException("Cannot create type " + typeName + ".", currentExpression.Line, currentExpression.Col);
		}

        object FuncSum(object[] args)
        {
            if (!CheckArgCount(2, 10, "sum", args))
                return null;

            int count = 0;
            for (int i = 0; i < args.Length; i++)
            {
                count += Convert.ToInt32(args[i]);
            }
            return count;
        }

        object FuncSub(object[] args)
        {
            if (!CheckArgCount(2, "sub", args))
                return null;

            return Convert.ToInt32(args[0]) - Convert.ToInt32(args[1]);
        }

        #endregion

        /// <summary>
        /// gets library of functions that are available
        /// for the tempalte execution
        /// </summary>
        public Dictionary<string, TemplateFunction> Functions
		{
			get { return functions; }
		}

		/// <summary>
		/// sets value for variable called name
		/// </summary>
		public void SetValue(string name, object value)
		{
			variables[name] = value;
		}

		/// <summary>
		/// gets value for variable called name.
		/// Throws exception if value is not found
		/// </summary>
		public object GetValue(string name)
		{
			if (variables.IsDefined(name))
				return variables[name];
			else
				throw new Exception("Variable '" + name + "' cannot be found in current scope.");
		}

		/// <summary>
		/// processes current template and sends output to writer
		/// </summary>
		/// <param name="writer"></param>
		public void Process(TextWriter writer)
		{
			this.writer = writer;
			this.currentTemplate = mainTemplate;

			if (handler != null)
			{
				SetValue("this", handler);
				handler.BeforeProcess(this);
			}

			ProcessElements(mainTemplate.Elements);

			if (handler != null)
				handler.AfterProcess(this);
		}

		/// <summary>
		/// processes templates and returns string value
		/// </summary>
		public string Process()
		{
			StringWriter writer = new StringWriter();
			Process(writer);
			return writer.ToString();
		}

		/// <summary>
		/// resets all variables. If TemplateManager is used to 
		/// process template multiple times, Reset() must be 
		/// called prior to Process if varialbes need to be cleared
		/// </summary>
		public void Reset()
		{
			variables.Clear();
		}

		/// <summary>
		/// processes list of elements.
		/// This method is mostly used by extenders of the manager
		/// from custom functions or custom tags.
		/// </summary>
		public void ProcessElements(List<Element> list)
		{
			foreach (Element elem in list)
			{
				ProcessElement(elem);
			}
		}

        /// <summary>
        /// Process element.
        /// </summary>
        /// <param name="elem">The element.</param>
		protected void ProcessElement(Element elem)
		{
			if (elem is Text)
			{
				Text text = (Text)elem;
				WriteValue(text.Data);
			}
			else if (elem is Expression)
				ProcessExpression((Expression)elem);
			else if (elem is TagIf)
				ProcessIf((TagIf)elem);
			else if (elem is Tag)
				ProcessTag((Tag)elem);
		}

        /// <summary>
        /// Process expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
		protected void ProcessExpression(Expression exp)
		{
			object value = EvalExpression(exp);
			WriteValue(value);
		}

		/// <summary>
		/// evaluates expression.
		/// This method is used by TemplateManager extensibility.
		/// </summary>
		public object EvalExpression(Expression exp)
		{
			currentExpression = exp;

			try
			{
				if (exp is StringLiteral)
					return ((StringLiteral)exp).Content;
				else if (exp is Name)
				{
					return GetValue(((Name)exp).Id);
				}
				else if (exp is FieldAccess)
				{
					FieldAccess fa = (FieldAccess)exp;
					object obj = EvalExpression(fa.Exp);
					string propertyName = fa.Field;
					return EvalProperty(obj, propertyName);
				}
				else if (exp is MethodCall)
				{
					MethodCall ma = (MethodCall)exp;
					object obj = EvalExpression(ma.CallObject);
					string methodName = ma.Name;

					return EvalMethodCall(obj, methodName, EvalArguments(ma.Args));
				}
				else if (exp is IntLiteral)
					return ((IntLiteral)exp).Value;
				else if (exp is DoubleLiteral)
					return ((DoubleLiteral)exp).Value;
				else if (exp is FCall)
				{
					FCall fcall = (FCall)exp;
					if (!functions.ContainsKey(fcall.Name))
					{
						string msg = string.Format("Function {0} is not defined", fcall.Name);
						throw new TemplateRuntimeException(msg, exp.Line, exp.Col);
					}

					TemplateFunction func = functions[fcall.Name];
					object[] values = EvalArguments(fcall.Args);

					return func(values);
				}
				else if (exp is StringExpression)
				{
					StringExpression stringExp = (StringExpression)exp;
					StringBuilder sb = new StringBuilder();
					foreach (Expression ex in stringExp.Expressions)
						sb.Append(EvalExpression(ex));

					return sb.ToString();
				}
				else if (exp is BinaryExpression)
					return EvalBinaryExpression(exp as BinaryExpression);
				else if (exp is ArrayAccess)
					return EvalArrayAccess(exp as ArrayAccess);
				else
					throw new TemplateRuntimeException("Invalid expression type: " + exp.GetType().Name, exp.Line, exp.Col);

			}
			catch (TemplateRuntimeException ex)
			{
				DisplayError(ex);
				return null;
			}
			catch (Exception ex)
			{
				DisplayError(new TemplateRuntimeException(ex.Message, currentExpression.Line, currentExpression.Col));
				return null;
			}
		}

        /// <summary>
        /// Eval array access.
        /// </summary>
        /// <param name="arrayAccess">The array access.</param>
        /// <returns>The object.</returns>
		protected object EvalArrayAccess(ArrayAccess arrayAccess)
		{
			object obj = EvalExpression(arrayAccess.Exp);
			
			object index = EvalExpression(arrayAccess.Index);

			if (obj is Array)
			{
				Array array = (Array)obj;
				if (index is Int32)
				{
					return array.GetValue((int)index);
				}
				else
					throw new TemplateRuntimeException("Index of array has to be integer", arrayAccess.Line, arrayAccess.Col);
			}
			else
				return EvalMethodCall(obj, "get_Item", new object[] { index });

		}

        /// <summary>
        /// Eval binary expression.
        /// </summary>
        /// <param name="exp">The expression.</param>
        /// <returns>The object.</returns>
        protected object EvalBinaryExpression(BinaryExpression exp)
        {
            switch (exp.Operator)
            {
                case XK.NBear.TemplateEngine.Parser.TokenKind.OpOr:
                {
					object lhsValue = EvalExpression(exp.Lhs);
					if (ConvertEx.ObjectToBool(lhsValue))
						return true;

					object rhsValue = EvalExpression(exp.Rhs);
                    return ConvertEx.ObjectToBool(rhsValue);
                }
                case XK.NBear.TemplateEngine.Parser.TokenKind.OpAnd:
                {
					object lhsValue = EvalExpression(exp.Lhs);
                    if (!ConvertEx.ObjectToBool(lhsValue))
						return false;

					object rhsValue = EvalExpression(exp.Rhs);
                    return ConvertEx.ObjectToBool(rhsValue);

                }
				case XK.NBear.TemplateEngine.Parser.TokenKind.OpIs:
				{
					object lhsValue = EvalExpression(exp.Lhs);
					object rhsValue = EvalExpression(exp.Rhs);

					return lhsValue.Equals(rhsValue);
				}
				case XK.NBear.TemplateEngine.Parser.TokenKind.OpIsNot:
				{
					object lhsValue = EvalExpression(exp.Lhs);
					object rhsValue = EvalExpression(exp.Rhs);

					return !lhsValue.Equals(rhsValue);

				}
				case XK.NBear.TemplateEngine.Parser.TokenKind.OpGt:
				{
					object lhsValue = EvalExpression(exp.Lhs);
					object rhsValue = EvalExpression(exp.Rhs);

					IComparable c1 = lhsValue as IComparable;
					IComparable c2 = rhsValue as IComparable;
					if (c1 == null || c2 == null)
						return false;
					else
						return c1.CompareTo(c2) == 1;

				}
				case XK.NBear.TemplateEngine.Parser.TokenKind.OpLt:
				{
					object lhsValue = EvalExpression(exp.Lhs);
					object rhsValue = EvalExpression(exp.Rhs);

					IComparable c1 = lhsValue as IComparable;
					IComparable c2 = rhsValue as IComparable;
					if (c1 == null || c2 == null)
						return false;
					else
						return c1.CompareTo(c2) == -1;

				}
				case XK.NBear.TemplateEngine.Parser.TokenKind.OpGte:
				{
					object lhsValue = EvalExpression(exp.Lhs);
					object rhsValue = EvalExpression(exp.Rhs);

					IComparable c1 = lhsValue as IComparable;
					IComparable c2 = rhsValue as IComparable;
					if (c1 == null || c2 == null)
						return false;
					else
						return c1.CompareTo(c2) >= 0;

				}
				case XK.NBear.TemplateEngine.Parser.TokenKind.OpLte:
				{
					object lhsValue = EvalExpression(exp.Lhs);
					object rhsValue = EvalExpression(exp.Rhs);

					IComparable c1 = lhsValue as IComparable;
					IComparable c2 = rhsValue as IComparable;
					if (c1 == null || c2 == null)
						return false;
					else
						return c1.CompareTo(c2) <= 0;

				}
				default:
					throw new TemplateRuntimeException("Operator " + exp.Operator.ToString() + " is not supported.", exp.Line, exp.Col);
            }
        }

        /// <summary>
        /// Eval arguments.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <returns>The object.</returns>
		protected object[] EvalArguments(Expression[] args)
		{
			object[] values = new object[args.Length];
			for (int i = 0; i < values.Length; i++)
				values[i] = EvalExpression(args[i]);

			return values;
		}

        /// <summary>
        /// Eval property.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">The property name.</param>
        /// <returns>The object.</returns>
		protected static object EvalProperty(object obj, string propertyName)
		{
			if (obj is StaticTypeReference)
			{
				Type type = (obj as StaticTypeReference).Type;

				PropertyInfo  pinfo = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.GetProperty | BindingFlags.Static);
				if (pinfo != null)
					return pinfo.GetValue(null, null);

				FieldInfo finfo = type.GetField(propertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.GetField | BindingFlags.Static);
				if (finfo != null)
					return finfo.GetValue(null);
				else
					throw new Exception("Cannot find property or field named '" + propertyName + "' in object of type '" + type.Name + "'");
				

			}
			else
			{
				PropertyInfo pinfo = obj.GetType().GetProperty(propertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.GetProperty | BindingFlags.Instance);

				if (pinfo != null)
					return pinfo.GetValue(obj, null);

				FieldInfo finfo = obj.GetType().GetField(propertyName, BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.GetField | BindingFlags.Instance);

				if (finfo != null)
					return finfo.GetValue(obj);						
				else
					throw new Exception("Cannot find property or field named '" + propertyName + "' in object of type '" + obj.GetType().Name + "'");

			}

		}

        /// <summary>
        /// Eval method call.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="methodName">The method name.</param>
        /// <param name="args">The args.</param>
        /// <returns>The object.</returns>
		protected object EvalMethodCall(object obj, string methodName, object[] args)
		{
			Type[] types = new Type[args.Length];
			for (int i = 0; i < args.Length; i++)
				types[i] = args[i].GetType();

			if (obj is StaticTypeReference)
			{
				Type type = (obj as StaticTypeReference).Type;
				MethodInfo method = type.GetMethod(methodName,
					BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Static,
					null, types, null);

				if (method == null)
					throw new Exception(string.Format("method {0} not found for static object of type {1}", methodName, type.Name));

				return method.Invoke(null, args);
			}
			else
			{

				MethodInfo method = obj.GetType().GetMethod(methodName,
					BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance,
					null, types, null);

				if (method == null)
					throw new Exception(string.Format("method {0} not found for object of type {1}", methodName, obj.GetType().Name));

				return method.Invoke(obj, args);
			}
		}

        /// <summary>
        /// Process if.
        /// </summary>
        /// <param name="tagIf">The tagif.</param>
		protected void ProcessIf(TagIf tagIf)
		{
			bool condition = false;

			try
			{
				object value = EvalExpression(tagIf.Test);

                condition = ConvertEx.ObjectToBool(value);
			}
			catch (Exception ex)
			{
				DisplayError("Error evaluating condition for if statement: " + ex.Message, 
					tagIf.Line, tagIf.Col);
				return;
			}

			if (condition)
				ProcessElements(tagIf.InnerElements);
			else
				ProcessElement(tagIf.FalseBranch);

		}

        /// <summary>
        /// Process tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
		protected void ProcessTag(Tag tag)
		{
			string name = tag.Name.ToLowerInvariant();
			try
			{
				switch (name)
				{
					case "template":
						// skip those, because those are processed first
						break;
					case "else":
						ProcessElements(tag.InnerElements);
						break;
					case "apply":
						object val = EvalExpression(tag.AttributeValue("template"));
						ProcessTemplate(val.ToString(), tag);
						break;
					case "foreach":
						ProcessForEach(tag);
						break;
					case "for":
						ProcessFor(tag);
						break;
					case "set":
						ProcessTagSet(tag);
						break;
					default:
						ProcessTemplate(tag.Name, tag);
						break;
				}
			}
			catch (TemplateRuntimeException ex)
			{
				DisplayError(ex);
			}
			catch (Exception ex)
			{
				DisplayError("Error executing tag '" + name + "': " + ex.Message, tag.Line, tag.Col);

			}
		}

        /// <summary>
        /// Process tagset.
        /// </summary>
        /// <param name="tag">The tag.</param>
		protected void ProcessTagSet(Tag tag)
		{
			Expression expName = tag.AttributeValue("name");
			if (expName == null)
			{
				throw new TemplateRuntimeException("Set is missing required attribute: name", tag.Line, tag.Col);
			}

			Expression expValue = tag.AttributeValue("value");
			if (expValue == null)
			{
				throw new TemplateRuntimeException("Set is missing required attribute: value", tag.Line, tag.Col);
			}

			string name = EvalExpression(expName).ToString();
			if (!RegexCheck.IsValidVariableName(name))
				throw new TemplateRuntimeException("'" + name + "' is not valid variable name.", expName.Line, expName.Col);

			object value = EvalExpression(expValue);

			this.SetValue(name, value);
		}

        /// <summary>
        /// Process foreach.
        /// </summary>
        /// <param name="tag">The tag.</param>
		protected void ProcessForEach(Tag tag)
		{
			Expression expCollection = tag.AttributeValue("collection");
			if (expCollection == null)
			{
				throw new TemplateRuntimeException("Foreach is missing required attribute: collection", tag.Line, tag.Col);
			}

			object collection = EvalExpression(expCollection);
			if (!(collection is IEnumerable))
			{
				throw new TemplateRuntimeException("Collection used in foreach has to be enumerable", tag.Line, tag.Col);
			}

			Expression expVar = tag.AttributeValue("var");
			if (expCollection == null)
			{
				throw new TemplateRuntimeException("Foreach is missing required attribute: var", tag.Line, tag.Col);
			}
			object varObject = EvalExpression(expVar);
			if (varObject == null)
				varObject = "foreach";
			string varname = varObject.ToString();

			Expression expIndex = tag.AttributeValue("index");
			string indexname = null;
			if (expIndex != null)
			{
				object obj = EvalExpression(expIndex);
				if (obj != null)
					indexname = obj.ToString();
			}

			IEnumerator ienum = ((IEnumerable)collection).GetEnumerator();
			int index = 0;
			while (ienum.MoveNext())
			{
				index++;
				object value = ienum.Current;
				variables[varname] = value;
				if (indexname != null)
					variables[indexname] = index;

				ProcessElements(tag.InnerElements);
			}
		}

        /// <summary>
        /// Process for.
        /// </summary>
        /// <param name="tag">The tag.</param>
		protected void ProcessFor(Tag tag)
		{
			Expression expFrom = tag.AttributeValue("from");
			if (expFrom == null)
			{
				throw new TemplateRuntimeException("For is missing required attribute: start", tag.Line, tag.Col);
			}

			Expression expTo = tag.AttributeValue("to");
			if (expTo == null)
			{
				throw new TemplateRuntimeException("For is missing required attribute: to", tag.Line, tag.Col);
			}

			Expression expIndex = tag.AttributeValue("index");
			if (expIndex == null)
			{
				throw new TemplateRuntimeException("For is missing required attribute: index", tag.Line, tag.Col);
			}

			object obj = EvalExpression(expIndex);
			string indexName = obj.ToString();
			
			int start = Convert.ToInt32(EvalExpression(expFrom));
			int end = Convert.ToInt32(EvalExpression(expTo));

			for (int index = start; index <= end; index++)
			{
				SetValue(indexName, index);
				//variables[indexName] = index;

				ProcessElements(tag.InnerElements);
			}
		}

        /// <summary>
        /// Execute custom tag.
        /// </summary>
        /// <param name="tag">The tag.</param>
		protected void ExecuteCustomTag(Tag tag)
		{
			ITagHandler tagHandler = customTags[tag.Name];

			bool processInnerElements = true;
			bool captureInnerContent = false;

			tagHandler.TagBeginProcess(this, tag, ref processInnerElements, ref captureInnerContent);

			string innerContent = null;

			if (processInnerElements)
			{
				TextWriter saveWriter = writer;

				if (captureInnerContent)
					writer = new StringWriter();

				try
				{
					ProcessElements(tag.InnerElements);

					innerContent = writer.ToString();
				}
				finally
				{
					writer = saveWriter;
				}
			}

			tagHandler.TagEndProcess(this, tag, innerContent);

		}

        /// <summary>
        /// Process template.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="tag">The tag.</param>
		protected void ProcessTemplate(string name, Tag tag)
		{
			if (customTags != null && customTags.ContainsKey(name))
			{
				ExecuteCustomTag(tag);
				return;
			}

			Template useTemplate = currentTemplate.FindTemplate(name);
			if (useTemplate == null)
			{
				string msg = string.Format("Template '{0}' not found", name);
				throw new TemplateRuntimeException(msg, tag.Line, tag.Col);
			}

			// process inner elements and save content
			TextWriter saveWriter = writer;
			writer = new StringWriter();
			string content = string.Empty;

			try
			{
				ProcessElements(tag.InnerElements);

				content = writer.ToString();
			}
			finally
			{
				writer = saveWriter;
			}

			Template saveTemplate = currentTemplate;
			variables = new VariableScope(variables);
			variables["innerText"] = content;

			try
			{
				foreach (TagAttribute attrib in tag.Attributes)
				{
					object val = EvalExpression(attrib.Expression);
					variables[attrib.Name] = val;
				}

				currentTemplate = useTemplate;
				ProcessElements(currentTemplate.Elements);
			}
			finally
			{
				variables = variables.Parent;
				currentTemplate = saveTemplate;
			}

			
		}

		/// <summary>
		/// writes value to current writer
		/// </summary>
		/// <param name="value">value to be written</param>
		public void WriteValue(object value)
		{
			if (value == null)
				writer.Write("[null]");
			else
				writer.Write(value);
		}

		private void DisplayError(Exception ex)
		{
			if (ex is TemplateRuntimeException)
			{
				TemplateRuntimeException tex = (TemplateRuntimeException)ex;
				DisplayError(ex.Message, tex.Line, tex.Col);
			}
			else
				DisplayError(ex.Message, 0, 0);
		}

		private void DisplayError(string msg, int line, int col)
		{
			if (!silentErrors)
				writer.Write("[ERROR ({0}, {1}): {2}]", line, col, msg);
		}
	}
}
