   M S B A M L   `   `   `  ����@  <Hotel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Hotel.ViewsHotel.Views  5   	       Hotel.Views.ClientView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Hotel.Views     5   	     � Title$  
ClientView��5   	   $	��450��6   $
��1000��6)   ��5
      �� 5   
    �� ImageSource$1 +D:\Proiecte WPF\Hotel\Hotel\Images\pic6.png��5      .��5      � .+�5   
   �� $)��#View the rooms types from the hotel��6   $
��Left=�6>   $��	10,10,0,0q�6Y   $	��Top=�6l   $	��206��6�   �� 5   
   $��Rooms��6/   $
��Left=�6?   $��	94,41,0,0q�6Z   $	��Top=�6m   $��61��6�   ��6   �� *	ViewRooms+6�   �� 5   
   $&�� Check availability for a period:��6   $
��Left=�6;   $��	10,78,0,0q�6V   $	��Top=�6i   �� 5   
   $��16(�6+   $��Check��69   $
��Left=�6I   $��180,124,0,0q�6d   $	��Top=�6y   $��28��6�   $��70��6�   ��6   �� *Check+6�   �� 5   
   
�������
���  ��$3��-View latest packages the hotel has to offer !��6:   $
��Left=�6r   $��
10,219,0,0q�6�   $	��Top=�6�   $	��240��6�   �� 5   
   $��View offers��60   $
��Left=�6F   $��
94,250,0,0q�6a   $	��Top=�6u   $��24��6�   $��92��6�   ��6   �� *
ViewOffers+6�   (  "System.Windows.Controls.DatePicker  5   
   $
��Left=�6^   $��
17,109,0,0q�6y   $	��Top=�6�   $��30��6�   $	��143��6�      SelectedDate 6   �� *	BeginDate+ �� UpdateSourceTrigger$ PropertyChanged=�6�     5   
   $
��Left=�6[   $��
17,152,0,0q�6v   $	��Top=�6�   $��30��6�   $	��143��6�    6   �� *	EndDate+$ PropertyChanged=�6�   �� 5   
   
�������
���  ��$��View your reservations��69   $
��Left=�6Z   $��
17,310,0,0q�6u   $	��Top=�6�   $	��143��6�   �� 5   
   $��View reservations��6-   $
��Left=�6I   $��
60,352,0,0q�6d   $	��Top=�6x   $��35��6�   $	��100��6�   ��6   �� *	ViewRes+6�   �� 5   
   -   5         ��Name$ listFacilities��5   O   ���#BBD8EE$	��194��6(   $
��Left=�64   $��754,50,0,98q�6�   ��6h   �� *
Services+$ PropertyChanged=���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5       �� $��16(�6$   $	��170��6H   ��62   �� *name+6H   5"      5$      5'      �� 5(   
   $��17(�6   $��Hotel facilities:��6   $
��Left=�6:   $��
756,12,0,0q�6U   $	��Top=�6i   $��33��6�   $	��129��6�   5*      5+      