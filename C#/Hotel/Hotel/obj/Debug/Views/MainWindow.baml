   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:HotelHotel  5   	   3clr-namespace:Hotel.ViewModelsHotel.ViewModels  5   	       Hotel.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Hotel     5   	   5
viewmodelsclr-namespace:Hotel.ViewModels     5   	     � Title$  
MainWindow��5   	   $	��410��6   $	��750��6)    � DataContext 5      %  Hotel.ViewModels.LoginViewModel  5   
   6&   ��5      �� 5   
    �� ImageSource$6 0 D:\Proiecte WPF\Hotel\Hotel\Images\hotelpic.jpg��5      .��5      � .+�5   
   �� $��Login
��6   $
��Left=�6*   $��
547,76,0,0q�6E   $	��Top=�6Y   $��53��6q   $	��212��6}   $��30(�6�   �� 5   
   $
��Left=�6   $��547,147,0,0q�6-    �� TextWrapping$
 Wrap=�6B   $��16(�6V   $	��Top=�6d   $	��163��6|   $��35��6�   ��6�   �� *
Username+ �� UpdateSourceTrigger$ PropertyChanged=��� 5   
   $
��Left=�6   $��547,187,0,0q�6-   $
 Wrap=�6B   $��16(�6V   $	��Top=�6d   $	��163��6|   $��35��6�   ��6�   �� *
Password+$ PropertyChanged=��� 5   
   $��   Username:��6   $
��Left=�6(   $��464,152,0,0q�6C   $	��Top=�6X   $��83��6p   $
��Bold"�6{   �� 5   
   $��Password:

��6   $
��Left=�69   $��478,189,0,0q�6T   $	��Top=�6i   $��78��6�   $
��Bold"�6�   $��31��6�   �� 5   
   $��Connect��6   $
��Left=�6?   $��592,227,0,0q�6Z   $	��Top=�6o    J� RenderTransformOrigin$ 0.141,-0.395&�6�   $��26��6�   $��74��6�   ��6#   �� *	Connect+6�   �� 5    
   $��Connect as guest��6   $
��Left=�6O   $��572,340,0,0q�6j   $	��Top=�6   $��26��6�   $	��162��6�   ��6,   �� *ConnectAsGuest+6�   �� 5!   
   $��Register��6   $
��Left=�6A   $��
22,340,0,0q�6\   $	��Top=�6p   $��26��6�   $��75��6�   ��6$   �� *
Register+6�   5$      5%      