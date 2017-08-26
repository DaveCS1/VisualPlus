﻿#region Namespace

using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using VisualPlus.Structure;

#endregion

namespace VisualPlus.Styles
{
    public class Visual : IBorder, ICheckmark, IControl, IControlState, IFont, IProgress, ITab, IWatermark
    {
        #region Variables

        private readonly Color defaultBackgroundColorNoDepth = Color.White;
        private readonly float[] triplePosition = {0, 1 / 2f, 1};
        private readonly float[] twoPosition = {0, 1};

        #endregion

        #region Properties

        public Color ActiveColor
        {
            get { return Color.Gray; }
        }

        public Color BackCircle
        {
            get { return Color.FromArgb(52, 73, 96); }
        }

        public Gradient BackProgress
        {
            get
            {
                Color[] backgroundColors =
                {
                    ControlPaint.Light(Color.Gainsboro),
                    Color.Gainsboro
                };

                Gradient backgroundGradient = new Gradient
                {
                    Colors = backgroundColors,
                    Positions = twoPosition
                };

                return backgroundGradient;
            }
        }

        public Gradient BoxDisabled
        {
            get
            {
                Color[] boxDisabledColors =
                {
                    ControlPaint.Light(Color.FromArgb(131, 129, 129)),
                    Color.FromArgb(131, 129, 129)
                };

                Gradient boxDisabled = new Gradient
                {
                    Colors = boxDisabledColors,
                    Positions = twoPosition
                };

                return boxDisabled;
            }
        }

        public Gradient BoxEnabled
        {
            get
            {
                Color[] boxEnabledColors =
                {
                    ControlPaint.Light(Color.FromArgb(241, 244, 249)),
                    Color.FromArgb(241, 244, 249)
                };

                Gradient boxEnabled = new Gradient
                {
                    Colors = boxEnabledColors,
                    Positions = twoPosition
                };

                return boxEnabled;
            }
        }

        public Color Color
        {
            get { return Color.FromArgb(180, 180, 180); }
        }

        public Gradient ControlDisabled
        {
            get
            {
                Color[] controlDisabledColors =
                {
                    Color.FromArgb(243, 243, 243),
                    ControlPaint.Light(Color.FromArgb(243, 243, 243)),
                    Color.FromArgb(243, 243, 243)
                };

                Gradient controlDisabled = new Gradient
                {
                    Colors = controlDisabledColors,
                    Positions = triplePosition
                };

                return controlDisabled;
            }
        }

        public Gradient ControlEnabled
        {
            get
            {
                Color[] controlEnabledColors =
                {
                    Color.FromArgb(226, 226, 226),
                    ControlPaint.Light(Color.FromArgb(226, 226, 226)),
                    Color.FromArgb(226, 226, 226)
                };

                Gradient controlEnabled = new Gradient
                {
                    Colors = controlEnabledColors,
                    Positions = triplePosition
                };

                return controlEnabled;
            }
        }

        public Gradient ControlHover
        {
            get
            {
                Color[] controlHoverColors =
                {
                    Color.FromArgb(181, 181, 181),
                    ControlPaint.Light(Color.FromArgb(181, 181, 181)),
                    Color.FromArgb(181, 181, 181)
                };

                Gradient controlHover = new Gradient
                {
                    Colors = controlHoverColors,
                    Positions = triplePosition
                };

                return controlHover;
            }
        }

        public Gradient ControlPressed
        {
            get
            {
                Color[] controlPressedColors =
                {
                    Color.FromArgb(137, 136, 136),
                    ControlPaint.Light(Color.FromArgb(137, 136, 136)),
                    Color.FromArgb(137, 136, 136)
                };

                Gradient controlPressed = new Gradient
                {
                    Colors = controlPressedColors,
                    Positions = triplePosition
                };

                return controlPressed;
            }
        }

        public Gradient DisabledGradient
        {
            get
            {
                Color[] disabledColors =
                {
                    ControlPaint.Light(Color.FromArgb(131, 129, 129)),
                    Color.FromArgb(131, 129, 129)
                };

                Gradient disabledGradient = new Gradient
                {
                    Colors = disabledColors,
                    Positions = twoPosition
                };

                return disabledGradient;
            }
        }

        public Gradient EnabledGradient
        {
            get
            {
                Color[] enabledColors =
                {
                    ControlPaint.Light(ColorTranslator.FromHtml("#2D882D")),
                    ColorTranslator.FromHtml("#2D882D")
                };

                Gradient enabledGradient = new Gradient
                {
                    Colors = enabledColors,
                    Positions = twoPosition
                };

                return enabledGradient;
            }
        }

        public Color FlatButtonDisabled
        {
            get { return Color.FromArgb(243, 243, 243); }
        }

        public Color FlatButtonEnabled
        {
            get { return Color.FromArgb(119, 119, 118); }
        }

        public FontFamily FontFamily
        {
            get { return new FontFamily("Segoe UI"); }
        }

        public float FontSize
        {
            get { return 8.25F; }
        }

        public FontStyle FontStyle
        {
            get { return FontStyle.Regular; }
        }

        public Color ForeCircle
        {
            get { return Color.FromArgb(48, 56, 68); }
        }

        public Color ForeColor
        {
            get { return Color.Black; }
        }

        public Color ForeColorDisabled
        {
            get { return Color.FromArgb(131, 129, 129); }
        }

        public Color ForeColorSelected
        {
            get { return Color.FromArgb(217, 220, 227); }
        }

        public Color Hatch
        {
            get { return Color.FromArgb(20, Color.Black); }
        }

        public Color HoverColor
        {
            get { return Color.FromArgb(120, 183, 230); }
        }

        public Color InactiveColor
        {
            get { return Color.LightGray; }
        }

        public Color ItemEnabled
        {
            get { return Color.White; }
        }

        public Color ItemHover
        {
            get { return Color.FromArgb(241, 241, 241); }
        }

        public Color Line
        {
            get { return Color.FromArgb(224, 222, 220); }
        }

        public Color Menu
        {
            get { return Color.FromArgb(55, 61, 73); }
        }

        public Gradient Progress
        {
            get
            {
                Color[] progressColors =
                {
                    ControlPaint.Light(ColorTranslator.FromHtml("#2D882D")),
                    ColorTranslator.FromHtml("#2D882D")
                };

                Gradient progressGradient = new Gradient
                {
                    Colors = progressColors,
                    Positions = twoPosition
                };

                return progressGradient;
            }
        }

        public Gradient ProgressDisabled
        {
            get
            {
                Color[] progressDisabledColors =
                {
                    ControlPaint.Light(Color.FromArgb(131, 129, 129)),
                    Color.FromArgb(131, 129, 129)
                };

                Gradient progressDisabled = new Gradient
                {
                    Colors = progressDisabledColors,
                    Positions = twoPosition
                };

                return progressDisabled;
            }
        }

        public Color Shadow
        {
            get { return Color.FromArgb(250, 249, 249); }
        }

        public Enumerators.Styles StyleManagement
        {
            get { return Enumerators.Styles.Visual; }
        }

        public Color TabEnabled
        {
            get { return Color.FromArgb(55, 61, 73); }
        }

        public Color TabHover
        {
            get { return Color.FromArgb(35, 36, 38); }
        }

        public Color TabSelected
        {
            get { return Color.FromArgb(70, 76, 88); }
        }

        #endregion

        #region Events

        private static List<Color> GetBackgroundColor()
        {
            var list = new List<Color>
            {
                ControlPaint.LightLight(Color.Gainsboro),
                ControlPaint.Light(Color.Gainsboro),
                Color.FromArgb(66, 64, 65),
                Color.FromArgb(241, 244, 249)
            };

            return list;
        }

        Color IControl.Background(int depth)
        {
            if (depth < GetBackgroundColor().Count)
            {
                return GetBackgroundColor()[depth];
            }

            return defaultBackgroundColorNoDepth;
        }

        #endregion
    }
}