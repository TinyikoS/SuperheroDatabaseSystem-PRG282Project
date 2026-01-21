# Superhero Database System 

## Project Description
This project was developed for **PRG2782** as a version-controlled C# Windows Forms application.
The system manages superhero trainee records for the One Kick Heroes Academy, a fictional sister campus of Belgium Campus.
The application replaces a paper-based assessment process by digitally capturing hero details, automatically calculating hero ranks based on exam scores, and generating summary reports. 

---

## Objectives
- Develop a C# Windows Forms application
- Implement file-based data storage using text files
- Automate rank and threat-level calculations
- Apply CRUD (Create, Read, Update, Delete) functionality
- Use Git and GitHub for version control

---

## Technologies Used
- C#
- Windows Forms (.NET Framework)
- Text Files for data storage
- Git
- GitHub

---

## Features

### Add New Superhero
- Capture superhero details via a form:
  - Hero ID
  - Name
  - Age
  - Superpower
  - Hero Exam Score
- Automatically calculate:
  - Hero Rank
  - Threat Level
- Save records to `superheroes.txt`

---

### View All Superheroes
- Display all superhero records in a **DataGridView**
- Show:
  - Personal details
  - Exam score
  - Calculated rank
  - Threat level

---

### Update Superhero Information
- Search for a superhero by Hero ID
- Edit superhero details through the form
- Recalculate rank and threat level
- Save updated data back to the file

---

### Delete a Superhero
- Select a superhero from the DataGridView
- Remove the selected record from `superheroes.txt`

---

### Generate Summary Report
- Calculate and display:
  - Total number of superheroes
  - Average age
  - Average exam score
  - Number of heroes per rank
- Save the report to `summary.txt`

---

## Hero Ranking & Threat Level System

Each superhero’s rank is automatically calculated based on their Hero Exam Score.
The rank also determines the level of threat the hero is qualified to handle within the One Kick Heroes Academy.

### Ranking Criteria

| Exam Score Range | Hero Rank |
|------------------|-----------|
| 81 – 100         | S-Rank    |
| 61 – 80          | A-Rank    |
| 41 – 60          | B-Rank    |
| 0 – 40           | C-Rank    |

---

### Threat Levels by Rank

| Hero Rank | Threat Level Description |
|----------|---------------------------|
| **S-Rank** | Finals Week – threat to the entire academy |
| **A-Rank** | Midterm Madness – threat to a department |
| **B-Rank** | Group Project Gone Wrong – threat to a study group |
| **C-Rank** | Pop Quiz – potential threat to an individual student |

---

### Automatic Calculation
- The hero’s rank and threat level are calculated automatically when:
  - A new superhero is added
  - An existing superhero’s exam score is updated
- These calculated values are stored and displayed alongside the superhero’s other details.

## How to Run the Project
1. Clone or download the repository
2. Open the solution file (`.sln`) in **Visual Studio 2022**
3. Build the solution
4. Run the application

---

## What I Learned
- Building Windows Forms applications in C#
- Implementing CRUD operations using text files
- Using DataGridView for data display
- Applying business logic to calculate ranks and threat levels
- Using Git and GitHub for version control in a real project

---

## 👥 Contributors
- Tinyiko Siwele
- Tumelo Bapela
- Shinique Dippenaar
- Tshiamo Maise
- Puleng Ramorapeli
