# networking-dog
An endless runner game following a small dog trying to gain social media klout through networking on a procedurally generated sidewalk.  Created as a Capstone Project for Ada Developers Academy.
## Summary
![networking-dog-trailer](https://github.com/murog/networking-dog/blob/master/networking_dog_trailer.gif)

## Development 
![stage-0](https://d2w9rnfcy7mm78.cloudfront.net/1554873/original_1450422604ce52e1500e89423c383140.gif)

![stage-1](https://d2w9rnfcy7mm78.cloudfront.net/1628557/large_7e75955cac01a982dafe8d7bd74b65b4.png)

![stage-2](https://d2w9rnfcy7mm78.cloudfront.net/1628558/original_6a6090f50805ead0861343151e30484e.gif)

![stage-3](https://d2w9rnfcy7mm78.cloudfront.net/1628560/large_1e9ede746fc150a073c030ec9241919c.png)

![stage-4](https://d2w9rnfcy7mm78.cloudfront.net/1628562/large_a9e9b1eaba2ae7c4fd705ed43305e8c0.png)

![stage-5](https://d2w9rnfcy7mm78.cloudfront.net/1628561/large_2eddd6fecf21eb481b25fc5ff44a8541.png)

![stage-6](https://github.com/murog/networking-dog/blob/master/networking-profile.png)

![stage-7](https://github.com/murog/networking-dog/blob/master/networking_dog_sidewalk3.gif)

## Capstone Concept 
![networking-dog](https://i.imgur.com/kq7vcyj.png)

## Product Plan Components
1. __Personal Learning Goals__: 
    - C#: Animations, physics, postprocessing
    - Physics: Layers and collision matrix, raycast
    - Lighting
    - Game Design

1. __Problem Statement__: 'Networking Dog' is a short and randomized dog-walking simulator in which you are a dog trying to increase professional klout by getting humans to stop and pet you during a walk without your owner getting too annoyed (they are resentful of your social media presence and just want you to be normal dog). 

1. __Market Research__: Outline the key insights from your research, including:
    - http://hairnah.com/
    - https://captaingames.itch.io/enviro-bear-2000
    - http://www.sg4adults.eu/files/art-game-design.pdf
    - http://art.yale.edu/file_columns/0000/1474/homo_ludens_johan_huizinga_routledge_1949_.pdf
    - https://gamifique.files.wordpress.com/2011/11/1-rules-of-play-game-design-fundamentals.pdf
    - http://gamestudies.org/0601/articles/rodriges
    

## MVP Feature Set
1. Web Executable 
1.  Timed Round
	- Round is over after 2 minutes.
	- No 'winning' condition.  Player must survive round to receive score.  Round will always take at least 2 minutes. 
	- Scoring: 'Klout' score will be represented on a 1 to 5 rubric coupled with an animation depicting their LinkedIn Connections, Twitter Followers and New Itunes Reviews on the dog's podcast.
	- Losing conditions: Tension meter fills up.
1. Tension meter with leash
	- Round is ended if tension meter is filled (Animation: Owner picks you up and walks you the rest of the way, not allowing you to network).
	- Positive Encounters increase tension meter.
	- Player must balance getting points and avoiding to lose.
1.  Collisions with Positive and Negative Encounters
	- Positive Encounters: People who stop to pet you increase 'klout' scores.  Random 'small talk' text will appear on screen to indicate positive encounter.
	- Negative Encounters: When you pass by trash, you eat it and decrease 'klout' scores.  Random 'embarrasssed' text will appear on screen to indicate negative encounter. "Don't put this on snapchat...!"
1. User moves through 3D environment in first person perspective
	- Elements in game will be 2D sprites (planes), but the physical space (sidewalk) will be a 3D space.
	- Since game will continue until game over conditions are met (losing or 2 min completion) 
	- User will see animation of their own dog paws on screen that will animate up and down to create sense of walking forward.
	- Sidewalk will be circle in larger environment, but will always appear as mostly straight line in first person perspective. 
1.  User controlled horizontal movement
	- Left and right movement across sidewalk
	- User will stop during encounters.
	- User will always be moving when not in an encounter (not sure about this: maybe not moving at adequate speed will increase tension meter? Not sure what will be more difficult to implemement).
1.  Randomized spawning of encounters.
	- Every time the game is played, the encounters will spawn in different locations.
1. Score displayed at end of round.
	- Score will take in values from the positive and negative encounters player collides with during walk.

	
### Potential Additional Features

1.  User controls movement by moving each paw forward.
1. User controls vertical movement, not keeping up speed with owner will increase tension meter.
1.  User can collect randomized "power ups" that will increase different attributes.
	- Increase charm with outfits and accessories.
	- Increase speed by finding a good snack on sidewalk.
1.  User can view "speed" attribute.
	- Increased speed will allow dog to get to positive encounters more quickly and minimize addition to tension meter.
1.  User can view "charm" attribute.
	- Increased charm will increase the radius needed to collide with positive encounters, bringing them to you and minimizing addition to tension meter.
1. Not all encounters with people are positive, avoid negative people who are allergic to you (the interaction would be awkward).
1. Not all encounters with positive people end well, dog should make correct "small talk" 
	- User must type phrase in accurately and within time limit of interaction to get positive klout
	- Innaccurate typing will result in embarrassment and negative klout.
1.  Multiple levels of increasing difficulty.
1.  User can choose dog breed at beginning of round.
1. Implement as VR game?

## Draft Technology Choices

- Unity
- C# 
- Git


## Additional Content, diagrams, wireframes, etc.
Very rough!
![home-screen](https://i.imgur.com/KtvVsvT.png)
![play-cycle](https://i.imgur.com/w1B8cYj.png)
