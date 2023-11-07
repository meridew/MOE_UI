namespace MOE_UI.ViewModels
{
    public class CriterionViewModel : BaseViewModel
    {
        string _field;
        public string Field
        {
            get => _field;
            set => SetProperty(ref _field, value);
        }

        string _operand;
        public string Operand
        {
            get => _operand;
            set => SetProperty(ref _operand, value);
        }

        string _value;
        public string Value
        {
            get => _value;
            set => SetProperty(ref _value, value);
        }

        public CriterionViewModel(string field, string operand, string value)
        {
            Field = field;
            Operand = operand;
            Value = value;
        }

        public override void ValidateProperty(string propertyName, object value)
        {
            base.ValidateProperty(propertyName, value);

            ClearError(propertyName);

            switch (propertyName)
            {
                case nameof(Field):
                    if (string.IsNullOrEmpty(Field))
                    {
                        AddError(propertyName, "Field is required.");
                    }
                    break;
                case nameof(Operand):
                    if (string.IsNullOrEmpty(Operand))
                    {
                        AddError(propertyName, "Operand is required.");
                    }
                    break;
                case nameof(Value):
                    if (string.IsNullOrEmpty(Value))
                    {
                        AddError(propertyName, "Value is required.");
                    }
                    break;
            }
        }
    }
}
