   M S B A M L   `   `   `  ����E  ASerienlook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Serienlook
Serienlook  5   	       Serienlook.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   U QMahApps.Metro, Version=1.5.0.23, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4f;Controls,http://metro.mahapps.com/winfx/xaml/controls  5   	   $localclr-namespace:Serienlook  5   	   -   5        (  "MahApps.Metro.Controls.MetroWindow   Name$
  main��5       � Title$ 
MediaWatch��5	   	   $	��545��6   $	��653��6)   $	��653��65   $	��653��6D   $	��545��6S   $	��545��6c    � 
ResizeMode$ CanMinimize=�6s    � WindowStartupLocation$ CenterScreen=�6�       IsMaxRestoreButtonEnabled .     TitlebarHeight$ 28��6�      	TitleCaps .     TitleCharacterCasing$ Normal=�6�   ��5
      
� 5   
   .��5      �  � Color$ 	#FF3A3A3A��6   	 � Offset$	 0Q�6-   � 5      $ 	#FF323232��6   $	 1Q�6-   � 5      $ 	#FF3E3C3C��6   $	 0.129Q�6-   5      .��5      � $
��Left=�6   $��	10,10,0,0q�6&   $	��634��69   $	��497��6E   $	��Top=�6R   .+�5   
   �� -   5        
 ��Name$
 combobox_search��5      $
��Left=�6,   $��	55,-5,0,0q�6G   $	��Top=�6Z   $	��255��6r    �� 
IsEditable . $��26��6�    �� IsDropDownOpen .   �� StaysOpenOnEdit . ���	#FFDEDEDE���	#FFDEDEDE&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6e  ��6O  Z� 6e  �� 5   
   -   5         ��Name$ label_search��5      $��Search:��6&   $
��Left=�68   $��	-5,-5,0,0q�6S   $	��Top=�6f   ���	#FF6CD3B8$	��140��6�   ��6�   Z� �� 5   
   $
��Left=�6   $��5,35,0,0q�6/   
���   �$	��Top=�6P   �� 5   
   -   5         ��Name$ imagebox��5      $
��Left=�6"   $��5,35,0,0q�6=   $	��Top=�6O   $
��Fill=�6g   �� 5   
   -   5        $ label_title��5      $��Titel��6%   $
��Left=�65   $��
315,21,0,0q�6P   $	��Top=�6d   ���	#FF6CD3B8$��55��6�   ��6|   Z� 6�   �� 5   
   -   5        $ label_previewname��5      $��<empty>��6+   $
��Left=�6C   $��
375,21,0,0q�6^   $	��Top=�6r   $	��257��6�   ���	#FFECECEC��6�   Z� 6�   �� 5   
   -   5         ��Name$ button��5      $��downloadPNG��6!   $
��Left=�67   $��5,530,0,-58q�6R   $	��Top=�6g   $	��110��6   6�   �� 5   
   -   5        $ button_Copy1��5      $��getData��6'   $
��Left=�69   $��135,530,0,-58q�6T   $	��Top=�6k   $��84��6�   6�   �� 5   
   -	   5        $ image_preview��5      $
��Left=�6'   $	��475��6B   $��
-5,26,0,-4q�6O   $	��Top=�6c   $	��320��6{    � UseLayoutRounding .  � ToolTip$ Preview��6�   �� 5   
   -
   5         ��Name$" textblock_previewdescription��5      $
��Left=�6:   $��320,151,0,-4q�6U   $
��Wrap=�6k   $	��Top=�6   $	��350��6�   $	��312��6�   ���	#FFECECEC6�   �� 5   
   -   5        $ label_views��5      $��Views��6%   $
��Left=�65   $��
315,47,0,0q�6P   $	��Top=�6d   ���	#FF6CD3B8$��55��6�   ��6|   Z� 6�   �� 5   
   -   5        $ label_previewviews��5      $��<empty>��6,   $
��Left=�6D   $��
375,47,0,0q�6_   $	��Top=�6s   $	��257��6�   ���	#FFECECEC��6�   Z� 6�   �� 5   
   -   5        $ label_rating��5      $��Rating��6&   $
��Left=�67   $��
315,73,0,0q�6R   $	��Top=�6f   ���	#FF6CD3B8$��55��6�   ��6~   Z� 6�   �� 5   
   -   5        $ label_previewrating��5      $��<empty>��6-   $
��Left=�6E   $��
375,73,0,0q�6`   $	��Top=�6t   $	��257��6�   ���	#FFECECEC��6�   Z� 6�   �� 5    
   -   5        $ label_id��5       $��Id��6"   $
��Left=�6/   $��
315,99,0,0q�6J   $	��Top=�6^   ���	#FF6CD3B8$��55��6�   ��6v   Z� 6�   �� 5!   
   -   5        $ label_description��5!      $��Description��6+   $
��Left=�6A   $��315,125,0,0q�6\   $	��Top=�6q   ���	#FF6CD3B8$��80��6�   ��6�   Z� 6�   �� 5"   
   -   5        $ label_previewid��5"      $��<empty>��6)   $
��Left=�6A   $��
375,99,0,0q�6\   $	��Top=�6p   $	��257��6�   ���	#FFECECEC��6�   Z� 6�   5#      5$      