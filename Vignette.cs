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
    public class Vignette : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    var bitmap = GetMapsetBitmap("sb/v.png");
            var vig = GetLayer("").CreateSprite("sb/v.png", OsbOrigin.Centre);

            vig.Scale(0, 480.0f / bitmap.Height);
            vig.Fade(684,1);
            vig.Fade(332726,0);
            
        }
    }
}
