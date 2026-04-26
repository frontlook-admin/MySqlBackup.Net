using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MySqlBackupTestApp
{
    static class Program
    {
        public static string Version = MySqlBackup.Version;
        public static string DateVersion = "March 12, 2025";

        private static string _connectionString = string.Empty;

        public static string ConnectionString
        {
            get
            {
                if (String.IsNullOrEmpty(_connectionString))
                    throw new Exception("Connection string is empty.");
                else
                    return _connectionString;
            }
            set
            {
                _connectionString = value;
            }
        }
        public static string DefaultFolder = string.Empty;
        public static string TargetFile = string.Empty;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Register for form creation to apply dark theme
            Application.AddMessageFilter(new DarkThemeMessageFilter());
            
            Application.Run(new FormMain());
        }

        public static bool TargetDirectoryIsValid()
        {
            try
            {
                string dir = System.IO.Path.GetDirectoryName(Program.TargetFile);

                if (!System.IO.Directory.Exists(dir))
                {
                    System.IO.Directory.CreateDirectory(dir);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Specify path is not valid. Press [Export As] to specify a valid file path." + Environment.NewLine + Environment.NewLine + ex.Message, "Invalid Directory", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        public static bool SourceFileExists()
        {
            if (!System.IO.File.Exists(Program.TargetFile))
            {
                MessageBox.Show("File is not exists. Press [Select File] to choose a SQL Dump file." + Environment.NewLine + Environment.NewLine + Program.TargetFile, "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
    }

    // Message filter to intercept form creation and apply dark theme
    public class DarkThemeMessageFilter : IMessageFilter
    {
        private const int WM_CREATE = 0x0001;
        
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_CREATE && m.HWnd != IntPtr.Zero)
            {
                // Get the form that's being created
                Control control = Control.FromHandle(m.HWnd);
                if (control != null && control is Form form)
                {
                    // Apply dark theme to the new form
                    form.HandleCreated += (s, e) => DarkThemeManager.ApplyDarkTheme(form);
                }
            }
            return false;
        }
    }
}
