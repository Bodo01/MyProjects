   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Hotel.ViewsHotel.Views  5   	       Hotel.Views.OffersView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Hotel.Views     5   	     � Title$  
OffersView��5   	   $	��720��6   $
��1200��6)   .��5	      � .+�5
   
   �� -   5         ��Name$ listFacilities��5
   9   $	��192��6   $
��Left=�6   $��12,193,0,132q�6�   ��6R   �� *
OffersList+ �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedItem 6�   �� *CurrentPackage+��5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� $��16(�6$   $	��170��6H   ��62   �� *name+6H   5      5      5      �� 5   
   $��17(�6   $��Offers:��6   $
��Left=�60   $��
12,162,0,0q�6K   $	��Top=�6_   $��96��6w      Hotel.Views.RoomControl2  5   
   $��441,142,10,123q�6M    � DataContext 6   �� *CurrentPackage.RoomType+6g   �� 5   
   -   5        $ listFacilities_Copy��5   9   $	��192��6   $
��Left=�6   $��221,193,0,132q�6�   ��6W   �� * CurrentPackage.PackagesOptions+$ PropertyChanged=� 6�   �� *Index+$ PropertyChanged=���5      �� 5      .R�5      �� $ 
Horizontal=�6!   .+�5      �� $��16(�6$   $	��170��6T   ��62   �� *ExtraOption.name+6T   5      5       5#      �� 5$   
   $��17(�6   $��Offer's extraoptions:��6   $
��Left=�6>   $��221,155,0,0q�6Y   $	��Top=�6n   $	��167��6�   �� 5%   
   $��20(�6   $��Package period:��6   $
��Left=�68   $��	12,65,0,0q�6S   $	��Top=�6f   $��75��6~   $	��166��6�   �� 5&   
   $��20(�6   $
��Left=�6L   $��
183,65,0,0q�6g   $	��Top=�6{   $��75��6�   $	��166��6�   ��6   �� *CurrentPackage.start_date+6�   �� 5'   
   $��20(�6   $
��Left=�6J   $��
354,65,0,0q�6e   $	��Top=�6y   $��75��6�   $	��166��6�   ��6   �� *CurrentPackage.end_date+6�   �� 5(   
   $��25(�6   $��Package price:��6   $
��Left=�67   $��
543,54,0,0q�6R   $	��Top=�6f   $��75��6~   $	��166��6�   �� 5)   
   $��25(�6   $
��Left=�6G   $��
714,54,0,0q�6b   $	��Top=�6v   $��75��6�   $	��166��6�   ��6   �� *CurrentPackage.price+6�   �� 5*   
   $��25(�6M   $��Book this package��6[   $
��Left=�6w   $��908,599,0,0q�6�   $	��Top=�6�   $��75��6�   $	��257��6�   {�6   �� *	Enabled+��6/   �� *	LoadOffer+6�   5+      5,      