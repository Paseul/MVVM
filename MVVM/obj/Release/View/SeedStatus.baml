   M S B A M L   `   `   `  ���� ?  ;MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVM.ViewModelMVVM.ViewModel      MVVM.View.SeedStatus   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:MVVM.ViewModel       � Title$  
SeedStatus��$	��180��$	��270�� � WindowStartupLocation$ CenterScreen=� � DataContext ��    Locator �� Source# [   �� Path$ 
SeedStatus� � 	Resources )  #MVVM.ViewModel.BoolGrayRedConverter  BoolGrayRedConverter)  #MVVM.ViewModel.BoolLimeRedConverter  BoolLimeRedConverter��%   &	       &	          .��� 
�������.+��� $��Current��$
��Left=�$	��Top=�$	��127��$
��Bold"�$��8,19,0,0q�$��18(�$��24����Z� �� $
��Temp��$
��Left=�$	��Top=�$	��127��$
��Bold"�$��8,59,0,0q�$��18(�$��24����Z� �� $��RF TEC��$
��Left=�$	��Top=�$	��127��$
��Bold"�$��8,97,0,0q�$��18(�$��24����Z� �� -    ��Name$ seedCurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
128,24,0,0q����� *SeedCurrentLow+ �� 	Converter# [ ��Z�  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   
BlurRadius$	 10Q�
   ShadowDepth$
 5Q��� -   $ seedTempLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
128,63,0,0q����� *SeedTempLow+# [ ��Z�    $	 10Q�$
 5Q��� -   $ 	rfTempLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��128,102,0,0q����� *SeedTemp1Low+# [ ��Z�    $	 10Q�$
 5Q��� -   $ seedCurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
190,24,0,0q����� *SeedCurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ seedTempHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
190,63,0,0q����� *SeedTemp1High+# [ ��Z�    $	 10Q�$
 5Q��� -   $ 
rfTempHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��190,102,0,0q����� *SeedTempHigh+# [ ��Z�    $	 10Q�$
 5Q�