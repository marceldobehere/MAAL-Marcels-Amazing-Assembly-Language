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
you can call syscalls directly by doing
```
syscall (byte)SYSCALL_NUMBER_1 (byte)SYSCALL_NUMBER_2 ARG_1 ARG_2 ARG_N;
```

#### Printing a value to the console
```
print 10;
print x;
```
It will print the variable to the console.
If the datatype is char then it will print the ASCII representation.

print also works with pointers.
```
print "Hello, world!";
```

```
char* test = "Hoi!";
print test;
```


#### malloc
You can allocate some memory by doing:
```
malloc (size in bytes) (address of var to store);
```
Example
```
char* data;
malloc 10 &data;
// this will malloc 10 bytes and set data to the address.
```

#### free
You can free allocated memory by doing:
```
free (address of malloc);
```
Example:
```
char* data;
malloc 20 &data; // will malloc 20 bytes
// ...
free data; // will free the data again
```






### Including other files
You can include files by using
```
#include "FILE_PATH_GOES_HERE"
```
(It will basically copy paste the given file into that area)









