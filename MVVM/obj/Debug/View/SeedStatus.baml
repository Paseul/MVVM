   M S B A M L   `   `   `  ����?  ;MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVM.ViewModelMVVM.ViewModel  5   	       MVVM.View.SeedStatus   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:MVVM.ViewModel     5   	     � Title$  
SeedStatus��5   	   $	��180��6   $	��270��6)    � WindowStartupLocation$ CenterScreen=�5
   	    � DataContext 5	   	   ��    Locator �� Source# [   �� Path$ 
SeedStatus� � 	Resources 5      )  #MVVM.ViewModel.BoolGrayRedConverter  BoolGrayRedConverter)  #MVVM.ViewModel.BoolLimeRedConverter  BoolLimeRedConverter(  "MVVM.ViewModel.IntToColorConverter  IntToColorConverter��%W   &	       &	      &	 &       5   
   6%     5   
   6%     5   
   6$   5      .��5      � 
�������.+�5   
   �� $��Current��6   $
��Left=�6#   $	��Top=�6>   $	��127��6V   $
��Bold"�6b   $��8,19,0,0q�6t   $��18(�6�   $��24��6�   ��6�   Z� 6�   �� 5   
   $
��Temp��6   $
��Left=�6    $	��Top=�6;   $	��127��6S   $
��Bold"�6_   $��8,59,0,0q�6q   $��18(�6�   $��24��6�   ��6�   Z� 6�   �� 5   
   $��RF TEC��6   $
��Left=�6"   $	��Top=�6=   $	��127��6U   $
��Bold"�6a   $��8,97,0,0q�6s   $��18(�6�   $��24��6�   ��6�   Z� 6�   �� 5   
   -   5         ��Name$ seedCurrentLow��5      $	��Low��6)   $
��Left=�67   $	��Top=�6R   $��56��6j   $
��Bold"�6u   $��
128,24,0,0q�6�   ��6�   �� *SeedCurrentLow+ �� 	Converter# [ ��6�   Z�  J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 10Q�6#   
   ShadowDepth$
 5Q�63   5      �� 5   
   -   5        $ seedTempLow��5      $	��Low��6&   $
��Left=�64   $	��Top=�6O   $��56��6g   $
��Bold"�6r   $��
128,63,0,0q�6�   ��6�   �� *SeedTempLow+# [ ��6�   Z�  5        5      $	 10Q�6#   $
 5Q�63   5      �� 5   
   -   5        $ 	rfTempLow��5      $	��Low��6$   $
��Left=�62   $	��Top=�6M   $��56��6e   $
��Bold"�6p   $��128,102,0,0q�6�   ��6�   �� *SeedTemp1Low+# [ ��6�   Z�  5        5       $	 10Q�6#   $
 5Q�63   5"      �� 5#   
   -   5        $ seedCurrentHigh��5#      $
��High��6*   $
��Left=�69   $	��Top=�6T   $��56��6l   $
��Bold"�6w   $��
190,24,0,0q�6�   ��6�   �� *SeedCurrentHigh+# [ ��6�   Z�  5$        5%      $	 10Q�6#   $
 5Q�63   5'      �� 5(   
   -   5        $ seedTempHigh��5(      $
��High��6'   $
��Left=�66   $	��Top=�6Q   $��56��6i   $
��Bold"�6t   $��
190,63,0,0q�6�   ��6�   �� *SeedTempHigh+# [ ��6�   Z�  5)        5*      $	 10Q�6#   $
 5Q�63   5,      �� 5-   
   -   5        $ 
rfTempHigh��5-      $
��High��6%   $
��Left=�64   $	��Top=�6O   $��56��6g   $
��Bold"�6r   $��190,102,0,0q�6�   ��6�   �� *SeedTemp1High+# [ ��6�   Z�  5.        5/      $	 10Q�6#   $
 5Q�63   51      52      53      