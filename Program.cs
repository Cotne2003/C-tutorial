// Console.WriteLine("Enter an integer value between 5 and 10");
// bool validNumber = false;
// do
// {
//     string? userCode = Console.ReadLine();
//     int numericValue;
//     if (int.TryParse(userCode, out numericValue))
//     {
//         if (numericValue > 5 && numericValue < 10)
//         {
//             validNumber = true;
//             Console.WriteLine($"Your input value ({numericValue}) has been accepted.");
//         }
//         else
//         {
//             Console.WriteLine($"You entered {numericValue}. Please enter a number between 5 and 10.");
//         }
//     }
//     else
//     {
//         Console.WriteLine("Sorry, you entered an invalid number, please try again");
//     }
// } while (validNumber == false);

// Console.WriteLine("Enter your role name (Administrator, Manager, or User)");
// bool validRole = false;
// do
// {
//     string? role = Console.ReadLine();
//     if (role != null)
//         role = role.Trim().ToLower();

//     {
//         if (role == "administrator" || role == "manager" || role == "user")
//         {
//             Console.WriteLine($"Your input value ({role}) has been accepted.");
//             validRole = true;
//         }
//         else
//             Console.WriteLine($"The role name that you entered, \"{role}\" is not valid. Enter your role name (Administrator, Manager, or User) Administrator");
//     }
// } while (validRole == false);


string[] myStrings = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
int periodLocation;
foreach (string myString in myStrings)
{
    if (myString.IndexOf(".") != -1)
    {
        periodLocation = myString.IndexOf(".");
        Console.WriteLine(myString.Substring(0, periodLocation));
        Console.WriteLine(myString.Substring(periodLocation, myString.Length - periodLocation));
        // do
        // {
        //     Console.WriteLine(myString.Substring(0, periodLocation));
        // } while (false);
    }
}