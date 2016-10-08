using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

namespace XK.NBear.Extends
{
    /// <summary>
    /// 摘要: 扩展 WebControl
    /// </summary>
    public static class WebControlExtends
    {
        /// <summary>
        /// 摘要: 扩展 Control 的 FindControl
        /// </summary>
        /// <param name="control"></param>
        /// <param name="controlID"></param>
        /// <returns></returns>
        public static Control FindAllControl(System.Web.UI.Control control, string controlID)
        {
            Control resultControl = control.FindControl(controlID);
            resultControl = FindControlForeach(control, controlID);
            return resultControl;
        }
        /// <summary>
        /// 摘要: 根据递归算法查找指定 ID 的 Control.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="controlID"></param>
        /// <returns></returns>
        private static Control FindControlForeach(Control control, string controlID)
        {
            Control resultControl = control.FindControl(controlID);
            if (resultControl == null)
            {
                foreach (Control childControl in control.Controls)
                {
                    resultControl = FindControlForeach(childControl, controlID);
                    if (resultControl != null) break;
                }
            }
            return resultControl;
        }
    }
}
