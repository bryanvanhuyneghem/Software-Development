   M S B A M L   `   `   `  ����B  >QuizGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:QuizGUIQuizGUI  5   	       QuizGUI.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:QuizGUI     5   	     � Title$  Quiz GUI��5   	   $	��400��6   $	��500��6'   .��5	      �  � RowDefinitions 5
   
   �� 5      $	��80* �6   �� 5      $
��240* �6    � ColumnDefinitions 5   
   �� 5      $
��400* �6   .+�5   
      QuizGUI.LoadQuiz  -   5          Name$ loadQuiz��5      $��0��6+   $��0��68      QuizGUI.ShowQuiz  5   
   -   5          Name$ showQuiz��5      $��1��6+   $��0��68   5      5      