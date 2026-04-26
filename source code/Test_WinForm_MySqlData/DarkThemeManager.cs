using System;
using System.Drawing;
using System.Windows.Forms;

namespace MySqlBackupTestApp
{
    public static class DarkThemeManager
    {
        // Dark theme colors
        public static Color BackgroundColor = Color.FromArgb(32, 32, 32);
        public static Color SecondaryBackgroundColor = Color.FromArgb(45, 45, 48);
        public static Color TextColor = Color.FromArgb(240, 240, 240);
        public static Color AccentColor = Color.FromArgb(0, 122, 204);
        public static Color ButtonColor = Color.FromArgb(60, 60, 60);
        public static Color ButtonTextColor = Color.FromArgb(240, 240, 240);
        public static Color BorderColor = Color.FromArgb(80, 80, 80);
        public static Color MenuBackColor = Color.FromArgb(45, 45, 48);
        public static Color MenuSelectedColor = Color.FromArgb(65, 65, 68);

        // Set dark theme for a form
        public static void ApplyDarkTheme(Form form)
        {
            if (form == null) return;

            form.BackColor = BackgroundColor;
            form.ForeColor = TextColor;

            // Handle MainMenu if present (older style menus)
            if (form.Menu != null)
            {
                StyleMainMenu(form.Menu);
            }

            // Apply styles to all controls in the form
            ApplyThemeToControls(form.Controls);
            
            // Make sure the form has the Windows forms style (to keep min/max/close buttons)
            if (form.FormBorderStyle != FormBorderStyle.None)
                form.FormBorderStyle = FormBorderStyle.Sizable;
            
            // Apply the professional renderer for menus and toolbars
            ApplyProfessionalRenderer();
        }

        // Apply a custom renderer that works well with dark themes
        private static void ApplyProfessionalRenderer()
        {
            // Create a custom professional renderer with our dark theme colors
            ToolStripProfessionalRenderer renderer = new ToolStripProfessionalRenderer();
            renderer.RoundedEdges = false;
            
            // Set custom colors for the renderer
            var colorTable = new CustomColorTable();
            renderer = new ToolStripProfessionalRenderer(colorTable);
            
            // Apply the renderer globally
            ToolStripManager.Renderer = renderer;
        }

        // Apply dark theme to all controls recursively
        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                // Set forecolor for all controls
                control.ForeColor = TextColor;

                // Handle specific control types
                if (control is Button button)
                {
                    StyleButton(button);
                }
                else if (control is TextBox textBox)
                {
                    StyleTextBox(textBox);
                }
                else if (control is RichTextBox richTextBox)
                {
                    StyleRichTextBox(richTextBox);
                }
                else if (control is ComboBox comboBox)
                {
                    StyleComboBox(comboBox);
                }
                else if (control is ListBox listBox)
                {
                    StyleListBox(listBox);
                }
                else if (control is CheckBox checkBox)
                {
                    StyleCheckBox(checkBox);
                }
                else if (control is RadioButton radioButton)
                {
                    StyleRadioButton(radioButton);
                }
                else if (control is DataGridView dataGridView)
                {
                    StyleDataGridView(dataGridView);
                }
                else if (control is GroupBox groupBox)
                {
                    groupBox.ForeColor = TextColor;
                    groupBox.BackColor = SecondaryBackgroundColor;
                }
                else if (control is TabControl tabControl)
                {
                    StyleTabControl(tabControl);
                }
                else if (control is Panel panel)
                {
                    panel.BackColor = SecondaryBackgroundColor;
                }
                else if (control is Label)
                {
                    // Labels already have text color set from parent
                }
                else if (control is WebBrowser)
                {
                    // WebBrowser doesn't support theme changes directly
                }
                else if (control is NumericUpDown numericUpDown)
                {
                    numericUpDown.BackColor = SecondaryBackgroundColor;
                    numericUpDown.ForeColor = TextColor;
                }
                else if (control is ProgressBar)
                {
                    // Progress bars don't properly support custom coloring in Windows Forms
                }
                else if (control is MenuStrip menuStrip)
                {
                    StyleMenuStrip(menuStrip);
                }
                else if (control is ToolStrip toolStrip)
                {
                    StyleToolStrip(toolStrip);
                }
                else if (control is ContextMenuStrip contextMenuStrip)
                {
                    StyleContextMenuStrip(contextMenuStrip);
                }
                else if (control is StatusStrip statusStrip)
                {
                    StyleStatusStrip(statusStrip);
                }
                else
                {
                    // Generic control background
                    control.BackColor = SecondaryBackgroundColor;
                }

                // Recursively apply theme to child controls
                if (control.Controls.Count > 0)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }

        private static void StyleButton(Button button)
        {
            button.BackColor = ButtonColor;
            button.ForeColor = ButtonTextColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = BorderColor;
        }

        private static void StyleTextBox(TextBox textBox)
        {
            textBox.BackColor = SecondaryBackgroundColor;
            textBox.ForeColor = TextColor;
            textBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleRichTextBox(RichTextBox richTextBox)
        {
            richTextBox.BackColor = SecondaryBackgroundColor;
            richTextBox.ForeColor = TextColor;
            richTextBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleComboBox(ComboBox comboBox)
        {
            comboBox.BackColor = SecondaryBackgroundColor;
            comboBox.ForeColor = TextColor;
            comboBox.FlatStyle = FlatStyle.Flat;
        }

        private static void StyleListBox(ListBox listBox)
        {
            listBox.BackColor = SecondaryBackgroundColor;
            listBox.ForeColor = TextColor;
            listBox.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleCheckBox(CheckBox checkBox)
        {
            checkBox.BackColor = Color.Transparent;
            checkBox.ForeColor = TextColor;
            checkBox.FlatStyle = FlatStyle.Flat;
        }

        private static void StyleRadioButton(RadioButton radioButton)
        {
            radioButton.BackColor = Color.Transparent;
            radioButton.ForeColor = TextColor;
            radioButton.FlatStyle = FlatStyle.Flat;
        }

        private static void StyleDataGridView(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = SecondaryBackgroundColor;
            dataGridView.ForeColor = TextColor;
            dataGridView.GridColor = BorderColor;
            dataGridView.BorderStyle = BorderStyle.None;
            
            // Style the header
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = ButtonColor;
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = TextColor;
            dataGridView.RowHeadersDefaultCellStyle.BackColor = ButtonColor;
            
            // Style the cells
            dataGridView.DefaultCellStyle.BackColor = SecondaryBackgroundColor;
            dataGridView.DefaultCellStyle.ForeColor = TextColor;
            dataGridView.DefaultCellStyle.SelectionBackColor = AccentColor;
            dataGridView.DefaultCellStyle.SelectionForeColor = Color.White;
        }

        private static void StyleTabControl(TabControl tabControl)
        {
            tabControl.BackColor = BackgroundColor;
            tabControl.ForeColor = TextColor;
            
            // Style each tab page
            foreach (TabPage page in tabControl.TabPages)
            {
                page.BackColor = SecondaryBackgroundColor;
                page.ForeColor = TextColor;
            }
        }

        private static void StyleMainMenu(MainMenu mainMenu)
        {
            // Old-style menus don't support direct styling
            // We can only change their appearance through Win32 API, which is beyond the scope
            // of this implementation, but we'll at least style any modern menus they might show
        }

        private static void StyleMenuStrip(MenuStrip menuStrip)
        {
            menuStrip.BackColor = MenuBackColor;
            menuStrip.ForeColor = TextColor;
            menuStrip.RenderMode = ToolStripRenderMode.Professional;
            
            // Apply style to items
            foreach (ToolStripItem item in menuStrip.Items)
            {
                StyleToolStripItem(item);
            }
        }
        
        private static void StyleToolStrip(ToolStrip toolStrip)
        {
            toolStrip.BackColor = MenuBackColor;
            toolStrip.ForeColor = TextColor;
            toolStrip.RenderMode = ToolStripRenderMode.Professional;
            
            // Apply style to items
            foreach (ToolStripItem item in toolStrip.Items)
            {
                StyleToolStripItem(item);
            }
        }

        private static void StyleContextMenuStrip(ContextMenuStrip contextMenuStrip)
        {
            contextMenuStrip.BackColor = MenuBackColor;
            contextMenuStrip.ForeColor = TextColor;
            contextMenuStrip.RenderMode = ToolStripRenderMode.Professional;
            
            // Apply style to items
            foreach (ToolStripItem item in contextMenuStrip.Items)
            {
                StyleToolStripItem(item);
            }
        }

        private static void StyleStatusStrip(StatusStrip statusStrip)
        {
            statusStrip.BackColor = MenuBackColor;
            statusStrip.ForeColor = TextColor;
            statusStrip.RenderMode = ToolStripRenderMode.Professional;
            
            // Apply style to items
            foreach (ToolStripItem item in statusStrip.Items)
            {
                StyleToolStripItem(item);
            }
        }

        private static void StyleToolStripItem(ToolStripItem item)
        {
            item.BackColor = MenuBackColor;
            item.ForeColor = TextColor;
            
            if (item is ToolStripMenuItem menuItem)
            {
                // Style dropdown items recursively
                foreach (ToolStripItem dropDownItem in menuItem.DropDownItems)
                {
                    StyleToolStripItem(dropDownItem);
                }
            }
            else if (item is ToolStripDropDownItem dropDownItem)
            {
                // Style any other kind of dropdown items
                foreach (ToolStripItem childItem in dropDownItem.DropDownItems)
                {
                    StyleToolStripItem(childItem);
                }
            }
        }
    }

    // Custom color table for the ToolStripRenderer to support dark theme
    public class CustomColorTable : ProfessionalColorTable
    {
        public override Color MenuStripGradientBegin => DarkThemeManager.MenuBackColor;
        public override Color MenuStripGradientEnd => DarkThemeManager.MenuBackColor;
        public override Color ToolStripGradientBegin => DarkThemeManager.MenuBackColor;
        public override Color ToolStripGradientEnd => DarkThemeManager.MenuBackColor;
        public override Color ToolStripDropDownBackground => DarkThemeManager.MenuBackColor;
        public override Color ImageMarginGradientBegin => DarkThemeManager.MenuBackColor;
        public override Color ImageMarginGradientMiddle => DarkThemeManager.MenuBackColor;
        public override Color ImageMarginGradientEnd => DarkThemeManager.MenuBackColor;
        
        // Button selected and hover states
        public override Color ButtonSelectedHighlight => DarkThemeManager.MenuSelectedColor;
        public override Color ButtonSelectedGradientBegin => DarkThemeManager.MenuSelectedColor;
        public override Color ButtonSelectedGradientMiddle => DarkThemeManager.MenuSelectedColor;
        public override Color ButtonSelectedGradientEnd => DarkThemeManager.MenuSelectedColor;
        
        public override Color ButtonPressedHighlight => DarkThemeManager.AccentColor;
        public override Color ButtonPressedGradientBegin => DarkThemeManager.AccentColor;
        public override Color ButtonPressedGradientMiddle => DarkThemeManager.AccentColor;
        public override Color ButtonPressedGradientEnd => DarkThemeManager.AccentColor;
        
        public override Color ButtonSelectedBorder => DarkThemeManager.BorderColor;
        
        // Menu item selected and hover states
        public override Color MenuItemSelected => DarkThemeManager.MenuSelectedColor;
        public override Color MenuItemSelectedGradientBegin => DarkThemeManager.MenuSelectedColor;
        public override Color MenuItemSelectedGradientEnd => DarkThemeManager.MenuSelectedColor;
        
        public override Color MenuItemPressedGradientBegin => DarkThemeManager.AccentColor;
        public override Color MenuItemPressedGradientMiddle => DarkThemeManager.AccentColor;
        public override Color MenuItemPressedGradientEnd => DarkThemeManager.AccentColor;
        
        public override Color MenuItemBorder => DarkThemeManager.BorderColor;
        public override Color MenuBorder => DarkThemeManager.BorderColor;
        
        // Separator
        public override Color SeparatorDark => DarkThemeManager.BorderColor;
        public override Color SeparatorLight => DarkThemeManager.BorderColor;
    }
}