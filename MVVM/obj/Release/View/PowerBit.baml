   M S B A M L   `   `   `  ���� ?  ;MVVM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:MVVM.ViewModelMVVM.ViewModel      MVVM.View.PowerBit   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     .localclr-namespace:MVVM.ViewModel       � Title$  PowerBit��$	��400��$	��404�� � WindowStartupLocation$ CenterScreen=� � DataContext ��    Locator �� Source# [   �� Path$ PowerBit� � 	Resources )  #MVVM.ViewModel.BoolGrayRedConverter  BoolGrayRedConverter)  #MVVM.ViewModel.BoolLimeRedConverter  BoolLimeRedConverter��%   &	       &	          .��� 
�������.+��� $
��Left=�$��	122,9,0,0q�$
��Wrap=�$��Voltage��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��	282,8,0,0q�$
��Wrap=�$��Current��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��	10,35,0,0q�$
��Wrap=�$��380VAC��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��	10,60,0,0q�$
��Wrap=�$��Board��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��	10,85,0,0q�$
��Wrap=�$��PA1, 2��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,110,0,0q�$
��Wrap=�$	��PA3��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,135,0,0q�$
��Wrap=�$��PA4-1��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,160,0,0q�$
��Wrap=�$��PA4-2��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,185,0,0q�$
��Wrap=�$��PA4-3��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,210,0,0q�$
��Wrap=�$��PA4-4��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,235,0,0q�$
��Wrap=�$��PA4-5��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,260,0,0q�$
��Wrap=�$��PA4-6��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,336,0,0q�$
��Wrap=�$��E-Stop��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,286,0,0q�$
��Wrap=�$��Humid��$	��Top=�$��50��$
��Bold"��� $
��Left=�$��
10,311,0,0q�$
��Wrap=�$
��Temp��$	��Top=�$��50��$
��Bold"��� -    ��Name$ 
vacVoltLow��$	��Low��$
��Left=�$��	69,33,0,0q�$	��Top=�$��75��$
��Bold"����� *
VacVoltLow+ �� 	Converter# [  J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect  	   
BlurRadius$	 10Q�
   ShadowDepth$
 5Q��� -   $ 	pbVoltLow��$	��Low��$
��Left=�$��	69,58,0,0q�$	��Top=�$��75��$
��Bold"����� *	PbVoltLow+# [    $	 10Q�$
 5Q��� -   $ amp1_2VoltLow��$	��Low��$
��Left=�$��	69,83,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp1_2VoltLow+# [    $	 10Q�$
 5Q��� -   $ amp3VoltLow��$	��Low��$
��Left=�$��
69,108,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp3VoltLow+# [    $	 10Q�$
 5Q��� -   $ amp4_1VoltLow��$	��Low��$
��Left=�$��
69,133,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_1VoltLow+# [    $	 10Q�$
 5Q��� -   $ amp4_2VoltLow��$	��Low��$
��Left=�$��
69,158,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_2VoltLow+# [    $	 10Q�$
 5Q��� -   $ amp4_3VoltLow��$	��Low��$
��Left=�$��
69,183,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_3VoltLow+# [    $	 10Q�$
 5Q��� -   $ amp4_4VoltLow��$	��Low��$
��Left=�$��
69,208,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_4VoltLow+# [    $	 10Q�$
 5Q��� -	   $ amp4_5VoltLow��$	��Low��$
��Left=�$��
69,233,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_5VoltLow+# [    $	 10Q�$
 5Q��� -
   $ amp4_6VoltLow��$	��Low��$
��Left=�$��
69,258,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_6VoltLow+# [    $	 10Q�$
 5Q��� -   $ e_stop��$�� ��$
��Left=�$��
69,334,0,0q�$	��Top=�$��75��$
��Bold"����� *E_stop+# [    $	 10Q�$
 5Q��� -   $ vacVoltHigh��$
��High��$
��Left=�$��
149,33,0,0q�$	��Top=�$��75��$
��Bold"����� *VacVoltHigh+# [    $	 10Q�$
 5Q��� -   $ 
pbVoltHigh��$
��High��$
��Left=�$��
149,58,0,0q�$	��Top=�$��75��$
��Bold"����� *
PbVoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp1_2VoltHigh��$
��High��$
��Left=�$��
149,83,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp1_2VoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp3VoltHigh��$
��High��$
��Left=�$��149,108,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp3VoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp4_1VoltHigh��$
��High��$
��Left=�$��149,133,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_1VoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp4_2VoltHigh��$
��High��$
��Left=�$��149,158,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_2VoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp4_3VoltHigh��$
��High��$
��Left=�$��149,183,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_3VoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp4_4VoltHigh��$
��High��$
��Left=�$��149,208,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_4VoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp4_5VoltHigh��$
��High��$
��Left=�$��149,233,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_5VoltHigh+# [    $	 10Q�$
 5Q��� -   $ amp4_6VoltHigh��$
��High��$
��Left=�$��149,258,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_6VoltHigh+# [    $	 10Q�$
 5Q��� -   $ humidityLow��$	��Low��$
��Left=�$��
69,284,0,0q�$	��Top=�$��75��$
��Bold"����� *HumidityLow+# [    $	 10Q�$
 5Q��� -   $ 
vacCurrLow��$	��Low��$
��Left=�$��
229,33,0,0q�$	��Top=�$��75��$
��Bold"����� *
VacCurrLow+# [    $	 10Q�$
 5Q��� -   $ 	pbCurrLow��$	��Low��$
��Left=�$��
229,58,0,0q�$	��Top=�$��75��$
��Bold"����� *	PbCurrLow+# [    $	 10Q�$
 5Q��� -   $ amp1_2CurrLow��$	��Low��$
��Left=�$��
229,83,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp1_2CurrLow+# [    $	 10Q�$
 5Q��� -   $ amp3CurrLow��$	��Low��$
��Left=�$��229,108,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp3CurrLow+# [    $	 10Q�$
 5Q��� -   $ amp4_1CurrLow��$	��Low��$
��Left=�$��229,133,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_1CurrLow+# [    $	 10Q�$
 5Q��� -   $ amp4_2CurrLow��$	��Low��$
��Left=�$��229,158,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_2CurrLow+# [    $	 10Q�$
 5Q��� -   $ amp4_3CurrLow��$	��Low��$
��Left=�$��229,183,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_3CurrLow+# [    $	 10Q�$
 5Q��� -   $ amp4_4CurrLow��$	��Low��$
��Left=�$��229,208,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_4CurrLow+# [    $	 10Q�$
 5Q��� -   $ amp4_5CurrLow��$	��Low��$
��Left=�$��229,233,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_5CurrLow+# [    $	 10Q�$
 5Q��� -    $ amp4_6CurrLow��$	��Low��$
��Left=�$��229,258,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_6CurrLow+# [    $	 10Q�$
 5Q��� -!   $ tempLow��$	��Low��$
��Left=�$��
69,309,0,0q�$	��Top=�$��75��$
��Bold"����� *	TempLow+# [    $	 10Q�$
 5Q��� -"   $ vacCurrHigh��$
��High��$
��Left=�$��
309,33,0,0q�$	��Top=�$��75��$
��Bold"����� *VacCurrHigh+# [    $	 10Q�$
 5Q��� -#   $ 
pbCurrHigh��$
��High��$
��Left=�$��
309,58,0,0q�$	��Top=�$��75��$
��Bold"����� *
PbCurrHigh+# [    $	 10Q�$
 5Q��� -$   $ amp1_2CurrHigh��$
��High��$
��Left=�$��
309,83,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp1_2CurrHigh+# [    $	 10Q�$
 5Q��� -%   $ amp3CurrHigh��$
��High��$
��Left=�$��309,108,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp3CurrHigh+# [    $	 10Q�$
 5Q��� -&   $ amp4_1CurrHigh��$
��High��$
��Left=�$��309,133,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_1CurrHigh+# [    $	 10Q�$
 5Q��� -'   $ amp4_2CurrHigh��$
��High��$
��Left=�$��309,158,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_2CurrHigh+# [    $	 10Q�$
 5Q��� -(   $ amp4_3CurrHigh��$
��High��$
��Left=�$��309,183,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_3CurrHigh+# [    $	 10Q�$
 5Q��� -)   $ amp4_4CurrHigh��$
��High��$
��Left=�$��309,208,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_4CurrHigh+# [    $	 10Q�$
 5Q��� -*   $ amp4_5CurrHigh��$
��High��$
��Left=�$��309,233,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_5CurrHigh+# [    $	 10Q�$
 5Q��� -+   $ amp4_6CurrHigh��$
��High��$
��Left=�$��309,258,0,0q�$	��Top=�$��75��$
��Bold"����� *Amp4_6CurrHigh+# [    $	 10Q�$
 5Q��� -,   $ humidityHigh��$
��High��$
��Left=�$��149,284,0,0q�$	��Top=�$��75��$
��Bold"����� *HumidityHigh+# [    $	 10Q�$
 5Q��� --   $ tempHigh��$
��High��$
��Left=�$��149,309,0,0q�$	��Top=�$��75��$
��Bold"����� *
TempHigh+# [    $	 10Q�$
 5Q�