using System;
using System.IO;
namespace FinancialPrudence {
    public static class Animation {
        private static string _welcomeMessage = 
            $@" 
            /**   *  /**  *****  /**  *****   ******  **********   *****     
            /**  *** /** **///** /** **///** **////**//**//**//** **///**    
            /** **/**/**/******* /**/**  // /**   /** /** /** /**/*******    
            /**** //****/**////  /**/**   **/**   /** /** /** /**/**////     
            /**/   ///**//****** ***//***** //******  *** /** /**//******    
            //       //  ////// ///  /////   //////  ///  //  //  //////     
                                    **                                    
                                    /**                                    
                                    ******  ******                          
                                    ///**/  **////**                         
                                    /**  /**   /**                         
                                    /**  /**   /**                         
                                    //** //******                          
                                    //   //////                           
            ******** **                                     **            **
            /**///// //                                     //            /**
            /**       ** *******   ******   *******   *****  **  ******   /**
            /******* /**//**///** //////** //**///** **///**/** //////**  /**
            /**////  /** /**  /**  *******  /**  /**/**  // /**  *******  /**
            /**      /** /**  /** **////**  /**  /**/**   **/** **////**  /**
            /**      /** ***  /**//******** ***  /**//***** /**//******** ***
            //       // ///   //  //////// ///   //  /////  //  //////// /// 
            *******                      **                                 
            /**////**                    /**                                 
            /**   /** ****** **   **     /**  *****  *******   *****   ***** 
            /******* //**//*/**  /**  ****** **///**//**///** **///** **///**
            /**////   /** / /**  /** **///**/******* /**  /**/**  // /*******
            /**       /**   /**  /**/**  /**/**////  /**  /**/**   **/**//// 
            /**      /***   //******//******//****** ***  /**//***** //******
            //       ///     //////  //////  ////// ///   //  /////   ////// "
        ;
        // Various colors held in string array
        private static string[] _colorString = new string[10]{
            "Blue", "Yellow", "Red", 
            "Green", "Cyan", "Gray",
            "DarkBlue","DarkGray", "DarkCyan", 
            "DarkYellow"
        };
        private static string[] GetColors() {
            return _colorString;
        }
        private static string GetGreeting() {
            return _welcomeMessage;
        }
        private static string GoodBye() {
            return _frame;
        }
        public static void AnimateShapes() {
            var greetings = GetGreeting();
            var colors = GetColors();
            for (int i = 0; i < 10; i++) {
                Random random1 = new Random();
                int index1 = random1.Next(9);
                string colorType = colors[index1];

                Console.Clear();
                Console.SetCursorPosition(20,10);
                Console.ForegroundColor =(ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorType,true);
                Console.WriteLine(greetings);
                Thread.Sleep(600);
                Console.Clear();
            }
            // Resets color to system default after animation
            Console.ResetColor();
            // Makes cursor visible after animation
            Console.CursorVisible = true;
            
        }
        public static void AnimateGoodbye() {
            var greetings = GoodBye();
            var colors = GetColors();
            for (int i = 0; i < 7; i++) {
                Random random1 = new Random();
                int index1 = random1.Next(9);
                string colorType = colors[index1];

                Console.Clear();
                Console.SetCursorPosition(20,10);
                Console.ForegroundColor =(ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorType,true);
                Console.WriteLine(greetings);
                Thread.Sleep(400);
                Console.Clear();
            }
            // Resets color to system default after animation
            Console.ResetColor();
            // Makes cursor visible after animation
            Console.CursorVisible = true;
            
        }
        public static string _frame = 
            $@"
            .--..--..--..--..--..--..--..--..--..--..--..--..--..--..--..--.
            / .. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \.. \
            \ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/ /
            \/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/
            / /\/ /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /`' /\/ /\\/
            / /\ \/`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'\ \/\ \
            \ \/\ \                                                    /\ \/ /
            \/ /\ \                  Thank You For                     / /\/ /
            / /\/ /                                                    \ \/ /\
            / /\ \/                      Using                         \ \/\ \
            \ \/\ \                                                    /\ \/ /
            \/ /\ \                                                    / /\/ /
            / /\/ /                Financial Prudence                  \ \/ /\
            / /\ \/                                                    \ \/\ \
            \ \/\ \.--..--..--..--..--..--..--..--..--..--..--..--..--./\ \/ /
            \/ /\/ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ ../ /\/ /\/
            / /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\/ /\\/
            / /\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \/\ \
            \ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `'\ `' /
            `--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'`--'";
    }
}