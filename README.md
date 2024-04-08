# Cookie Cookbook Challenge Project

## Contents
1. [Problem](#problem)
2. [Solution](#solution)
3. [How To Use The App](#how-to-use-the-app)
4. [What I Learned](#what-i-learned)
5. [Tech Stack](#tech-stack)
6. [How To Run Locally](#how-to-run-locally)

## Problem

As a major part of my journey in learning C#, I have been following Krystyna Ślusarczyk's excellent Ultimate C# Masterclass for 2024.  Module 4 is about object oriented programming: Polymorphism, Inheritance, Interfaces.  At the end of the module is a challenge project, which is to create a Cookie Cookbook.  An overview of the brief is:
- "This application lets the user create and save cookie recipes. The user can select the ingredients that will be included in the recipe from a list. The recipe is then saved to a text file along with recipes that have been created before. The text file might be either in a *.txt or a *.json format, depending on the setting defined in a program."

There is then a series of more detailed requirements given.  Very few guidelines are given on how to go about it - it is left almost entirely up to the student.

My specfic objectives in this challenge were to:
- implement clean code, using the object orientation, polymorphism, interface and inheritance principles taught in the module
- implement using SOLID principles
- implement low coupling and high cohesion

## Solution

The solution is a console application in C#.

The solution is implemented using an object oriented approach.  There are 4 classes for cookbook-related items:
- Ingredient: holds the details of a single ingredient
- Ingredients: holds a collection of Ingredient objects as a reference for available ingredients
- Recipe: holds a collection of Ingredient objects to represent a specific recipe
- Recipes: holds a collection of Recipe objects as a repository of all recipes

There are then some classes for reading recipe data from and writing it to a file:
- an abstract base class RecipeStore which defines abstract Read and Write format method signatures
- the RecipeStore base class also takes a StringTextualRepository object in the constructor, which handles the physical read from and writing to the file
- a RecipeStoreJson class which inherits from RecipeStore and implements the Read and Write format methods for a JSON file store
- a RecipeStoreText class which inherits from RecipeStore and implements the Read and Write format methods for a plain text file store

it took a number of iterations to arrive at this design (which are discussed in the "What I Learned" section below, but this solution successfully implements:
- SOLID design principles:
  - a single responsibility for all classes (Single Respnsibility Principle)
  - the RecipeStore abstract class allows for other formatters to be created without modification to the existing classes, implementing the open/closed principle
  - the RecipeStoreJson and RecipeStoreText objects substitute for the RecipeStore object, depending on which is configured.  This implements the Liskov substitution principle
  - the RecipeStore class takes a repository object in the constructor, implementing the dependency inversion principle
  - there was no need to implement the interface segregation principle, since there are no specific Interfaces and the class interfaces are simple
- the RecipeStoreJson and RecipeStoreText objects inherit from and implement abstract methods, implementing polymorphism
- the classes/objects are loosely coupled and have high cohesion:
  - generally classes do not rely on implementation details of other classes
  - although they are stores of other class objects, the Ingredients, Recipe and Recipes classes do not rely on knowledge of internal methods of the objects that they store, giving low coupling
  - one exception to this is in Recipe class, where is it depending on knowledge that the passed Ingredients class can access an Ingredient object by Id.  I think this represents a low degree of coupling but it is something that could be improved.

[Back to top](#tic-tac-toe-machine-learning-project)

## How To Use The App

The app is extremely simple to use. You play first (you are playing X).  Click on a square and the computer will respond with a move. As in a standard tic tac toe game, the game is over when either player scores 3 in a row or all the squares are filled.

Try to beat the computer.  It is surprisingly difficult: the rules of tic-tac-toe generally mean that you can only win if your opponent makes a mistake and the computer is not too prone to careless moves like us humans!

[Back to top](#tic-tac-toe-machine-learning-project)

## What I Learned

This has been an excellent project for starting to explore machine learning.  The mechanics of the algorithms are relatively simple, but the concepts behind them are profound.

I also reinforced my learning from the higher-or-lower app to re-render only the square clicked on and the square completed in response.  This mechanism is working well and I think it will become my standard approach.

[Back to top](#tic-tac-toe-machine-learning-project)

## Tech Stack

React, Javascript, vitest

## How To Run Locally

Clone the project

```bash
  git clone https://github.com/Dug-F/ExploreSolarSystemTs.git
```

Go to the project directory

```bash
  cd explore-solar-system-ts
```

Install dependencies

```bash
  npm install
```

Start the server

```bash
  npm run dev
```

Click on the link shown to invoke the app in your browser

<hr>

[Back to top](#tic-tac-toe-machine-learning-project)
