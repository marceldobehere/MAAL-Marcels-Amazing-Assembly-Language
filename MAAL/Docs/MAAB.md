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

#### Copy fixed data from variable memory address to another variable memory address
```
[4][Size of Value in bytes (1 Byte)][Address of Address From (8 Bytes)][Address of Address To (8 Bytes)]
```
Example
```
[2][0x01][0x00.00.00.00.00.00.00.01][0x0F]
// will set the byte at address 1 to 15

[2][0x01][0x00.00.00.00.00.00.00.02][0xFF]
// will set the byte at address 2 to 255

[2][0x01][0x00.00.00.00.00.00.00.0F][0x20]
// will set the byte at address 15 to 32

[4][0x01][0x00.00.00.00.00.00.00.01][0x00.00.00.00.00.00.00.02]
// This will copy 1 byte from the address located at 1 
// to the adress located at 2
// The adress located at 1 is 15   (FROM)
// The address located at 2 is 255 (TO)
// The byte located at 15 is 32    (DATA)
// Meaning it will copy 1 byte (the value 32) from 15 to 255
```


#### Copy variable data from variable memory address to another variable memory address
```
[5][Adress of Size (8 Bytes)][Address of Address From (8 Bytes)][Address of Address To (8 Bytes)]
```
Example
```
[2][0x01][0x00.00.00.00.00.00.00.01][0x0F]
// will set the byte at address 1 to 15

[2][0x01][0x00.00.00.00.00.00.00.02][0xFF]
// will set the byte at address 2 to 255

[2][0x01][0x00.00.00.00.00.00.00.0F][0x20]
// will set the byte at address 15 to 32

[2][0x01][0x00.00.00.00.00.00.00.03][0x01]
// will set the byte at address 3 to 1

[5][0x00.00.00.00.00.00.00.03][0x00.00.00.00.00.00.00.01][0x00.00.00.00.00.00.00.02]
// This will copy 1 byte (Amount of bytes gets read from the value at address 3)
// from the address located at 1 
// to the adress located at 2
// The adress located at 1 is 15   (FROM)
// The address located at 2 is 255 (TO)
// The byte located at 15 is 32    (DATA)
// Meaning it will copy 1 byte (the value 32) from 15 to 255
```


### Math and Operations

```
[10][Operation number (1 Byte)][Datatype number of Operand 1 (1 Byte)][Operand 1 (x Bytes)][Datatype number of Operand 2 (1 Byte)][Operand 2 (y Bytes)]
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



#### `+`
a

### Casting Datatypes
Death 2 - Electric Boogaloo

### Jumping


### Subroutines

#### Entering a subroutine



#### Returning from a subroutine



### Conditional Jumps


### Conditional Subroutines


### Syscalls


#### Console


##### Printing a char




#### malloc


#### free
















