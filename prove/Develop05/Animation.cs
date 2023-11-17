using System;
using System.IO;

namespace EternalGoal {
    public class Animation {
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
            ****************
            CONGRATULATIONS!",
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
            ****************
            CONGRATULATIONS!",
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
            ****************
            CONGRATULATIONS!"
        };

        private string[] _waveShapes = new string[6]{
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

        private string[] _squareShapes = new string[6]{
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
        private string[] _colorString = new string[10]{
            "Blue", "Yellow", "Red", 
            "Green", "Cyan", "Gray",
            "DarkBlue","DarkGray", "DarkCyan", 
            "DarkYellow"
        };
        // public List<List<string>> GetAnimation() {
        //     _listOfList.Add(_coloredSquare);
        //     _listOfList.Add(_coloredWaves);
        //     _listOfList.Add(_coloredBalls);
        //     _listOfList.Add(_coloredCrosses);
        //     return _listOfList;
        // }
        public string[] GetBallShape() {
            return _ballShapes;
        }
        public string[] GetCrossShape() {
            return _crossShapes;
        }
        public string[] GetSquareShape() {
            return _squareShapes;
        }
        public string[] GetWaveShape() {
            return _ballShapes;
        }

        public string[] GetColors() {
            return _colorString;
        }
        public Animation(string[] colo) {
            _colorString = colo;
        }
        // public List<string> GetColors() {
        //     return _colorString;
        // }
        public void AnimateShapes(string[] shapes, string[] colors, int x = 26, int y = 19) {
            

            string[] strShape = GenerateShape(shapes);

            Console.CursorVisible = false;
            for (int i = 0; i < strShape.Length; i++) {
                Random randomX = new Random();
                int xCoord = randomX.Next(1, x);

                Random randomY = new Random();
                int yCoord = randomY.Next(2, y+x);
                
                string colorType = GenerateRandomColor(colors);
                
                Console.Clear();
                Console.SetCursorPosition(xCoord, yCoord);
                Console.ForegroundColor =(ConsoleColor) Enum.Parse(typeof(ConsoleColor), colorType,true);
                Console.WriteLine(strShape[i]);
                Thread.Sleep(700);
                Console.Clear();
            }
            Console.ResetColor();
            Console.CursorVisible = true;
        }
        public string[] GenerateShape(string[] shapes, int z = 3) {
            // int count = 0;
            // while (count < 4) {
            //     Random random = new Random();
            //     int ind = random.Next(4);
                
            //     switch (ind){
            //             case 1:
            //                 string[] str1 = GetBallShape();
            //                 break;
            //             case 2:
            //                 string[] str2 = GetCrossShape();
            //                 break;
            //             case 3:
            //                 string[] str3 = GetSquareShape();
            //                 break;
            //             case 4:
            //                 string[] str4 = GetWaveShape();
            //                 break;
            //     }
            // }
            // for (int i = 0; i < shapes.Length; i++) {

            // }
            // Random randomX = new Random();
            // int index = randomX.Next(z);
            // string shapeAnimation = shapes[index];
            return shapes;
        }
        public string GenerateRandomColor(string[] color, int x = 9) {
            Random randomX = new Random();
            int index = randomX.Next(x);
            string colorType = color[index];
            return colorType;
        }
    }
}