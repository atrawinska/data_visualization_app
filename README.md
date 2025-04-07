# Hi!

This is a simple visualization graph application built with **Avalonia for Desktop**.  
The program provides multiple charts to visualize the dataset from [Global Food Wastage Dataset (2018–2024)](https://www.kaggle.com/datasets/atharvasoundankar/global-food-wastage-dataset-2018-2024) about global food waste.  
We included a few different charts — some of them can also be modified.

---

## Use Guide

1. Open the project (the CSV file is already included, so no additional setup is required).
2. Add a chart you want from the side panel by clicking one of the colorful buttons.
3. Click on a chart to open it in a full view.
4. You will be redirected to a fullscreen view with options to:
   - Remove the graph
   - Go back to the dashboard
   - In some cases — modify the graph
   - Zoom in and inspect the graph in more detail

> • Modified graphs update without any additional clicking  
> • Additional styling and animations have been added

---

## Details

The application includes various **bar** and **line charts**.  
The code also includes dynamic queries:
- `'capita'` graph changes based on chosen year and/or country
- `'time'` chart changes based on selected or typed-in country (auto-suggestions included)

---

## Basic Requirements

- Use the following technologies: **C#**, **Avalonia**, **CommunityToolkit**, **LiveCharts2**, and **CsvHelper** ✔️  
- Follow the **MVVM** (Model-View-ViewModel) architecture ✔️  
- Apply **SOLID** principles to ensure clean and maintainable code ✔️ (to some extent)  
- Create a **UI sketch** (e.g. drawing, Figma, etc.) ✔️  
- Single-screen app with a **dashboard and control panel** ✔️  
- Control panel includes a list of preset queries ✔️  
- Read a dataset from a CSV file ✔️  
- Use **LINQ** to process and analyze data (grouping, sorting, filtering, etc.) ✔️  
- Implement **5–10 preset queries** ✔️  
- Include at least **two types of charts** (bar, line, etc.) ✔️  
- Provide an intuitive, modern UI with additional styling ✔️  
- Allow users to dynamically **add/remove graphs** ✔️  
- Selecting an option displays the corresponding chart ✔️  
- Users can remove a chart via a **delete button** ✔️

---

## Additional Feature

- Dynamic queries based on user input

---

## Potential Improvements

- No comments/documentation yet — sorry! 🥲  
- A more SOLID-based architecture (currently optimized for this dataset and chart types)  
- Support for more dynamic chart options  
- Resizing and drag-and-drop layout  
- Undo/redo functionality

---

## Project Prototype / Visualization

<img width="840" alt="image" src="https://github.com/user-attachments/assets/8fce8b17-6fe0-427d-acb3-dbec8dad34cc" />  
<img width="840" alt="image" src="https://github.com/user-attachments/assets/21f4c7a7-3c4e-45ee-b530-89f03c1607eb" />
