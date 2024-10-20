using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

		public static RequiredValidDel RequiredFieldValidDel
		{
			get
			{	
				if (_requiredValidDel == null)
					_requiredValidDel = new RequiredValidDel(RequiredValidDel);

				return _requiredValidDel;
			}
		}

		public static StringLengthValidDel StringLengthFieldValidDel
		{
			get
			{
				if (_stringLengthValidDel == null)
					_stringLengthValidDel = new StringLengthValidDel(StringLengthValidDel);

				return _stringLengthValidDel;
			}
		}

		public static DateValidDel DateFieldValidDel
		{
			get
			{
				if (_dateValidDel == null)
					_dateValidDel = new DateValidDel(DateValidDel);

				return _dateValidDel;
			}
		}

		public static PatternMatchValidDel PatternMatchFieldValidDel
		{
			get
			{
				if (_patternMatchValidDel == null)
					_patternMatchValidDel = new PatternMatchValidDel(PatternMatchValidDel);

				return _patternMatchValidDel;
			}
		}

		public static CompareFieldsValidDel FieldsCompareVaidDel
		{
			get
			{
				if (_compareFieldsValidDel == null)
					_compareFieldsValidDel = new CompareFieldsValidDel(FieldComparisonValid);

				return _compareFieldsValidDel;
			}
		}

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

		private static bool PatternMatchValidDel(string fieldVal, string regularExpressionPattern)
		{
			Regex regex = new Regex(regularExpressionPattern);

			if (regex.IsMatch(fieldVal))
				return true;

			return false;

		}

		private static bool FieldComparisonValid (string field1, string field2)
		{
			if (field1.Equals(field2))
				return true;

			return false;

		}
	}
}
