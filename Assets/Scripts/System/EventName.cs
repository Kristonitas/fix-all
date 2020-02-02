using System.Collections.Generic;
using System.Linq;

public class EventName
{
    public class UI
    {
        public static string CardCreated() { return "UI_ShowNextCard"; }
        public static string ShowNextCard() { return "UI_ShowNextCard"; }
        public static string ShowResult() { return "UI_ShowResult"; }
        public static string ShowPostScreen() { return "UI_ShowPostScreen"; }
        public static List<string> Get() { return new List<string> { CardCreated(), ShowNextCard(), ShowPostScreen() }; }
    }
    /*     public class Editor
        {
            public static string None() { return null; }
            public static List<string> Get() { return new List<string> { None() }; }
        } */
    public class Input
    {
        public class Swipe
        {
            public static string Start() { return "Swipe_Start"; }//unused
            public static string FinishLeft() { return "Swipe_FinishLeft"; }
            public static string FinishRight() { return "Swipe_FinishRight"; }
            public static string Cancel() { return "Swipe_Cancel"; }//unused
            public static List<string> Get() { return new List<string> { Start(), FinishLeft(), FinishRight(), Cancel() }; }
        }
        public class Tap
        {
            public static string Left() { return "Tap_Left"; }//unused
            public static string Right() { return "Tap_Right"; }//unused
            public static List<string> Get() { return new List<string> { Left(), Right() }; }
        }
        /*         public class Network{
                    public static string View() { return "View"; }
                    public static string PlayerJoined() { return "PlayerJoined"; }
                    public static string PlayerLeft() { return "PlayerLeft"; }
                    public static List<string> Get() { return new List<string> {View(), PlayerJoined(),PlayerLeft() }; }
                } */
        public static string CardSelected() { return "Input_CardSelected"; }
        public static string PlayerName() { return "Input_PlayerName"; }
        public static string StartGame() { return "StartGame"; }
        public static string ResetGame() { return "ResetGame"; }
        public static List<string> Get()
        {
            return new List<string> {
            StartGame(),PlayerName(),ResetGame()
            }.Concat(Swipe.Get())
//.Concat(SheepUpgrade.Get())
.Concat(Tap.Get())
//.Concat(Network.Get())
.ToList();
        }
    }
    public class System
    {
        public class Economy
        {
            public static string ModifyResource() { return "Economy_ModifyResource"; }
            public static string ResourceChanged() { return "Economy_ResourceChanged"; }
            public static List<string> Get() { return new List<string> { ModifyResource() }; }
        }
        public class Story
        {
            public static string UnlockEnding() { return "System_Story_UnlockEnding"; }//unused
            public static List<string> Get() { return new List<string> { UnlockEnding() }; }
        }
        public static string MatchStarted() { return "MatchStarted"; }
        public static string EndGame() { return "EndGame"; }
        public static List<string> Get()
        {
            return new List<string>
            {
                EndGame(),MatchStarted()
                //NextScene(), LoadScene(),s
                //SceneLoaded()
            }.Concat(Economy.Get()).Concat(Story.Get()).ToList();
        }
    }
    /*     public class AI
        {
            public static string None() { return null; }
            public static List<string> Get() { return new List<string> { None() }; }
        } */
    /*     public class PCTest{
            public static string SwitchFakeController() {return "SwitchFakeController";}
            public static List<string> Get() { return new List<string> {
            SwitchFakeController()}.ToList();    }
        } */
    public static List<string> Get()
    {
        return new List<string> { }.Concat(UI.Get())
                                    //.Concat(Editor.Get())
                                    .Concat(Input.Get())
                                    .Concat(System.Get())
                                    //.Concat(AI.Get())
                                    //.Concat(PCTest.Get())
                                    .Where(s => !string.IsNullOrEmpty(s)).Distinct().ToList();
    }
}