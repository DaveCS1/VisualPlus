﻿namespace VisualPlus.Toolkit.Controls
{
    #region Namespace

    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Design;
    using System.IO;
    using System.Windows.Forms;

    using VisualPlus.Enumerators;
    using VisualPlus.Localization.Category;
    using VisualPlus.Renders;
    using VisualPlus.Structure;
    using VisualPlus.Toolkit.ActionList;
    using VisualPlus.Toolkit.Components;
    using VisualPlus.Toolkit.VisualBase;

    #endregion

    [ToolboxItem(true)]
    [ToolboxBitmap(typeof(RichTextBox))]
    [DefaultEvent("TextChanged")]
    [DefaultProperty("Text")]
    [Description("The Visual RichTextBox")]
    [Designer(typeof(VisualRichBoxTasks))]
    public class VisualRichTextBox : ContainedControlBase, IInputMethods
    {
        #region Variables

        private Border _border;

        private RichTextBox _richTextBox;

        #endregion

        #region Constructors

        /// <summary>Initializes a new instance of the <see cref="VisualRichTextBox"/> class.</summary>
        public VisualRichTextBox()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);

            // Contains another control
            SetStyle(ControlStyles.ContainerControl, true);

            // Cannot select this control, only the child and does not generate a click event
            SetStyle(ControlStyles.Selectable | ControlStyles.StandardClick, false);
            _border = new Border();
            _richTextBox = new RichTextBox
                {
                    Size = GetInternalControlSize(Size, _border),
                    Location = GetInternalControlLocation(_border),
                    Text = string.Empty,
                    BorderStyle = BorderStyle.None,
                    Font = Font,
                    ForeColor = ForeColor,
                    BackColor = Background,
                    Multiline = true
                };

            BackColor = Color.Transparent;
            AutoSize = false;
            Size = new Size(150, 100);

            Controls.Add(_richTextBox);

            UpdateTheme(Settings.DefaultValue.DefaultStyle);
        }

        #endregion

        #region Properties

        public new Color Background
        {
            get
            {
                return base.Background;
            }

            set
            {
                _richTextBox.BackColor = value;
                base.Background = value;
            }
        }

        [TypeConverter(typeof(BorderConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category(Property.Appearance)]
        public Border Border
        {
            get
            {
                return _border;
            }

            set
            {
                _border = value;
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(false)]
        [Description("Gets access to the contained control.")]
        public RichTextBox ContainedControl
        {
            get
            {
                return _richTextBox;
            }
        }

        public new Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                _richTextBox.Font = value;
                base.Font = value;
            }
        }

        public new Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                _richTextBox.ForeColor = value;
                base.ForeColor = value;
            }
        }

        [Category(Property.Appearance)]
        [Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(false)]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                _richTextBox.Text = value;
                base.Text = value;
            }
        }

        #endregion

        #region Events

        /// <summary>Appends text to the current text of a rich text box.</summary>
        /// <param name="text">The text to append to the current contents of the text box.</param>
        public void AppendText(string text)
        {
            _richTextBox.AppendText(text);
        }

        /// <summary>Determines whether you can paste information from the Clipboard in the specified data format.</summary>
        /// <param name="clipFormat">One of the System.Windows.Forms.DataFormats.Format values.</param>
        /// <returns>true if you can paste data from the Clipboard in the specified data format; otherwise, false.</returns>
        public bool CanPaste(DataFormats.Format clipFormat)
        {
            return _richTextBox.CanPaste(clipFormat);
        }

        /// <summary>Clears all text from the text box control.</summary>
        public void Clear()
        {
            _richTextBox.Clear();
        }

        /// <summary>Clears information about the most recent operation from the undo buffer of the rich text box.</summary>
        public void ClearUndo()
        {
            _richTextBox.ClearUndo();
        }

        /// <summary>Copies the current selection in the text box to the Clipboard.</summary>
        public void Copy()
        {
            _richTextBox.Copy();
        }

        /// <summary>Moves the current selection in the text box to the Clipboard.</summary>
        public void Cut()
        {
            _richTextBox.Cut();
        }

        /// <summary>
        ///     Specifies that the value of the SelectionLength property is zero so that no characters are selected in the
        ///     control.
        /// </summary>
        public void DeselectAll()
        {
            _richTextBox.DeselectAll();
        }

        /// <summary>Searches the text in a RichTextBox control for a string.</summary>
        /// <param name="str">The text to locate in the control.</param>
        /// <returns>
        ///     The location within the control where the search text was found or -1 if the search string is not found or an
        ///     empty search string is specified in the str parameter.
        /// </returns>
        public int Find(string str)
        {
            return _richTextBox.Find(str);
        }

        /// <summary>Searches the text of a RichTextBox control for the first instance of a character from a list of characters.</summary>
        /// <param name="characterSet">The array of characters to search for.</param>
        /// <returns>
        ///     The location within the control where the search characters were found or -1 if the search characters are not
        ///     found or an empty search character set is specified in the char parameter.
        /// </returns>
        public int Find(char[] characterSet)
        {
            return _richTextBox.Find(characterSet);
        }

        /// <summary>
        ///     Searches the text of a RichTextBox control, at a specific starting point, for the first instance of a
        ///     character from a list of characters.
        /// </summary>
        /// <param name="characterSet">The array of characters to search for.</param>
        /// <param name="start">The location within the control's text at which to begin searching.</param>
        /// <returns>The location within the control where the search characters are found.</returns>
        public int Find(char[] characterSet, int start)
        {
            return _richTextBox.Find(characterSet, start);
        }

        /// <summary>Searches the text in a RichTextBox control for a string with specific options applied to the search.</summary>
        /// <param name="str">The text to locate in the control.</param>
        /// <param name="options">A bit wise combination of the RichTextBoxFinds values.</param>
        /// <returns>The location within the control where the search text was found.</returns>
        public int Find(string str, RichTextBoxFinds options)
        {
            return _richTextBox.Find(str, options);
        }

        /// <summary>
        ///     Searches a range of text in a RichTextBox control for the first instance of a character from a list of
        ///     characters.
        /// </summary>
        /// <param name="characterSet">The array of characters to search for.</param>
        /// <param name="start">The location within the control's text at which to begin searching.</param>
        /// <param name="end">The location within the control's text at which to end searching.</param>
        /// <returns>The location within the control where the search characters are found.</returns>
        public int Find(char[] characterSet, int start, int end)
        {
            return _richTextBox.Find(characterSet, start, end);
        }

        /// <summary>
        ///     Searches the text in a RichTextBox control for a string at a specific location within the control and with
        ///     specific options applied to the search.
        /// </summary>
        /// <param name="str">The text to locate in the control.</param>
        /// <param name="start">The location within the control's text at which to begin searching.</param>
        /// <param name="options">A bit wise combination of the RichTextBoxFinds values.</param>
        /// <returns>The location within the control where the search text was found.</returns>
        public int Find(string str, int start, RichTextBoxFinds options)
        {
            return _richTextBox.Find(str, start, options);
        }

        /// <summary>
        ///     Searches the text in a RichTextBox control for a string within a range of text within the control and with
        ///     specific options applied to the search.
        /// </summary>
        /// <param name="str">The text to locate in the control.</param>
        /// <param name="start">The location within the control's text at which to begin searching.</param>
        /// <param name="end">
        ///     The location within the control's text at which to end searching. This value must be equal to
        ///     negative one (-1) or greater than or equal to the start parameter.
        /// </param>
        /// <param name="options">A bit wise combination of the RichTextBoxFinds values.</param>
        /// <returns>Returns search results.</returns>
        public int Find(string str, int start, int end, RichTextBoxFinds options)
        {
            return _richTextBox.Find(str, start, end, options);
        }

        /// <summary>Retrieves the character that is closest to the specified location within the control.</summary>
        /// <param name="pt">The location from which to seek the nearest character.</param>
        /// <returns>The character at the specified location.</returns>
        public int GetCharFromPosition(Point pt)
        {
            return _richTextBox.GetCharFromPosition(pt);
        }

        /// <summary>Retrieves the index of the character nearest to the specified location.</summary>
        /// <param name="pt">The location to search.</param>
        /// <returns>The zero-based character index at the specified location.</returns>
        public int GetCharIndexFromPosition(Point pt)
        {
            return _richTextBox.GetCharIndexFromPosition(pt);
        }

        /// <summary>Retrieves the index of the first character of a given line.</summary>
        /// <param name="lineNumber">The line for which to get the index of its first character.</param>
        /// <returns>The zero-based character index in the specified line.</returns>
        public int GetFirstCharIndexFromLine(int lineNumber)
        {
            return _richTextBox.GetFirstCharIndexFromLine(lineNumber);
        }

        /// <summary>Retrieves the index of the first character of the current line.</summary>
        /// <returns>The zero-based character index in the current line.</returns>
        public int GetFirstCharIndexOfCurrentLine()
        {
            return _richTextBox.GetFirstCharIndexOfCurrentLine();
        }

        /// <summary>Retrieves the line number from the specified character position within the text of the RichTextBox control.</summary>
        /// <param name="index">The character index position to search.</param>
        /// <returns>The zero-based line number in which the character index is located.</returns>
        public int GetLineFromCharIndex(int index)
        {
            return _richTextBox.GetLineFromCharIndex(index);
        }

        /// <summary>Retrieves the location within the control at the specified character index.</summary>
        /// <param name="index">The index of the character for which to retrieve the location.</param>
        /// <returns>The location of the specified character.</returns>
        public Point GetPositionFromCharIndex(int index)
        {
            return _richTextBox.GetPositionFromCharIndex(index);
        }

        /// <summary>Loads a rich text format (RTF) or standard ASCII text file into the RichTextBox control.</summary>
        /// <param name="path">The name and location of the file to load into the control.</param>
        public void LoadFile(string path)
        {
            _richTextBox.LoadFile(path);
        }

        /// <summary>Loads the contents of an existing data stream into the RichTextBox control.</summary>
        /// <param name="data">A stream of data to load into the RichTextBox control.</param>
        /// <param name="fileType">One of the RichTextBoxStreamType values.</param>
        public void LoadFile(Stream data, RichTextBoxStreamType fileType)
        {
            _richTextBox.LoadFile(data, fileType);
        }

        /// <summary>Loads a specific type of file into the RichTextBox control.</summary>
        /// <param name="path">The name and location of the file to load into the control.</param>
        /// <param name="fileType">One of the RichTextBoxStreamType values.</param>
        public void LoadFile(string path, RichTextBoxStreamType fileType)
        {
            _richTextBox.LoadFile(path, fileType);
        }

        /// <summary>Replaces the current selection in the text box with the contents of the Clipboard.</summary>
        public void Paste()
        {
            _richTextBox.Paste();
        }

        /// <summary>Pastes the contents of the Clipboard in the specified Clipboard format.</summary>
        /// <param name="clipFormat">The Clipboard format in which the data should be obtained from the Clipboard.</param>
        public void Paste(DataFormats.Format clipFormat)
        {
            _richTextBox.Paste(clipFormat);
        }

        /// <summary>Reapplies the last operation that was undone in the control.</summary>
        public void Redo()
        {
            _richTextBox.Redo();
        }

        /// <summary>Saves the contents of the RichTextBox to a rich text format (RTF) file.</summary>
        /// <param name="path">The name and location of the file to save.</param>
        public void SaveFile(string path)
        {
            _richTextBox.SaveFile(path);
        }

        /// <summary>Saves the contents of a RichTextBox control to an open data stream.</summary>
        /// <param name="data">The data stream that contains the file to save to.</param>
        /// <param name="fileType">One of the RichTextBoxStreamType values.</param>
        public void SaveFile(Stream data, RichTextBoxStreamType fileType)
        {
            _richTextBox.SaveFile(data, fileType);
        }

        /// <summary>Saves the contents of the KryptonRichTextBox to a specific type of file.</summary>
        /// <param name="path">The name and location of the file to save.</param>
        /// <param name="fileType">One of the RichTextBoxStreamType values.</param>
        public void SaveFile(string path, RichTextBoxStreamType fileType)
        {
            _richTextBox.SaveFile(path, fileType);
        }

        /// <summary>Scrolls the contents of the control to the current caret position.</summary>
        public void ScrollToCaret()
        {
            _richTextBox.ScrollToCaret();
        }

        /// <summary>Selects a range of text in the control.</summary>
        /// <param name="start">The position of the first character in the current text selection within the text box.</param>
        /// <param name="length">The number of characters to select.</param>
        public void Select(int start, int length)
        {
            _richTextBox.Select(start, length);
        }

        /// <summary>Selects all text in the control.</summary>
        public void SelectAll()
        {
            _richTextBox.SelectAll();
        }

        /// <summary>Undoes the last edit operation in the text box.</summary>
        public void Undo()
        {
            _richTextBox.Undo();
        }

        public void UpdateTheme(Styles style)
        {
            StyleManager = new VisualStyleManager(style);

            ForeColor = StyleManager.FontStyle.ForeColor;
            ForeColorDisabled = StyleManager.FontStyle.ForeColorDisabled;

            Background = StyleManager.ControlStyle.Background(3);
            BackgroundDisabled = StyleManager.ControlStyle.Background(0);

            _border.Color = StyleManager.BorderStyle.Color;
            _border.HoverColor = StyleManager.BorderStyle.HoverColor;

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_richTextBox.BackColor != Background)
            {
                _richTextBox.BackColor = Background;
            }

            ControlGraphicsPath = VisualBorderRenderer.GetBorderShape(ClientRectangle, _border);
            e.Graphics.FillPath(new SolidBrush(Background), ControlGraphicsPath);
            VisualBorderRenderer.DrawBorderStyle(e.Graphics, _border, MouseState, ControlGraphicsPath);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            _richTextBox.Location = GetInternalControlLocation(_border);
            _richTextBox.Size = GetInternalControlSize(Size, _border);
        }

        #endregion
    }
}