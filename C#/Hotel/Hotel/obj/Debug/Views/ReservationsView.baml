   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Hotel.ViewsHotel.Views  5   	   "    Hotel.Views.ReservationsView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Hotel.Views     5   	     � Title$  ReservationsView��5   	   $	��480��6"   $	��820��6/   .��5	      � .+�5
   
   �� -   5         ��Name$ listFacilities��5
   9   $	��672��6   $
��Left=�6   $��
10,50,0,10q�6�   ��6R   �� *Reservations+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *CurrentReservation+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��16(�6$   $	��130��6d   ��62   �� *
start_date+ �� StringFormat$ {0:d}��6d   �� 5      $��16(�6$   $	��130��6c   ��62   �� *
end_date+$ {0:d}��6c   �� 5      $��16(�6$   $	��100��6J   ��62   �� *price+6J   �� 5      $��16(�6$   $	��140��6K   ��62   �� *STATUS+6K   �� 5      $��16(�6$   $	��100��6N   ��62   �� *	User.name+6N   5      5      5      �� 5   
   $��
Start date��6   $
��Left=�6%   $��	10,19,0,0q�6@   $	��Top=�6S   $��74��6k   �� 5   
   $��End date��6   $
��Left=�6#   $��
139,19,0,0q�6>   $	��Top=�6R   $��74��6j   �� 5   
   $��Price��6   $
��Left=�6    $��
272,19,0,0q�6;   $	��Top=�6O   $��74��6g   �� 5   
   $��Reservation status��6   $
��Left=�6-   $��
361,19,0,0q�6H   $	��Top=�6\   �� 5   
   $��   Cancel 
reservation��6/   $
��Left=�6Y   $��710,356,0,0q�6t   $	��Top=�6�   $��42��6�   $��80��6�   ��6   �� *	CancelRes+6�   �� 5   
   $��       Pay 
Reservation��6/   $
��Left=�6Z   $��710,403,0,0q�6u   $	��Top=�6�   $��42��6�   $��80��6�   ��6   �� *PayRes+6�   �� 5   
   $��Name on reservation��6   $
��Left=�6.   $��
521,19,0,0q�6I   $	��Top=�6]   5       5!      