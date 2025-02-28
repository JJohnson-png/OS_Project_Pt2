Language: c#

Focus: Parent-Child Process Communication

This project serves as a simple demonstration on how processes can communicate with each other.
The parent process creates an anonymous pipe server and sends a message to the child program.
You can visualize the communication between the 2 from the messages printed on the screen
making it easier to understand conceptually.

Setup:

Clone the repository to your local machine:

git clone https://github.com/JJohnson-png/OS_Project_Pt2

Modify the path in the child program to reflect the location
of your child.dll file...

child.StartInfo.Arguments = "INSERT YOUR FILE PATH HERE";

Build and run both Parent and Child

Done!

Example output:
Attempting to start child...
Child process started!
Child received: Test message from parent to child

Things to note: The parent process is what creates the pipe and also starts the Child program
The child program listens to the Parent through the pipe.
