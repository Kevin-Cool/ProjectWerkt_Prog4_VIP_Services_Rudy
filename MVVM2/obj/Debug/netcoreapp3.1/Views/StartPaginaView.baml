   M S B A M L   `   `   `  ����@  <MVVM2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:MVVM2.ViewsMVVM2.Views  5      !    MVVM2.Views.StartPaginaView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:MVVM2.Views     5      -   5          N� Title$  StartPaginaView��5	       N� 
Background
 �����.��5      � .+�5   
   �� -   5         ��Name$ listboxMaand��5      $
��Left=�6)   $	��399��6D   $��	10,10,0,0q�6Q   $	��Top=�6d   $	��277��6|   ��6�   �� *LijstReserveringen+ �� Mode$ OneWay=���5      �� 5      .R�5      ��  �� Orientation$ 
Horizontal=�6!   .+�5      �� ��6$   �� *
toString+6@   5      5      5      �� 5   
   -   5        $ ��maak niewe reservering aan��5      $
��Left=�66   $��627,415,0,0q�6Q   $	��Top=�6f   $��25��6~   $	��163��6�   6�   �� 5   
   -   5         ��Name$	 Uur��5      $
��Left=�6   $��585,274,0,0q�6:   $��hh��6O    �� TextWrapping$
 Wrap=�6Y   $	��Top=�6m   $��23��6�   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ DatumSelect��5      $
��Left=�6*   $��440,271,0,0q�6E   $	��Top=�6Z      SelectedDate 6�   �� *DatumReservatie+$ TwoWay=��� 5   
   $��StartDatum:��6   $
��Left=�6&   $��360,270,0,0q�6A   $	��Top=�6V   �� 5   
   $
��uur:��6   $
��Left=�6   $��550,269,0,0q�6:   $	��Top=�6O   �� 5   
   $��Aatnal uur gereserveert:��6   $
��Left=�63   $��360,295,0,0q�6N   $	��Top=�6c   �� 5   
   -   5        $ 	AantalUur��5      $
��Left=�6%   $��504,299,0,0q�6@   $��0��6U   $
 Wrap=�6^   $	��Top=�6r   $��38��6�   �� 5   
   $��StartLocatie:��6   $
��Left=�6(   $��360,321,0,0q�6C   $	��Top=�6X   �� 5   
   -   5        	 ��Name$	 StartLocatieDropDown��5      $
��Left=�63   $��440,323,0,0q�6N   $	��Top=�6c   $	��120��6{   ��6�   �� *LijstLocaties+��5       �� 5!      .R�5"      �� $ 
Horizontal=�6!   .+�5#      �� ��6$   �� *Naam+6<   5$      5%      5'      �� 5(   
   $��EindLocatie:��6   $
��Left=�6'   $��360,347,0,0q�6B   $	��Top=�6W   �� 5)   
   -   5        $	 EindLocatieDropDown��5)      $
��Left=�60   $��440,350,0,0q�6K   $	��Top=�6`   $	��120��6x   ��6�   �� *LijstLocaties+��5*      �� 5+      .R�5,      �� $ 
Horizontal=�6!   .+�5-      �� ��6$   �� *Naam+6<   5.      5/      51      �� 52   
   $��
Limousine:��6   $
��Left=�6%   $��360,373,0,0q�6@   $	��Top=�6U   �� 53   
   -	   5        $	 LimousineDropDown��53      $
��Left=�6/   $��440,377,0,0q�6J   $	��Top=�6_   $	��120��6w   ��6�   �� *LijstLimousine+��54      �� 55      .R�56      �� $ 
Horizontal=�6!   .+�57      �� ��6$   �� *Naam+6<   58      59      5;      �� 5<   
   $��Klant:��6   $
��Left=�6!   $��361,399,0,0q�6<   $	��Top=�6Q   �� 5=   
   -
   5        $	 KlantDropDown��5=      $
��Left=�6+   $��440,403,0,0q�6F   $	��Top=�6[   $	��120��6s   ��6�   �� *LijstKlanten+��5>      �� 5?      .R�5@      �� $ 
Horizontal=�6!   .+�5A      �� ��6$   �� *Naam+6<   5B      5C      5E      �� 5F   
   $��ReservatiType:��6   $
��Left=�6)   $��585,323,0,0q�6D   $	��Top=�6Y   �� 5G   
   -   5        $	 ReservatiType��5G      $
��Left=�6*   $��670,325,0,0q�6E   $	��Top=�6Z   $	��120��6r   6�   �� 5H   
   -   5        $��Geef Reserveringen van :��5H      $
��Left=�64   $��
308,35,0,0q�6O   $	��Top=�6c   6{   �� 5I   
   -   5        $��Geef Reserveringen op:��5I      $
��Left=�62   $��
308,70,0,0q�6M   $	��Top=�6a   $	��134��6y   6�   �� 5J   
   -   5        $	 KlantSelect��5J      $
��Left=�6(   $��
460,34,0,0q�6C   $	��Top=�6W   $	��120��6o   ��6�   �� *LijstKlanten+��5K      �� 5L      .R�5M      �� $ 
Horizontal=�6!   .+�5N      �� ��6$   �� *Naam+6<   5O      5P      5R        5S   
   $
��Left=�6   $��
460,68,0,0q�60   $	��Top=�6D    6\   �� *DatumReservatieZoeken+$ TwoWay=��� 5T   
   -   5        $$��Alle Reserveringen terug tonen��5T      $
��Left=�6:   $��361,107,0,0q�6U   $	��Top=�6j   $��22��6�   $	��174��6�   6�   5W      5X      