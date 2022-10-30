# MAAL-Marcels-Amazing-Assembly-Language
This tool compiles MAAL into MAALB (Bytecode)

The Bytecode can be interpreted in [Masl OS](https://github.com/marceldobehere/MaslOS).
It also has a [Windows Interpreter](https://github.com/marceldobehere/MAAB-CPP-Interpreter).


## Example
```
loc MAIN:
  print "Hello, world!";
  exit;
```

[More Examples can be found here](https://github.com/marceldobehere/MAAL-Marcels-Amazing-Assembly-Language/tree/master/MAAL/Examples)


## Documentation


[Docs for MAAL](MAAL/Docs/MAAL.md)


[Docs for MAAB](MAAL/Docs/MAAB.md)




## Windows C++ Interpreter

https://github.com/marceldobehere/MAAB-CPP-Interpreter



### EXE Arguments

```
[EXE PATH] [FILE PATH] (-yes_debug_out) (-yes_time_out)
```

#### Yes Debug out
This flag will show debug infos like the parsed tokens and bytes


#### Yes Time out
This flag will show timer stats.

