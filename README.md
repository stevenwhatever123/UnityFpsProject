# unityfpsproject

Download: https://drive.google.com/file/d/1y1OtsqM_QKwrNiHYsL8XncqtNyMLTEGT/view?usp=sharing

This is my attemp on using Unity Engine for the first time, I've set a one week limit for myself and see what could I come out with no knowledge and experience of using Unity Engine.

I decided to create a FPS game as I tried to figure out 
the basic mechanics and get a hang of how a game engine works first.

This is the menu of my game which I took the logo and copy the style of FINAL FANTASY XIII-2.
I really like the intro of it and find it beautiful but I always feel like the intro could do better by matching to its music.
So I tried recreate it, it looks good but I think I could do better on it.
![alt text](https://i.imgur.com/HBw3a93.png)

What I implemented:

1. Player Movement(of course)  
It took me a few days to implement as I don't quiet really know how the engine works.
At first, I used the Input.Get(KeyCode.W) for all WASD input which is not kinda good and efficient as there
is a lot of repeated code. So I rewrote it in a better style of code.
![image](https://github.com/stevenwhatever123/unityfpsproject/blob/master/1.gif)

2. Crouching Movement  
The crouching movement isn't that difficult to implement, but what I did is just resizing the collider of the player,
which is not doing in a good way as way because the player mesh went underneath the ground.
![image](https://github.com/stevenwhatever123/unityfpsproject/blob/master/2.gif)

3. Jumping  
Jumping is not that hard to code, but when working with wall sliding/climing, it did really give me a hard time.
![image](https://github.com/stevenwhatever123/unityfpsproject/blob/master/3.gif)

4. Wall Slilding/Climbing  
It took me a few days to code this part of my game.
I used animator to animate the camera rotation, which looks pretty good to me.
I tried different way to code how the player could slide/climb the wall but all didn't work as excepted.
Even the version now isn't what I except, but it does it job and I'll leave it here.
![image](https://github.com/stevenwhatever123/unityfpsproject/blob/master/4.gif)

5. A Gun which can fire bullets  
It's fun when working in this part, working in animation of the gun is easier than what I thought it would be.
The bullet with trail coming out of the gun is the most satisfying part I've worked in.
![image](https://github.com/stevenwhatever123/unityfpsproject/blob/master/5.gif)

Conclusion:  
It's a fun week on making a game by self teaching myself. There are many things I have never thought about. Next time, I may try to make a 2D game as I think there are fewer work to implements when compared to a 3D game and giving me freedom to implement what I wanted to.
I have many thoughts of making a game and may want to take part in a bit of music composing next time.
