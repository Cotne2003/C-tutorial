using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FieldValidatorAPI
{
	public delegate bool RequiredValidDel(string fieldVal);
	public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
	public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
	public delegate bool PatternMatchValidDel(string fieldVal, string pattern);
	public delegate bool CompareFieldsValidDel(string fieldVal, string fieldValCompare);
	public class CommonFieldValidatorFunctions
	{
		private static RequiredValidDel _requiredValidDel = null;
		private static StringLengthValidDel _stringLengthValidDel = null;
		private static DateValidDel _dateValidDel = null;
		private static PatternMatchValidDel _patternMatchValidDel = null;
		private static CompareFieldsValidDel _compareFieldsValidDel = null;

		private static bool RequiredValidDel(string fieldVal)
		{
			if (!string.IsNullOrEmpty(fieldVal))
				return true;

			return false;

		}

		private static bool StringLengthValidDel(string fieldVal, int min, int max)
		{
			if(fieldVal.Length >= min && fieldVal.Length <= max)
				return true;

			return false;

		}

		private static bool DateValidDel(string dateTime, out DateTime validDateTime)
		{
			if (DateTime.TryParse(dateTime, out validDateTime))
				return true;

			return false;

		}
	}
}
