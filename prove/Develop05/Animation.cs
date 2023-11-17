using System;
using System.IO;

namespace EternalGoal {
    public class Animation {
        private List<List<string>> _listOfList;
        private List<string> _coloredBalls = new() {
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
        private List<string> _coloredCrosses = new() {
            $@"
            ****************
            *******  *******
            *******  *******
            ****        ****
            *******  *******
            *******  *******
            ****************",
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
            ****************",
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
            ****************",
            $@"
            ****************
            *      **      *
            *      **      *
            *   ***  ***   *
            *      **      *
            *      **      *
            ****************"
        };

        private List<string> _coloredWaves = new() {
            $@"
            ****************
            **** **  *** ***
            *** **  *** ****
            ** **  *** *****
            ** **  *** *****
            *** **  *** ****
            ****************",
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
            ****************",
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
            ****************",
            $@"
            ****************
            *** ***  ** ****
            **** ***  ** ***
            ***** ***  ** **
            ***** ***  ** **
            **** ***  ** ***
            ****************"
        };

        private List<string> _coloredSquare = new() {
            $@"
            ********************************
            *             ******************
            *             ******************
            **************             *****
            **************             *****
            ********************************
            ******************             *
            ******************             *
            ********************************
            ***************             ****
            ***************             ****
            *              *****************
            *              *****************
            ********************************",
            $@"
            ********************************
            ***************             ****
            ***************             ****
            *              *****************
            *              *****************
            ********************************
            ******************             *
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
            **************             *****
            **************             *****
            ********************************
            ******************             *
            ******************             *
            ********************************
            ***************             ****
            ***************             ****
            *              *****************
            *              *****************
            ********************************",
            $@"
            ********************************
            ***************             ****
            ***************             ****
            *              *****************
            *              *****************
            ********************************
            ******************             *
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
            **************             *****
            **************             *****
            ********************************
            ******************             *
            ******************             *
            ********************************
            ***************             ****
            ***************             ****
            *              *****************
            *              *****************
            ********************************",
            $@"
            ********************************
            ***************             ****
            ***************             ****
            *              *****************
            *              *****************
            ********************************
            ******************             *
            ******************             *
            ********************************
            *             ******************
            *             ******************
            **************             *****
            **************             *****
            ********************************"
        };
        private List<string> _colorString = new() {
            "Blue", "Yellow", "Red", 
            "Green", "Cyan", "Gray",
            "DarkBlue","DarkGray", "DarkCyan", 
            "DarkYellow"
        };
        public List<List<string>> GetAnimation() {
            _listOfList.Add(_coloredSquare);
            _listOfList.Add(_coloredWaves);
            _listOfList.Add(_coloredBalls);
            _listOfList.Add(_coloredCrosses);
            return _listOfList;
        }
         public List<string> GetColors() {
            return _colorString;
        }
        // public Animation(List<string> colorAnim) {
        //     _coloredShapes = colorAnim;
        // }
        // public List<string> GetColors() {
        //     return _colorString;
        // }
        public void AnimateShapes(List<string> shapes, List<string> colors, int x = 50, int y = 50) {
            Random randomX = new Random();
            int xCoord = randomX.Next(x);

            Random randomY = new Random();
            int yCoord = randomY.Next(y);

            string strShape = GenerateRandomShape(shapes);
            string colorType = GenerateRandomColor(colors);

            Console.CursorVisible = false;
            for (int i = 0; i < 6; i++) {
                Console.Clear();
                Console.SetCursorPosition(xCoord, yCoord);
                Console.ForegroundColor =(ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorType,true);
                Console.WriteLine(strShape);
            }
            Console.CursorVisible = true;
        }
        public string GenerateRandomShape(List<string> shapes, int z = 3) {
            Random randomX = new Random();
            int index = randomX.Next(z);
            string shapeAnimation = shapes[index];
            return shapeAnimation;
        }
        public string GenerateRandomColor(List<string> color, int x = 9) {
            Random randomX = new Random();
            int index = randomX.Next(x);
            string colorType = color[index];
            return colorType;
        }
    }
}