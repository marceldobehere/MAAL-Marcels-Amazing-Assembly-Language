# MAAL-Marcels-Amazing-Assembly-Language
This tool will compile MAAL into MAALB (Bytecode)

The Bytecode is planned to be run by MaslOS and possibly a windows interpreter.


## Example
```
loc MAIN:
  print "Hello, world!";
  exit;
```


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

