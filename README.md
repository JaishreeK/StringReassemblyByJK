# StringReassemblyByJK

Design Brief
Problem statement:
Write a program that reads a file of text fragments and attempts to reconstruct the original document out of the fragments. The fragments were created by duplicating the original document many times over and chopping each copy into pieces. The fragments overlap one another and your program will search for overlaps and align the fragments to reassemble them into their original order.

Solution Approach:
Greedy Match and Merge
	This program works on the greedy match and merge approach.
It tries to find the number of overlaps between first two strings by counting the common characters by iterating the two strings from both ways. This way, the rest of the strings from the set are processed to find the best overlap and then merging is done. 

Specifications:
Built using Visual studio 2017 With Resharper Ultimate
Framework:  .Net Standard 1.4
Structure of the solution:
StringReassembly.cs – Main class library file containing all methods to check the overlap and merge the strings.
StringReassemblyTest.cs – Unit test file containing 7 different tests to test the methods from StringReassembly class library

Methods Brief:
1.	AssembleStrings Method: This method is the main method which can be called from outside and takes a string array as an input parameter, it calls the BestOverlap method Combination to find the overlap and combine the strings from the input string Array.
2.	FindOverlaps Method: Finds the best overlap by traversing the 2 input strings in both ways.

Testing:
•	Testing is done using list of strings as Input.
•	Test methods are implemented for testing AssembleStrings method only.

