# MAAB DOCS
Here are the Docs to MAAB (Marcels Amazing Assembly Bytecode)

## General Stuff

MAAB is using Big Endian Byte Encoding!

### Instruction Layout
instructions look like this
```
[OPCODE (== 1 BYTE)][ARG1 (>= 1 BYTE)][ARG2 (>= 1 BYTE)]...
```


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
[5][Adress of Size (8 Byts)][Address of Address From (8 Bytes)][Address of Address To (8 Bytes)]
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
















