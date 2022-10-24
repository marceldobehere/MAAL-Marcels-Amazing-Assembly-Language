# MAAL DOCS
Here are the Docs to MAAL (Marcels Amazing Assembly Language)


### Datatypes:
*	INT
*	LONG
*	ULONG
*	BYTE
*	CHAR
*	FLOAT
*	DOUBLE
*	BOOL
*	POINTERS (INT*, CHAR*, DOUBLE**, etc.)

You can cast things like this
```
int x = (int)10.0;
int y = (int)(10.0 + x);
```


### Variables
```
(Datatype) (Varname);
```
or
```
(Datatype) (Varname) = (Value);
```


### Operations

#### Math:
*	`+`
*	`-`
*	`*`
*	`/`
*	`%`

#### Comparison:
*	`==`
*	`!=`
*	`>`
*	`<`
*	`>=`
*	`<=`

#### Logic:
*	`&&`
*	`||`
*	`!`

#### Bit Logic:
*	`&`
*	`|`
*	`~`
*	`>>`
*	`<<`

#### Command:
*	`=`
*	`++`
*	`--`
*	`+=`
*	`-=`
*	`*=`
*	`/=`
*	`%=`


Example
```
bool x = (1 != (3 – 1 * 2)); // should be false
```


### Labels / Locations
Locations get defined like this

```
loc NAME:
    ...
```
```
location NAME:
    ...
```

you can jump to those locations



Example
```
loc MAIN:
    int x = 5;
    int y = 10;
    int z = x * y;
exit
```



### Jumping


### Conditionals



### Subroutines
Subroutines get defined like this
```
sub NAME:
    ...
ret;
```
```
sub
    ...
    return;
```

### Direct Memory Manipulation




### Dynamic Memory Stuff





### Systemcalls













