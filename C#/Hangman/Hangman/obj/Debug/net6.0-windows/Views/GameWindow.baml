   M S B A M L   `   `   `  ����B  >Hangman, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Hangman.ViewsHangman.Views  5   	       Hangman.Views.GameWindow   5   	   W SPresentationCore, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Hangman.Views     5   	     � Title$  
GameWindow��5   	   $	��700��6   $
��1200��6)   .��5	      � .+�5   
   o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� $��New Game��6    m� Command 6-   ��  �� Path$ NewGame�m� 5      $��	Open Game��6    6.   �� $ OpenGame�m� 5      $��	Save Game��6    6.   �� $ SaveGame�m� 5      $
��Exit��6   5      m� 5      $��
Categories��6   {�6+   �� *CategoryEnable+��6P   �� $ 
Categories� �� UpdateSourceTrigger$ PropertyChanged=���5      �� 5      .R�5      m�  m� IsCheckable$
 True��6C   ��6#   �� *CategoryName+ m� 	IsChecked 6V   �� *	IsChecked+6x   5      5#      m� 5$      $
��Help��6   5&      �� 5'   
   $��Q��6�   $
��Left=�6�   $��	556,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonQ�{�6:   �� *KeyBoardCl.ButtonQ.IsEnabled+$ PropertyChanged=�6'  �� 5(   
   $��W��6�   $
��Left=�6�   $��	612,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonW�{�6:   �� *KeyBoardCl.ButtonW.IsEnabled+$ PropertyChanged=�6'  �� 5)   
   $��E��6�   $
��Left=�6�   $��	667,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonE�{�6:   �� *KeyBoardCl.ButtonE.IsEnabled+$ PropertyChanged=�6'  �� 5*   
   $��R��6�   $
��Left=�6�   $��	721,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonR�{�6:   �� *KeyBoardCl.ButtonR.IsEnabled+$ PropertyChanged=�6'  �� 5+   
   $��T��6�   $
��Left=�6�   $��	776,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonT�{�6:   �� *KeyBoardCl.ButtonT.IsEnabled+$ PropertyChanged=�6'  �� 5,   
   $��Y��6�   $
��Left=�6�   $��	830,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonY�{�6:   �� *KeyBoardCl.ButtonY.IsEnabled+$ PropertyChanged=�6'  �� 5-   
   $��U��6�   $
��Left=�6�   $��	884,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonU�{�6:   �� *KeyBoardCl.ButtonU.IsEnabled+$ PropertyChanged=�6'  �� 5.   
   $��I��6�   $
��Left=�6�   $��	942,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonI�{�6:   �� *KeyBoardCl.ButtonI.IsEnabled+$ PropertyChanged=�6'  �� 5/   
   $��O��6�   $
��Left=�6�   $��
1000,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6(  ��6   �� $ DisableButtonO�{�6:   �� *KeyBoardCl.ButtonO.IsEnabled+$ PropertyChanged=�6(  �� 50   
   $��P��6�   $
��Left=�6�   $��
1058,0,0,0q�6�   $��Center=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6(  ��6   �� $ DisableButtonP�{�6:   �� *KeyBoardCl.ButtonP.IsEnabled+$ PropertyChanged=�6(  �� 51   
   $��A��6�   $��Center=�6�   $��	0,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonA�{�6:   �� *KeyBoardCl.ButtonA.IsEnabled+$ PropertyChanged=�6&  �� 52   
   $��S��6�   $
��Left=�6�   $��634,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonS�{�6:   �� *KeyBoardCl.ButtonS.IsEnabled+$ PropertyChanged=�6&  �� 53   
   $��D��6�   $
��Left=�6�   $��689,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonD�{�6:   �� *KeyBoardCl.ButtonD.IsEnabled+$ PropertyChanged=�6&  �� 54   
   $��F��6�   $
��Left=�6�   $��743,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonF�{�6:   �� *KeyBoardCl.ButtonF.IsEnabled+$ PropertyChanged=�6&  �� 55   
   $��G��6�   $
��Left=�6�   $��798,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonG�{�6:   �� *KeyBoardCl.ButtonG.IsEnabled+$ PropertyChanged=�6&  �� 56   
   $��H��6�   $
��Left=�6�   $��852,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonH�{�6:   �� *KeyBoardCl.ButtonH.IsEnabled+$ PropertyChanged=�6&  �� 57   
   $��J��6�   $
��Left=�6�   $��906,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonJ�{�6:   �� *KeyBoardCl.ButtonJ.IsEnabled+$ PropertyChanged=�6&  �� 58   
   $��K��6�   $
��Left=�6�   $��964,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonK�{�6:   �� *KeyBoardCl.ButtonK.IsEnabled+$ PropertyChanged=�6&  �� 59   
   $��L��6�   $
��Left=�6�   $��1022,370,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6'  ��6   �� $ DisableButtonL�{�6:   �� *KeyBoardCl.ButtonL.IsEnabled+$ PropertyChanged=�6'  �� 5:   
   $��Z��6�   $
��Left=�6�   $��600,421,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonZ�{�6:   �� *KeyBoardCl.ButtonZ.IsEnabled+$ PropertyChanged=�6&  �� 5;   
   $��X��6�   $
��Left=�6�   $��656,421,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonX�{�6:   �� *KeyBoardCl.ButtonX.IsEnabled+$ PropertyChanged=�6&  �� 5<   
   $��C��6�   $
��Left=�6�   $��711,421,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonC�{�6:   �� *KeyBoardCl.ButtonC.IsEnabled+$ PropertyChanged=�6&  �� 5=   
   $��V��6�   $
��Left=�6�   $��765,421,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonV�{�6:   �� *KeyBoardCl.ButtonV.IsEnabled+$ PropertyChanged=�6&  �� 5>   
   $��B��6�   $
��Left=�6�   $��820,421,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonB�{�6:   �� *KeyBoardCl.ButtonB.IsEnabled+$ PropertyChanged=�6&  �� 5?   
   $��N��6�   $
��Left=�6�   $��874,421,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonN�{�6:   �� *KeyBoardCl.ButtonN.IsEnabled+$ PropertyChanged=�6&  �� 5@   
   $��M��6�   $
��Left=�6�   $��928,421,0,0q�6�   $	��Top=�6�   $��44��6�   $��46��6�   $
��Bold"�6�   ���	#FFFAFD00$��24(�6&  ��6   �� $ DisableButtonM�{�6:   �� *KeyBoardCl.ButtonM.IsEnabled+$ PropertyChanged=�6&  �� 5A   
   $��40(�6   $��	Category:��6   $
��Left=�62   $��
10,527,0,0q�6M   $	��Top=�6a   $��61��6y   $	��191��6�   $
��Bold"�6�   $��Cambria)�6�   �� 5B   
   $��40(�6   $
��Left=�6D   $��206,527,0,0q�6_   $	��Top=�6t   $��61��6�   $	��967��6�   $
��Bold"�6�   $��Cambria)�6�   ��6   �� *CurrentCategories+6�   �� 5C   
   $��0,46,774,217q�6W   $
��Fill=�6m   ��6   �� *GamePhaseImage+$ PropertyChanged=�6m   �� 5D   
   $��40(�6   $��Word:��6   $
��Left=�6.   $��
10,613,0,0q�6I   $	��Top=�6]   $��61��6u   $	��130��6�   $
��Bold"�6�   $��Cambria)�6�   �� 5E   
   $��40(�6   $
��Left=�6o   $��148,613,0,0q�6�   $	��Top=�6�   $��61��6�   $	��932��6�   $
��Bold"�6�   $��Bahnschrift)�6�   ��6   �� *CurrentGame.GuessedWord+$ PropertyChanged=�6�   �� 5F   
   $��30(�6   $��Current level:��6   $
��Left=�67   $��
436,23,0,0q�6R   $	��Top=�6f   $��61��6~   $	��208��6�   $
��Bold"�6�   $��Cambria)�6�   �� 5G   
   $��30(�6   $
��Left=�6i   $��
644,23,0,0q�6�   $	��Top=�6�   $��61��6�   $��67��6�   $
��Bold"�6�   $��Cambria)�6�   ��6   �� *CurrentGame.Level+$ PropertyChanged=�6�   5J      5K      