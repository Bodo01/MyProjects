   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Hotel.ViewsHotel.Views  5   	       Hotel.Views.ModifyRoom   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Hotel.Views     5   	     � Title$  
ModifyRoom��5   	   $	��800��6   $
��1400��6)   .��5	      � .+�5
   
      Hotel.Views.RoomControl  $��10,10,593,253q�6=    � DataContext 6   �� *
Enhanced+6V   �� 5   
   $��Delete Picture��63   $
��Left=�6L   $��289,536,0,0q�6g   $	��Top=�6|   $��88��6�   $��39��6�   ��6   �� *DeletePicture+6�   �� 5   
   $��Delete facility��64   $
��Left=�6N   $��
15,536,0,0q�6i   $	��Top=�6}   $��80��6�   $��39��6�   ��6   �� *DeleteFacility+6�   �� 5   
   $��Add facility��6   $
��Left=�6H   $��807,397,0,0q�6c   $	��Top=�6x   $��80��6�   $��39��6�   ��6(   �� *AddFacility+6�   �� 5   
   $��Add picture��60   $
��Left=�6F   $��389,536,0,0q�6a   $	��Top=�6v   $��80��6�   $��39��6�   ��6   �� *
AddPicture+6�   �� 5   
   -   5         ��Name$ listFacilities��5   9   $	��253��6   $
��Left=�6   $��807,81,0,392q�6�   ��6R   �� *FacilitiesList+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *CurrentFacility+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��16(�6$   $	��130��6H   ��62   �� *name+6H   5      5      5      �� 5   
   -   5        $ listFacilities_Copy��5   9   $	��285��6   $
��Left=�6   $��1087,81,0,392q�6  ��6W   �� *!Enhanced.CurrentRoom.RoomPrices+$ PropertyChanged=� 6�   �� *CurrentRoomPrice+$ PropertyChanged=���5      �� 5      .R�5      �� $ 
Horizontal=�6!   .+�5       �� $��16(�6$   $��80��6I   ��62   �� *price+6I   �� 5!      $��16(�6$   $	��100��6d   ��62   �� *
start_date+ �� StringFormat$ {0:d}��6d   �� 5"      $��16(�6$   $��80��6b   ��62   �� *
end_date+$ {0:d}��6b   5#      5%      5(      �� 5)   
   $��Room prices:��6   $
��Left=�6'   $��1087,23,0,0q�6B   $	��Top=�6W   $��77��6o   �� 5*   
   $ ��Available facilities list:��6   $
��Left=�65   $��
807,50,0,0q�6P   $	��Top=�6d   $	��127��6|   �� 5+   
   $��Price:��6   $
��Left=�6!   $��1087,50,0,0q�6<   $	��Top=�6Q   $��63��6i   �� 5,   
   $��Start date:��6   $
��Left=�6&   $��1169,50,0,0q�6A   $	��Top=�6V   $��62��6n   �� 5-   
   $��	End date:��6   $
��Left=�6$   $��1267,50,0,0q�6?   $	��Top=�6T   $��62��6l   �� 5.   
   $��Delete Price��61   $
��Left=�6H   $��1087,397,0,0q�6c   $	��Top=�6y   $��88��6�   $��39��6�   ��6   �� *DeletePrice+6�   �� 5/   
   $��Add new 
price
��6.   $
��Left=�6U   $��1284,397,0,0q�6p   $	��Top=�6�   $��88��6�   $��39��6�   ��6   �� *
AddPrice+6�   (  "System.Windows.Controls.DatePicker  50   
   $
��Left=�68   $��1270,441,0,0q�6S   $	��Top=�6i      SelectedDate 6   �� *	StartDate+6i     51   
   $
��Left=�66   $��1270,470,0,0q�6Q   $	��Top=�6g    6   �� *	EndDate+6g   �� 52   
   $��Start��6   $
��Left=�6    $��1223,441,0,0q�6;   $	��Top=�6Q   $��24��6i   $��42��6u   �� 53   
   $	��End��6   $
��Left=�6   $��1223,470,0,0q�69   $	��Top=�6O   $��24��6g   $��42��6s   �� 54   
   $��Price��6   $
��Left=�6    $��1223,499,0,0q�6;   $	��Top=�6Q   $��24��6i   $��42��6u   �� 55   
   $
��Left=�6   $��1270,502,0,0q�6-    �� TextWrapping$
 Wrap=�6C   $	��Top=�6q   $	��120��6�   ��6W   �� *
NewPrice+6�   56      57      