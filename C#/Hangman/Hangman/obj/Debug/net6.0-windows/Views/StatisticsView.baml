   M S B A M L   `   `   `  ����B  >Hangman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Hangman.ViewsHangman.Views  5   	   "    Hangman.Views.StatisticsView   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Hangman.Views     5   	     � Title$  StatisticsView��5   	   $	��450��6    $	��800��6-   .��5	      � .+�5
   
   �� $	��218��6   $	��300��6   $
��Left=�6+   $��	0,30,0,58q�6�   ��6H   �� *Users+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex 6�   �� *SelectedItem+$ PropertyChanged=���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��40��6?   $��40��6J   ��6    �� *PicturePath+6J   �� 5      $��16(�6$   ��62   �� *Name+5      5      5      �� 5   
   $	��218��6   $	��300��6   $
��Left=�6+   $��342,53,0,81q�6�   ��6G   �� *StatisticsListCurrent+$ PropertyChanged=���5      �� 5      .R�5      �� $ 
Horizontal=�6!   .+�5      �� $��16(�6$   $	��120��6P   ��62   �� *CategoryName+6P   �� 5      $��16(�6$   $��40��6G   ��62   �� *Won+6G   �� 5      $��16(�6$   $��20��6H   ��62   �� *Lost+6H   5      5!      5$      �� 5%   
   $��
Load Stats��65   $
��Left=�6J   $��	243,0,0,0q�6e   $��Center=�6x   $��74��6�   $��28��6�   ��6   ��  �� Path$ 	LoadStats�6�   �� 5&   
   $1��+Category                  Wins        Loses��6   $
��Left=�6F   $��
342,24,0,0q�6a   $	��Top=�6u   $	��218��6�   5(      5)      