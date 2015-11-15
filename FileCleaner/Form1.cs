using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Windows.Forms;

namespace FileCleaner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (FD.ShowDialog() == DialogResult.OK)
            {
                createifnotext();
                if (!ifextOnfile(Application.StartupPath + @"\settings.cfg", FD.SelectedPath) && (!ifextOnfile(Application.StartupPath + @"\Exclusions.cfg", FD.SelectedPath)))
                {
                    if (!ifsubpath(FD.SelectedPath, true) && !ifsubpath(FD.SelectedPath, false))
                    {
                        File.SetAttributes(Application.StartupPath + @"\settings.cfg", FileAttributes.Normal);
                        File.AppendAllText(Application.StartupPath + @"\settings.cfg", FD.SelectedPath + Environment.NewLine, Encoding.Unicode);
                        File.SetAttributes(Application.StartupPath + @"\settings.cfg", FileAttributes.ReadOnly);
                        showselected();
                    }
                    else
                    {
                        MessageBox.Show("Вы пытаетесь выбрать папку, очистка которой приведёт к удалению другой выбранной папки или одна из выбранных папок содержит будучи удаленную папку, которая добавлена в ИСКЛЮЧЕНИЯ!" + Environment.NewLine +
                            "РЕКОМЕНДУЕТСЯ сначала добавлять папки в список выбранных, а потом добавлять нужные папки и файлы в исключения, чтобы не было путаницы.");
                    }
                }
                else
                {
                    MessageBox.Show("Данная папка уже добавлена в список папок или исключений!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (OF.ShowDialog() == DialogResult.OK)
            {
                createifnotext();
                string[] str = OF.FileNames;
                File.SetAttributes(Application.StartupPath + @"\Exclusions.cfg", FileAttributes.Normal);
                for (int k = 0; k < str.Length; k++)
                {
                    string path = Path.GetDirectoryName(str[k]);
                    if (!ifextOnfile(Application.StartupPath + @"\Exclusions.cfg", str[k]))
                    {
                        if (ifextOnfile(Application.StartupPath + @"\settings.cfg", path))
                        {
                            deselected.Items.Add(str[k]);
                            File.AppendAllText(Application.StartupPath + @"\Exclusions.cfg", str[k] + Environment.NewLine, Encoding.Unicode);
                        }
                        else
                        {
                            MessageBox.Show("Не вижу смысла добавлять исключение, если оно не относится с добавленным папкам...");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Эта папка уже добавлена в исключения!");
                    }
                }
                File.SetAttributes(Application.StartupPath + @"\Exclusions.cfg", FileAttributes.ReadOnly);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (FD.ShowDialog() == DialogResult.OK)
            {
                createifnotext();
                if (!ifextOnfile(Application.StartupPath + @"\settings.cfg", FD.SelectedPath) && (!ifextOnfile(Application.StartupPath + @"\Exclusions.cfg", FD.SelectedPath)))
                {
                    if (!ifsubpath(FD.SelectedPath, false) && ifsubpathoffolder(true, FD.SelectedPath))
                    {
                        deselected.Items.Add(FD.SelectedPath);
                        File.SetAttributes(Application.StartupPath + @"\Exclusions.cfg", FileAttributes.Normal);
                        File.AppendAllText(Application.StartupPath + @"\Exclusions.cfg", FD.SelectedPath + Environment.NewLine, Encoding.Unicode);
                        File.SetAttributes(Application.StartupPath + @"\Exclusions.cfg", FileAttributes.ReadOnly);
                    }
                    else
                    {
                        MessageBox.Show("Путь данной папки некорректен, т.к. он составляет часть пути уже выбранного исключения или не относится к добавленным папкам!");
                    }
                }
                else
                {
                    MessageBox.Show("Такая папка уже добавлена либо в исключения, либо в выбранные папки!");
                }
            }
        }

        private bool ifsubpathoffolder(bool where, string path)
        {
            string filestr;
            if (where) filestr = Application.StartupPath + @"\settings.cfg";
            else filestr = Application.StartupPath + @"\Exclusions.cfg";
            FileInfo fi = new FileInfo(filestr);
            if (fi.Exists)
            {
                string[] con = path.Split('\\');
                if (con.Length > 0)
                {
                    string pat = con[0] + '\\';
                    for (int k = 1; k < con.Length - 1; k++)
                    {
                        pat += con[k];
                        if (k + 1 < con.Length - 1) pat += '\\';
                    }
                    string[] textstr = File.ReadAllLines(filestr, Encoding.Unicode);
                    for (int k = 0; k < textstr.Length; k++)
                    {
                        if (textstr[k]==pat) return true;
                    }
                }
            }
            return false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bt_exit = true;
            Application.Exit();
        }

        private void ni_MouseUp(object sender, MouseEventArgs e)
        {
            this.Show();
            if (this.WindowState != FormWindowState.Normal) this.WindowState = FormWindowState.Normal;
            ni.Visible = false;
        }

        bool bt_exit = false;

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!bt_exit)
            {
                ni.Visible = true;
                this.Hide();
                ni.ShowBalloonTip(7000, "Я здесь! :)", "Мониторинг в реальном времени активирован!", ToolTipIcon.Info);
                e.Cancel = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MyProgram mp = new MyProgram();
            mp.ShowDialog();
            mp.Dispose();
            mp = null;
        }

        private void showselected()
        {
            selected.Items.Clear();
            string filestr = Application.StartupPath + @"\settings.cfg";
            FileInfo fi = new FileInfo(filestr);
            if (fi.Exists)
            {
                string[] textstr = File.ReadAllLines(filestr, Encoding.Unicode);
                for (int k = 0; k < textstr.Length; k++)
                {
                    selected.Items.Add(textstr[k]);
                }
            }
        }

        private bool ifExclusion(string[] txt, string name)
        {
            for (int k = 0; k < txt.Length; k++)
            {
                if (txt[k] == name) return true;
            }
            return false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selected.SelectedItem != null)
            {
                createifnotext();
                File.SetAttributes(Application.StartupPath + @"\settings.cfg", FileAttributes.Normal);
                removeFromFile(Application.StartupPath + @"\settings.cfg", selected.SelectedItem.ToString());
                File.SetAttributes(Application.StartupPath + @"\settings.cfg", FileAttributes.ReadOnly);
                selected.Items.Remove(selected.SelectedItem);
            }
        }

        private void removeFromFile(string path, string what)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                string[] textstr = File.ReadAllLines(path, Encoding.Unicode);
                string[] ext=new string[0];
                for (int k = 0; k < textstr.Length; k++)
                {
                    if (textstr[k].Length > 0)
                    {
                        if (textstr[k] != what)
                        {
                            Array.Resize(ref ext, ext.Length + 1);
                            ext[ext.Length - 1] = textstr[k];
                        }
                    }
                }
                File.WriteAllLines(path, ext, Encoding.Unicode);
                textstr = null;
                ext = null;
            }
            fi = null;
        }

        private bool ifextOnfile(string path, string what)
        {
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                string[] textstr = File.ReadAllLines(path, Encoding.Unicode);
                for (int k = 0; k < textstr.Length; k++)
                {
                    if (textstr[k].Length > 0)
                    {
                        if (textstr[k] == what)
                        {
                            textstr = null;
                            fi = null;
                            return true;
                        }
                    }
                }
                textstr = null;
            }
            fi = null;
            return false;
        }

        private bool ifsubpath(string what, bool file)
        {
            string filestr;
            if (file) filestr = Application.StartupPath + @"\settings.cfg";
            else filestr = Application.StartupPath + @"\Exclusions.cfg";
            FileInfo fi = new FileInfo(filestr);
            if (fi.Exists)
            {
                string[] textstr = File.ReadAllLines(filestr, Encoding.Unicode);
                for (int k = 0; k < textstr.Length; k++)
                {
                    if (textstr[k].StartsWith(what)) return true;
                    if (what.StartsWith(textstr[k])) return true;
                }
            }
            return false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (deselected.SelectedItem != null)
            {
                createifnotext();
                File.SetAttributes(Application.StartupPath + @"\Exclusions.cfg", FileAttributes.Normal);
                removeFromFile(Application.StartupPath + @"\Exclusions.cfg", deselected.SelectedItem.ToString());
                File.SetAttributes(Application.StartupPath + @"\Exclusions.cfg", FileAttributes.ReadOnly);
                deselected.Items.Remove(deselected.SelectedItem);
            }
        }

        internal static bool programStarted = false;

        private void tt_Tick(object sender, EventArgs e)
        {
            if (!programStarted)
            {
                tt.Interval = 1200000; this.Hide(); ni.Visible = true;
                ResourceManager resourceManager = new ResourceManager("FileCleaner.Res", Assembly.GetExecutingAssembly());
                ni.Icon = (Icon)resourceManager.GetObject("clean");
                this.Icon = (Icon)resourceManager.GetObject("clean");
                if (File.Exists(Application.StartupPath + @"\Exclusions.cfg"))
                {
                    string[] txt = File.ReadAllLines(Application.StartupPath + @"\Exclusions.cfg", Encoding.Unicode);
                    for (int k = 0; k < txt.Length; k++)
                    {
                        if (txt[k].Length > 1)
                        {
                            deselected.Items.Add(txt[k]);
                        }
                    }
                }
                showselected();
                FileInfo fii = new FileInfo(Application.StartupPath + @"\num.cfg");
                if (fii.Exists)
                {
                    string[] textstr = File.ReadAllLines(Application.StartupPath + @"\num.cfg", Encoding.Unicode);
                    if (textstr.Length > 0)
                    {
                        int couu = 0;
                        try
                        {
                            couu = Convert.ToInt32(textstr[0]);
                        }
                        catch { }
                        if (couu > 0) tb.Text = couu.ToString();
                    }
                }
                programStarted = true;
            }
            createifnotext();
            string filestr = Application.StartupPath + @"\settings.cfg";
            FileInfo fi = new FileInfo(filestr);
            if (fi.Exists)
            {
                string[] textstr = File.ReadAllLines(filestr, Encoding.Unicode); int razn = 0;
                try
                {
                    razn = Convert.ToInt32(tb.Text);
                    if (razn > 30) razn = 30;
                    if (razn < 1) razn = 1;
                    tb.Text = razn.ToString();
                }
                catch
                {
                    razn = 3;
                    tb.Text = razn.ToString();
                }
                string[] txt = File.ReadAllLines(Application.StartupPath + @"\Exclusions.cfg", Encoding.Unicode);
                DateTime dt = DateTime.Now;
                for (int k = 0; k < textstr.Length; k++)
                {
                    if (textstr[k].Length > 0)
                    {
                        try
                        {
                            DirectoryInfo dir = new DirectoryInfo(textstr[k]);
                            foreach (FileInfo files in dir.GetFiles())
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(files.Name))
                                    {
                                        if (!ifExclusion(txt, textstr[k] + "\\" + files.Name))
                                        {
                                            File.SetAttributes(textstr[k] + "\\" + files.Name, FileAttributes.Normal);
                                            DateTime fdt = File.GetCreationTime(textstr[k] + "\\" + files.Name);
                                            if (dt.Year > fdt.Year) File.Delete(textstr[k] + "\\" + files.Name);
                                            else
                                            {
                                                if (dt.Month > fdt.Month) File.Delete(textstr[k] + "\\" + files.Name);
                                                else
                                                {
                                                    if (dt.Day - fdt.Day >= razn)
                                                    {
                                                        if (dt.Hour > fdt.Hour) File.Delete(textstr[k] + "\\" + files.Name);
                                                        else
                                                        {
                                                            if (dt.Minute > fdt.Minute) File.Delete(textstr[k] + "\\" + files.Name);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch { }
                            }
                        }
                        catch { }
                        try
                        {
                            string[] dirs = Directory.GetDirectories(textstr[k]);
                            foreach (string pat in dirs)
                            {
                                try
                                {
                                    if (!string.IsNullOrEmpty(pat))
                                    {
                                        if (!ifExclusion(txt, pat))
                                        {
                                            DateTime fdt = Directory.GetCreationTime(pat);
                                            if (dt.Year > fdt.Year) Directory.Delete(pat, true);
                                            else
                                            {
                                                if (dt.Month > fdt.Month) Directory.Delete(pat, true);
                                                else
                                                {
                                                    if (dt.Day - fdt.Day >= razn)
                                                    {
                                                        if (dt.Hour > fdt.Hour) Directory.Delete(pat, true);
                                                        else
                                                        {
                                                            if (dt.Minute > fdt.Minute) Directory.Delete(pat, true);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                catch { }
                            }
                            dirs = null;
                        }
                        catch { }
                    }
                }
            }
            GC.Collect();
        }

        private void tb_TextChanged(object sender, EventArgs e)
        {
            createifnotext();
            File.WriteAllText(Application.StartupPath + "\\num.cfg", tb.Text, Encoding.Unicode);
        }

        private void createifnotext()
        {
            string main = Application.StartupPath + @"\settings.cfg";
            string second = Application.StartupPath + @"\Exclusions.cfg";
            string third = Application.StartupPath + @"\num.cfg";
            FileInfo fii = new FileInfo(main);
            if (!fii.Exists) File.Create(main).Close();
            else if (fii.Length > 2097152) File.Create(main).Close();
            fii = new FileInfo(second);
            if (!fii.Exists) File.Create(second).Close();
            else if (fii.Length > 2097152) File.Create(second).Close();
            fii = new FileInfo(third);
            if (!fii.Exists) File.Create(third).Close();
            else if (fii.Length > 2097152) File.Create(third).Close();
            File.SetAttributes(main, FileAttributes.ReadOnly);
            File.SetAttributes(second, FileAttributes.ReadOnly);
        }
    }
}
