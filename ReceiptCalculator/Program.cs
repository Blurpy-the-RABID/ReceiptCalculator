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
            // string moveOn = "Y"; // This will control whether or not the user wishes to re-enter a receipt.
            string receiptOwner = "X";
            ArrayList aReceiptList = new ArrayList(); // This ArrayList will hold Andy's receipts.
            ArrayList vReceiptList = new ArrayList(); // This ArrayList will hold Vince's receipts.
            ArrayList mReceiptList = new ArrayList(); // This ArrayList will hold Mike's receipts.

            Console.WriteLine("Welcome to the Receipt Calculator Program, written by Vincent Fantini.");
            Console.WriteLine("This calculator assumes that there are only (3) people who've submitted receipts:  Vince; Mike; and Andy.");
            Console.WriteLine("All receipts are to be sorted by the initial written on the top of each receipt.  The initial on each receipt corresponds to the person who paid for the items on the receipt.");
            Console.WriteLine("This program will assume that you have sorted all of the receipts into groups based on the initial written on the top of each receipt prior to using this program.");
            Console.WriteLine("If you haven't done this yet, then please do this now before proceeding.");

            while (aList.returnIsListComplete() == false || vList.returnIsListComplete() == false || mList.returnIsListComplete() == false) {
                Console.Write("\nWhose receipts will you be entering?  Enter the person's first initial ([A]ndy, [V]ince, [M]ike): ");
                receiptOwner = Console.ReadLine().ToUpper();

                while (receiptOwner == "A") {
                    if (aList.returnIsListComplete() == true) {
                        Console.Write("You've already entered all of Andrew's receipts.  Please enter either 'V' for Vince, or 'M' for Mike: ");
                        receiptOwner = Console.ReadLine().ToUpper();
                    }
                    else {
                        break;
                    }
                }
                    
                while (receiptOwner == "V") {
                    if (vList.returnIsListComplete() == true) {
                        Console.Write("You've already entered all of Vince's receipts.  Please enter either 'A' for Andy, or 'M' for Mike: ");
                        receiptOwner = Console.ReadLine().ToUpper();
                    }
                    else {
                        break;
                    }
                }
                while (receiptOwner == "M") {
                    if (mList.returnIsListComplete() == true) {
                        Console.Write("You've already entered all of Mike's receipts.  Please enter either 'A' for Andy, or 'V' for Vince: ");
                        receiptOwner = Console.ReadLine().ToUpper();
                    }
                    else {
                        break;
                    }
                }
                         
/*
                        Console.Write("Error: Unacceptable user input.  Please enter 'A' for Andy, 'V' for Vince, or 'M' for Mike: ");
                        receiptOwner = Console.ReadLine().ToUpper();
                        break;
                }
*/
                addAnotherReceipt = "Y";
                // As long as the user answers "Y" to the last question in this for loop (i.e. to add another receipt to this List), this loop will create a new receipt and push it onto
                // the current Owner's List.
                for (int i = 1; addAnotherReceipt == "Y"; i++) {
                    Receipt receipt = new Receipt(receiptOwner, i);
                    Console.WriteLine("\nReceipt {0}{1}:", receiptOwner, i);
                    Console.Write("Enter Receipt {0}{1}'s Communal Total: ", receiptOwner, i);
                    double communalTotal = Convert.ToDouble(Console.ReadLine());
                    receipt.getCommunalTotal(communalTotal);

                    Console.Write("\nAre there any individual items that are not communal? (y/n): ");
                    string answer = Console.ReadLine().ToUpper();

                    if (answer == "Y") {
                        Console.WriteLine("Enter the first initial of the persons to whom the item(s) was bought for (A / V / M).");
                        Console.Write("If multiple persons have items on this Receipt, separate their initials with a space: ");
                        string indivItemOwner = Console.ReadLine().ToUpper();
                        string[] initials = indivItemOwner.Split(' ');

                        for (int j = 0; j < initials.Length; j++) {
                            indivItemOwner = initials[j];
                            switch (initials[j]) {
                                case "A":
                                    Console.Write("\nEnter the total amount (including tax) that Andy owes for his items on Receipt {0}{1}: ", receiptOwner, i);
                                    receipt.getIndivTotal(indivItemOwner, Convert.ToDouble(Console.ReadLine()));
                                    break;
                                case "V":
                                    Console.Write("\nEnter the total amount (including tax) that Vinny owes for his items on Receipt {0}{1}: ", receiptOwner, i);
                                    receipt.getIndivTotal(indivItemOwner, Convert.ToDouble(Console.ReadLine()));
                                    break;
                                case "M":
                                    Console.Write("\nEnter the total amount (including tax) that Mike owes for his items on Receipt {0}{1}: ", receiptOwner, i);
                                    receipt.getIndivTotal(indivItemOwner, Convert.ToDouble(Console.ReadLine()));
                                    break;
                                default:
                                    Console.WriteLine("Error: Unrecognized first initial.");
                                    break;
                            }
                        }
                    }
                    // Now we display all of the data entered for the current receipt.
                    Console.WriteLine("\nReceipt {0}{1}:", receiptOwner, i);
                    Console.WriteLine("Communal Total = {0}", receipt.returnCommunalTotal());
                    if (receiptOwner == "A") {
                        Console.WriteLine("Additional Amount Owed By Vince: {0}", receipt.returnVTotal());
                        Console.WriteLine("Additional Amount Owed By Mike: {0}", receipt.returnMTotal());
                    }
                    else if (receiptOwner == "V") {
                        Console.WriteLine("Additional Amount Owed By Andy: {0}", receipt.returnATotal());
                        Console.WriteLine("Additional Amount Owed By Mike: {0}", receipt.returnMTotal());
                    }
                    else if (receiptOwner == "M") {
                        Console.WriteLine("Additional Amount Owed By Andy: {0}", receipt.returnATotal());
                        Console.WriteLine("Additional Amount Owed By Vince: {0}", receipt.returnVTotal());
                    }
                    // Console.Write("Is this information for Receipt {0}{1} correct? (y/n): ", receiptOwner, i);
                    // moveOn = Console.ReadLine().ToUpper();

                    // Now that the user is satisfied with this receipt's information, we'll add this receipt to the current Receipt Owner's List.
                    switch (receiptOwner) {
                        case "A":
                            aReceiptList.Add(receipt);
                            break;
                        case "V":
                            vReceiptList.Add(receipt);
                            break;
                        case "M":
                            mReceiptList.Add(receipt);
                            break;
                    }

                    // Now to ask the user if they wish to add another receipt to the current Receipt Owner's List...
                    Console.Write("Do you wish to add another Receipt to the {0} Receipt List? (y/n): ", receiptOwner);
                    addAnotherReceipt = Console.ReadLine().ToUpper();
                }

                // So now we're done entering receipts for the current Owner's List.  Let's display the results of all of the totals on this List...
                double listCommunalTotal = 0;
                double aListTotal = 0;
                double vListTotal = 0;
                double mListTotal = 0;

                switch (receiptOwner) {
                    case "A":
                        foreach (Receipt receipt in aReceiptList) {
                            listCommunalTotal = receipt.returnCommunalTotal();
                            aListTotal += receipt.returnATotal();
                            vListTotal += receipt.returnVTotal();
                            mListTotal += receipt.returnMTotal();
                        }
                        break;
                    case "V":
                        foreach (Receipt receipt in vReceiptList) {
                            listCommunalTotal = receipt.returnCommunalTotal();
                            aListTotal += receipt.returnATotal();
                            vListTotal += receipt.returnVTotal();
                            mListTotal += receipt.returnMTotal();
                        }
                        break;
                    case "M":
                        foreach (Receipt receipt in mReceiptList) {
                            listCommunalTotal = receipt.returnCommunalTotal();
                            aListTotal += receipt.returnATotal();
                            vListTotal += receipt.returnVTotal();
                            mListTotal += receipt.returnMTotal();
                        }
                        break;
                }
                

                Console.WriteLine("\nTotals For {0} Receipt List:", receiptOwner);
                Console.WriteLine("Communal Total For {0} Receipt List = {1}", receiptOwner, listCommunalTotal);
                Console.WriteLine("Amount Owed Per Person For Communal Total = {0}", listCommunalTotal / 3);
                Console.WriteLine("Additional Amount Owed By Andy To {0} = {1}", receiptOwner, aListTotal);
                Console.WriteLine("Additional Amount Owed By Vince To {0} = {1}", receiptOwner, vListTotal);
                Console.WriteLine("Additional Amount Owed By Mike To {0} = {1}", receiptOwner, mListTotal);

                // The last thing we do is set the corresponding ListComplete boolean variable to true.  Once all three are set to "true," then we move onto the next phase of calculations. 
                switch (receiptOwner) {
                    case "A":
                        aList.setIsListComplete(true);
                        aList.getListOwner(receiptOwner);
                        aList.getReceiptList(aReceiptList);
                        break;
                    case "V":
                        vList.setIsListComplete(true);
                        vList.getListOwner(receiptOwner);
                        vList.getReceiptList(vReceiptList);
                        break;
                    case "M":
                        mList.setIsListComplete(true);
                        mList.getListOwner(receiptOwner);
                        mList.getReceiptList(mReceiptList);
                        break;
                }
            }
            // Now that we've completed all three Receipt Lists, we'll give the user the opportunity to review them before moving on.
            Console.Write("All (3) Receipt Lists are completed.  Would you like to review them now before moving on? (y/n): ");
            string reviewReceipts = Console.ReadLine().ToUpper();
            if (reviewReceipts == "Y") {
                bool reviewAgain = true;
                while (reviewAgain == true) {
                    Console.Write("\nPlease specify whose Receipt List you wish to review (A/V/M): ");
                    string receiptListToReview = Console.ReadLine().ToUpper();

                    switch (receiptListToReview) {
                        case "A":
                            aList.showAllReceipts();
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

            // Insert code here for writing data to a file!
        }
    }
}
