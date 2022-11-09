Hello!

Welcome to the instructions and setup guide for the GayPanic assets for OBS and Streamer.bot. Everything is pretty simple, and a little work is left for customization.
I will be working on this as time goes on and I find new ways to improve what already exists. This is my first attempt at a more complex set of instructions for streamer.bot and OBS, so I am sure that there are a few places that could be a little more efficient.

To setup OBS:
	1. Install the Mob 200 Text
	2. Open OBS and create a scene that will hold the text and actions that you would like to happen on screen as the percent rises for your chat collevtively.
	3. Add GDI Text sources using the Mob 200 font. Be sure to add a little text so that you can play around with size and location on the scene.
	4. Add that scene as a source to all other scenes that you want this to be visible
	
The original code for Streamer.bot has 8 levels that will show and hide sources that increase in intensity from white to red. Unfortuneately, there was nothing to  control this gradient in streamer.bot at this moment. If there ever is, I will be sure to update the C# code and get it out asap.

The next thing to set up is streamer.bot. Be sure to install and setup this very helpful streamer tool to make this a lot easier. Otherwise, I have also provided the C# code  for reference if you would prefer to use another system and willing to translate that over to your prefered language.

To setup streamer.bot:
	1. Open streamer.bot
	2. At the top left, there should be an import option
	3. Copy the string in the gayPanic.txt and paste it in the Import String box. You should one Action and two Commands.
	4. Import

After you have imported the action and commands, you can open the C# code and edit it. In there find all locations for PlaySound and PlaySoundFromFile, and replace the "<C:/Enter/File/Path/Here>" with your preferred string. Be sure to keep the "" as these are strings, and the compiler will not compile your code otherwise. After that, you can check out gayPanic(). Under //do gay things, put in any sounds you want to play or make sources visible. Feel free to edit this as much as you would like and put in whatever is fitting for you and your stream. Lastly, feel free to edit any other portion of this code. I have values set on how often I want chat to reach 100% based on my prefrences, and allowed for individual tracking. Be sure that LOWEST, LOWER, LOW, etc. are set to the correct sources that you have, and that the name of your scene matches PANIC_SCENE. No worries about chaning the persistent values, those should already align with the values imported in by streamer.bot. 

Anyways, thanks for using this setup, and I hope you enjoy. Feel free to make edits, or to reach out to me and we can collaborate on new ideas to improve this, or on another idea. 