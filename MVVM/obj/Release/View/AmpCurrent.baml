   M S B A M L   `   `   `  ���� ?  ;MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVM.ViewModelMVVM.ViewModel      MVVM.View.AmpCurrent   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:MVVM.ViewModel       � Title$  
AmpCurrent��$	��420��$	��250�� � WindowStartupLocation$ CenterScreen=� � DataContext ��    Locator �� Source# [   �� Path$ 
AmpCurrent� � 	Resources )  #MVVM.ViewModel.BoolGrayRedConverter  BoolGrayRedConverter)  #MVVM.ViewModel.BoolLimeRedConverter  BoolLimeRedConverter��%   &	       &	          .��� 
�������.+��� $	��PA1��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��	12,25,0,0q�$��18(�$��24����Z� �� $	��PA2��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��	12,65,0,0q�$��18(�$��24����Z� �� $	��PA3��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��
12,105,0,0q�$��18(�$��24����Z� �� $��PA4-1��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��
12,148,0,0q�$��18(�$��24����Z� �� $��PA4-2��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��
12,188,0,0q�$��18(�$��24����Z� �� $��PA4-3��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��
12,224,0,0q�$��18(�$��24����Z� �� $��PA4-4��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��
12,265,0,0q�$��18(�$��24����Z� �� $��PA4-5��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��
12,304,0,0q�$��18(�$��24����Z� �� $��PA4-6��$
��Left=�$	��Top=�$	��110��$
��Bold"�$��
12,344,0,0q�$��18(�$��24����Z� �� -    ��Name$ pa1CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
106,30,0,0q����� *Pa1CurrentLow+ �� 	Converter# [ ��Z�  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   
BlurRadius$	 10Q�
   ShadowDepth$
 5Q��� -   $ pa2CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
106,70,0,0q����� *Pa2CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa3CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��106,110,0,0q����� *Pa3CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_1CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��106,152,0,0q����� *Pa4_1CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_2CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��106,192,0,0q����� *Pa4_2CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_3CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��106,229,0,0q����� *Pa4_3CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_4CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��106,269,0,0q����� *Pa4_4CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_5CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��106,309,0,0q����� *Pa4_5CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -	   $ pa4_6CurrentLow��$	��Low��$
��Left=�$	��Top=�$��56��$
��Bold"�$��106,348,0,0q����� *Pa4_6CurrentLow+# [ ��Z�    $	 10Q�$
 5Q��� -
   $ pa1CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
168,30,0,0q����� *Pa1CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa2CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��
168,70,0,0q����� *Pa2CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa3CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��168,110,0,0q����� *Pa3CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_1CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��168,152,0,0q����� *Pa4_1CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_2CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��168,192,0,0q����� *Pa4_2CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_3CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��168,229,0,0q����� *Pa4_3CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_4CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��168,269,0,0q����� *Pa4_4CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_5CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��168,309,0,0q����� *Pa4_5CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q��� -   $ pa4_6CurrentHigh��$
��High��$
��Left=�$	��Top=�$��56��$
��Bold"�$��168,348,0,0q����� *Pa4_6CurrentHigh+# [ ��Z�    $	 10Q�$
 5Q�