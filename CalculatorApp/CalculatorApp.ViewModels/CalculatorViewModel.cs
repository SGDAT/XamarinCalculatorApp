using CalculatorApp.ViewModels.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CalculatorApp.ViewModels
{
    public class CalculatorViewModel : INotifyPropertyChanged
    {
        
        public CalculatorViewModel()
        {
            _number = "0";
            Operands = new List<string>();
        }

        string _number { get; set; }
        public string Number {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                OnPropertyChanged();
            }
        }

        string _allOperands { get; set; }
        public string AllOperands
        {
            get
            {
                return _allOperands;
            }
            set
            {
                _allOperands = value;
                OnPropertyChanged();
            }
        }


        List<string> _operands { get; set; }
        public List<string> Operands
        {
            get
            {
                return _operands;
            }
            set
            {
                _operands = value;
                //OnPropertyChanged();
            }
        }

        public Command PointCommand
        {
            get
            {

                return new Command(() => { Number = NumberPadExtensions.AppendPoint(Number); });
            }

        }

        private void Operation(string operation)
        {
            if (Number != "0")
            {
                Operands.Add(Number);
                Operands.Add(operation);
                Number = "0";
                AllOperands = string.Join(" ", Operands);
            }
        }

        public Command AddCommand
        {
            get
            {
                return new Command(() =>
                {
                    Operation("+");
                });
            }
        }

        public Command SubtractCommand
        {
            get
            {
                return new Command(() =>
                {
                    Operation("-");
                });
            }
        }

        public Command DivideCommand
        {
            get
            {
                return new Command(() =>
                {
                    Operation("/");
                });
            }
        }

        public Command MultiplyCommand
        {
            get
            {
                return new Command(() =>
                {
                    Operation("*");
                });
            }
        }

        public Command EqualsCommand
        {
            get
            {
                return new Command(() => {
                    Operands.Add(Number);
                    float result = 0;
                    string operation = string.Empty;
                    foreach(string operand in Operands)
                    {
                        switch (operand)
                        {
                            default:
                                if (operation == string.Empty)
                                {
                                    result = float.Parse(operand);
                                    break;
                                }
                                result = SubResult(operand, operation, result);
                                break;

                            case "+":
                            case "-":
                            case "*":
                            case "/":
                                operation = operand;
                                break;
                        }
                    }
                    Number = result.ToString();

                    Operands.Clear();
                    AllOperands = string.Empty;
                    
                });
            }

        }

        private float SubResult(string operandNum, string operation, float result)
        {
            switch (operation)
            {
                default:
                    break;

                case "+":
                    result += float.Parse(operandNum);
                    break;
                case "-":
                    result -= float.Parse(operandNum);
                    break;
                case "*":
                    result *= float.Parse(operandNum);
                    break;
                case "/":
                    result /= float.Parse(operandNum);
                    break;
            }

            return result;
        }

        public Command ClearCommand
        {
            get
            {
                return new Command(() => {
                    Number = "0";
                    Operands.Clear();
                    AllOperands = string.Empty;
                });
            }
        }

        public Command NumberPad0Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "0"); });
            }
        }

        public Command NumberPad1Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "1"); });
            }
        }

        public Command NumberPad2Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "2"); });
            }
        }

        public Command NumberPad3Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "3"); });
            }
        }

        public Command NumberPad4Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "4"); });
            }
        }

        public Command NumberPad5Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "5"); });
            }
        }

        public Command NumberPad6Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "6"); });
            }
        }

        public Command NumberPad7Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "7"); });
            }
        }

        public Command NumberPad8Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "8"); });
            }
        }

        public Command NumberPad9Command
        {
            get
            {
                return new Command(() => { Number = NumberPadExtensions.AppendNumber(Number, "9"); });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}