using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace XK.NBear.Common
{
    public static class MediaFactory
    {
        public static string CreatePlayer(string mediaPath, string width, string height)
        {
            string player = string.Empty;
            string extendName = mediaPath.Substring(mediaPath.LastIndexOf('.') + 1, mediaPath.Length - mediaPath.LastIndexOf('.') - 1);
            switch (extendName.ToLower())
            {
                case "wmv": player = new WmvModel().Play(mediaPath, width, height); break;
                case "wma": player = new WmvModel().Play(mediaPath, width, height); break;
                case "mpg": player = new WmvModel().Play(mediaPath, width, height); break;
                case "asf": player = new WmvModel().Play(mediaPath, width, height); break;
                case "avi": player = new WmvModel().Play(mediaPath, width, height); break;
                case "swf": player = new SwfModel().Play(mediaPath, width, height); break;
                default: player = string.Empty; break;
            }
            return player;
        }
    }
}
