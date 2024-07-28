// decimal price = 67.55m;
// decimal salePrice = 59.99m;

// string yourDiscount = String.Format("You saved {0:C2} off the regular {1:C2} price. ", (price - salePrice), price);

// yourDiscount += $"A discount of {((price - salePrice) / price):P2}!"; //inserted
// Console.WriteLine(yourDiscount);

// int invoiceNumber = 1201;
// decimal productShares = 25.4568m;
// decimal subtotal = 2750.00m;
// decimal taxPercentage = .15825m;
// decimal total = 3185.19m;

// Console.WriteLine($"Invoice Number: {invoiceNumber}");
// Console.WriteLine($"   Shares: {productShares:N3} Product");
// Console.WriteLine($"     Sub Total: {subtotal:C}");
// Console.WriteLine($"           Tax: {taxPercentage:P2}");
// Console.WriteLine($"     Total Billed: {total:C}");

// string input = "Pad this";
// Console.WriteLine(input.PadRight(12));

// Console.WriteLine(input.PadLeft(12, '-'));
// Console.WriteLine(input.PadRight(12, '-'));

// string paymentId = "769C";
// string payeeName = "Mr. Stephen Ortega";
// string paymentAmount = "$5,000.00";

// var formattedLine = paymentId.PadRight(6);
// formattedLine += payeeName.PadRight(24);
// formattedLine += paymentAmount.PadLeft(10);

// Console.WriteLine("1234567890123456789012345678901234567890");
// Console.WriteLine(formattedLine);

string customerName = "Ms. Barros";

string currentProduct = "Magic Yield";
int currentShares = 2975000;
decimal currentReturn = 0.1275m;
decimal currentProfit = 55000000.0m;

string newProduct = "Glorious Future";
decimal newReturn = 0.13125m;
decimal newProfit = 63000000.0m;

// Your logic here

Console.WriteLine("Dear {0},", customerName);
Console.WriteLine("As a customer of our {0} offering we are excited to tell you about a new financial product that would dramatically increase your return.\n", currentProduct);
Console.WriteLine("Currently, you own {0:N} shares at a return of {1:P}.\n", currentShares, currentReturn);
Console.WriteLine("Our new product, {0} offers a return of {1:P}  Given your current volume, your potential profit would be {2:C}.\n", newProduct, newReturn, newProfit);

Console.WriteLine("Here's a quick comparison:\n");

string comparisonMessage = string.Format("{0}\t{1:P}\t{2:N}\n{3}\t{4:P}\t{5:P}", currentProduct, currentReturn, currentProfit, newProduct, newReturn, newProfit);

// Your logic here

Console.WriteLine(comparisonMessage);