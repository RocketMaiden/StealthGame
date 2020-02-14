namespace Assets.MVC.Scripts.Ground.Model
{
    public class FieldStorage
    {
        private static FieldModel _field;       

        public static void UpdateField(FieldModel fieldModel)
        {
            _field = fieldModel;
        }

        public static FieldModel GetField()
        {
            return _field;
        }

    }  
}
