using System;

namespace FlightSimulator
{
    public class ConsoleUi : IApplicationUi
    {
        private readonly string[] _positions = new string[7];
        private int _currentPosition = 2;
        private readonly string _skyView = "****************************************\r\n" +
                                          "*      {0}             __   _            *\r\n" +
                                          "*      {1}           _(  )_( )_          *\r\n" +
                                          "*      {2}          (_   _    _)         *\r\n" +
                                          "*      {3}            (_) (__)           *\r\n" +
                                          "*      {4}                               *\r\n" +
                                          "*      {5}                               *\r\n" +
                                          "*      {6}                               *\r\n" +
                                          "****************************************\r\n";

        private readonly string _controlsMenu = "         Controls           \r\n" +
                                                "                            \r\n" +
                                                "         ↑   - Fly up       \r\n" +
                                                "         ↓   - Fly down     \r\n" +
                                                "         Esc - Quit         \r\n";
        public void RenderView()
        {
            for (var i = 0; i < _positions.Length; i++)
            {
                _positions[i] = (i == _currentPosition) ? "►" : " ";
            }



            Console.WriteLine(_skyView, _positions);
        }

        public void ClearView()
        {
            Console.Clear();
        }

        public void RenderControls()
        {
            Console.WriteLine(_controlsMenu);
        }

        public int GetUserControlOption()
        {
            do
            {
                var keyOption = Console.ReadKey();

                switch (keyOption.Key)
                {
                    case ConsoleKey.UpArrow:
                        return 1;
                    case ConsoleKey.DownArrow:
                        return 2;
                    case ConsoleKey.Escape:
                        return 3;
                }
            } while (true);
        }

        public void FlyUp()
        {
            _currentPosition = Math.Max(0, _currentPosition - 1);
        }

        public void FlyDown()
        {
            _currentPosition = Math.Min(_positions.Length - 1, _currentPosition + 1);
        }
    }
}
