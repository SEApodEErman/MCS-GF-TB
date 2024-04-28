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
    public class TransitionFlash : StoryboardObjectGenerator
    {
        public override void Generate()
        {

            
		    //I hope no one gets mad that I use a 16x9 pixel cuz I'm lazy to use Vector Scale LOL.
            var bitmap = GetMapsetBitmap("sb/tp.png");
            var tp = GetLayer("").CreateSprite("sb/tp.png", OsbOrigin.Centre);
            
            //Forced to add credits here cuz the White background and black bars at the end is in here.

            //Storybrew keeps warning me about frame buffer or whatever but it seems to work fine without any noticable performance hit so whatever.
            var credits = GetLayer("").CreateSprite("sb/credits.png", OsbOrigin.Centre);// Yes I'm using a long ass image that scrolls for the credit instead of needing to use a billion individual images for everyone.
            var sthx = GetLayer("").CreateSprite("sb/sthx.png", OsbOrigin.Centre);
            var fmth = GetLayer("").CreateSprite("sb/fmth.png", OsbOrigin.Centre);            


            //Flashes
            tp.Scale(1284,480.0f / bitmap.Height);
            tp.Fade(OsbEasing.OutExpo,1284,1284 + 500, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,10883,10883 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,20483,20483 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,41933,41933 + 2000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,61284,61284 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,70884,70884 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,90083,90083 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,109283,109283 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,147684,147684 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,166884,166884 + 1000, 0.3, 0);
            tp.Fade(OsbEasing.OutExpo,186083,186083 + 1000, 0.5, 0);
            tp.Fade(OsbEasing.InExpo,202884,205283, 0, 1);
            tp.Fade(OsbEasing.OutExpo,224483,224483 + 1000, 0.5, 0);
            tp.Fade(OsbEasing.OutExpo,253283,253283 + 1000, 0.5, 0);
            tp.Fade(OsbEasing.OutExpo,262884,262884 + 1000, 0.5, 0);
            tp.Fade(OsbEasing.In,296283,297894, 0, 1);
            tp.Fade(OsbEasing.In,328498,331720, 1, 0);

            //Black Transition
            var b1 = GetLayer("").CreateSprite("sb/px.png", OsbOrigin.TopCentre, new Vector2(320, 0));
            var b2 = GetLayer("").CreateSprite("sb/px.png", OsbOrigin.BottomCentre, new Vector2(320, 480));

            b1.Color(18083, Color4.Black);
            b2.Color(18083, Color4.Black);
            
            //Ok I lied, but I'll only use it for this transition thingy because I only know how to do it properly here.
            b1.ScaleVec(OsbEasing.InExpo, 18083, 19284, 864, 0, 864, 240);
            b2.ScaleVec(OsbEasing.InExpo, 18083, 19284, 864, 0, 864, 240);

            // Ok IDK what happened here but it just killed everything it seems
            // So it's time for a hack
            // UPDATE: I know why but I cba to change everything and it doesn't seem to break anything so we're staying with this.
            b1.ScaleVec(20483,864, 0);
            b2.ScaleVec(20483,864, 0);

            b1.ScaleVec(OsbEasing.InExpo, 39083, 39683, 864, 0, 864, 240);
            b2.ScaleVec(OsbEasing.InExpo, 39083, 39683, 864, 0, 864, 240);

            b1.ScaleVec(39683,864, 0);
            b2.ScaleVec(39683,864, 0);

            b1.ScaleVec(OsbEasing.Out, 89484, 90083, 864, 0, 864, 240);
            b2.ScaleVec(OsbEasing.Out, 89484, 90083, 864, 0, 864, 240);

            b1.ScaleVec(90083,864, 0);
            b2.ScaleVec(90083,864, 0);

            b1.ScaleVec(OsbEasing.Out, 128184, 128483, 864, 0, 864, 480);
            b1.ScaleVec(128483,864, 0);

            b2.ScaleVec(224483,864, 0);

            //This is so ass but I guess that happens when you need to put something in between two (now three) things that's inside a single script.
            credits.Scale(297089,0.3);
            credits.Move(297089,325277,320,1200,320,-760);
            credits.Fade(297089,1);
            credits.Fade(325277,0);

            sthx.Scale(325277,0.5);
            sthx.Move(325277,320,240);
            sthx.Fade(325277,325277 + 400,0,1);
            sthx.Fade(327290-300,327290,1,0);

            fmth.Scale(327290,0.5);
            fmth.Move(327290,320,240);
            fmth.Fade(327290,327290 + 400,0,1);
            fmth.Fade(OsbEasing.In,328498,331720, 1, 0);

            b1.ScaleVec(OsbEasing.Out, 262584, 262884, 864, 0, 864, 240);
            b2.ScaleVec(OsbEasing.Out, 262584, 262884, 864, 0, 864, 240);

            b2.Color(262509, Color4.Black);
            b1.ScaleVec(262884,864, 0);
            b2.ScaleVec(262884,864, 0);

            b1.ScaleVec(296283,864,35);
            b2.ScaleVec(296283,864,35);
            b1.ScaleVec(331720,864, 0);
            b2.ScaleVec(331720,864, 0);

            
        }
    }
}
