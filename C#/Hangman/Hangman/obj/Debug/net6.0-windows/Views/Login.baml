   M S B A M L   `   `   `  ����B  >Hangman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Hangman.ViewsHangman.Views  5   	   7 clr-namespace:Hangman.ViewModelsHangman.ViewModels  5   	       Hangman.Views.Login   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Hangman.Views     5   	   7
ViewModels clr-namespace:Hangman.ViewModels     5   	     � Title$  Login��5	   	   $	��450��6   $	��800��6$    � DataContext 5      &   Hangman.ViewModels.UserViewModel  5   
   .��5      � .+�5   
   �� $��20(�6   $
��Left=�6   $	��Top=�69   $��Available Users:��6Q   $	��218��6l   �� 5   
   -   5         ��Name$ 	listUsers��5   F   $	��218��6   $	��300��6   $
��Left=�6+   $��	0,30,0,58q�6�   ��6Z   �� *Users+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex 6�   �� *SelectedUser+$ PropertyChanged=���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��40��6?   $��40��6J   ��6    �� *PicturePath+6J   �� 5      $��16(�6$   ��62   �� *Name+5      5      5"      �� 5#   
   $��New User��6   $
��Left=�6E   $��	12,0,0,10q�6`   $��Bottom=�6s   $��97��6�   $��29��6�   ��6$   ��  �� Path$ NewUser�6�   �� 5$   
   $��Delete User��66   $
��Left=�6L   $��
121,0,0,10q�6g   $��Bottom=�6{   $��97��6�   $��29��6�   ��6   �� $ 
DeleteUser�6�   �� 5%   
   $��Refresh��6-   $
��Left=�6?   $��
174,0,0,50q�6Z   $��Bottom=�6n   ��6   �� *	Refresh+6n   �� 5&   
   $��Right=�6   $	��Top=�6,   $	��560��6D   $	��350��6P   $:��4D:\Proiecte WPF\Hangman\Hangman\Pictures\hangman.png��6]   $
��Fill=�6�   �� 5'   
   $��Bottom=�6/   $
��PLAY��6J   
�������
���   �$
��Left=�6   $��449,0,20,10q�6�   $	��117��6�   $��29��6�   ��6   �� $
 Play�6�   �� 5(   
   $��View Statistics��60   $
��Left=�6J   $��
240,0,0,10q�6e   $��Bottom=�6z   $��29��6�   $	��106��6�   ��6   �� $ Stats�6�   5+      5-      