   M S B A M L   `   `   `  ����@  <PLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PLWPFPLWPF  5   	       PLWPF.Address   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:PLWPF     5   	     � Title$  Address��5   	   $	��300��6   $	��300��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��Country��6   $��3q�6"   $	��Top=�6-   �� 5   
   $
��City��6   $��3q�6   $��1��6*   �� 5   
   $��Street��6   $��3q�6!   $��2��6,   �� 5   
   $��Number��6   $��3q�6!   $��3��6,   �� 5   
   $��Zip Code��6   $��3q�6#   $��4��6.   �� 5   
   $��1��6   $��3q�6"   ��6-   �� *	Country+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . �� 5   
   $��1��6   $��3q�6"   $��1��6-   ��6:   �� *City+$ TwoWay=� .  . �� 5   
   $��1��6   $��3q�6"   $��2��6-   ��6:   �� *Street+$ TwoWay=� .  . �� 5   
   $��1��6   $��3q�6"   $��3��6-   ��6:   �� *Number+$ TwoWay=� .  . �� 5   
   $��1��6   $��3q�6"   $��4��6-   ��6:   �� *	ZipCode+$ TwoWay=� .  . �� 5    
   -   5        $
��Okay��5       $��3q�6    $��5��6+   $��Center=�68   $��75��6S   $��2��6^   6r   5!      5"      