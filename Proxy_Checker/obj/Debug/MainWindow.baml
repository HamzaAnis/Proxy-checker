   M S B A M L   `   `   `  ����H  DProxy_Checker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:Proxy_CheckerProxy_Checker  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       Proxy_Checker.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:Proxy_Checker     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.1.953, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   3system&clr-namespace:System;assembly=mscorlib  5   	     � 
ResizeMode$  NoResize=�5
   	    � Title$ Proxy Check��5   	   $	��700��6   $	��800��6*    � 	Resources 5       �� MergedDictionaries �� Source �� 
TargetType "  MaterialDesignCaptionTextBlock �� BasedOn  Caption �� Property �� Value�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�5      �� 5      $d ^pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Card.xaml?�5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.CheckBox.xaml?�5      �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Flipper.xaml?�5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Popupbox.xaml?�5      �� 5      $k epack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ProgressBar.xaml?�5      �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ComboBox.xaml?�5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Slider.xaml?�5      �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�5       %d   &	       7   �� 5#      " ��6   8   .�5$      ��  �@J�Opacity$	 .68Q�6,   5%      5&      .��5*      � 	 � ColumnDefinitions	 5+   
   �� 5,      $
��297* �6   �� 5-      $
��100* �6   
 � RowDefinitions
 5/   
   �� 50      $	��13* �6   �� 51      $
��174* �6   �� 52      $
��274* �6   �� 53      $
��210* �6   .+�55   
   �� $��8,8,-0.4,0.675q�6   $��4��6-   $��2��6>   .+�56      ��  �� Orientation$ 
Horizontal=�6   $��0 3 0 0q�62   .+�57      �� -   5         ��Name$ btnFileLoad��57        MaterialDesignRaisedButton#���  6.   $��16 0 0 0q�58       � ToolTip$ Load proxy list��59      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth5=�5:      $	��228��6J   $��	Load List��6V   5;      5<      �� 5=      $��Threads��6     MaterialDesignGroupBox#���  6(   $��16,28,535.6,16q�6Y   $ Depth3=�5>      $	��0.5q�6H   $	��108��6^   .��5?      �� -   5         ��Name$ txtBoxThread��5?      $��4��60   $��1��6=   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Threads��6M   $ Specify number of threads��5@       % !MaterialDesignFloatingHintTextBox#��[ 5A      $��0,0,0,22q�6U   $	��159��6g   5B      5C      �� 5D      $��
Start/Stop��6   #���  6+   $��16,25,535.6,16q�6\   $ Depth3=�5E      $	��0.5q�6H   $	��168��6^   5F      �� 5G   
   $��0,0,-0.4,0.675q�6   $��4��6-   $��2��6>   .+�5H      &   MaterialDesignThemes.Wpf.Flipper  -   5          MaterialDesignCardFlipper#��[ 5H   %   $��580 610 0 0q�6X      FrontContent 5J      �� 5L        MaterialDesignFlatButton#��[ 6      FlipCommand#��Z 5M      $��8q�5N      $	��184��5O      $��Powered By!��5P         BackContent 5R      �� 5S       " MaterialDesignRaisedDarkButton#��[ 6   #��Z 5T      $��8q�5U      $	��184��5V      $ ��Brothers Tech. Services ®��5W      5Y      5Z      �� 5[   
   $��0��6   $��Stretch=�6"   $	��670��6@   $��0,0,-0.4,0.675q�6M   $��Bottom=�5\      $��4��60   $��2��6A   .+�5^      � -   5         �Name$ prgrsBar��5^       � IsIndeterminate .  $��24,600,23.6,24q�6D   �� 5_      -   5         ��Name$ 	lblStatus��5_      $��Status��6'   $��	400,0,0,0q�68   $y�Hidden=�6K   � 5`      -   5        $ statusProgress��5c       % !MaterialDesignCircularProgressBar#��[ 5`       � Value$ 20Q�5a       .  $��4��5d      $��0��6#   $��Center=�63   $��Center=�6N   $��-27 -22 0 0q�6k   $y�Hidden=�6�   5f      � 5g   
   $��2��6   $��263,81.467,34.6,10.275q�6#   $��2��6C   $��1��6T   .+�5h      �� $��5q�6   $��0,0,0,0q�6/   .��5y      �� -   5         ��Name$ txtbox_Proxydetails��5�      $��2��5z       %� IsContainerVirtualizable .  %� IsVirtualizing . ��. $
��Auto=�5~      $
��Auto=�5      5�      5�      5�      �� 5�   
   -   5        $ 
textButton��5�       $	  MaterialDesignRaisedAccentButton#��[	 6%   $ Change to text mode��5�      $��315,5.467,205.6,131.111q�6/   $
��Text��6P   $
��Auto��5�      $��1��66   $y�Hidden=�6C   �� 5�   
   -	   5        $ 
listButton��5�      #��[	 6%   $ Change to List mode��5�      $��405,5.467,115.6,131.111q�6/   $
��List��6P   $
��Auto��5�      $��1��66   $y�Hidden=�6C   �� 5�   
   -
   5        #���  5�      $��35,86.889,343.6,155.275q�5�      $ Depth3=�5�      $��Start��6B   $
��Auto��5�      $��2��6   6,   �� 5�   
    #
 MaterialDesignRaisedLightButton#��� 
 6   $��35,140.889,343.6,101.275q�5�      $ Depth3=�5�      $
��Stop��6B   $
��Auto��5�      $��2��6   �� 5�   
   
�������$��1q�6)   $
��Left=�6=   $	��184��6X   $��25,215.889,0,0q�6e   $��2��5�      $	��Top=�6"   $	��233��6:   $��2��6F   ._�5�      �� $o��iStatistics:

     Checking:
        Remain: 
           Good:
              Bad:
           Errors:��5�      5�      5�      5�      