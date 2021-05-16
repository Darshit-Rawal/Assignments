using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace jasminAndKarmaAssignment9
{
    class IsPartOfConstraint : Constraint
    {
        readonly int[] _expected;
        public IsPartOfConstraint(int[] expected)
        {
            _expected = expected;
            Description = $"Expected to be part of array.";
        }
        public override ConstraintResult ApplyTo<TActual>(TActual actual)
        {
            if (typeof(TActual) != typeof(int))
                return new ConstraintResult(this, actual, ConstraintStatus.Error);

            var actualInt = Convert.ToInt32(actual);

            var result = false;
            for (int i = 0; i < _expected.Length; i++)
            {
                if (_expected[i] == actualInt)
                {
                    result = true;
                    break;
                }
            }

            if (result == true)
                return new ConstraintResult(this, actual, ConstraintStatus.Success);
            else
                return new ConstraintResult(this, actual, ConstraintStatus.Failure);
        }
    }
}
