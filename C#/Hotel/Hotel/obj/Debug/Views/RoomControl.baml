   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Hotel.ViewsHotel.Views  5          Hotel.Views.RoomControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:Hotel.Views     5      .��5	      � .+�5
   
   �� $��Room type: ��6   $��20(�6&   $
��Left=�64   $��	10,10,0,0q�6O   $	��Top=�6b   �� 5   
   $��20(�6Z   $
��Left=�6h   $��
126,10,0,0q�6�   $	��Top=�6�   $��37��6�   $	��132��6�   ��6   �� *CurrentRoom.name+  �� UpdateSourceTrigger$  PropertyChanged=�6�   �� 5   
   -   5         ��Name$ listFacilities��5   9   $	��218��6   $
��Left=�6   $��	0,95,0,10q�6�   ��6R   �� *CurrentRoom.RoomFacilities+$  PropertyChanged=� �� SelectedIndex 6�   �� *IndexFacility+$  PropertyChanged=���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��16(�6$   ��62   �� *Facility.name+5      5      5      �� 5   
   -   5        $ listFacilities_Copy��5   9   $	��490��6   $
��Left=�6   $��274,61,0,10q�6�   ��6W   �� *CurrentRoom.RoomTypesImages+$  PropertyChanged=� 6�   �� *IndexPicture+��5      �� 5      .R�5      �� $ 
Horizontal=�6!   .+�5      �� $	��480��68   $	��400��6D   ��6    �� *path+6D   5      5      5!      �� 5"   
   $��
Facilities��6   $
��Left=�6%   $��5,64,0,0q�6@   $	��Top=�6R   $��68��6j   �� 5#   
   $��Pictures��6   $
��Left=�6#   $��
274,30,0,0q�6>   $	��Top=�6R   $��68��6j   5%      5&      