# room-descriptor
Language for describing the layout of desks in an office room

## Example
A room consisting of 6x5 squares where the desks are arranged in a 2x2 configuration:

b6/5 d1..2 s1 d3..4 sX d5..6 s1 d7..8

## Commands

`1` here represents any number.

### Boundary
Token: `b`

Defines the boundary/size of the room.

Syntax:
- `b1`: defines the width, height is equal to width
- `b1/1`: defines the width and the height

### Desk
Token: `d`

Defines a desk.

Syntax: 
- `d1`: defines a desk with an index
- `d1..1`: defines an array of desks, both inclusive, e.g. `d1..3` is the same as `d1 d2 d3`
- `d1s1`: defines a single desk with an offset. The distance the desk is shifted by is not defined (but usually half a space). Offset indices are:
	- 0: none
	- 1: up
	- 2: right
	- 3: down
	- 4: left
- `d1..1s1`: array of desks, the array itself is shifted

### Skip
Token: `s`

Defines an empty space.

Syntax:
- `s1`: defines a skip with a length
- `sX`: defines a skip that spans the entire width.