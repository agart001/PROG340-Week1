using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PROG340_Week1.Utility;

namespace PROG340_Week1
{
    public class Game
    {
        public string Title = "The Path";

        public string TitleASCII = @"
  _______ _              _____      _   _     
 |__   __| |            |  __ \    | | | |    
    | |  | |__   ___    | |__) |_ _| |_| |__  
    | |  | '_ \ / _ \   |  ___/ _` | __| '_ \ 
    | |  | | | |  __/   | |  | (_| | |_| | | |
    |_|  |_| |_|\___|   |_|   \__,_|\__|_| |_|
                                              
                                              
";

        public Player PC = new Player();

        public List<Level> Levels { get; set; }

        public Game() 
        {
            Levels = CreateLevels();
        }

        public List<Level> CreateLevels()
        {
            List<Level> levels = new List<Level>
            {
                new Level()
                {
                    //Image Source: https://stock.adobe.com/search?k=three+roads&asset_id=67005743 -- "Road with three ways" by andrew7726
                    ASCIIArt = @"                      &&                     
                    (&&&&.                   
&&&&&&,            &&&&&&&&            *&&&&&
     /&&&&&&&/&&&&&&&&&&&&&&&&&&/&&&&&&&/    
            ,&&&&&&&&&&&&&&&&&&&&            
              &&&&&&&%&%&&&&&&&#             
            &&&%&&%%%%%%%%%%&&&&&(           
           .&&&&&&%&&&%&%&&&%&&&&&.          
         &&&&&%&%&&&%&%%&%&&&&%&&&&&&        
        .&%%&&%&&&&&&%&&%&@%&@&&&&&@&.       ",
                    Question = $" You come to a fork in the path.{Environment.NewLine} Which direction will you go?",
                    TrueAnswer = 1,
                    Answers = new string[] 
                    { 
                        "Left.", 
                        "Middle.", 
                        "Right." 
                    },
                    Responses = new string[] 
                    { 
                        " The path ends. Discourgaed, you head home.", 
                        " The path continues and so does your journey.", 
                        " The path continues to a dark cave. You never see daylight again." 
                    }
                },
                new Level()
                {
                    //Image Source: https://www.istockphoto.com/photo/close-up-of-isolated-stub-log-with-wooden-texture-gm113592252-15897256 -- "Close-up of Isolated stub log with wooden texture stock photo" by vitalytitov
                    ASCIIArt = @"                                             
                                             
                                             
                                             
                                             
   /,%//*&(#*&(&%%&(,((#/,*/((%##/,///##(@%  
  &/.(%##(#((##*/(((((//%(*/#(&#((/*%%(#*%#  
  (#//(((%(&%%*%/,(#*%(/%%(#%//%#/%#@((##*(  
                  .,((   ....  .             
                                             
                                             
                                             
                                             ",
                    Question = $" You come to a fallen tree blocking the path.{Environment.NewLine} How will you cross it?",
                    TrueAnswer = 1,
                    Answers = new string[] 
                    {
                        "Go over it.", 
                        "Go under it.", 
                        "Go through it."
                    },
                    Responses = new string[]
                    {
                        " You vault over the tree, trip, and knock yourself out.", 
                        " You crawl under the tree and continue your journey.", 
                        " As you chop at the tree, your axe rebounds and knocks you out."
                    }
                }, 
                new Level()
                {
                    //Image Source: https://stock.adobe.com/search?k=cliff&asset_id=203071694 -- "Cliff stone isolated on white background" by kamonrat
                    ASCIIArt = @"                                             
                                             
                                             
                                             
                                             
            ((#(((#%###((#((#                
       (####%##%%##(((%&%%#%(                
 *#(##/%(####((##(#%%%&%%###%                
(((#(#((%#%##&%%%%#&%&###%%#                 
#%##(/((#%%&%#&##%#&##(####/                 
%##%###/#&%&%%(#%%####&&%%#                  
&%&&%&%%(%%%#%%#%##                          
%&#&&%%&#%%%%####                            
%&&&&&##%%#%#(#                              ",
                    Question = $" You come to the end of the path, a steep cliff heading straight down.{Environment.NewLine} How will you get down?",
                    TrueAnswer = 2,
                    Answers = new string[] 
                    {
                        "Jump.", 
                        "Free climb.", 
                        "Repel."
                    },
                    Responses = new string[]
                    {
                        " The wind rushes around. You feel weightless until potenial energy catches up.",
                        " The climb is intense. Your palms are sweaty and you slip. Mom's spahgetti.",
                        " Safetly tied off, you glide down with ease and assurance. You reach the bottom"
                    }
                }
            };

            return levels;
        }

        public void Start()
        {
            ConsoleSpacer();
            Print(TitleASCII, true, ConsoleColor.Cyan);
            ConsoleSpacer();

            if (BoolQuestion(" Want to play?", "y", "n")) ClearConsole(); Loop();
        }

        public void Loop()
        {
            ConsoleSpacer();
            Print(Levels[PC.Level].ASCIIArt, true, ConsoleColor.Cyan);
            ConsoleSpacer();

            Print($" Level: {PC.Level + 1} ---- Lives: {PC.Lives} ", true, ConsoleColor.Cyan);
            ConsoleSpacer();

            Levels[PC.Level].Loop();
            
            ConsoleSpacer();

            if (Levels[PC.Level].Completed)
            {
                PC.IncrementLevel();

                if (CheckWin()) return;

                if (BoolQuestion(" Want to continue?", "y", "n"))
                {
                    ClearConsole();
                    Loop();
                }
                else
                {
                    return;
                }
            }
            else
            {
                PC.DecrementLives();

                if (CheckLoss()) return;

                if (BoolQuestion(" Want to try again?", "y", "n"))
                {
                    ClearConsole();
                    Loop();
                }
                else
                {
                    return;
                }
            }
        }

        public bool CheckWin()
        {
            if (Levels.All(L => L.Completed == true))
            {
                string ASCIIWin = @"
          __          _______ _   _           
          \ \        / /_   _| \ | |          
  ______   \ \  /\  / /  | | |  \| |   ______ 
 |______|   \ \/  \/ /   | | | . ` |  |______|
             \  /\  /   _| |_| |\  |          
              \/  \/   |_____|_| \_|          
                                              
                                              
";
                ClearConsole();

                ConsoleSpacer();
                Print(ASCIIWin, true, ConsoleColor.Blue);
                ConsoleSpacer();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckLoss()
        {
            if(PC.Lives <= 0)
            {
                string ASCIILose = @"
           _       ____    _____  ______          
          | |     / __ \  / ____||  ____|         
  ______  | |    | |  | || (___  | |__     ______ 
 |______| | |    | |  | | \___ \ |  __|   |______|
          | |____| |__| | ____) || |____          
          |______|\____/ |_____/ |______|         
                                                  
                                                  
";
                ClearConsole();

                ConsoleSpacer();
                Print(ASCIILose, true, ConsoleColor.Magenta);
                ConsoleSpacer();
                return true;
            }
            return false;
        }
    }
}
