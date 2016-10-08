using System;
using System.Collections.Generic;
using System.Text;

namespace XK.NBear.Common
{
    public class SwfModel : IPlay
    {
        private StringBuilder mediaCode = new StringBuilder();

        public string Play(string mediaPath, string width, string height)
        {
            mediaCode.Append(string.Format("<OBJECT CODEBASE=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0\" HEIGHT=\"{0}\" WIDTH=\"{1}\" >", height, width));
            mediaCode.Append("<PARAM NAME=\"FLASHVARS\" VALUE=\"\">");
            mediaCode.Append(string.Format("<PARAM NAME=\"MOVIE\" VALUE=\"\">"));
            mediaCode.Append(string.Format("<PARAM NAME=\"SRC\" VALUE=\"{0}\">", mediaPath));
            mediaCode.Append("<PARAM NAME=\"WMode\" VALUE=\"Window\">");
            mediaCode.Append("<PARAM NAME=\"Play\" VALUE=\"-1\">");
            mediaCode.Append("<PARAM NAME=\"Loop\" VALUE=\"-1\">");
            mediaCode.Append("<PARAM NAME=\"Quality\" VALUE=\"High\">");
            mediaCode.Append("<PARAM NAME=\"SAlign\" VALUE=\"\">");
            mediaCode.Append("<PARAM NAME=\"Menu\" VALUE=\"0\">");
            mediaCode.Append("<PARAM NAME=\"Base\" VALUE=\"\">");
            mediaCode.Append("<PARAM NAME=\"ALLOWSCRIPTACCESS\" VALUE=\"always\">");
            mediaCode.Append("<PARAM NAME=\"Scale\" VALUE=\"ShowAll\">");
            mediaCode.Append("<PARAM NAME=\"DeviceFont\" VALUE=\"0\">");
            mediaCode.Append("<PARAM NAME=\"EmbedMovie\" VALUE=\"0\">");
            mediaCode.Append("<PARAM NAME=\"BGColor\" VALUE=\"\">");
            mediaCode.Append("<PARAM NAME=\"SWRemote\" VALUE=\"\">");
            mediaCode.Append("<PARAM NAME=\"MovieData\" VALUE=\"\">");
            mediaCode.Append("<PARAM NAME=\"SeamlessTabbing\" VALUE=\"1\">");
            mediaCode.Append(string.Format("<EMBED SRC=\"{0}\" HEIGHT=\"{1}\" WIDTH=\"{2}\" QUALITY=\"HIGH\" PLUGINSPAGE=\"\" MENU=\"FALSE\"></EMBED>", mediaPath, height, width));
            mediaCode.Append("</OBJECT>");
            return mediaCode.ToString().Trim();
        }
    }
}
