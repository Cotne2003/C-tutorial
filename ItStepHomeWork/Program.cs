Console.WriteLine(AbbrevName("tsotne basiashvili"));

string AbbrevName(string name)
{
	string[] newArr = name.ToUpper().Split(" ");
	string newStr = $"{newArr[0][0]}.{newArr[1][0]}";
	return newStr;
}