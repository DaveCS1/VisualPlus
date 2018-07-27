﻿#region Namespace

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;

using VisualPlus.Constants;
using VisualPlus.Delegates;
using VisualPlus.Extensibility;
using VisualPlus.Localization;
using VisualPlus.Managers;
using VisualPlus.TypeConverters;

#endregion

namespace VisualPlus.Structure
{
    [TypeConverter(typeof(BasicSettingsTypeConverter))]
    [ToolboxItem(false)]
    [DesignerCategory("code")]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [ComVisible(true)]
    [Description("The Gradient structure.")]
    public class Gradient
    {
        #region Variables

        private float _angle;
        private Color[] _colors;
        private float[] _locations;
        private Rectangle _rectangle;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="Gradient" /> class.</summary>
        /// <param name="colors">The colors.</param>
        /// <param name="offsets">The offsets.</param>
        /// <param name="rectangle">The rectangle.</param>
        public Gradient(Color[] colors, float[] offsets, Rectangle rectangle) : this()
        {
            InitializeGradient(0, colors, SortPositions(offsets), rectangle);
        }

        /// <summary>Initializes a new instance of the <see cref="Gradient" /> class.</summary>
        /// <param name="angle">The angle.</param>
        /// <param name="colors">The colors.</param>
        /// <param name="offsets">The offsets.</param>
        /// <param name="rectangle">The rectangle.</param>
        public Gradient(float angle, Color[] colors, float[] offsets, Rectangle rectangle) : this()
        {
            InitializeGradient(angle, colors, SortPositions(offsets), rectangle);
        }

        /// <summary>Prevents a default instance of the <see cref="Gradient" /> class from being created.</summary>
        private Gradient()
        {
            _angle = 0;
            _colors = null;
            _locations = null;
            _rectangle = new Rectangle(0, 0, 1, 1);
            Brush = null;
        }

        #endregion

        #region Events

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event GradientAngleChangedEventHandler AngleChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event GradientColorChangedEventHandler ColorsChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event GradientPositionsChangedEventHandler PositionsChanged;

        [Category(EventCategory.PropertyChanged)]
        [Description(EventDescription.PropertyEventChanged)]
        public event GradientRectangleChangedEventHandler RectangleChanged;

        #endregion

        #region Properties

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Angle)]
        public float Angle
        {
            get
            {
                return _angle;
            }

            set
            {
                _angle = value;
                OnAngleChanged();
            }
        }

        /// <summary>The <see cref="LinearGradientBrush"></see> that can be used to paint the <see cref="Gradient"></see>.</summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public LinearGradientBrush Brush { get; private set; }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Colors)]
        public Color[] Colors
        {
            get
            {
                return _colors;
            }

            set
            {
                _colors = value;
                OnColorsChanged();
            }
        }

        /// <summary>Gets the total number of colors in all the dimensions of the <see cref="Gradient"></see>.</summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public int Count => Colors.Length == Locations.Length ? Colors.Length : 0;

        /// <summary>Gets the <see cref="Gradient" /> as an image.</summary>
        [Browsable(true)]
        [Description(PropertyDescription.Image)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public Image Image
        {
            get
            {
                Bitmap _bitmap = new Bitmap(_rectangle.Width, _rectangle.Height);
                Graphics _graphics = Graphics.FromImage(_bitmap);
                _graphics.FillRectangle(Brush, _rectangle);
                return _bitmap;
            }
        }

        /// <summary>Gets a value indicating whether this <see cref="Gradient" /> is empty.</summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public bool IsEmpty => (_colors.Length <= 0) && (_locations.Length <= 0);

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Positions)]
        public float[] Locations
        {
            get
            {
                return _locations;
            }

            set
            {
                _locations = value;
                OnPositionsChanged();
            }
        }

        [NotifyParentProperty(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Description(PropertyDescription.Rectangle)]
        public Rectangle Rectangle
        {
            get
            {
                return _rectangle;
            }

            set
            {
                _rectangle = value;
                OnRectangleChanged();
            }
        }

        #endregion

        #region Overrides

        protected virtual void OnAngleChanged()
        {
            InitializeGradient(_angle, _colors, SortPositions(_locations), _rectangle);
            AngleChanged?.Invoke();
        }

        protected virtual void OnColorsChanged()
        {
            InitializeGradient(_angle, _colors, SortPositions(_locations), _rectangle);
            ColorsChanged?.Invoke();
        }

        protected virtual void OnPositionsChanged()
        {
            InitializeGradient(_angle, _colors, SortPositions(_locations), _rectangle);
            PositionsChanged?.Invoke();
        }

        protected virtual void OnRectangleChanged()
        {
            InitializeGradient(_angle, _colors, SortPositions(_locations), _rectangle);
            RectangleChanged?.Invoke();
        }

        #endregion

        #region Methods

        /// <summary>Creates a gradient brush.</summary>
        /// <param name="gradient">The gradient.</param>
        /// <returns>The <see cref="LinearGradientBrush" />.</returns>
        public static LinearGradientBrush CreateBrush(Gradient gradient)
        {
            return CreateBrush(gradient.Angle, gradient.Colors, gradient.Locations, gradient.Rectangle);
        }

        /// <summary>Creates a gradient brush.</summary>
        /// <param name="angle">The angle.</param>
        /// <param name="colors">The colors.</param>
        /// <param name="positions">The positions.</param>
        /// <param name="rectangle">The rectangle.</param>
        /// <returns>The <see cref="LinearGradientBrush" />.</returns>
        public static LinearGradientBrush CreateBrush(float angle, Color[] colors, float[] positions, Rectangle rectangle)
        {
            var _points = new[] { new Point { X = rectangle.Width, Y = 0 }, new Point { X = rectangle.Width, Y = rectangle.Height } };
            LinearGradientBrush _linearGradientBrush = new LinearGradientBrush(_points[0], _points[1], Color.Black, Color.Black);

            ColorBlend _colorBlend = new ColorBlend
                {
                    Positions = positions,
                    Colors = colors
                };

            _linearGradientBrush.InterpolationColors = _colorBlend;
            _linearGradientBrush.RotateTransform(angle);

            return _linearGradientBrush;
        }

        /// <summary>Draws the gradient rectangle.</summary>
        /// <param name="graphics">The specified graphics to draw on.</param>
        /// <param name="gradient">The gradient.</param>
        public static void Draw(Graphics graphics, Gradient gradient)
        {
            LinearGradientBrush _linearGradientBrush = CreateBrush(gradient);
            graphics.FillRectangle(_linearGradientBrush, gradient.Rectangle);
        }

        /// <summary>Sorts the offsets to an entire <see cref="Array" />.</summary>
        /// <param name="customOffsets">The custom offsets for the colors to be positioned.</param>
        /// <returns>The <see cref="float" />.</returns>
        public static float[] SortPositions(float[] customOffsets)
        {
            if (!customOffsets.Contains(SettingConstants.StartPoint))
            {
                throw new ArgumentNullException(nameof(customOffsets), @"A start position of " + SettingConstants.StartPoint + @".0F doesn't exist.");
            }

            if (!customOffsets.Contains(SettingConstants.EndPoint))
            {
                throw new ArgumentNullException(nameof(customOffsets), @"A end position of " + SettingConstants.EndPoint + @".0F doesn't exist.");
            }

            foreach (float offset in customOffsets)
            {
                if (ExceptionManager.ArgumentOutOfRangeException(offset, 0.0F, 1.0F))
                {
                }

                if (customOffsets.Length != customOffsets.Distinct().Count())
                {
                    throw new ArgumentException(@"Found duplicate offset: " + offset, nameof(offset));
                }
            }

            Array.Sort(customOffsets);
            return customOffsets;
        }

        /// <summary>Initializes a new instance of the <see cref="Gradient" /> component.</summary>
        /// <param name="angle">The angle.</param>
        /// <param name="colors">The colors.</param>
        /// <param name="offsets">The offsets.</param>
        /// <param name="rectangle">The rectangle.</param>
        private void InitializeGradient(float angle, Color[] colors, float[] offsets, Rectangle rectangle)
        {
            if (colors.IsNullOrEmpty() || (colors.Length < 2))
            {
                throw new ArgumentNullException(nameof(colors), @"You must specify at least 2 different colors.");
            }

            if (offsets.IsNullOrEmpty() || (offsets.Length < 2))
            {
                throw new ArgumentNullException(nameof(offsets), @"You must specify at least 2 offsets.");
            }

            if (colors.Length != offsets.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(colors), @"The amount of colors must be equal to the amount of offsets.");
            }

            if ((rectangle.Size.Width < 1) || (rectangle.Size.Height < 1))
            {
                throw new ArgumentOutOfRangeException(nameof(rectangle.Size), @"The rectangle must have a minimum size of (width: 1, height: 1).");
            }

            _angle = angle;
            _colors = colors;
            _locations = SortPositions(offsets);
            _rectangle = rectangle;

            Brush = CreateBrush(_angle, _colors, _locations, _rectangle);
        }

        #endregion
    }
}