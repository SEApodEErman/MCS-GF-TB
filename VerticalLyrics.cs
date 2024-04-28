using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Subtitles;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;

namespace StorybrewScripts
{
    public class VerticalLyrics : StoryboardObjectGenerator
    {
        [Description("Path to a .sbv, .srt, .ass or .ssa file in your project's folder.\nThese can be made with a tool like aegisub.")]
        [Configurable] public string SubtitlesPath = "lyrics.srt";
        [Configurable] public float SubtitleX = 400;

        [Configurable] public float SubtitleY = 10;
        [Configurable] public float verticalShift = 20;

        [Configurable] public float spacing = 30;

        [Group("Font")]
        [Description("The name of a system font, or the path to a font relative to your project's folder.\nIt is preferable to add fonts to the project folder and use their file name rather than installing fonts.")]
        [Configurable] public string FontName = "Verdana";
        [Description("A path inside your mapset's folder where lyrics images will be generated.")]
        [Configurable] public string SpritesPath = "sb/f";
        [Description("The Size of the font.\nIncreasing the font size creates larger images.")]
        [Configurable] public int FontSize = 26;
        [Description("The Scale of the font.\nIncreasing the font scale does not creates larger images, but the result may be blurrier.")]
        [Configurable] public float FontScale = 0.5f;
        [Configurable] public Color4 FontColor = Color4.White;
        [Configurable] public FontStyle FontStyle = FontStyle.Regular;

        [Group("Outline")]
        [Configurable] public int OutlineThickness = 3;
        [Configurable] public Color4 OutlineColor = new Color4(50, 50, 50, 200);

        [Group("Shadow")]
        [Configurable] public int ShadowThickness = 0;
        [Configurable] public Color4 ShadowColor = new Color4(0, 0, 0, 100);

        [Group("Glow")]
        [Configurable] public int GlowRadius = 0;
        [Configurable] public Color4 GlowColor = new Color4(255, 255, 255, 100);
        [Configurable] public bool GlowAdditive = true;

        [Group("Misc")]
        [Configurable] public bool PerCharacter = true;

        [Configurable] public bool Vertical = true;
        [Configurable] public bool blackBar = true;
        [Configurable] public bool TrimTransparency = true;
        [Configurable] public bool EffectsOnly = false;
        [Description("How much extra space is allocated around the text when generating it.\nShould be increased when characters look cut off.")]
        [Configurable] public Vector2 Padding = Vector2.Zero;
        [Configurable] public OsbOrigin Origin = OsbOrigin.Centre;

        public override void Generate()
        {
            var font = LoadFont(SpritesPath, new FontDescription()
            {
                FontPath = FontName,
                FontSize = FontSize,
                Color = FontColor,
                Padding = Padding,
                FontStyle = FontStyle,
                TrimTransparency = TrimTransparency,
                EffectsOnly = EffectsOnly,
            },
            new FontGlow()
            {
                Radius = GlowAdditive ? 0 : GlowRadius,
                Color = GlowColor,
            },
            new FontOutline()
            {
                Thickness = OutlineThickness,
                Color = OutlineColor,
            },
            new FontShadow()
            {
                Thickness = ShadowThickness,
                Color = ShadowColor,
            });

            var subtitles = LoadSubtitles(SubtitlesPath);

            if (GlowRadius > 0 && GlowAdditive)
            {
                var glowFont = LoadFont(Path.Combine(SpritesPath, "glow"), new FontDescription()
                {
                    FontPath = FontName,
                    FontSize = FontSize,
                    Color = FontColor,
                    Padding = Padding,
                    FontStyle = FontStyle,
                    TrimTransparency = TrimTransparency,
                    EffectsOnly = true,
                },
                new FontGlow()
                {
                    Radius = GlowRadius,
                    Color = GlowColor,
                });
                generateLyrics(glowFont, subtitles, "glow", true);
            }
            generateLyrics(font, subtitles, "", false);
        }

        public void generateLyrics(FontGenerator font, SubtitleSet subtitles, string layerName, bool additive)
        {
            var layer = GetLayer(layerName);
            if (PerCharacter && Vertical) generatePerCharacterVertically(font, subtitles, layer, additive);
            else if (PerCharacter) generatePerCharacterHorizontally(font, subtitles, layer, additive);
            else generatePerLine(font, subtitles, layer, additive);
        }

        public void generatePerLine(FontGenerator font, SubtitleSet subtitles, StoryboardLayer layer, bool additive)
        {
            foreach (var line in subtitles.Lines)
            {
                var texture = font.GetTexture(line.Text);
                var position = new Vector2(320 - texture.BaseWidth * FontScale * 0.5f, SubtitleX)
                    + texture.OffsetFor(Origin) * FontScale;

                var sprite = layer.CreateSprite(texture.Path, Origin, position);
                sprite.Scale(line.StartTime, FontScale);
                sprite.Fade(line.StartTime - 200, line.StartTime, 0, 1);
                sprite.Fade(line.EndTime - 200, line.EndTime, 1, 0);
                if (additive) sprite.Additive(line.StartTime - 200, line.EndTime);
            }
        }

        public void generatePerCharacterVertically(FontGenerator font, SubtitleSet subtitles, StoryboardLayer layer, bool additive)
        {
            foreach (var subtitleLine in subtitles.Lines)
            {
                var letterX = SubtitleX;
                var delay = 0; 
                var i = 0;
                var dir = 1;
                foreach (var line in subtitleLine.Text.Split('\n'))
                {
                    var lineWidth = 0f;
                    var lineHeight = 0f;
                    foreach (var letter in line)
                    {
                        var texture = font.GetTexture(letter.ToString());
                        lineWidth = Math.Max(lineWidth, texture.BaseWidth * FontScale);
                        lineHeight += texture.BaseHeight * FontScale;
                    }

                    
                    var letterY = SubtitleY + verticalShift * i;

                    if(blackBar){
                        var p = layer.CreateSprite("sb/p.png", OsbOrigin.TopCentre, new Vector2(letterX, letterY));
                        p.ScaleVec(OsbEasing.OutExpo, subtitleLine.StartTime + delay, subtitleLine.EndTime, lineWidth, 0, lineWidth, lineHeight);
                        p.Color(subtitleLine.StartTime + delay, Color4.Black);
                        p.Fade(subtitleLine.EndTime - 200, subtitleLine.EndTime, 1, 0);
                    }
                    
                    
                    foreach (var letter in line)
                    {
                        var texture = font.GetTexture(letter.ToString());
                        if (!texture.IsEmpty)
                        {
                            var position = new Vector2(letterX, letterY)
                                + texture.OffsetFor(Origin) * FontScale;

                            var sprite = layer.CreateSprite(texture.Path, Origin, position);
                            sprite.Scale(subtitleLine.StartTime + delay, FontScale);
                            sprite.Fade(subtitleLine.StartTime - 200 + delay, subtitleLine.StartTime + delay, 0, 1);
                            sprite.MoveX(OsbEasing.OutExpo, subtitleLine.StartTime - 200 + delay, subtitleLine.EndTime, letterX, letterX + 5 * dir);
                            sprite.Rotate(OsbEasing.OutExpo, subtitleLine.StartTime - 200 + delay, subtitleLine.EndTime, 0, Math.PI/30 * dir);
                            sprite.Fade(subtitleLine.EndTime - 200, subtitleLine.EndTime, 1, 0);
                            if (additive) sprite.Additive(subtitleLine.StartTime - 200 + delay, subtitleLine.EndTime);
                        }
                        letterY += texture.BaseHeight * FontScale;
                        delay += 100;
                        dir *= -1;
                    }
                    letterX -= lineWidth + spacing;
                    i++;
                }
            }
        }

        public void generatePerCharacterHorizontally(FontGenerator font, SubtitleSet subtitles, StoryboardLayer layer, bool additive)
        {
            foreach (var subtitleLine in subtitles.Lines)
            {
                var letterY = SubtitleY;
                var delay = 0;
                var dir = 1;
                foreach (var line in subtitleLine.Text.Split('\n'))
                {
                    var lineWidth = 0f;
                    var lineHeight = 0f;
                    foreach (var letter in line)
                    {
                        var texture = font.GetTexture(letter.ToString());
                        lineWidth += texture.BaseWidth * FontScale;
                        lineHeight = Math.Max(lineHeight, texture.BaseHeight * FontScale);
                    }

                    var letterX = 320f;

                    if(blackBar){
                        var p = layer.CreateSprite("sb/p.png", OsbOrigin.CentreLeft, new Vector2(letterX, letterY));
                        p.ScaleVec(OsbEasing.OutExpo, subtitleLine.StartTime + delay, subtitleLine.EndTime, 0, lineHeight, lineWidth, lineHeight);
                        p.Color(subtitleLine.StartTime + delay, Color4.Black);
                        p.Fade(subtitleLine.EndTime - 200, subtitleLine.EndTime, 1, 0);
                    }
                    
                    foreach (var letter in line)
                    {
                        var texture = font.GetTexture(letter.ToString());
                        if (!texture.IsEmpty)
                        {
                            var position = new Vector2(letterX, letterY)
                                + texture.OffsetFor(Origin) * FontScale;

                            var sprite = layer.CreateSprite(texture.Path, Origin, position);
                            sprite.Scale(subtitleLine.StartTime + delay, FontScale);
                            sprite.Fade(subtitleLine.StartTime - 200 + delay, subtitleLine.StartTime + delay, 0, 1);
                            sprite.MoveY(OsbEasing.OutExpo, subtitleLine.StartTime - 200 + delay, subtitleLine.EndTime, letterY, letterY + 5 * dir);
                            sprite.Rotate(OsbEasing.OutExpo, subtitleLine.StartTime - 200 + delay, subtitleLine.EndTime, 0, Math.PI/30 * dir);
                            sprite.Fade(subtitleLine.EndTime - 200, subtitleLine.EndTime, 1, 0);
                            if (additive) sprite.Additive(subtitleLine.StartTime - 200 + delay, subtitleLine.EndTime);
                        }
                        letterX += texture.BaseWidth * FontScale;
                        delay += 100;
                        dir *= -1;
                    }
                    letterY += lineHeight + spacing;
                }
            }
        }
    }
}
