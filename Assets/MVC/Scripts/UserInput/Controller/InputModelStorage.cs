using Assets.MVC.Scripts.Ground.Model;

namespace Assets.MVC.Scripts.UserInput.Controller
{
    class InputModelStorage
    {

        private static Point _target;

        private static bool _isClicked;
        public static void SetTargetIndex(Point gridIndex)
        {            
            
            _target = gridIndex;
            _isClicked = true;
                        
        }
        public static Point PopTargetIndex()
        {
            _isClicked = false;
            return _target;
           
        }

        public static bool IsClicked()
        {
            return _isClicked;
        }

    }
}
