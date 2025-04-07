Hi!
This is a simple visualization graph in Avalonia for Desktop. This program provides multiple charts to visualize the data set "https://www.kaggle.com/datasets/atharvasoundankar/global-food-wastage-dataset-2018-2024" about global food waste. We included a few different charts where some of them can be modified.


Use guide:
1. open the project (the csv file is already there so no additonal setup should be required),
2. add a chart you want from the side panel by clicking one of the colorful buttons
3. if you want to look more carefully at the graph you can open it by clicking on it,
4. you will be redirected to a full view with options to remove the graph, go back to dashboard, in some cases- to modify the graph as well as to take a closer look (there are settings which allow user to zoom the graphs).

*modified graphs are set without any additional clicking
*addtional styling and animations were added

Details:
The application includes various bar and line charts. The code has also various dynamic queries: 
a. 'capita' graph changes based on chosen year and/or country
b. 'time' chart changes based on chosen or typed in country (auto-suggestions are implemented)

Besides, it meets the given below requirenments.

Basic requirements:
- Use the following technologies: C#, Avalonia, CommunityToolkit, LiveCharts2 and CsvHelper, Done
- Follow the MVVM (Model-View-ViewModel) architecture. Done
- Apply SOLID principles to ensure clean and maintainable code. (more or less) Done
- Create a UI sketch (this can be: a drawing on paper sent as a photo, in Paint, Figma, or any other design tool). Done
- Think of it as a single-screen application with a dashboard and a control panel.
The control panel should contain a list of preset queries for users to choose from.The sketch  does not need to be very detailed, use any of the designs/sketches presented in class as a reference. Done
- Read a dataset from a CSV file (you can select one from the provided datasets at the bottom of this document, the CSV files are posted on itslearning so you do not need to download them from the links). Done
- Use LINQ to process and analyze the data (grouping, sorting, filtering, etc.).
Implement 5-10 preset queries. Done
- Include at least two types of charts, such as: Pie charts, Bar charts, Line charts Other - your choice. Done
- Ensure an intuitive and modern UI by applying additional styling. (hopefully) Done
- Allow users to add and remove graphs dynamically, Done
- When a user selects an option from the list, the corresponding chart should appear on the dashboard. Done
- Users should be able to remove a chart by clicking a delete button. Done

Additional feature: dynamic queries


Potential improvements:
- comments: there are none, I am sorry I did not have time
- more SOLID-based approach, here we used what was neccessary and probably while adding different types of graphs and datasets, it should be changed
- more dynamic options (like adding different types of graphs)
- resizing/drag and drop features
- undo/redo feature

#**Project prototype/Visualisation:**
<img width="840" alt="image" src="https://github.com/user-attachments/assets/8fce8b17-6fe0-427d-acb3-dbec8dad34cc" />
<img width="840" alt="image" src="https://github.com/user-attachments/assets/21f4c7a7-3c4e-45ee-b530-89f03c1607eb" />



