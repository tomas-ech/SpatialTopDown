CODE DOCUMENTATION
The documentation will follow the next format:
1. Class
  1.1 Methods

1. PlayerHealth
This class is used by the player to know if his/her character is still alive or is dead.
There is no custom methos, just an OnTriggerEnter2D, when the "EnemyBullet" hits player
he/she dies

2. PlayerMovement
Its function is move the player when WASD or space bar input is used

   2.1 IEnumerator Dash()
   A Coroutine who give the player the ability to make a dash when spacebar is pressed.
   This methos use boolean to control the cooldown and duration of the ability and
   rigidbody2d to give the player extra speed

   2.2 PlayerInput()
   This method receive the data of input when the player press button or move the mouse

   2.3 Movement()
   This method use rigidbody2d and angle calculations to move the player in the game,
   and the same time rotates to look at the cursor all the time. W move to cursor

   2.3 Boundaries()
   Method who control the limits of the game, player should stay in the camara view

   2.4 SpeedControl()
   Method to control the player speed using magnitude and normalized vectors

3. PlayerAbilities
Class who give the player the possibility to use abilities

  3.1 PlayerShoot1()
   Method who shoots and instanciated object with certain rigidbody2d force to launched
   it forward

4. PointerScript
Class to move a Gameobject who will work as mousepointer, it use the camera and the method
Screentoworldpoint to know the position of the mouse and place the pointer there

5. VidPlayer
Class to place mp4 video in the videoplayer object to use it as moving background to the game

  5.1 PlayVideo()
  This method gets the path in "StreamingAssets" folder where the video is and place that path or
  url in the video player object

6. Enemy
Parent Class of all the enemies in the game. It use triggers and collisions to attack the player
and be attacked by him/her

  6.1 GetTarget()
  This methods search for the player and store his/her transform in a variable
  
  6.2 RotateToTarget()
  Calculates and angle using Mathf.Atan2 to give the enemy the ability to rotato towards the player 

7. EnemyChaser
Children class of Enemy

  7.1 EnemyMovement()
  Uses rigidbody2d to impulse the enemy forward, using herency to rotate and chase the player

8. EnemyShooter
Children class of enemy

  8.1 WalkToPoint()
  This method choose randomly to each enemy of this kind a waypoint, once an enemy spawn it will
  run to that point and then rotates towards the player

  8.2 Shoot()
  Ability of the enemy, once in the way point and rotates to player, it will instanciate a shoot
  prefab every few seconds 

9. GameManager
Class to control every important aspect of the game like be able of begin the game, count coins,
enemies and calculate score and save information

  9.1 Save()
  Stores important data like coins collected, enemies defeated and players score using PlayerPref

10. AudioManager
Class who control all the music and sound effects

  10.1 PlayRandomBGM()
  This method check if is there background music playing, if not, play random music

  10.2 PlaySFX(int index)
  Used to activate sound effects, it also use a random value for pitch to give the game more variability

  10.3 StopSFX(int index)
  Stops the indicated sound effect

  10.4 PlayBGM(int index)
  Play an especific background music

  10.5 StopBGM()
  Stops all the background music
  
11. SpawnManager
Spawns coins and enemies using different point and positions to instanciate those gameobject

  11.1 SpawnCoins()
  calculate random numbers between the allowed limits and then instantiate a coind prefab

  11.2 SpawnEnemy()
  Also calculates random number to choose inside an array of gameobjects the one who will be instantiated
  and the random point where it will be summoned

12. Ui_Main
the principal class in the UI

  12.1 SwitchMenu(GameObject uiMenu)
  Method to use in buttons, it will deactivated all the canvas children and then activate the chosen UI gameobject

  12.2 ExitGame()
  Method to exit the game when launch in windows or mobile devices

  12.3 StartGame()
  Method who activates the boolean condition to begin the game, also it makes the mouse invisible

  12.4 RestartGame()
  Method restart the scene, refreshing status of player dead

13. Ui_Game
Controls the UI related to the game itself, is used to give the player visuals about hes/her dash ability cooldown

  13.1 UpdateScore()
  It changes the number in the UI to match the real score the player is getting

14. UI_Dead
Controls all the texts the playes sees when he/she dies


