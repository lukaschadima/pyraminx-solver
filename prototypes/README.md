# Prototypes

Two console programs that came before the WinForms Pyraminx solver in this
repository. Both use the same idea — search the move tree until the puzzle is
solved — and together they show how the approach developed.

## `rubiks-cube-console/`

The first attempt, and the one that started the project: a 3×3×3 Rubik's cube
represented as 8 corner cubies and 12 edge cubies, each with a position index
and an orientation. All 18 face turns are implemented as permutations of that
array. The search is a plain depth-first search capped at depth 7, with pruning
that rejects two turns of the same face in a row and turns of two opposite
faces in the wrong order.

Depth 7 is where this approach stops being useful. A 3×3×3 cube needs up to 20
moves, and the tree grows by roughly a factor of 13 per level even after
pruning, so anything past a shallow scramble is out of reach. Finding that out
is what led to picking the Pyraminx instead — a puzzle small enough that
exhaustive search actually finishes.

Note the folder name doesn't match the code: the project is called
`Rubic 2x2x2` because that's what I set out to write, but the implementation is
the full 3×3×3.

**FIX:** `IsSolved()` originally checked corners and edges in one loop running
to 8, so edges 8–11 were never tested and the solver could report a scrambled
cube as solved. Split into two loops, marked in the source.

## `pyraminx-console/`

The same machinery applied to a Pyraminx, and a better search: proper iterative
deepening (depth 1, then 2, and so on) rather than a fixed cutoff, so the first
solution found is guaranteed to be the shortest. A Pyraminx is modelled as 8
tips/corners that only have an orientation and 12 half-edges that only have a
position — much smaller than a cube, and small enough that this terminates.

This is the version whose logic was carried over into the WinForms application
in the repository root.

## Running

Both are .NET Framework console projects. The scramble is set by the sequence
of move calls at the top of `Main` — edit those to try a different one.
