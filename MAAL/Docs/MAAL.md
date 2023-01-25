# MAAL DOCS
Here are the Docs to MAAL (Marcels Amazing Assembly Language)


### Datatypes:
*	INT
*   UINT
*   SHORT
*   USHORT
*	LONG
*	ULONG
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

### Value suffixes
Since implicit type casting is not really a thing in MAAL, you can use the value suffixes to tell the compiler the datatype of the value without casting it.
Here is a short table covering all suffixes:

| Datatype | Suffix | Example |
|----------|--------|---------|
| INT      | i      | 5i      |
| UINT     | ui     | 2ui     |
| SHORT    | s      | 28s     |
| USHORT   | us     | 256us   |
| LONG     | l      | 125l    |
| ULONG    | ul     | 12345ul |
| CHAR     | c      | 65c     |
| FLOAT    | f      | 10f     |
| DOUBLE   | d      | 2.4d    |



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


#### if
Executes code if a condition is met.
```
int x = 5;
if (x == 10)
{
    print "TEN";
}
if (x == 5)
{
    print "FIVE";
}

// will print FIVE.

```


#### while
Repeats code while a condition is met.
```
int x = 0;
while (x < 10)
{
    x++;
}
print x; // will print 10.
```



#### if_jump
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
There are some syscalls related to dynamic memory.
(Mainly malloc and free)


### Namespaces
You can define namespaces like this:
```
namespace NAME
{
    ...
    ...
}
```
If you want to refer to Variables/Locations/Subroutines/... inside the namespace you can use \:\:.
```
int x;

namespace TEST
{
    int x;
}


x = 10;
TEST::x = 20;

```
If you want to refer to Variables/etc which are outside the current namespace you can use GLOBAL\:\:.
```
int x;

namespace TEST
{
    int x;

    sub SET_VARS:
        x = 5; // x in TEST
        GLOBAL::x = 10; // global x
        GLOBAL::TEST::x = 20; // still x in TEST
        ret;_
}

x = 100; // global x
TEST::x = 5; // x in TEST

sub TEST::SET_VARS; 
// will set the global x to 10 and 
// the x in TEST to 5 and then to 20.
```




### MaslOS Window API
you can work with the Window API of MaslOS.
Some quick infos.

Windows have IDs and attributes, which can be read and set.

There are several commands to interact with the Window API.
Also the Window and GUI Api don't work in the CPP-Interpreter. (Atleast not for now)

#### Creating a Window
You can create a window with a given Id by using
```
createWindow winID;
```

I would suggest using random IDs instead of fixed ones like this:
```
long winID;
ulong randomUlong;

getRandomUlong &randomUlong; // get random value into ulong
winID = (long)randomUlong; // get random window id

createWindow winID;
```

#### Deleting a Window
You can delete a window given it's ID like this:
```
deleteWindow winID;
```

#### Setting A Window Attribute
You can set an Attribute of a Window by using the Window ID and the Attribute index and the value.
```
setWindowAttr winID 60 "This is a Title!"; // set title
setWindowAttr winID 20 200;                // set width to 200px
```
If you are wondering where to get the numbers from, you can look at the Window Attribute table [here](https://github.com/marceldobehere/MaslOS/wiki/Window-Attribute-Table).


#### Getting A Window Attribute
You can get an Attribute of a Window by using the Window ID and the Attribute index.
```
uint tempSize;
getWindowAttr 123 20 &tempSize; // Gets window width
print "Winddow Size X: ";
print tempSize;
print "\n";
```










### MaslOS Window GUI API
you can work with the Window GUI API of MaslOS.
The most important tool will be [the GUI Component/Attribute table](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table).


#### Create a Component
You can create a component in a gui window like this:
```
createComponentWithId winID componentID componentType; // Creates a Button
```
The component type table can be found [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#component-type-table).


#### Delete a Component
You can delete a component in a gui window like this:
```
deleteComponentWithId winID componentID deleteChildren;
```




#### Set the base component attribute of a Component
You can set the base attribute of any component.
Every component has the same base attributes but unique specific attributes.
You can see the Base Component Atttribute Table [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#base-component-attributes).


```
setBaseComponentAttr winID componentID baseAttributeID value;
```

Example with the width
```
setBaseComponentAttr winID componentID 20 500; set fixed width 500px
```

#### Get the base component attribute of a Component

You can get the base attribute of any component.

Example:
```
int tempWidth = 5d;
getBaseComponentAttr winID componentID 20 &tempWidth; 
print "Size X: ";
print tempWidth;
print "\n";
```

#### Set the specific component attribute of a Component
You can set the specific component attributes of  a component.
Each component type has their own specific attribute set:
You can find the unique sets in the tables [here](https://github.com/marceldobehere/MaslOS/wiki/Gui-Component-Attribute-Table#tables).

Base
```
setSpecificComponentAttr winID componentID specificAttributeID value;
```

Example:
```
specificAttributeID
setSpecificComponentAttr winID componentID 20 "Hi";
```

#### Get the specific component attribute of a Component
You can also get the specific component attributes.

Base
```
getSpecificComponentAttr winID componentID specificAttributeID addressOfResult;
```
Example:
```
getSpecificComponentAttr winID componentID 42 &text1ID; // get Id of text from button
```






#### Setting The Active Screen of a Window (do not use rn pls)
You can set the active screen component of a gui window.
```
windowSetActiveScreen winID screenComponentID; // sets the active screen component
```


#### Getting The Active Screen of a Window
You can get the active screen component index of a gui window.
```
long screenComponentID;
windowGetActiveScreen winID &screenComponentID; // gets the active screen component id
```




### Other GUI Infos

#### Scaled vs Fixed Size
As you might have been able to see a component has a fixed and a scaled size.

You can set the Is...Fixed attribute to true if you want to use pixels.
You can set it to False if you want to use a percentage of the parent component.

So for Example
```
setBaseComponentAttr winID compID 24 true; // x fixed
setBaseComponentAttr winID compID 25 true; // y fixed

setBaseComponentAttr winID compID 20 50; // width  50px
setBaseComponentAttr winID compID 21 30; // height 25px

// This will set the component to have a fixed size of 50x25px
```

OR

```
setBaseComponentAttr winID compID 24 true; // x fixed
setBaseComponentAttr winID compID 25 false; // y fixed

setBaseComponentAttr winID compID 20 50; // width  50px
setBaseComponentAttr winID compID 23 0.5d; // height 40% of parent

// This will set the component to have a size where the width is 50px and the height is 40% of the parent height.
```




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

#### Reading a line as input
You can force the user to input a line and get the input.
```
readline (Address of Variable to store the input in);
```


Example:
```
char* input;

print "Enter Name: ";
readline &input;

print "\n\nHello ";
print input;
print "!";
```

#### Changing the text colour
You can set the Foreground (FG) or the Background (BG) colour using the color command.
It will take FG/BG and the color as an 32 bit integer. (Feel free to write it in decimal or hex)
The Colour Format is 0xAARRGGBB;
```
color FG 0xFF00FF00; // set foreground to green
```

#### Clearing the Console Screen
You can clear the console using the cls command.
```
cls;
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


#### sleep
You can sleep for a specific amount of time (in ms).

Example:
```
print "Hello, ";
sleep 2000; // This will sleep for 2 seconds
print "World!";
```

#### random ulong
You can get a random ulong.

Example:
```
ulong randomUlong;
getRandomUlong &randomUlong; // This will set the content of randomUlong to a random ulong.
```

#### random double
You can also get random doubles.

Example:
```
double randomDouble;
getRandomDouble &randomDouble; // This will set the content of randomDouble to a random double from 0 to 1.
```

#### getting the keyboard state
You can get the keyboard state by using the getKeyboardState function:
It takes the scancode which you can find [here](https://wiki.osdev.org/PS/2_Keyboard#Scan_Code_Set_1).
```
bool pressed;
getKeyboardState 0x1F &pressed; // Will set pressed to true, if the S key has been pressed.
```


#### getting the mouse state
You can get the mouse state by using the getMouseState function:
It takes the mouse argument and either sets the result var to an int or bool.

Here is the argument table:

| Mouse State Index | Description      | Output Type |
|-------------------|------------------|-------------|
| 0                 | Button 1 pressed (left) | bool        |
| 1                 | Button 2 pressed (right) | bool        |
| 2                 | Button 3 pressed (middle) | bool        |
| 3                 | Mouse X          | int         |
| 4                 | Mouse Y          | int         |

```
getMouseState index resultAddress;
```



Example:
```
bool pressed;
getMouseState 0 &pressed; // Will set pressed to true, if the left mouse button is pressed.
```

```
int mouseX;
getMouseState 3 &mouseX; // Will set mouseX to the Mouse X-Position.
```






### Including other files
You can include files by using
```
#include "FILE_PATH_GOES_HERE"
```
(It will basically copy paste the given file into that area)









