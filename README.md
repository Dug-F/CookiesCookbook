# Cookie Cookbook Challenge Project

## Contents
1. [Problem](#problem)
2. [Solution](#solution)
3. [How To Use The App](#how-to-use-the-app)
4. [What I Learned](#what-i-learned)
5. [Tech Stack](#tech-stack)
6. [How To Run Locally](#how-to-run-locally)

<hr>

## Problem

As a major part of my journey in learning C#, I have been following Krystyna Ślusarczyk's excellent Ultimate C# Masterclass for 2024.  Module 4 is about object oriented programming: Polymorphism, Inheritance, Interfaces.  At the end of the module is a challenge project, which is to create a Cookie Cookbook.  An overview of the brief is:
- "This application lets the user create and save cookie recipes. The user can select the ingredients that will be included in the recipe from a list. The recipe is then saved to a text file along with recipes that have been created before. The text file might be either in a *.txt or a *.json format, depending on the setting defined in a program."

There is then a series of more detailed requirements given.  Very few guidelines are given on how to go about it - it is left almost entirely up to the student.

My specfic objectives in this challenge were to:
- implement clean code, using the object orientation, polymorphism, interface and inheritance principles taught in the module
- implement using SOLID principles
- implement low coupling and high cohesion

<hr>

## Solution

The solution is a console application in C#.

Here is a screenshot:

<img src="/CookieCookbook.PNG" alt="Cookie Cookbook screenshot" width="500"/>

The solution is implemented using an object oriented approach.  There are 4 classes for cookbook-related items:
- Ingredient: holds the details of a single ingredient
- Ingredients: holds a collection of Ingredient objects as a reference for available ingredients
- Recipe: holds a collection of Ingredient objects to represent a specific recipe
- Recipes: holds a collection of Recipe objects as a repository of all recipes

There are then some classes for reading recipe data from and writing it to a file:
- an abstract base class RecipeStore which defines abstract Read and Write format method signatures
- the RecipeStore base class also takes a StringTextualRepository object in the constructor, which handles the physical reading from and writing to the file
- a RecipeStoreJson class which inherits from RecipeStore and implements the Read and Write format methods for a JSON file store
- a RecipeStoreText class which inherits from RecipeStore and implements the Read and Write format methods for a plain text file store

It took a number of iterations to arrive at this design (which are discussed in the "What I Learned" section below), but this solution successfully implements:
- SOLID design principles:
  - a single responsibility for all classes (Single Respnsibility Principle)
  - the RecipeStore abstract class allows for other formatters to be created without modification to the existing classes, implementing the open/closed principle
  - the RecipeStoreJson and RecipeStoreText objects substitute for the RecipeStore object, depending on which is configured.  This implements the Liskov substitution principle
  - the RecipeStore class takes a repository object in the constructor, implementing the dependency inversion principle
  - there was no need to implement the interface segregation principle, since there are no specific Interfaces and the class interfaces are simple
- RecipeStoreJson and RecipeStoreText objects that inherit from and implement abstract methods, implementing polymorphism
- classes/objects that are loosely coupled and have high cohesion:
  - generally classes do not rely on knowledge of methods or properties of other classes
  - although they are stores of other class objects, the Ingredients, Recipe and Recipes classes do not rely on knowledge of methods or properties of the objects that they store, giving low coupling
  - one exception to this is in the Recipe class, where it is dependent on knowledge that the passed Ingredients class has an Id property.  I think this represents a low degree of coupling but it is something that could be improved.

[Back to top](#cookie-cookbook-challenge-project)

<hr>

## How To Use The App

The app is extremely simple to use. Run the app and choose one or more ingredients to add.  When you have finished adding ingredients, press Enter and the recipe is saved to a flle.  The next time the app is run, each stored recipe is read from the file and displayed before allowing you to add ingredients for a new recipe.

The format for the file store is set by the value of fileType in Program.cs:
- if it is set to FileType.Json, the file store will have the suffix .json and be in JSON format
- if it is set to FileType.Text, the file store will have the suffix .txt and be in plain text format

[Back to top](#cookie-cookbook-challenge-project)

<hr>

## What I Learned

For a comparatively simple set of requirements, this has been a very rich learning experience.  The major challenge was to design the class structures to implement a solution using the design principles outlined above to give a clean solution.

### Types of objects to hold

One of the first considerations was what types of objects to hold in the various collections.  One of the key requirements was that the file store should contain only the ids of the ingredients, not serialised ingredient objects.  This led me to a first iteration where the collection objects contained only the id of the ingredients in order to make reading/writing to/from the file store and reconstituting the receipes easier.  This did not turn out to be a good approach since it made other areas of code more complicated and led to a  higher level of coupling to translate between the id and the ingredient.

I changed the approach so that the collection classes held the whole object required in their collection, e.g. a collection of ingredients holds Ingredient objects, not ids of Ingredient objects.  This was a much cleaner approach and removed a considerable degree of complexity and coupling from the code.

### Use of Interfaces and Abstract Classes to reduce coupling

In the early stages of attempting to solve the problem I had not fully grasped how to use Interfaces and Abstract Classes to reduce coupling between classes and so increase flexibility and maintainability.  Once I had learned how this approach could be implemented and what the benefits were, this area went from theoretical knowledge to a powerful tool in my toolbox.  The improvement in terms of flexibility and maintainability was a revelation, even if it makes the code slightly more complex.

### Implementing the single responsibiltiy principle in the main class

I had not fully grasped that the single responsiblity principle applied to the main class, since it seems that it was inherently orchestrating many disparate activities and the class became a more complex implementation that it should have been.  Part of this in the earlier stages was because (as mentioned above), I had not fully grasped how to use Interfaces and Abstract Classes and so I was moving the complexity of managing classes to the main class.  Once I realised that the single responsibility of the main class was to manage the workflow and also only contain a single reason to change, it became clear that new UserInterface and FileAccess namespaces/classes were needed.  

Once I had implemented the changes above, I was pleasantly surprised how much easier it became to implement changes to the code without having knock-on impacts.

[Back to top](#cookie-cookbook-challenge-project)

<hr>

## Tech Stack

C# .NET  
Visual Studio 2022 Community

[Back to top](#cookie-cookbook-challenge-project)

<hr>

## How To Run Locally

Clone the project

```bash
  git clone https://github.com/Dug-F/CookiesCookbook.git
```

Then open the project in Visual Studio (I was using 2022 Community edition) and run.

[Back to top](#cookie-cookbook-challenge-project)
