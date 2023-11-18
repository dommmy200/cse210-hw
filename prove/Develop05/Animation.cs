using System;
using System.IO;

namespace EternalGoal {
    public class Animation {
        private List<string[]> _listOfList = new List<string[]>(5);
        // Define string shape and held in an array as: _ballShapes, 
        // _crossShapes,_waveShapes and _squareShapes as shown below:
        private string[] _ballShapes = new string[6]{
            $@"
            ............
            .   oooo   .
            .   oooo   .
            ............",
            $@"
            ............
            .ooo    ooo.
            .ooo    ooo.
            ............",
            $@"
            ............
            .ooo oo ooo.
            .ooo oo ooo.
            ............",
            $@"
            ............
            .   ooo    .
            .    ooo   .
            ............",
            $@"
            ............
            .    ooo   .
            .   ooo    .
            ............",
            $@"
            ............
            .   oooo   .
            .   oooo   .
            ............"
        };
        private string[] _crossShapes = new string[6]{
            $@"
            ****************
            *******  *******
            *******  *******
            ****        ****
            *******  *******
            *******  *******
            ****************
            CONGRATULATIONS!",
            $@"
            ****************
            *      **      *
            *      **      *
            *   ***  ***   *
            *      **      *
            *      **      *
            ****************",
            $@"
            ****************
            *******  *******
            *******  *******
            ****        ****
            *******  *******
            *******  *******
            ****************
            CONGRATULATIONS!",
            $@"
            ****************
            *      **      *
            *      **      *
            *   ***  ***   *
            *      **      *
            *      **      *
            ****************",
            $@"
            ****************
            *******  *******
            *******  *******
            ****        ****
            *******  *******
            *******  *******
            ****************
            CONGRATULATIONS!",
            $@"
            ****************
            *      **      *
            *      **      *
            *   ***  ***   *
            *      **      *
            *      **      *
            ****************"
        };

        private string[] _waveShapes = new string[6]{
            $@"
            ****************
            **** **  *** ***
            *** **  *** ****
            ** **  *** *****
            ** **  *** *****
            *** **  *** ****
            ****************
            CONGRATULATIONS!",
            $@"
            ****************
            *** ***  ** ****
            **** ***  ** ***
            ***** ***  ** **
            ***** ***  ** **
            **** ***  ** ***
            ****************",
            $@"
            ****************
            **** **  *** ***
            *** **  *** ****
            ** **  *** *****
            ** **  *** *****
            *** **  *** ****
            ****************
            CONGRATULATIONS!",
            $@"
            ****************
            *** ***  ** ****
            **** ***  ** ***
            ***** ***  ** **
            ***** ***  ** **
            **** ***  ** ***
            ****************",
            $@"
            ****************
            **** **  *** ***
            *** **  *** ****
            ** **  *** *****
            ** **  *** *****
            *** **  *** ****
            ****************
            CONGRATULATIONS!",
            $@"
            ****************
            *** ***  ** ****
            **** ***  ** ***
            ***** ***  ** **
            ***** ***  ** **
            **** ***  ** ***
            ****************"
        };

        private string[] _squareShapes = new string[6]{
            $@"
            ********************************
            *             ******************
            *             ******************
            **************             *****
            *******       CONGRATULATIONS! *
            ********************************
            ******************             *
            ******************             *
            ********************************
            ***************             ****
            ***************             ****
            *              *****************
            *     CONGRATULATIONS!   *******
            ********************************",
            $@"
            ********************************
            ***************             ****
            ***************             ****
            * CONGRATULATIONS!    **********
            *              *****************
            ********************************
            *******       CONGRATULATIONS!**
            ******************             *
            ********************************
            *             ******************
            *             ******************
            **************             *****
            **************             *****
            ********************************",
            $@"
            ********************************
            *             ******************
            *             ******************
            ***   CONGRATULATIONS!    ******
            **************             *****
            ********************************
            ******************             *
            ******************             *
            ********************************
            ***************             ****
            **  CONGRATULATIONS!     *******
            *              *****************
            *              *****************
            ********************************",
            $@"
            ********************************
            ***************             ****
            ***************             ****
            *       CONGRATULATIONS!       *
            *              *****************
            ********************************
            ******************             *
            ******************             *
            ********************************
            *             ******************
            *             ******************
            **************             *****
            ****  CONGRATULATIONS!     *****
            ********************************",
            $@"
            ********************************
            *             ******************
            *             ******************
            **************             *****
            **************             *****
            **** CONGRATULATIONS!   ********
            ******************             *
            ******************             *
            ********************************
            ***************             ****
            ***************             ****
            *             CONGRATULATIONS! *
            *              *****************
            ********************************",
            $@"
            ********************************
            ***************             ****
            ***************             ****
            *           CONGRATULATIONS!   *
            *              *****************
            ********************************
            ******************             *
            ******************             *
            ********************************
            *             ******************
            *  CONGRATULATIONS!           **
            **************             *****
            **************             *****
            ********************************"
        };
        // Various colors held in string array
        private string[] _colorString = new string[10]{
            "Blue", "Yellow", "Red", 
            "Green", "Cyan", "Gray",
            "DarkBlue","DarkGray", "DarkCyan", 
            "DarkYellow"
        };
        // Method to get the list of string arrays
        public List<string[]> GetAnimation() {
            _listOfList.Add(_ballShapes);
            _listOfList.Add(_crossShapes);
            _listOfList.Add(_waveShapes);
            _listOfList.Add(_squareShapes);
            return _listOfList;
        }

        public string[] GetColors() {
            return _colorString;
        }
        // Animation Constructor
        public Animation(string[] colo) {
            _colorString = colo;
        }
        // The animation is processed by this method
        public void AnimateShapes(int x = 26, int y = 19, int z = 9) {
            string[] colors = GetColors();
            List<string[]> xxx = GetAnimation();
            // Makes cursor invisible during animation
            Console.CursorVisible = false;
            for (int i = 0; i < xxx.Count; i++) {
                Random random1 = new Random();
                int index1 = random1.Next(z);
                string colorType = colors[index1];

                Random random = new Random();
                int index = random.Next(4);
                string[] strShape = xxx[index];
   
                Random randomX = new Random();
                int xCoord = randomX.Next(1, x);

                Random randomY = new Random();
                int yCoord = randomY.Next(2, y+x);
                
                Console.Clear();
                Console.SetCursorPosition(xCoord, yCoord);
                // Color string is converted to ConsoleColor objects
                Console.ForegroundColor =(ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorType,true);
                Console.WriteLine(strShape[i]);
                Thread.Sleep(700);
                Console.Clear();
            }
            // Resets color to system default after animation
            Console.ResetColor();
            // Makes cursor visible after animation
            Console.CursorVisible = true;
        }
    }
}