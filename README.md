# Matrix Trace Console Application

## Description

This project is a console application that performs operations on matrices. Users input matrix dimensions, and the program fills the matrix with random numbers (ranging from 0 to 100). The program then calculates the matrix trace, which is the sum of all elements on the main diagonal. Additionally, the program prints the filled matrix to the console with the main diagonal highlighted. For an enhanced task, the program can also print the elements of the matrix in a snail shell order from the border to the center.

## Features

- Users input matrix dimensions (columns and lines).
- The program fills the matrix with random numbers (0 to 100 inclusive).
- The program calculates and prints the matrix trace (sum of main diagonal elements).
- The program prints the filled matrix to the console with the main diagonal highlighted.
- Enhanced task: The program prints the matrix elements in a snail shell order from the border to the center.

### Examples

**Example 1: Matrix Trace**

Input:

4 4

Matrix:

1 2 3 4

8 7 6 5

4 3 2 9

0 1 4 7


Output:

Matrix:

[1] 2 3 4

8 [7] 6 5

4 3 [2] 9

0 1 4 [7]

Trace: 1 + 7 + 2 + 7 = 17


**Example 2: Snail Shell Order**

Input:

4 3

Matrix:

1 2 3

8 7 6

4 3 2

9 5 1


Output:

Snail Shell Order:
1, 2, 3, 6, 2, 1, 5, 9, 4, 8, 7, 3