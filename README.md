I recently participated in my first programming meetup. We where given the simple task of implementing [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life).
I had previously avoided this, not because i found the program logic challenging but because i find any form of graphics challenging (including console applications), so this was a good opportunity to leave my comfort zone.

The program takes up to four flags:
* -s for source, the inital world state.
* -w for width
* -h for height
* -f for fixed size

If -s is absent the initial world is seeded with a random value (-w and -h are obligatory for a random world).
> Example:
> gameOfLife -w 50 -h 50

The program has a few preprogramed sample automatons. The currently available ones are 'glider' and 'pulsar'.
The source flag takes their name as argument:
> Example:
>gameOfLife -s glider

Finally the source flag can be given a string representation of a world with the following syntax:
"#..X|X.X|.XX" produces a glider. The string must start with a '#', the 'X' stands for a living cell and '.' for a dead one, and the '|' stands for newline. Each row must have the same length.
> Example:
> gameOfLife -s "#..X|X.X|.XX"

-w and -h are the size parameters.
They are required for random worlds but otherwise only have an effect if the -f flag is set.
If the -f flag has been set then they act as the max size.
> Example:
> gameOfLife -s glider -w 20 -h 20 -f

If the -f flag is absent the world will grow indefinitely (assuming the automatons in the world move in a direction) otherwise the world wraps around like a torus.
