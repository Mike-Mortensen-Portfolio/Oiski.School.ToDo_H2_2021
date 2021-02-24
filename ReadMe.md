# Oiski's To-Do App

## About The Project
The project is a **Razor Page** Application and like all the `Oiski.School` namespace projects, this project is written as the solution to an assignments.

### Terms of Development
The assignments specifies that the project is a _'To Do' Management Application_ that **must** include functionality for
creating, deleting and editing '_To Do_' tasks.
However, how those features are implemented and how exactly the application should look or behave is not specified;
Therefore the following diagram was formed according to the specifications and ideas of mine.
![ToDo_H2_2021_Diagram_Part1](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/blob/Developer/Oiski.School.ToDo_H2_2021_Diagram_Part1.png)
![ToDo_H2_2021_Diagram_Part2](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/blob/Developer/Oiski.School.ToDo_H2_2021_Diagram_Part2.png)


## The program
**Goal**
> Build a _Razor Page Application_ that can manage and maintain a 'To Do' list.

**Input**
> Missing description...s

**Output**
> Missing description...

See the [Wiki](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/wiki) for more in depth information about the project.

## Versioning
The Assignment specifies that versioning should be done according to the following template: [_Major_].[_Minor_].[_Path_].\
Each `Feature` must be branched out and developed on an isolated branch and merged back into the `Developer` branch when done.

The syntax for the structure of folders must be presented as: [DeveloperName]/[Version]/[BranchName], where as branches should be named as follows: [*Version*]-[*Feature*]_[*SubFeature*].\
**Example:**
>**Folder Structure:** _Oiski/v1_ \
>**Branch Name:** _1.0.0-Interface_MainMenu_ \
>**Full Path:** _Oiski/v1/1.0.0-Interface_MainMenu__

### Change Log
- **[v0.1.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v0.1.0)**
  - **Implemented Task Entities**
    - Ability to save the state of a task
    - Ability to build a task from a previous state
- **[v0.2.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v0.2.0)**
  - Implemented `Project`
    - Ability to save project state
    - Ability to load a previous state of a project
  - **Changes to `ProjectTask`**
    - Added IDKey to identify the ID value in a file
    - Fixed ambiguous call to ID property between `IMyCompletableModel` and `IMyRepositoryEntity` In `IMyTask`
  - **Changes to `EntryStatus`**
    - Changes NotCompleted to Open
    - Changed Completed to Closed
- **[v0.3.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v0.3.0)**
  - **Implemented `ProjctOverview`**
    - Ability to store and load projects
  - **Changes to `Project`**
    - Fixed ambiguous call to ID property between `IMyCompletableModel` and `IMyRepositoryEntity` In `IMyTask`
- **[v0.4.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v0.4.0)**
  - **Implemented Factories**
    - Added `TaskFactory` class
    - Added `ProjectFactory` class
- **[v1.1.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.1.0)**
  - Added Project Overview page
  - Setting up base page layout
- **[v1.2.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.2.0)**
  - Added `ProjectDetails` page
- **[v1.3.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.3.0)**
  - **Implemented `EditProject` page**
    - Changed Project property in `ProjectDetails` Page Model to be a `ProjectModel` instead of `IMyPrjoect`
  - **Changes to `ProjectModel` and `ProjectTaskModel`**
    - Added validation attributes to Name and Description
- **[v1.4.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.4.0)**
  - Added `DeleteProject` page
- **[v1.5.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.5.0)**
  - Added `CreateProject` page
- **[v1.6.0](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.6.0)**
  - **Changes to Pages**
    - Added `CreateTask` page
    - Added `EditTask` page
    - Added `DeleteTask` page
  - **Additonal Changes**
    - Reorganized folder structure for pages
- **[v1.6.1 - Revision 1](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.6.1)**
  - **Added coloring for Task and Project Status**
    - `Open` = _Green_
    - `InProgress` = _Orange_
    - `Closed` = _Red_
- **[v1.6.2 - Revision 2](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.6.2)**
  - Added documentation for all pages
  - Added an 'Edit' button to the `ProjectDetails` page
  - Fixed spelling mistake on `DeleteTask` page
- **[v1.6.3 - Revision 3](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ToDo_H2_2021/releases/tag/v1.6.3)**
  - Fixed spelling mistake in `DeleteTask`
  - Added a 'Delete' button to the `ProjectDetailsPage`

## [Oiski.School Namespace Collection](https://github.com/Mike-Mortensen-Portfolio) <-- Click Me
1. [Oiski.School.Library_H1_2020](https://github.com/ZhakalenDk/Oiski.School.Library_H1_2020)
2. [Oiski.School.Bank_H1_2020](https://github.com/ZhakalenDk/Oiski.School.Bank_H1_2020)
3. [Oiski.School.RainStatistic_H2_2021](https://github.com/ZhakalenDk/Oiski.School.RainStatistic_H2_2021)
4. [Oiski.School.FitnessLevel_H2_2021](https://github.com/ZhakalenDk/Oiski.School.FitnessLevel_H2_2021)
5. [Oiski.School.ParkAndWash_H2_2021](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.ParkAndWash_H2_2021)
6. [Oiski.School.WPF_H2_2021](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.WPF_H2_2021)
7. [Oiski.School.EUCCoffeeShop_H2_2021](https://github.com/Mike-Mortensen-Portfolio/Oiski.School.EUCCoffeeShop_H2_2021)
