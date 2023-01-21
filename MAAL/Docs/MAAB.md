# MAAB DOCS
Here are the Docs to MAAB (Marcels Amazing Assembly Bytecode)

## General Stuff

MAAB is using Little Endian Byte Encoding!

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
|`\|\|`   |      12|               2|Only works with bools|
|`!`      |      13|               1|Only works with bools|
|`&`      |      14|               2|             |
|`\|`    |      15|               2|             |
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

##### Reading a string
```
[50]
[0x01.04] // Sycall for Console and Readline
[Address of Pointer (8 Bytes)]
```

##### Setting the foreground colour
```
[50]
[0x01.05] // Sycall for Console and set foreground
[32 bit color value in AARRGGBB format (4 Bytes)]
```

##### Setting the background colour
```
[50]
[0x01.06] // Sycall for Console and set background
[32 bit color value in AARRGGBB format (4 Bytes)]
```

##### Clearing the Console
```
[50]
[0x01.07] // Sycall for Console and Cls
```

##### Sleep
```
[50]
[0x01.08] // Sycall for Console and Sleep
[Duration in MS (4 Bytes)]
```



#### Memory
There are some syscalls connected to dynamic memory.
The first byte of the syscall is 0x02.


##### Malloc
This is will alloc some bytes.
```
[50]
[0x02.01] // Sycall for Memory and Alloc
[Size in bytes (4 Bytes)]
[Address to save Address to (8 Bytes)]
```


##### Free
```
[50]
[0x02.02] // Sycall for Memory and Free
[Address to free (8 Bytes)]
```


#### Window API
There are some syscalls connected to the MaslOS Window API.
The first byte of the syscall is 0x03.


##### Create Window
```
[50]
[0x03.01] // Sycall for Window and Create Window
[Window ID (8 Bytes)]
```

##### Delete Window
```
[50]
[0x03.02] // Sycall for Window and Delete Window
[Window ID (8 Bytes)]
```

##### Set Window Attribute
Sets the attribute of a window.
You can check out the [Window Attribute Table here](https://github.com/marceldobehere/MaslOS/wiki/Window-Attribute-Table).
```
[50]
[0x03.03] // Sycall for Window and Set Window Attribute
[Window ID (8 Bytes)]
[Attribute Number (4 Bytes)]
[Value (8 Bytes)] // The value will have to be fit into those 8 bytes and the interpreter will extract the needed value
```

##### Get Window Attribute
Gets the attribute of a window into a memory location.
You can check out the [Window Attribute Table here](https://github.com/marceldobehere/MaslOS/wiki/Window-Attribute-Table).
```
[50]
[0x03.04] // Sycall for Window and Set Window Attribute
[Window ID (8 Bytes)]
[Attribute Number (4 Bytes)]
[Adress of result (8 Bytes)] // The size of the data being written to the address will vary depending on the attribute type.
```



##### Set Window Active Screen
Sets the attribute of a window.
You can check out the [Window Attribute Table here](https://github.com/marceldobehere/MaslOS/wiki/Window-Attribute-Table).
```
[50]
[0x03.03] // Sycall for Window and Set Window Attribute
[Window ID (8 Bytes)]
[Attribute Number (4 Bytes)]
[Value (8 Bytes)] // The value will have to be fit into those 8 bytes and the interpreter will extract the needed value
```



#### GUI API
There are some syscalls connected to the MaslOS Window GUI API.
The first byte of the syscall is 0x04.

##### Create Component
Creates a Component with an ID in a window with a type. The types can be seen [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#component-type-table).
```
[50]
[0x04.01] // Sycall for GUI and Create Component
[Window ID (8 Bytes)]
[Component ID (8 Bytes)]
[Component Type (4 Bytes)]
```

##### Delete Component
```
[50]
[0x04.02] // Sycall for GUI and Delete Component
[Window ID (8 Bytes)]
[Component ID (8 Bytes)]
[Delete Children (1 Bytes)]
```

##### Set Base Component Attribute
Sets a Base Attribute of a Component with an ID in a window to a value. The Base Component Attribute Types can be seen here [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#base-component-attributes).
```
[50]
[0x04.03] // Sycall for GUI and set base comp attr
[Window ID (8 Bytes)]
[Component ID (8 Bytes)]
[Base Attr Type (4 Bytes)]
[Value (8 Bytes)] // The value will have to be fit into those 8 bytes and the interpreter will extract the needed value
```


##### Get Base Component Attribute
Gets a Base Attribute of a Component with an ID in a window into an address. The Base Component Attribute Types can be seen here [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#base-component-attributes).
```
[50]
[0x04.04] // Sycall for GUI and get base comp attr
[Window ID (8 Bytes)]
[Component ID (8 Bytes)]
[Base Attr Type (4 Bytes)]
[Adress of result (8 Bytes)] // The size of the data being written to the address will vary depending on the attribute type.
```



##### Set Specific Component Attribute
Sets a Specific Attribute of a Component with an ID in a window to a value. The Specific Component Attribute Types can be seen starting from here [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#box-component).
```
[50]
[0x04.05] // Sycall for GUI and set spec comp attr
[Window ID (8 Bytes)]
[Component ID (8 Bytes)]
[Base Attr Type (4 Bytes)]
[Value (8 Bytes)] // The value will have to be fit into those 8 bytes and the interpreter will extract the needed value
```


##### Get Specific Component Attribute
Gets a Specific Attribute of a Component with an ID in a window into an address. The Specific Component Attribute Types can be seen starting from here [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#box-component).
```
[50]
[0x04.06] // Sycall for GUI and get spec comp attr
[Window ID (8 Bytes)]
[Component ID (8 Bytes)]
[Base Attr Type (4 Bytes)]
[Adress of result (8 Bytes)] // The size of the data being written to the address will vary depending on the attribute type.
```








#### Syscall Table
This is the table

|First Byte|Last Byte|Decimal Form|Description|
|----------|---------|------------|-----------|
|0x01      |0x01     |257         |Print a char to the console|
|0x01      |0x02     |258         |Print a value to the console|
|0x01      |0x03     |259         |Print a string to the console|
|0x01      |0x04     |260         |Read a string from the console|
|0x01      |0x05     |261         |Set Foreground Console Colour|
|0x01      |0x06     |262         |Set Background Console Colour|
|0x01      |0x07     |263         |Clear Console|
|0x01      |0x08     |264         |Sleep|
|0x02      |0x01     |513         |Malloc     |
|0x02      |0x02     |514         |Free       |
|0x03      |0x01     |769         |Create Window     |
|0x03      |0x02     |770         |Delete Window     |
|0x03      |0x03     |771         |Set Window Attr|
|0x03      |0x04     |772         |Get Window Attr|
|0x03      |0x05     |771         |Set Window Scr|
|0x03      |0x06     |772         |Get Window Scr|
|0x04      |0x01     |1025        |Create Comp     |
|0x04      |0x02     |1026        |Delete Comp     |
|0x04      |0x03     |1027        |Set Base Comp Attr|
|0x04      |0x04     |1028        |Get Base Comp Attr|
|0x04      |0x05     |1028        |Set Spec Comp Attr|
|0x04      |0x06     |1029        |Get Spec Comp Attr|



























