   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	   "    WpfApp1.WindowChangePassword   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$:  4Подтверждение нового пароля��5   	   $	��400��6-   $	��400��6:   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ 	LightCyan��6    � Offset$	 0.0Q�6-   � 5      $ Ivory��6   $	 1.0Q�6)   5      .��5      � $��20q�6    � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� $%��Изменение пароля��6   $��24(�5      $
��Bold"�5      ���#333$��Center=�5      $
��0,10q�5      $��Bahnschrift)�5      �� 5   
   $��1��6   $��Center=�6"   $	��300��6=   $��Center=�6I   .+�5      �� $!��Текущий пароль��6   $
��Bold"�6.   $��14(�6@   ���#4446N   G� 5      -   5         G�Name$ txtCurrentPassword��5      $��0, 5, 0, 10q�5      $��35��5       ���#BFAA98���#CCC$��1q�5#      �� 5$      $��Новый пароль��6   $
��Bold"�6,   $��14(�6>   ���#4446L   G� 5%      -   5        $ txtNewPassword��5%      $��0, 5, 0, 10q�5&      $��35��5'      ���#CCC$��1q�5)      �� 5*      $��Новый пароль��6   $
��Bold"�6,   $��14(�6>   ���#4446L   G� 5+      -   5        $ txtConfirmNewPassword��5+      $��0, 5, 0, 10q�5,      $��35��5-      ���#CCC$��1q�5/      �� 50      -   5        $#��Изменить пароль��50      $	��120��51      $��30��52      ���#BFAA98���#CCC$
��Bold"�55      $��Center=�56       � Cursor$
 Hand��57      $��0, 10, 0, 0q�58      $��0q�59      6%   5:      5;      5<      