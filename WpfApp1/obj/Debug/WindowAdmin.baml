   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.WindowAdmin   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$/  )Панель администратора��5   	   $	��500��6'   $	��800��67    � SizeToContent$ WidthAndHeight=�6F    � 
ResizeMode$ 	CanResize=�6e   ��5	      �� 5
   
    �� 
StartPoint$	 0,0&�6    �� EndPoint$	 1,1&�6/   .��5      �  � Color$ 	LightCyan��6    � Offset$	 0.0Q�6-   � 5      $ Ivory��6   $	 1.0Q�6)   5      .��5      � $��20q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ Users��5         AutoGenerateColumns .  	   CanUserAddRows	 .  $��10 10 10 10q�5      
   SelectionMode$
 Single=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Фамилия��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 auto 6S   1  +System.Windows.Controls.DataGridBoundColumn   Binding 66   �� *
lastname+6S     5      $ Имя��6%   $
 auto 6P    62   �� *	firstname+6P     5      $ Роль��6%   $
 auto 6L    63   �� *role+6L     5      $ 
Логин��6%   $
 auto 6Q    64   �� *
username+6Q     5      $ Заблокирован��6%   $
 auto 6X    6;   �� *
isLocked+6X   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��Center=�6/   $��Bottom=�6L   $��0 0 0 20q�6g   .+�5      �� -   5        $/��)Добавить пользователя��5      $	��160��5      $��30��5       ���#BFAA98���#444$
��Bold"�5#       � Cursor$
 Hand��6<   �� 5$      -   5        $"��Разблокировать��5$      $	��160��5%      $��30��5&      ���#BFAA98���#444$
��Bold"�5)      $
 Hand��6?   �� 5*      -   5        $+��%Сохранить изменения��5*      $	��160��5+      $��30��5,      ���#BFAA98���#444$
��Bold"�5/      $
 Hand��6:   51      53      54      