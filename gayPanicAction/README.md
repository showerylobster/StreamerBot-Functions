Hello!

Welcome to the instructions and setup guide for the GayPanic assets for OBS and Streamer.bot. Everything is pretty simple, and a little work is left for customization. I have left in what I use on my stream to be used as examples, feel free to make edits and changes as you need.

I will be working on this as time goes on and I find new ways to improve what already exists. This is my first attempt at a more complex set of instructions for streamer.bot and OBS, so I am sure that there are a few places that could be a little more efficient.

To setup OBS:
	1. Open OBS and create a scene that will hold the text and actions that you would like to happen on screen as the percent rises for your chat collevtively.
	2. Add GDI Text and any other sources that you want to use. Be sure to add a little text so that you can play around with size and location on the scene.
	3. Add that scene as a source to all other scenes that you want this to be visible
	
The original code for Streamer.bot has 8 levels of GDI Text sources that will show and hide the sources that increase in intensity from white to red. Unfortuneately, there was nothing to  control this gradient in streamer.bot at this moment. If there ever is, or another way to change that source, I will be sure to update this repo as soon as possible.

The next thing to set up is streamer.bot. Be sure to install and setup this very helpful streamer tool to make this a lot easier. Otherwise, I have also provided the C# code  for reference if you would prefer to use another system and willing to translate that over to your prefered language.

To setup streamer.bot:
	1. Open streamer.bot
	2. At the top left, there should be an import option
	3. Copy the string in the gayPanic.txt and paste it in the Import String box. You should one Action and two Commands.
	4. Import

After you have imported the action and commands, you can open the C# code and edit it. In there find all locations for PlaySound and PlaySoundFromFile, and replace the "<C:/Enter/File/Path/Here>" with your preferred string. Be sure to keep the "" as these are strings, and the compiler will not compile your code otherwise. After that, you can check out gayPanic(). Under //do gay things, put in any sounds you want to play or make sources visible. Feel free to edit this as much as you would like and put in whatever is fitting for you and your stream. Lastly, feel free to edit any other portion of this code. I have values set on how often I want chat to reach 100% based on my prefrences, and allowed for individual tracking. Be sure that LOWEST, LOWER, LOW, etc. are set to the correct sources that you have, and that the name of your scene matches PANIC_SCENE. No worries about chaning the persistent values, those should already align with the values imported in by streamer.bot. 

Anyways, thanks for using this setup, and I hope you enjoy. Feel free to make edits, or reach out to me and we can collaborate on new ideas to improve this. I've added the code mostly for viewing purposes.
