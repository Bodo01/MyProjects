   M S B A M L   `   `   `  ����B  >Hangman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Hangman.ViewsHangman.Views  5   	   7 clr-namespace:Hangman.ViewModelsHangman.ViewModels  5   	       Hangman.Views.NewUserView   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Hangman.Views     5   	   7
ViewModels clr-namespace:Hangman.ViewModels     5   	     � Title$  NewUserView��5	   	   $	��200��6   $	��700��6*   
���   � � DataContext 5      )  #Hangman.ViewModels.NewUserViewModel  5   
   .��5      ��  �� Orientation$ 
Horizontal=�6   .+�5   
   �� 
�������$��16(�6#   $��Center=�61   $��Center=�6N   $��	Username:��6i   �� 5   
   $	��250��6Q   $��30��6]   
��� �����6   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=�6i   �� 5   
   
�������
���   �$��10q�6^   $��20��6j   $��20��6v   $��<��6�   ��6   ��  �� Path$ PreviousPhoto�6�   �� 5   
   $	��180��6Y   ��6   �� *SelectedPhotostr+$ PropertyChanged=�6Y   �� 5   
   
�������
���   �$��10q�6Z   $��20��6f   $��20��6r   $��>��6}   ��6   �� $ 	NextPhoto�6}   �� 5   
   $��65��66   $��50��6A   
���   �
�������$��Create new
     user��6s   $��10,10,10,10q�6�   ��6   �� $ 
CreateUser�6�   5      5      