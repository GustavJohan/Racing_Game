Racing Game

My intention for the game was to make a top-down racing game featuring a physics-based car controller with an emphasis on drifting and building velocity. Two players would compete in 3 races with the winner being decided based on who finished first more times. 

The game can be started from any scene except for “Victory Screen”. The game uses the new input system and text mesh pro. 

The structure of my code is mostly centred around the script called position tracker, most other scripts read values from it, it also controls the players scoring and reads when a player finishes. The Position Tracker reads most of its values from the Car Position tracker scripts on the cars. When a level scene is loaded a script called Instantiator loads and instantiates several objects in the scene while giving references to objects in the scene where applicable. 

My code was created with mostly functionality in mind. If I could not find a clean way to implement something I would simply do the first solution I could think of with the intention of refactoring or redoing the code if I had the time. I sadly did not have the time to clean all of my code but I was able to create a functional game. 

Player 1 (the red car) uses WASD for driving and steering, C for brakes and F for powerups. Player 2 (the blue car) uses the arrow keys for steering, right control for brakes and right shift for powerups. 

The objective is self-explanatory, be the first to complete 2 laps. The winner is the best out of 3. There are 2 powerups, Speed boost (yellow) and enemy slow(blue) both are activated by pressing the powerup button. 

My source for learning about the wheel colliders was this:
https://docs.unity3d.com/Manual/class-WheelCollider.html

I used a method for calling a script every time a new scene was loaded in the script First Player Tracker which I got from this. 
https://docs.unity3d.com/ScriptReference/SceneManagement.SceneManager-sceneLoaded.html

2022.3.8f1

-Gustav Johansson
