namespace WCM.XenAdmin.Core
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public static class FormFontFixer
    {
        public static Font DefaultFont = (((Environment.OSVersion.Platform == PlatformID.Win32Windows) || (Environment.OSVersion.Version.Major < 5)) ? null : ((Environment.OSVersion.Version.Major < 6) ? SystemFonts.DialogFont : SystemFonts.MessageBoxFont));
        private static readonly List<string> FontReplaceList = new List<string>(new string[] { "Microsoft Sans Serif", "Tahoma", "Verdana", "Segoe UI", "Meiryo", "MS UI Gothic" });

        private static void c_ControlAdded(object sender, ControlEventArgs e)
        {
            RegisterAndReplace(e.Control);
        }

        private static void c_ControlRemoved(object sender, ControlEventArgs e)
        {
            Deregister(e.Control);
        }

        private static void c_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            Replace(e.Item);
        }

        private static void Deregister(Control c)
        {
            c.ControlAdded -= new ControlEventHandler(FormFontFixer.c_ControlAdded);
            c.ControlRemoved -= new ControlEventHandler(FormFontFixer.c_ControlRemoved);
            foreach (Control control in c.Controls)
            {
                Deregister(control);
            }
        }

        private static void Deregister(ToolStrip c)
        {
            c.ItemAdded -= new ToolStripItemEventHandler(FormFontFixer.c_ItemAdded);
        }

        public static void Fix(Form form)
        {
            if (DefaultFont != null)
            {
                RegisterAndReplace(form);
            }
        }

        private static bool IsLeaf(Control c)
        {
            return ((((c is Button) || (c is Label)) || ((c is TextBox) || (c is ComboBox))) || (c is ListBox));
        }

        private static void Register(Control c)
        {
            if (!IsLeaf(c))
            {
                c.ControlAdded -= new ControlEventHandler(FormFontFixer.c_ControlAdded);
                c.ControlAdded += new ControlEventHandler(FormFontFixer.c_ControlAdded);
                c.ControlRemoved -= new ControlEventHandler(FormFontFixer.c_ControlRemoved);
                c.ControlRemoved += new ControlEventHandler(FormFontFixer.c_ControlRemoved);
            }
        }

        private static void Register(ToolStrip c)
        {
            c.ItemAdded -= new ToolStripItemEventHandler(FormFontFixer.c_ItemAdded);
            c.ItemAdded += new ToolStripItemEventHandler(FormFontFixer.c_ItemAdded);
        }

        private static void RegisterAndReplace(Control c)
        {
            if (!ShouldPreserveFonts(c))
            {
                if (c is ToolStrip)
                {
                    ToolStrip strip = (ToolStrip) c;
                    Register(strip);
                    Replace(strip);
                    foreach (ToolStripItem item in strip.Items)
                    {
                        Replace(item);
                    }
                }
                else
                {
                    Register(c);
                    Replace(c);
                    foreach (Control control in c.Controls)
                    {
                        RegisterAndReplace(control);
                    }
                }
            }
        }

        private static void Replace(Control c)
        {
            c.Font = ReplacedFont(c.Font);
        }

        private static void Replace(ToolStripItem c)
        {
            c.Font = ReplacedFont(c.Font);
        }

        private static Font ReplacedFont(Font f)
        {
            if (FontReplaceList.IndexOf(f.Name) <= -1)
            {
                return f;
            }
            bool flag = (f.Size >= 8f) && (f.Size <= 9f);
            bool flag2 = ((!f.Italic && !f.Strikeout) && !f.Underline) && !f.Bold;
            if (flag && flag2)
            {
                return DefaultFont;
            }
            return new Font(DefaultFont.FontFamily, flag ? DefaultFont.SizeInPoints : f.SizeInPoints, f.Style);
        }

        private static bool ShouldPreserveFonts(Control c)
        {
            object[] customAttributes = c.GetType().GetCustomAttributes(typeof(PreserveFonts), true);
            return ((customAttributes.Length > 0) && ((PreserveFonts) customAttributes[0]).Preserve);
        }

        [AttributeUsage(AttributeTargets.Class)]
        public class PreserveFonts : Attribute
        {
            public bool Preserve;

            public PreserveFonts(bool preserve)
            {
                this.Preserve = preserve;
            }
        }
    }
}

