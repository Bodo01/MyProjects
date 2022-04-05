using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Notepad
{
    public class TabItems : PropertyChangedClass
    {

        public List<TabItem> Items { get; set; }
        

        public List<string> FilePaths { get; set; }

      

        private int _selectedItem;

        public int SelectedItem { get { return _selectedItem; } set { _selectedItem = value; RaisePropertyChanged(nameof(SelectedItem)); } }

        private int _fileOpened;

        public int FilesOpened { get { return _fileOpened; } set { _fileOpened = value; RaisePropertyChanged(nameof(FilesOpened)); } }

        public TabItems()
        {

            Items = new List<TabItem>();
            FilePaths = new List<string>();
         

        }

        public static string HeaderGen(string txt)
        {
            int i = txt.LastIndexOf('\\');


            return txt.Substring(i + 1);

        }



        public void AddNewItem(string text, string header)
        {
            FilesOpened++;

            TabItem tab = new TabItem();
            TextBox tb = new TextBox();


            
            tb.AutoWordSelection = true;
            tb.AcceptsReturn = true;
            tb.Text = text;


            tab.Content = tb;



            if (header == "")
            {
                FilePaths.Add(null);
                header = "New File"+FilesOpened.ToString();
            }
            else
            {
                FilePaths.Add(header);

                header = HeaderGen(header);
            }
            tab.Header = header;

            Items.Add(tab);

           
        }


        


        public void RemoveItem()
        {
            try
            {
                if (FilePaths[SelectedItem] != null)
                {
                    var tabItem = Items[SelectedItem] as TabItem;
                    var data = (tabItem.Content as TextBox).Text;

                    var text = File.ReadAllText(FilePaths[SelectedItem], Encoding.UTF8);

                    if (text != data)
                    {
                        if (MessageBox.Show("Do you want to save the file before closing?", "Save ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                            Save();


                    }

                }
                else {
                    if (MessageBox.Show("Do you want to save the file before closing?", "Save ?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        SaveItem();


                }

                Items.RemoveAt(SelectedItem);
                FilePaths.RemoveAt(SelectedItem);
               
                SelectedItem = 0;
                



            }
            catch { }
        }



        public void Save()
        {
            if (Items.Any())
            {
                try
                {

                    var tabItem = Items[SelectedItem] as TabItem;
                    var data = (tabItem.Content as TextBox).Text;

                    if (FilePaths[SelectedItem] != null)
                    {
                        File.WriteAllText(FilePaths[SelectedItem], data);
                    }
                    else
                    {
                        SaveFileDialog saveFileDialog = new SaveFileDialog();

                        saveFileDialog.Filter = "Text Files (*.txt)|*.txt";


                        if (saveFileDialog.ShowDialog() == true)
                        {
                            File.WriteAllText(saveFileDialog.FileName, data);
                            FilePaths[SelectedItem] = saveFileDialog.FileName;
                            tabItem.Header = HeaderGen(saveFileDialog.FileName);
                        }


                        //File.WriteAllText (saveFileDialog.FileName, data);
                        // FilePaths[SelectedItem] = saveFileDialog.FileName;


                    }
                }
                catch { }


            }


        }

        public void SaveItem()
        {
            if (Items.Any())
            {
                try
                {

                    var tabItem = Items[SelectedItem] as TabItem;
                    var data = (tabItem.Content as TextBox).Text;


                    SaveFileDialog saveFileDialog = new SaveFileDialog();

                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt";


                    if (saveFileDialog.ShowDialog() == true)
                    {
                        File.WriteAllText(saveFileDialog.FileName, data);
                        FilePaths[SelectedItem] = saveFileDialog.FileName;
                        tabItem.Header = HeaderGen(saveFileDialog.FileName);

                    }


                    //File.WriteAllText (saveFileDialog.FileName, data);
                    // FilePaths[SelectedItem] = saveFileDialog.FileName;



                }
                catch { }


            }

        }


        public void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                FilesOpened++;
                AddNewItem(File.ReadAllText(openFileDialog.FileName), openFileDialog.FileName);
            }
        }




        public void FindText(string text)
        {
            var tabItem = Items[SelectedItem] as TabItem;
            var data = tabItem.Content as TextBox;



            int index = data.Text.IndexOf(text);
            if (index >= 0 && index < data.Text.Length)
            {
                findWindow newFindW = new findWindow(text,ref data);

                newFindW.richText.AppendText(data.Text);
                newFindW.Show();

                newFindW.FindOrReplace(false, "ceva");

                

                data.Text = (new TextRange(newFindW.richText.Document.ContentStart, newFindW.richText.Document.ContentEnd)).Text;

            }
            else MessageBox.Show("No match found", "Nope", MessageBoxButton.OK, MessageBoxImage.Error);

           


        }

       

    }
}
