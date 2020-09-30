### How to Use

Type to CMD or Batch

> L4D2_AutoBhop_New.exe PlayerBase mFlag
  
Example :
> L4D2_AutoBhop_New.exe 0x7094D8 0xF0



if want Add more player Flags

Edit [[PlayerCs](https://github.com/KnifeLemon/Left4Dead2-Autobhop-CSharp/blob/f0a834fe99e54d9733609de79e7bd70d131a5d9c/L4D2_AutoBhop_New/Player.cs#L32, "Player.cs") -> 32 Line]
<pre>
<code>
  - 129 : Stand Ground
  - 131 : Duck Ground
  return flag == 129 || flag == 131;
</code>
</pre>
