using System;
using System.Collections.Generic;

public class CPHInline
{
    Dictionary<String, int> chatterPanic;
    // maximum panic amount, feel free to change this based on how often your chat will interact
    private int MAX_PANIC = 1000;
	
    // used for random number generator to decide how much panic is generated, feel free to adjust based on how fast you want chat to reach goal
    private int PANIC_ROLLER = 10;
	
    // used to set thresholds for various levels of panic
    private double PANIC_INCREMENT = 12.5;
	
    // time in miliseconds to wait until resetting chat panic scene and sources
    private int WAIT_TIMER = 30000;
    private int TWO_SECONDS = 2000;
    private int THREE_SECONDS = 3000;
    private int FORTY_SECONDS = 40000;
    private int GIF_TIME_LENGTH = 3300;
	
    // variable used for max RGB value
    private int MAX_COLOR_VALUE = 255;
	
    // panic levels
    private int PANIC_LOWER = 1;
    private int PANIC_LOW = 2;
    private int PANIC_MEDIUM = 3;
    private int PANIC_HIGH = 4;
    private int PANIC_HIGHER = 5;
    private int PANIC_HIGHEST = 6;
	
    // panic scene that will be used for displaying panic text and overlays, feel free to customize
    private String PANIC_SCENE = "Chat Panic Level";
	
    // GDI Text values that can be set, feel free to customize
    private String LOWEST = "Chat Panic Lowest";
    private String LOWER = "Chat Panic Lower";
    private String LOW = "Chat Panic Low";
    private String MEDIUM = "Chat Panic Medium";
    private String HIGH = "Chat Panic High";
    private String HIGHER = "Chat Panic Higher";
    private String HIGHEST = "Chat Panic Highest";
    private String MAXED = "Chat Panic Maxed Out";
    private String WHITE_SCREEN = "Panic Reached";
    private String GIF = "Nose Bleed";
    private String SKYRIM = "Skyrim";
	private String GAY_PANIC_TEXT = "Gay Panic: ";
	
    // global variables
    private String CHAT_DICTIONARY = "global_chatter_dictionary";
    private String COLLECTIVE_GAY_PANIC = "global_panic";
    private String CURRENT_LEVEL = "global_panic_level";
    private String PREVIOUS_LEVEL = "global_previous_level";
	
    // file path to sound bites
    private String FILE_PATH = "C:/File/Path/To/Soundbites";
	
    public bool Execute()
    {
        int panicVal = generatePanic();
        String chatter = args["user"].ToString();
        generateMessage(panicVal, chatter);
        int globalPanic = CPH.GetGlobalVar<int>(COLLECTIVE_GAY_PANIC);
        globalPanic += panicVal;
        double percentPanic = ((double)globalPanic / (double)MAX_PANIC) * 100;
        if (!maxPanic(globalPanic))
        {
            CPH.SendMessage("Chat's collective gay panic is at " + percentPanic.ToString("#.##") + "%");
            CPH.SetGlobalVar(COLLECTIVE_GAY_PANIC, globalPanic);
            // show increase on screen
            setSceneText(percentPanic);
            // increase individual chatter panic and go through logic
            increaseChatterPanic(panicVal, chatter);
            // exit
            return true;
        }

        // increase individual chatter panic and go through logic
        increaseChatterPanic(panicVal, chatter);
        CPH.Wait(1000);
        // do gay shit
        gayPanic();
		CPH.SendMessage("Run gay panic method");
        // exit
        return true;
    }

    private int generatePanic() => new Random().Next() % PANIC_ROLLER + 1;
   
    private void generateMessage(int panicVal, String chatter)
    {
        // generate value based on panic value passed in, free to customize as desired these
        switch (panicVal)
        {
            case 1:
                CPH.SendMessage("@" + chatter + " is starting to feel something and adds a little to the collective panic.");
                break;
            case 2:
                CPH.SendMessage("@" + chatter + " is starting to blush and adds a little to the collective panic.");
                break;
            case 3:
                CPH.SendMessage("@" + chatter + " is starting to feel flustered and adds a little to the collective panic.");
                break;
            case 4:
                CPH.SendMessage("@" + chatter + " is blushing and moderately adds to the collective panic.");
                break;
            case 5:
                CPH.SendMessage("@" + chatter + " is blushing, flustered, and moderately adds to the collective panic.");
                break;
            case 6:
                CPH.SendMessage("@" + chatter + " is unable to finish their sentences and moderately adds to the collective panic.");
                break;
            case 7:
                CPH.SendMessage("@" + chatter + " is struggling to contain their panic and moderately adds to the collective panic.");
                break;
            case 8:
                CPH.SendMessage("@" + chatter + " is beet red and adds quite a bit to the collective panic.");
                break;
            case 9:
                CPH.SendMessage("@" + chatter + " is having a hard time containing themselves and adds a lot to the collective panic.");
                break;
            case 10:
                CPH.SendMessage("@" + chatter + " are you OK?!?!? @" + chatter + " has added significantly to the collective panic");
                break;
            default: // not needed but here for just in case
                CPH.SendMessage("hmm.... @" + chatter + " seems fine and not adding to the collective panic.");
                break;
        }
    }

    // simple check to make sure we do not pass 100% gay panic
    private bool maxPanic(int currentPanic) => currentPanic >= MAX_PANIC;

    /*
	* 100% Gay panic has been reached by the chat. Feel free to add in any sounds, scenes, and overlays to customize your stream.
	* A shell is given here to make sure that the correct sources are being used, allow for messages and sounds to be played, and 
	* finally reset the meter back to 0 so that chat can start all over again. Have fun and stay dengenerate!
	*/
    private void gayPanic()
    {
        // grab current scene to return to later
        string scene = CPH.ObsGetCurrentScene();
        // hide main follow meter
        CPH.ObsHideSource(PANIC_SCENE, HIGHEST);
        // send message to chat and begin ear ringing sound
        CPH.SendMessage("Chat are you ok???");
        CPH.SendMessage("PANIC gayJAM PANIC gayJAM PANIC gayJAM PANIC gayJAM PANIC gayJAM");
        CPH.PlaySound(FILE_PATH + "high-pitched-tone-quiet-to-loud-14549.mp3", 0.25f);
        // change to panic scene
        CPH.ObsSetScene(PANIC_SCENE);
        CPH.ObsShowSource(PANIC_SCENE, WHITE_SCREEN);
        CPH.ObsShowSource(PANIC_SCENE, MAXED);
        CPH.Wait(490);
        // gradually turn scene red to blend text
        for (int i = 0; i <= MAX_COLOR_VALUE; i++)
        {
            CPH.ObsSetColorSourceColor(PANIC_SCENE, WHITE_SCREEN, MAX_COLOR_VALUE, MAX_COLOR_VALUE, MAX_COLOR_VALUE - i, MAX_COLOR_VALUE - i);
            CPH.Wait(15);
        }

        // nose bleed gif
        CPH.ObsShowSource(PANIC_SCENE, GIF);
        CPH.ObsHideSource(PANIC_SCENE, MAXED);
        // wait for it to finish, then hide it
        CPH.Wait(GIF_TIME_LENGTH);
        CPH.ObsHideSource(PANIC_SCENE, GIF);
        // gradually fade to black
        for (int i = 0; i <= MAX_COLOR_VALUE; i++)
        {
            CPH.ObsSetColorSourceColor(PANIC_SCENE, WHITE_SCREEN, MAX_COLOR_VALUE, MAX_COLOR_VALUE - i, 0, 0);
            CPH.Wait(5);
        }

        // wait two seconds before starting skyrim meme
        CPH.Wait(TWO_SECONDS);
        CPH.ObsShowSource(PANIC_SCENE, SKYRIM);
        // wait for meme to finish, then hide it and the white screen
        CPH.Wait(FORTY_SECONDS);
        CPH.ObsHideSource(PANIC_SCENE, SKYRIM);
        CPH.ObsHideSource(PANIC_SCENE, WHITE_SCREEN);
        CPH.ObsSetColorSourceColor(PANIC_SCENE, WHITE_SCREEN, MAX_COLOR_VALUE, MAX_COLOR_VALUE, MAX_COLOR_VALUE, MAX_COLOR_VALUE);
        // return to original scene
        CPH.ObsSetScene(scene);
        CPH.SendMessage("Sheesh, are y'all good now? Did you get it all out?");
        // reset meter
        reset();
    }

    // Set scene sources to correctly disply 
    private void setSceneText(double percentPanic)
    {
        String panicLevel = getPanicLevel(percentPanic);
        String previousLevel = CPH.GetGlobalVar<String>(PREVIOUS_LEVEL);
        CPH.ObsShowSource(PANIC_SCENE, panicLevel);
        CPH.ObsHideSource(PANIC_SCENE, previousLevel);
        CPH.ObsSetGdiText(PANIC_SCENE, panicLevel, GAY_PANIC_TEXT + percentPanic.ToString("#.##") + "%");
        if (percentPanic == 69)
        {
            CPH.PlaySound(FILE_PATH + "Michael Rosen - (just) _click_ Nice.mp3");
            CPH.Wait(THREE_SECONDS);
            return;
        }

        if (percentPanic == 95)
        {
            CPH.PlaySound(FILE_PATH + "untouchedOpening.mp3");
            CPH.Wait(THREE_SECONDS);
            return;
        }
    }

    // find appropiate panic levels based off percent chat has reached
    private String getPanicLevel(double percentPanic)
    {
        if (percentPanic >= PANIC_INCREMENT * PANIC_HIGHER)
        {
            CPH.SetGlobalVar(CURRENT_LEVEL, HIGHEST);
            CPH.SetGlobalVar(PREVIOUS_LEVEL, HIGHER);
            return HIGHEST;
        }

        if (percentPanic >= PANIC_INCREMENT * PANIC_HIGHER)
        {
            CPH.SetGlobalVar(CURRENT_LEVEL, HIGHER);
            CPH.SetGlobalVar(PREVIOUS_LEVEL, HIGH);
            return HIGHER;
        }

        if (percentPanic >= PANIC_INCREMENT * PANIC_HIGH)
        {
            CPH.SetGlobalVar(CURRENT_LEVEL, HIGH);
            CPH.SetGlobalVar(PREVIOUS_LEVEL, MEDIUM);
            return HIGH;
        }

        if (percentPanic >= PANIC_INCREMENT * PANIC_MEDIUM)
        {
            CPH.SetGlobalVar(CURRENT_LEVEL, MEDIUM);
            CPH.SetGlobalVar(PREVIOUS_LEVEL, LOW);
            return MEDIUM;
        }

        if (percentPanic >= PANIC_INCREMENT * PANIC_LOW)
        {
            CPH.SetGlobalVar(CURRENT_LEVEL, LOW);
            CPH.SetGlobalVar(PREVIOUS_LEVEL, LOWER);
            return LOW;
        }

        if (percentPanic >= PANIC_INCREMENT * PANIC_LOWER)
        {
            CPH.SetGlobalVar(CURRENT_LEVEL, LOWER);
            CPH.SetGlobalVar(PREVIOUS_LEVEL, LOWEST);
            return LOWER;
        }

        CPH.SetGlobalVar(CURRENT_LEVEL, LOWEST);
        CPH.SetGlobalVar(PREVIOUS_LEVEL, MAXED);
        return LOWEST;
    }

    // after waiting a period of time, reset the chat panic scene
    private void reset()
    {
        //CPH.Wait(WAIT_TIMER);
        // reset global variable
        CPH.SetGlobalVar(COLLECTIVE_GAY_PANIC, 0);
		
        // grab lowest and previous panic levels
        String panicLevel = getPanicLevel(0);
        String previousLevel = CPH.GetGlobalVar<String>(PREVIOUS_LEVEL);
		
        // reset sources
        CPH.ObsSetGdiText(PANIC_SCENE, panicLevel, GAY_PANIC_TEXT + "0%");
        CPH.ObsShowSource(PANIC_SCENE, panicLevel);
        CPH.ObsHideSource(PANIC_SCENE, previousLevel);
    }

    private void increaseChatterPanic(int panicVal, String chatter)
    {
        chatterPanic = CPH.GetGlobalVar<Dictionary<String, int>>(CHAT_DICTIONARY);
        /*if (chatterPanic == null || chatterPanic.Count == 0)
        {
            chatterPanic = new Dictionary<String, int>();
            chatterPanic.Add(chatter, panicVal);
            CPH.SendMessage("@" + chatter + " is starting to feel the gay panic at " + panicVal.ToString() + "%");
            CPH.PlaySound(FILE_PATH + "queer/Hello I'm queer - Everybody Loves Raymond .mp3");
            CPH.SetGlobalVar(CHAT_DICTIONARY, chatterPanic);
            return;
        }*/
        // if new chatter, their journey begins
        if ((chatterPanic ??= new Dictionary<String, int>()).ContainsKey(chatter))
        {
            chatterPanic.Add(chatter, panicVal);
            CPH.SendMessage("@" + chatter + " is starting to feel the gay panic at " + panicVal.ToString() + "%");
            CPH.PlaySound(FILE_PATH + "queer/Hello I'm queer - Everybody Loves Raymond .mp3");
            CPH.SetGlobalVar(CHAT_DICTIONARY, chatterPanic);
            return;
        }

        // otherwise increase individual chatter gay panic value
        chatterPanic[chatter] += panicVal;
        // individual chatter action and reset
        if (chatterPanic[chatter] >= 100)
        {
            CPH.SendMessage("@" + chatter + "'s gay panic is too much. Bless your lil' gay heart.");
            // can add sounds and actions for individual chatter panic
            CPH.PlaySoundFromFolder(FILE_PATH + "bonk");
            // reset chatter panic
            chatterPanic[chatter] = 0;
            CPH.SetGlobalVar(CHAT_DICTIONARY, chatterPanic);
            return;
        }

        if (chatterPanic[chatter] == 69)
        {
            // play a gay panic sound
            CPH.PlaySoundFromFolder(FILE_PATH + "degenerate");
            CPH.Wait(THREE_SECONDS);
        }

        // otherwise increase chatter's gay panic
        CPH.SendMessage("@" + chatter + "'s gay panic is on the rise and currently at: " + chatterPanic[chatter].ToString() + "%.");
        CPH.SetGlobalVar(CHAT_DICTIONARY, chatterPanic);
    }
}
