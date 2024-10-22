using FieldValidatorAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMembersshipApplication.FieldValidators
{
	public class UserRegistrationValidator : IFieldValidator
	{
		const int FirstName_Min_Length = 2;
		const int FirstName_Max_Length = 100;
		const int LastName_Min_Length = 2;
		const int LastName_Max_Length = 100;

		delegate bool EmailExistsDel(string emailAddress);

		FieldValidatorDel _fieldValidatorDel = null;

		RequiredValidDel _requiredValidDel = null;
		StringLengthValidDel _stringLengthValidDel = null;
		DateValidDel _dateValidDel = null;
		PatternMatchValidDel _patternMatchValidDel = null;
		CompareFieldsValidDel _compareFieldsValidDel = null;

		EmailExistsDel _emailExistsDel = null;

		string[] _fieldArray = null;

		public string[] FieldArray
		{
			get
			{
				if (_fieldArray == null)
					_fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationField)).Length];
				return _fieldArray;
			}
		}

		public FieldValidatorDel ValidatorDel => _fieldValidatorDel;

		public void InitialiseValidatorDelegates()
		{
			throw new NotImplementedException();
		}
	}
}
