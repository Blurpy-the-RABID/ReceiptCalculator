using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptCalculator {
    class Program {
        static void Main(string[] args) {
            List aList = new List(); // This will store all of Andy's receipts.
            List vList = new List(); // This will store all of Vince's receipts.
            List mList = new List(); // This will store all of Mike's receipts.
            string addAnotherReceipt = "Y"; // This will control the for loop that adds additional receipts to this Receipt List.
            string receiptOwner = "X"; // This will store the first initial of this List's owner's name.
            Interface interFace = new Interface();

            Console.WriteLine("Welcome to the Receipt Calculator Program, written by Vincent Fantini.");
            Console.WriteLine("This calculator assumes that there are only (3) people who've submitted receipts:  Vince; Mike; and Andy.");
            Console.WriteLine("All receipts are to be sorted by the initial written on the top of each receipt.  The initial on each receipt corresponds to the person who paid for the items on the receipt.");
            Console.WriteLine("This program will assume that you have sorted all of the receipts into groups based on the initial written on the top of each receipt prior to using this program.");
            Console.WriteLine("If you haven't done this yet, then please do this now before proceeding.");

            while (aList.returnIsListComplete() == false || vList.returnIsListComplete() == false || mList.returnIsListComplete() == false) {
                Console.Write("\nWhose receipts will you be entering?  Enter the person's first initial ([A]ndy, [V]ince, [M]ike): ");
                receiptOwner = Console.ReadLine().ToUpper();
                bool loopInput = true;

                // Here's a while loop that I've come up with to keep the user from entering invalid input.  If the user types in something other than "A", "V", or "M", the program
                // will tell the user that their input is invalid, and it will ask them once again whose receipts will they be entering.
                while (loopInput == true) {
                    if (receiptOwner == "A" || receiptOwner == "V" || receiptOwner == "M") {
                        loopInput = false; // Since the user typed in valid input (A/V/M), we no longer need to repeat this while loop.  So first thing we do is set loopInput to "false".

                        while (receiptOwner == "A") {
                            if (aList.returnIsListComplete() == true) {
                                Console.Write("You've already entered all of Andrew's receipts.  Please enter either 'V' for Vince, or 'M' for Mike: ");
                                receiptOwner = Console.ReadLine().ToUpper();
                                loopInput = true;
                            }
                            else {
                                break;
                            }
                        }

                        while (receiptOwner == "V") {
                            if (vList.returnIsListComplete() == true) {
                                Console.Write("You've already entered all of Vince's receipts.  Please enter either 'A' for Andy, or 'M' for Mike: ");
                                receiptOwner = Console.ReadLine().ToUpper();
                                loopInput = true;
                            }
                            else {
                                break;
                            }
                        }
                        while (receiptOwner == "M") {
                            if (mList.returnIsListComplete() == true) {
                                Console.Write("You've already entered all of Mike's receipts.  Please enter either 'A' for Andy, or 'V' for Vince: ");
                                receiptOwner = Console.ReadLine().ToUpper();
                                loopInput = true;
                            }
                            else {
                                break;
                            }
                        }
                    }
                        // Here's where we deal with invalid input that the user gives us.
                    else if (receiptOwner != "A" || receiptOwner != "V" || receiptOwner != "M") {
                        Console.WriteLine("Invalid user input: {0}.  Please enter 'A' for Andy, 'V' for Vince, or 'M' for Mike.", receiptOwner);
                        Console.Write("\nWhose receipts will you be entering?  Enter the person's first initial ([A]ndy, [V]ince, [M]ike): ");
                        receiptOwner = Console.ReadLine().ToUpper();
                        loopInput = true;
                    }
                }

                addAnotherReceipt = "Y";
                // As long as the user answers "Y" to the last question in this for loop (i.e. to add another receipt to this List), this loop will create a new receipt and push it onto
                // the current Owner's List.
                for (int i = 1; addAnotherReceipt == "Y"; i++) {
                    Receipt receipt = interFace.getReceiptEntry(receiptOwner, i);

                    // Now that the user is satisfied with this receipt's information, we'll add this receipt to the current Receipt Owner's List.
                    switch (receiptOwner) {
                        case "A":
                            aList.addReceiptToList(receipt);
                            break;
                        case "V":
                            vList.addReceiptToList(receipt);
                            break;
                        case "M":
                            mList.addReceiptToList(receipt);
                            break;
                    }

                    // Now to ask the user if they wish to add another receipt to the current Receipt Owner's List...
                    Console.Write("Do you wish to add another Receipt to the {0} Receipt List? (y/n): ", receiptOwner);
                    addAnotherReceipt = Console.ReadLine().ToUpper();
                }

                // The last thing we do for each List is set the corresponding ListComplete boolean variable to true, set this List's Owner, and calculate the final totals for this List.
                // Once all three ListComplete booleans are set to "true," we will move onto displaying the lists and writing the results to a file.
                switch (receiptOwner) {
                    case "A":
                        aList.setIsListComplete(true);
                        aList.getListOwner(receiptOwner);
                        aList.calculateTotals();
                        break;
                    case "V":
                        vList.setIsListComplete(true);
                        vList.getListOwner(receiptOwner);
                        vList.calculateTotals();
                        break;
                    case "M":
                        mList.setIsListComplete(true);
                        mList.getListOwner(receiptOwner);
                        mList.calculateTotals();
                        break;
                    default:
                        Console.WriteLine("Invalid Receipt Owner Initial.  Cannot calculate receipt list totals.");
                        break;
                }
            }
            // Now that we've completed all three Receipt Lists, we'll give the user the opportunity to review & edit them before moving on.
            Console.Write("All (3) Receipt Lists are completed.  Would you like to review & edit them now before moving on? (y/n): ");
            string reviewReceipts = Console.ReadLine().ToUpper();
            if (reviewReceipts == "Y") {
                bool reviewAgain = true;
                while (reviewAgain == true) {
                    Console.Write("\nPlease specify whose Receipt List you wish to review (A/V/M): ");
                    string receiptListToReview = Console.ReadLine().ToUpper();
                    string editReceipt = "N";

                    switch (receiptListToReview) {
                        case "A":
                            aList.showAllReceipts();
                            Console.Write("Would you like to edit any of these receipts? (y/n): ");
                            editReceipt = Console.ReadLine().ToUpper();

                            if (editReceipt == "Y") {
                                Console.Write("Enter the number of the 'A' receipt you wish to edit (ex. 'A3'): A");
                                int receiptNumber = Convert.ToInt32(Console.ReadLine());
                                interFace.editReceiptEntry(aList, receiptNumber);
                            }

                            Console.Write("Would you like to review another list? (y/n): ");
                            reviewReceipts = Console.ReadLine().ToUpper();
                            if (reviewReceipts == "Y") {
                                reviewAgain = true;
                            }
                            else {
                                reviewAgain = false;
                            }
                            break;
                        case "V":
                            vList.showAllReceipts();

                            Console.Write("Would you like to edit any of these receipts? (y/n): ");
                            editReceipt = Console.ReadLine().ToUpper();

                            if (editReceipt == "Y") {
                                Console.Write("Enter the number of the 'V' receipt you wish to edit (ex. 'V3'): V");
                                int receiptNumber = Convert.ToInt32(Console.ReadLine());
                                interFace.editReceiptEntry(vList, receiptNumber);
                            }

                            Console.Write("Would you like to review another list? (y/n): ");
                            reviewReceipts = Console.ReadLine().ToUpper();
                            if (reviewReceipts == "Y") {
                                reviewAgain = true;
                            }
                            else {
                                reviewAgain = false;
                            }
                            break;
                        case "M":
                            mList.showAllReceipts();

                            Console.Write("Would you like to edit any of these receipts? (y/n): ");
                            editReceipt = Console.ReadLine().ToUpper();

                            if (editReceipt == "Y") {
                                Console.Write("Enter the number of the 'M' receipt you wish to edit (ex. 'M3'): M");
                                int receiptNumber = Convert.ToInt32(Console.ReadLine());
                                interFace.editReceiptEntry(mList, receiptNumber);
                            }

                            Console.Write("Would you like to review another list? (y/n): ");
                            reviewReceipts = Console.ReadLine().ToUpper();
                            if (reviewReceipts == "Y") {
                                reviewAgain = true;
                            }
                            else {
                                reviewAgain = false;
                            }
                            break;
                        default:
                            Console.WriteLine("Error:  Invalid user input.  Moving on...");
                            break;
                    }
                }
            }

            // STEP 4.)  Now that we're done reviewing receipts, it's time to start comparing the totals.
            Console.WriteLine("\n\nCalculating the totals owed to & by each person...");
            double aCommunalTotalPerPerson = aList.returnCommunalTotal() / 3;
            double vCommunalTotalPerPerson = vList.returnCommunalTotal() / 3;
            double mCommunalTotalPerPerson = mList.returnCommunalTotal() / 3;
            // Here are the amounts owed to Andy by Vince and Mike.
            double amountVOwesA = aList.returnVListTotal() + aCommunalTotalPerPerson;
            double amountMOwesA = aList.returnMListTotal() + aCommunalTotalPerPerson;
            // Here are the amounts owed to Vince by Andy and Mike.
            double amountAOwesV = vList.returnAListTotal() + vCommunalTotalPerPerson;
            double amountMOwesV = vList.returnMListTotal() + vCommunalTotalPerPerson;
            // Here are the amounts owed to Mike by Andy and Vince.
            double amountAOwesM = mList.returnAListTotal() + mCommunalTotalPerPerson;
            double amountVOwesM = mList.returnVListTotal() + mCommunalTotalPerPerson;

            // STEP 5.)  Now to compare each person's dues to the other person's dues.
            // First, we'll compare Andy's owed totals to the amounts he owes to Vince...
            Console.WriteLine("\nComparing amounts owed to amounts due for each person...");
            if (amountVOwesA >= amountAOwesV) {
                amountVOwesA -= amountAOwesV;
                amountAOwesV = 0;
            }
            else if (amountVOwesA < amountAOwesV) {
                amountAOwesV -= amountVOwesA;
                amountVOwesA = 0;
            }
            else {
                Console.WriteLine("ERROR:  Invalid input for amounts that Andy owes Vince & vice versa.");
            }

            // Now we'll compare Andy's owed totals to the amount he owes to Mike...
            if (amountMOwesA >= amountAOwesM) {
                amountMOwesA -= amountAOwesM;
                amountAOwesM = 0;
            }
            else if (amountMOwesA < amountAOwesM) {
                amountAOwesM -= amountMOwesA;
                amountMOwesA = 0;
            }
            else {
                Console.WriteLine("ERROR:  Invalid input for amounts that Andy owes Mike & vice versa.");
            }

            // Next, we'll compare Vince's owed totals.  Since we've already cleared Vince's dues with Andy,
            // we'll just move on to comparing Vince's owed totals to the amount he owes to Mike...
            if (amountMOwesV >= amountVOwesM) {
                amountMOwesV -= amountVOwesM;
                amountVOwesM = 0;
            }
            else if (amountMOwesV < amountVOwesM) {
                amountVOwesM -= amountMOwesV;
                amountMOwesV = 0;
            }
            else {
                Console.WriteLine("ERROR:  Invalid input for amounts that Vince owes Mike & vice versa.");
            }

            // In doing the above calculations, we've simultaneously cleared Mike's dues with Andy & Vince.
            // Now we can finally post the final results.
            Console.WriteLine("\nCalculations Complete!!!");
            Console.WriteLine("Below are the totals owed by each person to each person.");
            Console.WriteLine("\n\nAmounts Owed To Andy:");
            Console.WriteLine("========================");
            Console.WriteLine("- Vince Owes Andy:  ${0}", amountVOwesA);
            Console.WriteLine("- Mike Owes Andy:  ${0}", amountMOwesA);

            Console.WriteLine("\n\nAmounts Owed To Vince:");
            Console.WriteLine("========================");
            Console.WriteLine("- Andy Owes Vince:  ${0}", amountAOwesV);
            Console.WriteLine("- Mike Owes Vince:  ${0}", amountMOwesV);

            Console.WriteLine("\n\nAmounts Owed To Mike:");
            Console.WriteLine("========================");
            Console.WriteLine("- Andy Owes Mike:  ${0}", amountAOwesM);
            Console.WriteLine("- Vince Owes Mike:  ${0}", amountVOwesM);

            // Now that we're all done, let's write everything we've done to a .TXT file.
            Console.WriteLine("\n\nCreating output for 'ReceiptTotals.txt'...");
            List<string> finalOutputList = new List<string>();
            finalOutputList.AddRange(aList.writeAllReceiptsToFile());
            finalOutputList.Add(Environment.NewLine);
            finalOutputList.Add(String.Format("Final Totals For All Receipts On {0} List:", aList.returnListOwner()));
            finalOutputList.Add("----------------------------------");
            finalOutputList.Add(String.Format("Communal Total Of ALL Receipts On {0} List = {1}", aList.returnListOwner(), aList.returnCommunalTotal()));
            finalOutputList.Add(String.Format("Communal Total Owed Per Person Of ALL Receipts On {0} List = {1}", aList.returnListOwner(), aList.returnCommunalTotalPerPerson()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Andy On {0} List = {1}", aList.returnListOwner(), aList.returnAListTotal()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Vince On {0} List = {1}", aList.returnListOwner(), aList.returnVListTotal()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Mike On {0} List = {1}", aList.returnListOwner(), aList.returnMListTotal()));

            finalOutputList.AddRange(vList.writeAllReceiptsToFile());
            finalOutputList.Add(String.Format("Final Totals For All Receipts On {0} List:", vList.returnListOwner()));
            finalOutputList.Add("----------------------------------");
            finalOutputList.Add(String.Format("Communal Total Of ALL Receipts On {0} List = {1}", vList.returnListOwner(), vList.returnCommunalTotal()));
            finalOutputList.Add(String.Format("Communal Total Owed Per Person Of ALL Receipts On {0} List = {1}", vList.returnListOwner(), vList.returnCommunalTotalPerPerson()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Andy On {0} List = {1}", vList.returnListOwner(), vList.returnAListTotal()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Vince On {0} List = {1}", vList.returnListOwner(), vList.returnVListTotal()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Mike On {0} List = {1}", vList.returnListOwner(), vList.returnMListTotal()));

            finalOutputList.AddRange(mList.writeAllReceiptsToFile());
            finalOutputList.Add(String.Format("Final Totals For All Receipts On {0} List:", mList.returnListOwner()));
            finalOutputList.Add("----------------------------------");
            finalOutputList.Add(String.Format("Communal Total Of ALL Receipts On {0} List = {1}", mList.returnListOwner(), mList.returnCommunalTotal()));
            finalOutputList.Add(String.Format("Communal Total Owed Per Person Of ALL Receipts On {0} List = {1}", mList.returnListOwner(), mList.returnCommunalTotalPerPerson()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Andy On {0} List = {1}", mList.returnListOwner(), mList.returnAListTotal()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Vince On {0} List = {1}", mList.returnListOwner(), mList.returnVListTotal()));
            finalOutputList.Add(String.Format("Additional Total Amount Owed By Mike On {0} List = {1}", mList.returnListOwner(), mList.returnMListTotal()));

            finalOutputList.Add(Environment.NewLine);
            finalOutputList.Add("Calculations Complete!!!");
            finalOutputList.Add("Below are the totals owed by each person to each person.");
            finalOutputList.Add(Environment.NewLine);
            finalOutputList.Add("Amounts Owed To Andy:");
            finalOutputList.Add("========================");
            finalOutputList.Add(String.Format("- Vince Owes Andy:  ${0}", amountVOwesA));
            finalOutputList.Add(String.Format("- Mike Owes Andy:  ${0}", amountMOwesA));

            finalOutputList.Add(Environment.NewLine);
            finalOutputList.Add("Amounts Owed To Vince:");
            finalOutputList.Add("========================");
            finalOutputList.Add(String.Format("- Andy Owes Vince:  ${0}", amountAOwesV));
            finalOutputList.Add(String.Format("- Mike Owes Vince:  ${0}", amountMOwesV));

            finalOutputList.Add(Environment.NewLine);
            finalOutputList.Add("Amounts Owed To Mike:");
            finalOutputList.Add("========================");
            finalOutputList.Add(String.Format("- Andy Owes Mike:  ${0}", amountAOwesM));
            finalOutputList.Add(String.Format("- Vince Owes Mike:  ${0}", amountVOwesM));

            Console.WriteLine("These receipts & totals have been recorded at the following directory: C:/TestFolder/ReceiptTotals.txt");
            Console.Write("Would you like to see the final output for 'ReceiptTotals.txt'? (y/n): ");
            string reviewOutput = Console.ReadLine().ToUpper();

            if (reviewOutput == "Y") {
                foreach (string textLine in finalOutputList) {
                    Console.WriteLine(textLine);
                }
            }
            // Finally, we record everything to ReceiptTotals.txt...
            System.IO.File.WriteAllLines(@"C:\TestFolder\ReceiptTotals.txt", finalOutputList);
        }
    }
}
