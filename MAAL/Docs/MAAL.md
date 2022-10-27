# MAAL DOCS
Here are the Docs to MAAL (Marcels Amazing Assembly Language)


### Datatypes:
*	INT
*   UINT
*   SHORT
*   USHORT
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
Jumps somewhere.

Example:
```
jump 0;
```
```
loc TEST:

jump TEST;
```


### Conditionals
Jumps somewhere, if a condition is met.

Example:
```
loc TEST:

if_jump (x == 2) TEST;
```
```
sub TESTSUB:
    ...
ret;


...
if_sub (x == 2) TESTSUB;
...
```


### Subroutines
Subroutines get defined like this
```
sub NAME:
    ...
ret;
```
```
subroutine NAME;
    ...
    return;
```

Example:
```
int x;
sub TEST: // defines Subroutine
    x = 10;
ret;

loc MAIN: // Main Entry
x = 5;
sub TEST; // executes Subroutine
// x should be 10

```


### Direct Memory Manipulation
You can directly manipulate the memory by doing.
```
((ulong)1000) = 100;
```



### Dynamic Memory Stuff
none yet



### Syscalls
none yet


### Including other files
You can include files by using
```
#include "FILE_PATH_GOES_HERE"
```
(It will basically copy paste the given file into that area)









