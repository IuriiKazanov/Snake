   M S B A M L   `   `   `  ����I  EMyWPFSnakeGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MyWPFSnakeGameMyWPFSnakeGame  5   	   $    MyWPFSnakeGame.SaveScoreWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MyWPFSnakeGame     5   	     � Title$  SaveScoreWindow��5   	   $	��150��6!   $	��300��6.    � 
ResizeMode$ NoResize=�6:   .��5	      � .+�5
   
   �  � RowDefinitions 5      �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   .+�5      �� -   5         ��Name$ 
TextBlock1��5      $��0��6,   $��16(�69   $��The end!��6G   �� 5      -   5        $ 
TextBlock2��5      $��1��6,   $��16(�69   $	��100��6G   $
��Left=�6S   $��Your score:��6n   �� 5      -   5        $ TextBlockScore��5      $��1��60   $��16(�6=   $	��200��6K   $��Right=�6W   �� 5      -   5        $ 
TextBlock3��5      $��2��6,   $��16(�69   $	��175��6G   $
��Left=�6S   $��Please enter your name:��6n   �� 5      -   5         ��Name$ TextBoxName��5      $��2��6,   $��Right=�6:   $	��110��6V   $��20��6b   �� 5      -   5         ��Name$ 
ButtonSave��5      $��3��6)   $
��Save��66   $��Right=�6E   $	��100��6a   6m   5      5      5      