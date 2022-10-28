# MAAB DOCS
Here are the Docs to MAAB (Marcels Amazing Assembly Bytecode)

## General Stuff

MAAB is using Big Endian Byte Encoding!

### Instruction Layout
instructions look like this
```
[OPCODE (== 1 BYTE)][ARG1 (>= 1 BYTE)][ARG2 (>= 1 BYTE)]...
```

### Datatypes and their numbers
| Type     | Number | Size |
|----------|--------|------|
|int       |       0|     4|
|uint      |       1|     4|
|short     |       2|     2|
|ushort    |       3|     2|
|long      |       4|     8|
|ulong     |       5|     8|
|char      |       6|     1|
|bool      |       7|     1|
|float     |       8|     4|
|double    |       9|     8|



## Instructions

### nop
does nothing
```
[0]
```

### exit
the instruction for exiting a program is
```
[1]
```

### Direct Memory Manipulation

#### Set a fixed memory address to a fixed value
```
[2][Size of Value in bytes (1 Byte)][Address (8 Bytes)][Fixed Value (x Bytes)]
```
Example
```
[2][0x01][0x00.00.00.00.00.00.00.01][0xFF]
// will set the byte at address 1 to 255
```


#### Copy data from a fixed memory address to another fixed memory address
```
[3][Size of Value in bytes (1 Byte)][Address From (8 Bytes)][Address To (8 Bytes)]
```


### Math and Operations

```
[10][Operation number (1 Byte)][Datatype number of Operands (1 Byte)]
[Operand 1 (x Bytes)]
[Operand 2 (x Bytes)]
[Operand n (x Bytes)]
[Addr of return value (8 Bytes)]
```

#### List of Operators with their numbers:
| Operator | Number | Argument Count | Constraints |
|----------|--------|----------------|-------------|
|`+`      |       0|               2|             |
|`-`      |       1|               2|             |
|`*`      |       2|               2|             |
|`/`      |       3|               2|             |
|`%`      |       4|               2|             |
|`==`     |       5|               2|             |
|`!=`     |       6|               2|             |
|`>`      |       7|               2|             |
|`>=`     |       8|               2|             |
|`<`      |       9|               2|             |
|`<=`     |      10|               2|             |
|`&&`     |      11|               2|Only works with bools|
|`||`     |      12|               2|Only works with bools|
|`!`      |      13|               1|Only works with bools|
|`&`      |      14|               2|             |
|`|`      |      15|               2|             |
|`~`      |      16|               1|             |
|`<<`     |      17|               2|             |
|`>>`     |      18|               2|             |


Implementing all those like 1,6k unique choices will be a pain but yes

Example
```
[2][0x01][0x00.00.00.00.00.00.00.0A][0x00]
// This will set the byte at address 12 to 0 
// This will be where out result will be

[10] // OPCODE for Operation
[0x00] // Number of PLUS Operation
[0x06] // Number of CHAR Datatype (We are using bytes/chars)
[0x05] // Operand 1
[0x0A] // Operand 2
[0x00.00.00.00.00.00.00.0A] // Result

// will write the result of 5 + 10 into
// the address located at result

```



### Casting Datatypes
```
[15]
[Datatype number of input (1 Byte)]
[Datatype number of output (1 Byte)]
[Addr of input (8 Bytes)]
[Addr of output (8 Bytes)]
```
It will read the input as the given datatype 
then cast it into the second datatype and 
save the casted version into the given address.


```
[16]
[Datatype number of input (1 Byte)]
[Datatype number of output (1 Byte)]
[input (x Bytes)]
[Addr of output (8 Bytes)]
```




### Jumping
Jumps to an address in the RAM (also where the code resides yes).
```
[20][Address to jump to (8 Bytes)]
```


### Subroutines
Subroutines are like jumps, but when the subroutine finishes, 
it goes back to the piece of code where it jumped.


#### Entering a subroutine
```
[25][Address of subroutine(8 Bytes)]
```

#### Returning from a subroutine
You can return from a subroutine using the return command.
```
[30]
```


### Conditional Jumps

```
[40]
[bool condition result (1 Byte)]
[Address to jump to (8 Bytes)]
```


### Conditional Subroutines
```
[45]
[bool condition result (1 Byte)]
[Address of Subroutine (8 Bytes)]
```


### Syscalls
Syscalls are yes.
```
[50]
[Syscall Number (2 Bytes)]
[Argument 1 (x Bytes)]
[Argument 2 (y Bytes)]
[Argument n (z Bytes)]
```

#### Console
There are many syscalls connected to the console.
The first byte of the syscall is 0x01.


##### Printing a char
```
[50]
[0x01.01] // Sycall for Console and Print Char
[Byte to print (1 Byte)]
```

##### Printing values
```
[50]
[0x01.02] // Sycall for Console and Print Value
[Datatype of data (1 Byte)]
[Data to print (x Bytes)]
```

##### Printing a string
```
[50]
[0x01.03] // Sycall for Console and Print String
[Address of string (8 Bytes)]
```



#### malloc


#### free



#### Syscall Table
This is the table

|First Byte|Last Byte|Decimal Form|Description|
|----------|---------|------------|-----------|
|0x01      |0x01     |257         |Print a char to the console|
|0x01      |0x02     |258         |Print a value to the console|
|0x01      |0x03     |259         |Print a string to the console|
























