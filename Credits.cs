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
    public class Credits : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            
		    
            var gftb = GetLayer("").CreateSprite("sb/texts/gftb.png", OsbOrigin.Centre);
            var mccs = GetLayer("").CreateSprite("sb/texts/mccs.png", OsbOrigin.Centre);
            var take = GetLayer("").CreateSprite("sb/texts/takehirotei.png", OsbOrigin.Centre);
            var custom = GetLayer("").CreateSprite("sb/texts/customby.png", OsbOrigin.Centre);
            var remix = GetLayer("").CreateSprite("sb/texts/remix.png", OsbOrigin.Centre);
            var admm = GetLayer("").CreateSprite("sb/texts/additional.png", OsbOrigin.Centre);
            var cpod = GetLayer("").CreateSprite("sb/texts/cpod.png", OsbOrigin.Centre);
            var sbhs = GetLayer("").CreateSprite("sb/texts/sbhs.png", OsbOrigin.Centre);
            var hf = GetLayer("").CreateSprite("sb/texts/hf.png", OsbOrigin.Centre);
            var gl = GetLayer("").CreateSprite("sb/texts/gl.png", OsbOrigin.Centre);

            gftb.Move(1284,320,240);
            gftb.Scale(OsbEasing.OutExpo,1284,1284 + 300,2,0.55);
            gftb.Fade(1284,1);
            gftb.Fade(3684,0);


            mccs.Move(OsbEasing.OutExpo,1284,1284 + 300,320 - 50,240 - 25,320, 240 -25);
            mccs.Scale(1284,0.25);
            mccs.Fade(1284,1);
            mccs.Fade(3684,0);

            take.Move(3684,320,240);
            take.Scale(OsbEasing.OutExpo,3684,3684 + 300,2,0.55);
            take.Fade(3684,1);
            take.Fade(5783,0);


            custom.Move(OsbEasing.OutExpo,3684,3684 + 300,320 - 50,240 - 25,320, 240 -25);
            custom.Scale(3684,0.25);
            custom.Fade(3684,1);
            custom.Fade(5783,0);

            remix.Move(6084,320,240);
            remix.Scale(OsbEasing.OutExpo,6084,6084 + 300,2,0.55);
            remix.Fade(6084,1);
            remix.Fade(8484,0);


            admm.Move(OsbEasing.OutExpo,5783,5783 + 300,320 - 50,240 - 25,320, 240 -25);
            admm.Scale(5783,0.25);
            admm.Fade(5783,1);
            admm.Fade(8484,0);
            
            cpod.Move(8484,320,240);
            cpod.Scale(OsbEasing.OutExpo,8484,8484 + 300,2,0.55);
            cpod.Fade(8484,1);
            cpod.Fade(9684,0);


            sbhs.Move(OsbEasing.OutExpo,8484,8484 + 300,320 - 50,240 - 25,320, 240 -25);
            sbhs.Scale(8484,0.25);
            sbhs.Fade(8484,1);
            sbhs.Fade(9684,0);

            hf.Move(9684,320,240);
            hf.Scale(OsbEasing.OutExpo,9684,9684 + 300,2,0.55);
            hf.Fade(9684,1);
            hf.Fade(10883,0);


            gl.Move(OsbEasing.OutExpo,9684,9684 + 300,320 - 50,240 - 25,320, 240 -25);
            gl.Scale(9684,0.25);
            gl.Fade(9684,1);
            gl.Fade(10883,0);
        }
    }
}
