using System;
using System.Collections.Generic;
using System.Text;

namespace XK.NBear.Common
{
    public class WmvModel : IPlay
    {
        private StringBuilder mediaCode = new StringBuilder();

        public string Play(string mediaPath, string width, string height)
        {
            mediaCode.Append(string.Format("<OBJECT ID=\"WMPLAY\" STYLE=\"WIDTH:{0}PX;HEIGHT:{1}PX\" CLASSID=\"CLSID:6BF52A52-394A-11D3-B153-00C04F79FAA6\" TYPE=APPLICATION/X-OLEOBJECT STANDBY=\"LOADING WINDOWS MEDIA PLAYER COMPONENTS...\" CODEBASE=\"DOWNLOADS/MEDIAPLAYER9.0_CN.EXE\" VIEWASTEXT > \n", width, height));
            mediaCode.Append(string.Format("<PARAM NAME=\"URL\" VALUE='{0}'>\n", mediaPath));
            mediaCode.Append("<PARAM NAME=\"CONTROLS\" VALUE=\"CONTROLPANEL,STATUMEDIACODEA\">");
            mediaCode.Append("<PARAM NAME=\"HIDDEN\" VALUE=\"1\">");
            mediaCode.Append("<PARAM NAME=\"SHOWCONTROLS\" VALUE=\"1\">");
            mediaCode.Append("<PARAM NAME=\"RATE\" VALUE=\"1\">\n");
            mediaCode.Append("<PARAM NAME=\"BALANCE\" VALUE=\"0\">\n");
            mediaCode.Append("<PARAM NAME=\"CURRENTPOSITION\" VALUE=\"-1\">\n");
            mediaCode.Append("<PARAM NAME=\"DEFAULTFRAME\" VALUE=\"\">\n");
            mediaCode.Append("<PARAM NAME=\"PLAYCOUNT\" VALUE=\"100\">\n");
            mediaCode.Append("<PARAM NAME=\"AUTOSTART\" VALUE=\"-1\">\n");
            mediaCode.Append("<PARAM NAME=\"CURRENTMARKER\" VALUE=\"0\">\n");
            mediaCode.Append("<PARAM NAME=\"INVOKEURLS\" VALUE=\"-1\">\n");
            mediaCode.Append("<PARAM NAME=\"BASEURL\" VALUE=\"\">\n");
            mediaCode.Append("<PARAM NAME=\"VOLUME\" VALUE=\"85\">\n");
            mediaCode.Append("<PARAM NAME=\"MUTE\" VALUE=\"0\">\n");
            mediaCode.Append("<PARAM NAME=\"UIMODE\" VALUE=\"MINI\">\n");
            mediaCode.Append("<PARAM NAME=\"STRETCHTOFIT\" VALUE=\"0\">\n");
            mediaCode.Append("<PARAM NAME=\"WINDOWLESSVIDEO\" VALUE=\"0\">\n");
            mediaCode.Append("<PARAM NAME=\"ENABLED\" VALUE=\"-1\">\n");
            mediaCode.Append("<PARAM NAME=\"ENABLECONTEXTMENU\" VALUE=\"TRUE\">\n");
            mediaCode.Append("<PARAM NAME=\"FULLSCREEN\" VALUE=\"0\">\n");
            mediaCode.Append("<PARAM NAME=\"SAMISTYLE\" VALUE=\"\">\n");
            mediaCode.Append("<PARAM NAME=\"SAMILANG\" VALUE=\"\">\n");
            mediaCode.Append("<PARAM NAME=\"SAMIFILENAME\" VALUE=\"\">\n");
            mediaCode.Append("<PARAM NAME=\"CAPTIONINGID\" VALUE=\"\">\n");
            mediaCode.Append("</OBJECT><BR>\n");
            return mediaCode.ToString().Trim();
        }
    }
}
