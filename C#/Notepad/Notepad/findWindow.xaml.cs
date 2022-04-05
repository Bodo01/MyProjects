using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Notepad
{
    /// <summary>
    /// Interaction logic for findWindow.xaml
    /// </summary>
    public partial class findWindow : Window
    {
        public findWindow(string wrd,ref TextBox txtBox)
        {
            textBox = txtBox;
            Word = wrd;
            InitializeComponent();
        }

        private string _word;
        private TextBox _textBox;
        public string Word { get { return _word; } set { _word = value; } }
        
        public TextBox textBox { get { return _textBox; } set { _textBox = value; } }
        public string FindOrReplace(bool replace,string textReplace)
        {
            
            TextRange txt = new TextRange(richText.Document.ContentStart,richText.Document.ContentEnd);
            TextPointer current = txt.Start.GetInsertionPosition(LogicalDirection.Forward);
            while (current != null)
            {
                string textInRun = current.GetTextInRun(LogicalDirection.Forward);
                if (!string.IsNullOrWhiteSpace(textInRun))
                {
                    int index2 = textInRun.IndexOf(Word);
                    if (index2 != -1)
                    {
                        TextPointer selectionStart = current.GetPositionAtOffset(index2, LogicalDirection.Forward);
                        TextPointer selectionEnd = selectionStart.GetPositionAtOffset(Word.Length, LogicalDirection.Forward);
                        TextRange selection = new TextRange(selectionStart, selectionEnd);
                        
                        if (replace)
                        selection.Text = textReplace;


                        selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                       // richText.Selection.Select(selection.Start, selection.End);
                        richText.Focus();
                    }
                }
                current = current.GetNextContextPosition(LogicalDirection.Forward);
            }
          return (new TextRange(richText.Document.ContentStart, richText.Document.ContentEnd)).Text;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string str = (new TextRange(richText.Document.ContentStart, richText.Document.ContentEnd)).Text;

            str = str.Replace(Word, replaceWord.Text);
            Word = replaceWord.Text;
            
            
            richText.Document.Blocks.Clear();
            richText.AppendText(str);

            textBox.Text = str;
            FindOrReplace(false, Word);
        }


    }
}
