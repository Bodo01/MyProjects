   M S B A M L   `   `   `  ����B  >Notepad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:NotepadNotepad  5   	       Notepad.MainWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:Notepad     5   	     � Title$  	Notepad++��5   	   $	��450��6   $	��800��6(   .��5	      � .+�5   
   o�  o� 
IsMainMenu$
 True��6   $��17��6!   $��0,1,0,0q�6-   $
��Left=�6>   $	��Top=�6Y   $	��624��6q   .@�5      m� $
��File��6   .@�5      m� -   5        $	��New��5      6A   m� 5      -   5        $
��Open��5      6C   5      m� 5      $
��Help��6   .@�5      m� -   5        $��About��5      6@   5      5      �� 5   
   -   5         ��Name$ MainTabControl��5      $��0,18,0,0q�6�   ��6-   �� *Items+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex 6p   �� *SelectedItem+$ PropertyChanged=���5      �� 5      .R�5      ��  ��Name$
 txt1��6    ��6.   �� 5       � ContextMenu 5       �� 5!      .@�5"      m� -   5        $��
Remove Tab��5"      63   m� 5#      -   5        $
��Save��5#      6-   m� 5$      -   5        $��Save As��5$      60   5'      5+      �� 5,   
   -   5         ��Name$ FindTextBox��5,   �   $��Right=�6   $��0,1,0,0q�6.    �� TextWrapping$
 Wrap=�6?   $	��Top=�6S   $	��176��6k   	 J� RenderTransformOrigin$	 -0.16,-0.265&�6w   6�   �� 5-   
   -	   5        $��Find in text��5-      $��Right=�6(   $��1,0,0,0q�6D   $	��Top=�6U   6m   5/      50      