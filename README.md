# Graphics Package Evaluation Criteria

## Project Description

The Graphics Package Evaluation Criteria project is a comprehensive assessment of various graphics algorithms and transformations. This project aims to provide implementations and evaluations for fundamental graphics algorithms, specifically focusing on line drawing algorithms, circle and ellipse drawing algorithms, as well as 2D transformations including translation, scaling, rotation, reflection, and shearing.

## Implemented Algorithms

### Line Drawing Algorithms

1. **Line DDA (Digital Differential Analyzer)**
   - Description: The Line DDA algorithm is used to draw a straight line between two given points using incremental calculations. It ensures that each pixel is included in the line by calculating intermediate coordinates.
   - Implementation: [link to code](Form1.cs)

2. **Line Bresenham’s**
   - Description: The Bresenham's Line algorithm is another method for drawing lines on a grid. It uses integer calculations and incremental error adjustments to determine which pixels to include in the line.
   - Implementation: [link to code](Form1.cs)

### Circle and Ellipse Drawing Algorithms

1. **Circle Drawing Algorithm**
   - Description: This algorithm is used to draw a circle with a given center and radius. It utilizes the properties of symmetry and calculates pixel positions based on the circle's equation.
   - Implementation: [link to code](Form1.cs)

2. **Ellipse Drawing Algorithm**
   - Description: The Ellipse Drawing algorithm is used to draw ellipses with given dimensions and center coordinates. It adapts the circle drawing approach, adjusting for different radii along the major and minor axes.
   - Implementation: [link to code](Form1.cs)

### 2D Transformations

1. **Translation**
   - Description: Translation involves moving an object from one position to another by adding a constant value to its coordinates. It allows for shifting an object's position on the screen.
   - Implementation: [link to code](Form1.cs)

2. **Scaling**
   - Description: Scaling is used to resize objects, either making them larger or smaller. It involves multiplying the coordinates by scaling factors along the x and y axes.
   - Implementation: [link to code](Form1.cs)

3. **Rotation**
   - Description: Rotation transforms an object around a specified point by a given angle. It uses trigonometric functions to calculate new coordinates after rotation.
   - Implementation: [link to code](Form1.cs)

4. **Reflection**
   - Description: Reflection flips an object over a specified axis. It involves changing the sign of coordinates either horizontally or vertically.
   - Implementation: [link to code](Form1.cs)

5. **Shearing**
   - Description: Shearing skews an object along one axis, while keeping the other axis constant. It involves modifying coordinates based on a shearing factor.
   - Implementation: [link to code](Form1.cs)

## Usage

Each algorithm and transformation is implemented as a separate Python script. You can navigate to each link provided above to view the source code and understand the implementation details. To use these implementations in your own projects, you can download the scripts and integrate them as needed.
