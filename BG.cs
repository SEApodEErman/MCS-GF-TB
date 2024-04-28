using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class BG : StoryboardObjectGenerator
    {

        
        public override void Generate()
        {
            // "Remove" BG from the storyboard.
            GetLayer("").CreateSprite(Beatmap.BackgroundPath).Fade(0,0);

            // We declare the variables of the background that we wanna use here.
            var bitmap = GetMapsetBitmap("sb/bggray.jpg"); // Everything has the same resolution so let's just use one bitmap.
            var bg = GetLayer("").CreateSprite("bg.jpg", OsbOrigin.Centre);
            var bgblurred = GetLayer("").CreateSprite("sb/bgblurred.jpg", OsbOrigin.Centre);
            var bggray = GetLayer("").CreateSprite("sb/bggray.jpg", OsbOrigin.Centre);
            var bggrayblurred = GetLayer("").CreateSprite("sb/bggrayblurred.jpg", OsbOrigin.Centre);

            //Please ignore my tendency to keep changing around how I use the Fade method.
            // Normal BG
            bg.Scale(20483, 480.0f / bitmap.Height);
            
            bg.Fade(20483, 1);
            bg.Fade(39683, 0);
            bg.Fade(90083, 1);
            bg.Fade(128483, 0);
            bg.Fade(186083, 1);
            bg.Fade(205283, 0);
            bg.Fade(224483 , 1);
            bg.Fade(262884, 1);
            bg.Fade(282084,0);

            // Blurred BG
            bgblurred.Scale(41933, 480.0f / bitmap.Height);
            bgblurred.Fade(41933, 0.5);
            bgblurred.Fade(70884, 0);
            bgblurred.Fade(OsbEasing.OutExpo,147233,147684,0, 0.4);
            bgblurred.Fade(OsbEasing.OutExpo,243684,243684 + 100,0, 1);
            bgblurred.Fade(205283 + 100, 0);
            bgblurred.Fade(OsbEasing.InExpo,253283 - 200,253283,1, 0);

            bgblurred.Scale(OsbEasing.OutExpo,61284,61284 + 200, 480.0f / bitmap.Height,480.0f / bitmap.Height * 1.1);
            bgblurred.Scale(OsbEasing.OutExpo,70583,70884, 480.0f / bitmap.Height * 1.1,480.0f / bitmap.Height);
            bgblurred.Scale(OsbEasing.OutExpo,166884,166884 + 200, 480.0f / bitmap.Height,480.0f / bitmap.Height * 1.1);
            bgblurred.Scale(OsbEasing.OutExpo,185934,186083, 480.0f / bitmap.Height * 1.1,480.0f / bitmap.Height);
            bgblurred.Scale(OsbEasing.OutExpo,243684,243684 + 200, 480.0f / bitmap.Height, 480.0f / bitmap.Height * 1.1);
            bgblurred.Scale(OsbEasing.InExpo,253283 - 100,253283, 480.0f / bitmap.Height * 1.1,480.0f / bitmap.Height);
            
            // Grayscaled BG
            bggray.Scale(10884, 480.0f / bitmap.Height);
            bggray.Fade(OsbEasing.OutExpo,10884, 10884 + 500, 0.2, 0.5);
            bggray.Fade(19884,0);
            bggray.Fade(OsbEasing.OutExpo,70884 - 100,70884,0,0.3);
            bggray.Fade(90083,0);

            //Blurred Grayscaled BG
            bggrayblurred.Scale(684, 480.0f / bitmap.Height);
            bggrayblurred.Fade(OsbEasing.OutExpo,684, 1684, 0, 0.4);
            bggrayblurred.Fade(OsbEasing.OutExpo,10884,10884 + 500,0.4, 0);
            bggrayblurred.Fade(OsbEasing.OutExpo,128483,132983,0, 0.4);
            bggrayblurred.Fade(147684,0);
            bggrayblurred.Fade(OsbEasing.OutExpo,282084-100,282084 + 500,0, 0.5);
            bggrayblurred.Fade(OsbEasing.InExpo,289283,292884,0.5,0);
        }   
    }
}
