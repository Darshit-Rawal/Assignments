using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace jasminAndKarmaAssignment9
{
    class IsCapitalizeConstraint : Constraint
    {
        readonly string _expected;
        public IsCapitalizeConstraint(string expected)
        {
            _expected = expected.ConvertToCapitalize();
            Description = $"Expected is {expected}";
        }
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (typeof(TActual) != typeof(string))
                return new ConstraintResult(this, actual, ConstraintStatus.Error);
            if (_expected == actual.ToString())
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            else
                return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }

    public static class ExtensionMethods
    {
        public static string ConvertToCapitalize(this string input)
        {
            string[] stringsArray = input.Split(' ');
            string output = string.Empty;
            foreach (var item in stringsArray)
            {
                output += char.ToUpper(item[0]) + item.Substring(1) + " ";
            }
            return output.Substring(0, input.Length);
        }
    }
}
