* Refer to BraceGame

1. Randomly seeded fractal landscape;
- 	Write Diamond-Square Algorithm in landscape.cs to generate the “title” effect, using Direct3D for drawing;

#Generate 2D matrix: Methods Initialization and testing 
Procedures:
Four coner assigned same height values;
void Diamond(): for generating the midpoint value, average the four conver value and add a randmon value within the heightRanges; 
void Square(): Taking each diamond of four points, generate a random value at the center of the diamond. Calculate the midpoint value by averaging the corner values, plus a random amount generated in the same range as used for the diamond step. This gives you squares again. 

#Vertex mapping from 2D Matrix:
Loop through 2d array, add new vertex definitions for generated vertex values from the 2D array;


2. Camera Motion: “camera.cs”
- Camera rotation (mouse), translation (movement: keyboard WASD, QE)

Apply view space to render all objects in a common(consistent) World View; (unlikely in project1, just one object being rendered)
Apply transformation matrix: translation, scale, rotation matrix, in accordance with user’s inputs (3-4 different 
matrices used here);
