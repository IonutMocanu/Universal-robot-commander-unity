# Connect the mobile robot to the app
### Find the robot IP
For this step you can use the following command in the robot terminal.
```
hostname -I
```
<br>
### Introduce the robot IP and the ROS port
Write the robot IP find in the first step in the first input field and the ROS port in the second one. The default ROS port is 10000.
<img src="https://github.com/IonutMocanu/Universal-robot-commander-unity/blob/main/Docs/Picture3.png" alt="Login" width="1200"/>
<br>
### UI introduction
3.1. Movemenet panel
Here you can control the movement of the robot
<img width="241" height="223" alt="image" src="https://github.com/user-attachments/assets/09b1d955-a6e5-40b1-928c-e70892fee798" />
3.2. Output stream
The panel where the selected output stream from the bottom meniu is displayed
<img width="499" height="325" alt="image" src="https://github.com/user-attachments/assets/c4ba8ddd-8e1b-453c-b3fb-6ec113a32baa" />
3.3. Speed Slider
The slider to control the speed of the robot.
> [!WARNING]
> If you are using the default settings for the configuration of the diff drive controller, the mobile robot will not move if the speed is bigger than 0.20. 
<img width="75" height="314" alt="image" src="https://github.com/user-attachments/assets/95741cbc-404e-491a-b9e2-441db92734e1" />
3.4. Bottom meniu
In this area you select the output stream and also the option to go back in the first scene.
<img width="1048" height="74" alt="image" src="https://github.com/user-attachments/assets/1089c4a0-7c47-4b76-a1d1-c59ec2db7bd3" />


