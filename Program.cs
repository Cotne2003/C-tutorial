string permission = "Admin|Manager";
int level = 19;

Console.WriteLine(permission.Contains("Admin") && level > 55 ? "Welcome, Admin User" : permission.Contains("Manager") && level >= 20 ? "Contact an Admin for acces" : permission.Contains("Manager") && level < 20 ? "You do not have sufficient privileges" : !permission.Contains("Admin|Manager") ? "You do not have sufficient privileges" : "hehe");