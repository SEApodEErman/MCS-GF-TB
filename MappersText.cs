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
    public class MappersText : StoryboardObjectGenerator
    {
        public override void Generate()
        {   
            //Using lyrics would've been more efficient here but whatever, what's done is done.

            //Variables for the text shadows
            var agagak2 = GetLayer("").CreateSprite("sb/texts/mappers/agagak.png", OsbOrigin.Centre);
            var banner2 = GetLayer("").CreateSprite("sb/texts/mappers/banner.png", OsbOrigin.Centre);
            var ch10ew2 = GetLayer("").CreateSprite("sb/texts/mappers/ch10ew.png", OsbOrigin.Centre);
            var cpod2 = GetLayer("").CreateSprite("sb/texts/mappers/cpod.png", OsbOrigin.Centre);
            var frame2 = GetLayer("").CreateSprite("sb/texts/mappers/frameglitch.png", OsbOrigin.Centre);
            var kard2 = GetLayer("").CreateSprite("sb/texts/mappers/kardshark.png", OsbOrigin.Centre);
            var kpmy2 = GetLayer("").CreateSprite("sb/texts/mappers/kpmy.png", OsbOrigin.Centre);

            //Variables for the actual white texts
		    var agagak = GetLayer("").CreateSprite("sb/texts/mappers/agagak.png", OsbOrigin.Centre);
            var banner = GetLayer("").CreateSprite("sb/texts/mappers/banner.png", OsbOrigin.Centre);
            var ch10ew = GetLayer("").CreateSprite("sb/texts/mappers/ch10ew.png", OsbOrigin.Centre);
            var cpod = GetLayer("").CreateSprite("sb/texts/mappers/cpod.png", OsbOrigin.Centre);
            var frame = GetLayer("").CreateSprite("sb/texts/mappers/frameglitch.png", OsbOrigin.Centre);
            var kard = GetLayer("").CreateSprite("sb/texts/mappers/kardshark.png", OsbOrigin.Centre);
            var kpmy = GetLayer("").CreateSprite("sb/texts/mappers/kpmy.png", OsbOrigin.Centre);

            //agagak
            agagak2.Color(128483,Color4.Black);
            agagak2.Scale(128483,0.35);
            agagak2.Move(128483,76,393+33);
            agagak2.Fade(128483,128483 + 500,0,1);
            agagak2.Fade(166884,0);

            agagak.Scale(128483,0.35);
            agagak.Move(128483,78,390+33);
            agagak.Fade(128483,128483 + 500,0,1);
            agagak.Fade(166884,1);

            //banner
            banner2.Color(61284,Color4.Black);
            banner2.Scale(61284,0.35);
            banner2.Move(61284,76,393+ 30);
            banner2.Fade(61284,1);
            banner2.Fade(90083,0);
            banner2.Fade(262884,1);
            banner2.Fade(282084,0);

            banner.Scale(61284,0.35);
            banner.Move(61284,78,390+ 30);
            banner.Fade(61284,1);
            banner.Fade(90083,0);
            banner.Fade(262884,1);
            banner.Fade(282084,0);
            //ch10ew
            ch10ew2.Color(109283,Color4.Black);
            ch10ew2.Scale(109283,0.35);
            ch10ew2.Move(109283,76+5,393+ 30);
            ch10ew2.Fade(109283,1);
            ch10ew2.Fade(128483,0);
            ch10ew2.Fade(282084,1);
            ch10ew2.Fade(OsbEasing.InExpo,289283,292884,1,0);

            ch10ew.Scale(109283,0.35);
            ch10ew.Move(109283,78+5,390+ 30);
            ch10ew.Fade(109283,1);
            ch10ew.Fade(128483,0);
            ch10ew.Fade(282084,1);
            ch10ew.Fade(OsbEasing.InExpo,289283,292884,1,0);


            //cpod
            cpod2.Color(20483,Color4.Black);
            cpod2.Scale(20483,0.35);
            cpod2.Move(20483,76,393 + 30);
            cpod2.Fade(20483,1);
            cpod2.Fade(39683,0);
            cpod2.Fade(90083,1);
            cpod2.Fade(109283,0);
            cpod2.Fade(186083,1);
            cpod2.Fade(205283,0);

            cpod.Scale(20483,0.35);
            cpod.Move(20483,78,390+ 30);
            cpod.Fade(20483,1);
            cpod.Fade(39683,0);
            cpod.Fade(90083,1);
            cpod.Fade(109283,0);
            cpod.Fade(186083,1);
            cpod.Fade(205283,0);
            //frame
            frame2.Color(224483,Color4.Black);
            frame2.Scale(224483,0.35);
            frame2.Move(224483,108 + 10,393+ 30);
            frame2.Fade(224483,1);
            frame2.Fade(243684,0);

            frame.Scale(224483,0.35);
            frame.Move(224483,110 + 10,390+ 30);
            frame.Fade(224483,1);
            frame.Fade(243684,0);
            //kard
            kard2.Color(41933,Color4.Black);
            kard2.Scale(41933,0.35);
            kard2.Move(41933,108,393+ 30);
            kard2.Fade(41933,1);
            kard2.Fade(61284,0);
            kard2.Fade(166884,1);
            kard2.Fade(186083,0);


            kard.Scale(41933,0.35);
            kard.Move(41933,110,390+ 30);
            kard.Fade(41933,1);
            kard.Fade(61284,0);
            kard.Fade(166884,1);
            kard.Fade(186083,0);

            //kpmy
            kpmy2.Color(10883,Color4.Black);
            kpmy2.Scale(10883,0.4);
            kpmy2.Move(10883,72,393+ 30);
            kpmy2.Fade(10883,1);
            kpmy2.Fade(20483,0);
            kpmy2.Fade(243684,1);
            kpmy2.Fade(262884,0);

            kpmy.Scale(10883,0.4);
            kpmy.Move(10883,74,390+ 30);
            kpmy.Fade(10883,1);
            kpmy.Fade(20483,0);
            kpmy.Fade(243684,1);
            kpmy.Fade(262884,1);
            
            
        }
    }
}
