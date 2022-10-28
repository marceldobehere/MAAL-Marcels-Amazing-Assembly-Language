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




## Windows C++ Interpreter (WIP)

https://github.com/marceldobehere/MAAB-CPP-Interpreter



### EXE Arguments

```
[EXE PATH] [FILE PATH] (-no_debug_out) (-no_time_out)
```

#### No Debug out
This flag will not show debug infos like the parsed tokens and bytes


#### No Time out
This flag will not show timer infos.

