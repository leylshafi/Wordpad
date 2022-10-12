namespace Wordpad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Font = fontDialog1.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int.TryParse(comboBox1.SelectedItem.ToString(), out int size);

            richTextBox1.Font = new Font(fontDialog1.Font.FontFamily, size, FontStyle.Regular);
        }

        private void Underline_CheckedChanged(object sender, EventArgs e)
        {
            string name = (sender as CheckBox).Name;
            if ((sender as CheckBox).Checked)
            {


                switch (name)
                {
                    case "Bold":
                        richTextBox1.Font = new Font(fontDialog1.Font.FontFamily, richTextBox1.Font.Size, richTextBox1.Font.Style | FontStyle.Bold);
                        break;
                    case "Underline":
                        richTextBox1.Font = new Font(fontDialog1.Font.FontFamily, richTextBox1.Font.Size, richTextBox1.Font.Style | FontStyle.Underline);
                        break;
                    case "Italic":
                        richTextBox1.Font = new Font(fontDialog1.Font.FontFamily, richTextBox1.Font.Size, richTextBox1.Font.Style | FontStyle.Italic);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                richTextBox1.Font = new Font(fontDialog1.Font.FontFamily, richTextBox1.Font.Size, FontStyle.Regular);
                Bold.Checked = false;
                Underline.Checked = false;
                Italic.Checked = false;

            }


        }

        private void btn_letf_Click(object sender, EventArgs e)
        {
            string name=(sender as Button).Tag.ToString();
            switch (name)
            {
                case "Left":
                    richTextBox1.SelectAll();
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
                    richTextBox1.DeselectAll();
                    break;
                case "Center":
                    richTextBox1.SelectAll();
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
                    richTextBox1.DeselectAll();
                    break;
                case "Right":
                    richTextBox1.SelectAll();
                    richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
                    richTextBox1.DeselectAll();
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog()==DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
                panel7.BackColor = colorDialog1.Color;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text Files|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                StreamReader sr = new(openFileDialog1.FileName);
                richTextBox1.Text = sr.ReadToEnd();
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using StreamWriter sw = new(saveFileDialog1.FileName);
                sw.Write(richTextBox1.Text);
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr= printDialog1.ShowDialog();
            if(dr==DialogResult.OK)
            {

            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(richTextBox1.CanUndo)
                richTextBox1.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanRedo)
                richTextBox1.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText!="")
            {
                richTextBox1.Cut();
            }
               
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionLength>0)
            {
                richTextBox1.Copy();
            }

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectedText = "";
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                richTextBox1.Paste();
            }
        }

        private void deleteAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void dateTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            richTextBox1.Text = dateTime.ToString();
        }

        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = true;
        }

        private void offToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.WordWrap = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is Wordpad Killer","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}