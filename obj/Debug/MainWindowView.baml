   M S B A M L   `   `   `  ����M  IMultipleChoiceMVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MultipleChoiceMVVMMultipleChoiceMVVM  5   	   K*clr-namespace:MultipleChoiceMVVM.ViewModelMultipleChoiceMVVM.ViewModel  5   	   #    MultipleChoiceMVVM.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MultipleChoiceMVVM     5   	   A
viewmodels*clr-namespace:MultipleChoiceMVVM.ViewModel     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)    � DataContext 5      6  0MultipleChoiceMVVM.ViewModel.MainWindowViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��10 �6   �� 5      $��50 �6   �� 5      �� 5      �� 5      $��10 �6    � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      $��* �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��25 �6   �� 5      $��10 �6   .+�5!   
   o� -   5         o�Name$ mainmenu��5"      $��0��5#      $��5��5$      $��Stretch=�5%      $	��Top=�5&      $
��Auto��5'      $��25��5(      .@�5)      m� -   5         m�Name$ filemenu��5)      $��_File��6)   .@�5*      m� -   5        $ filemenu_new��5*      $��_Open Database��61    m� Command 6I   ��  �� Path$ LoadTest�5+      m� 5,      -   5        $ editmenu��5,      $��_Edit��6)   .@�5-      m� -   5        $ editmenu_import��5-      $��_Import Questions��64    6O   �� $ LoadNewQuestions�5.      m� 5/      -   5        $ helpmenu��5/      $��_Help��6)   .@�50      m� -   5        $ readme��50      $��_ReadMe��6+   51      52      �� 54   
   -   5         ��Name$ questionBlock��55      $��1��56      $��1��57      $��3��58      $��WrapWithOverflow=�59      ��5:      �� *
Question+	� 5=   
   -	   5        	 	�Name$	 rdobtna��5?      $��A.��5>      $��1��5@      $��2��5A      $��Center=�5B      $��Center=�5C      
 d� 	IsChecked
 5D      �� *
Rdoanswera+�� 5E   
   -
   5        $
 lbla��5F      $��Center=�5G      $��2��5H      $��2��5I      $��2��5J      ��5K      �� *	Answera+	� 5M   
   -   5        $	 rdobtnb��5O      $��B.��5N      $��1��5P      $��3��5Q      $��Center=�5R      $��Center=�5S      
 5T      �� *
Rdoanswerb+�� 5U   
   -   5        $
 lblb��5V      $��Center=�5W      $��2��5X      $��3��5Y      $��2��5Z      ��5[      �� *	Answerb+	� 5]   
   -   5        $	 rdobtnc��5_      $��C.��5^      $��1��5`      $��4��5a      $��Center=�5b      $��Center=�5c      
 5d      �� *
Rdoanswerc+�� 5e   
   -   5        $
 blkc��5f      $��Center=�5g      $��2��5h      $��4��5i      $��2��5j      $��WrapWithOverflow=�5k      ��5l      �� *	Answerc+	� 5n   
   -   5        $	 rdobtnd��5p      $��D.��5o      $��1��5q      $��5��5r      $��Center=�5s      $��Center=�5t      
 5u      �� *
Rdoanswerd+�� 5v   
   -   5        $
 lbld��5w      $��Center=�5x      $��2��5y      $��5��5z      $��2��5{      ��5|      �� *	Answerd+�� 5~   
   -   5         ��Name$ Submit��5      $��3��5�      $��6��5�      $	��100��5�      $��25��5�      $��Submit��5�      ��5�      �� *SubmitAnswer+5�      5�      