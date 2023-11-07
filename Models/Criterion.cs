using MOE_UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOE_UI.Models
{
    public class Criterion : BaseViewModel
    {
        string _field;
        public string Field
        {
            get => _field; set => SetProperty(ref _field, value);
        }

        string _operand;
        public string Operand
        {
            get => _operand; set => SetProperty(ref _operand, value);
        }

        string _value;
        public string Value
        {
            get => _value; set => SetProperty(ref _value, value);
        }

        public Criterion(string field, string operand, string value)
        {
            Field = field;
            Operand = operand;
            Value = value;
        }
    }
}
