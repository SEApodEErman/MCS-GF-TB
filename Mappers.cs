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
    public class Mappers : StoryboardObjectGenerator
    {
        public override void Generate()
        {   

            //The box (scrapping the box for now)
		    //var box = GetLayer("").CreateSprite("sb/px.png", OsbOrigin.BottomCentre, new Vector2(50, 420));
            //box.ColorHsb(20483,20, 1, 33);
            //box.ScaleVec(20483,100,30);
            //box.Fade(20483,20483 + 10000, 0.8 , 0.8);

            var shadow = GetLayer("").CreateSprite("sb/mpfp/agagak.jpg", OsbOrigin.Centre);
            
            //Variables for mappers pfp and names
            var agagak = GetLayer("").CreateSprite("sb/mpfp/agagak.jpg", OsbOrigin.Centre);
            var banner = GetLayer("").CreateSprite("sb/mpfp/banner.jpg", OsbOrigin.Centre);
            var ch10ew = GetLayer("").CreateSprite("sb/mpfp/ch10ew.jpg", OsbOrigin.Centre);
            var cpod = GetLayer("").CreateSprite("sb/mpfp/cpod.jpg", OsbOrigin.Centre);
            var frame = GetLayer("").CreateSprite("sb/mpfp/fram.jpg", OsbOrigin.Centre);
            var kard = GetLayer("").CreateSprite("sb/mpfp/kard.jpg", OsbOrigin.Centre);
            var kpmy = GetLayer("").CreateSprite("sb/mpfp/kpmy.jpg", OsbOrigin.Centre);

            //shadow
            shadow.Scale(10883,0.22);
            shadow.Color(10883,Color4.Black);
            shadow.Move(10883,-24,395 + 30);
            shadow.Fade(10883,39683,1,1);
            shadow.Fade(41933,128483,1,1);
            shadow.Fade(128483,128483 + 500,0,1);
            shadow.Fade(128483 + 500,282084,1,1);
            shadow.Fade(OsbEasing.InExpo,289283,292884,1,0);

            //agagak
            agagak.Scale(128483,0.2);
            agagak.Move(128483,-19,390 + 30);
            agagak.Fade(128483,128483 + 500,0,1);
            agagak.Fade(128483 + 500,166884,1,1);
            agagak.Fade(166884,0);
            //banner
            banner.Scale(61284,0.2);
            banner.Move(61284,-19,390 + 30);
            banner.Fade(61284,90083,1,1);
            banner.Fade(90083,0);
            banner.Fade(262884,1);
            banner.Fade(282084,0);

            //ch10ew
            ch10ew.Scale(109283,0.2);
            ch10ew.Move(109283,-19,390 + 30);
            ch10ew.Fade(109283,128483,1,1);
            ch10ew.Fade(128483,0);
            ch10ew.Fade(282084,1);
            ch10ew.Fade(OsbEasing.InExpo,289283,292884,1,0);

            //cpod
            cpod.Scale(20483,0.2);
            cpod.Move(20483,-19,390 + 30);
            cpod.Fade(20483,39683,1,1);
            cpod.Fade(39683,0);
            cpod.Fade(90083,109283,1,1);
            cpod.Fade(109283,0);
            cpod.Fade(186083,1);
            cpod.Fade(205283,0);
            
            //frame
            frame.Scale(224483,0.2);
            frame.Move(224483,-19,390 + 30);
            frame.Fade(224483,1);
            frame.Fade(243684,0);

            //kard
            kard.Scale(41933,0.2);
            kard.Move(41933,-19,390 + 30);
            kard.Fade(41933,61284,1,1);
            kard.Fade(61284,0);
            kard.Fade(166884,1);
            kard.Fade(186083,0);

            //kpmy
            kpmy.Scale(10883,0.2);
            kpmy.Move(10883,-19,390 + 30);
            kpmy.Fade(11034,1);
            kpmy.Fade(20483,0);
            kpmy.Fade(243684,1);
            kpmy.Fade(262884,0);





            


            
        }
    }
}
