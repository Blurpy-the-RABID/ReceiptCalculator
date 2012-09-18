using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptCalculator {
    class Program {
        static void Main(string[] args) {
            /*
            Steps in calculating the receipt totals:
             1.)  Enter in all receipts for each person who has posted & initialed a receipt on the markerboard (referred to as the receipt's "owner").  All receipts with the same
                    initial on them are to be compiled into a Receipt List with the "Owner" being the person whose initial is on each receipt.
                    #=- NOTE:  Electric bills (which are paid for by Mike) are to be entered in as Receipts for the purposes of calculating what is owed to Mike.
             2.)  Calculate the amount that each individual owes to each Receipt List's Owner based on the communal totals.  This is done by adding all of a Receipt List's communal
                    totals together, and then dividing said total by 3.
             3.)  Calculate the amount that each individual owes to each Receipt List's Owner based on individual item totals.  This is done by checking the Receipt List for any
                    individual item totals that are owed to the Receipt List Owner by a specific individual, and then adding all of these totals together.  The result should be an
                    entry that specifies which individual owes the Receipt List Owner this additional amount.
             4.)  Once each Receipt List's totals have been calculated, the program will then determine which individual owes the Receipt List Owner money.  Each individual owes the
                    Receipt List Owner a Communal Total, as well as any Individual Item Total that the Receipt List may have recorded for that individual to pay.  These two totals
                    are added together and specified in an entry that reads something like, "Andy owes Vince $500 TOTAL ($300 Communal + ($200 Individual Items)".
             5.)  The program will then compare the total amounts owed and simplify them by calculating the difference between the amounts owed between each person.
                    #=- For example, if Vince is owed $500 for groceries by Mike, but Vince also owes Mike $200 for electric bills, the program will subtract $200 from the $500 that
                        Mike owes Vince, resulting in Mike owing Vince only $300.
             6.)  Now that the amounts owed have been simplified, the Receipt Lists and the FINAL total amounts owed to each person will be displayed in this fashion:
                    Vince's Receipt List:
                    =====================
                    Receipt V1:
                    -----------
                    Communal Total = $XX.XX
             
                    Receipt V2:
                    -----------
                    Communal Total = $XX.XX
                    Additional Amount Owed By Andy = $XX.XX
             
                    Receipt V3:
                    -----------
                    Communal Total = $XX.XX
                    ...
                 
                    Andy's Receipt List:
                    ====================
                    Receipt A1:
                    -----------
                    Communal Total = $XX.XX
             
                    Receipt A2:
                    -----------
                    Communal Total = $XX.XX
                    Additional Amount Owed By Mike = $XX.XX
             
                    Receipt A3:
                    -----------
                    Communal Total = $XX.XX
                    ...
             
                    Mike's Receipt List:
                    ====================
                    Receipt M1:
                    -----------
                    Communal Total = $XX.XX
             
                    Receipt M2:
                    -----------
                    Communal Total = $XX.XX
                    Additional Amount Owed By Mike = $XX.XX
             
                    Receipt M3:
                    -----------
                    Communal Total = $XX.XX
                    ...
             
                    Vince owes...
                    =============
                    - Andy:  $XXX.XX
                    - Mike:  $XXX.XX
             
                    Andy owes...
                    =============
                    - Vince:  $XXX.XX
                    - Mike:  $XXX.XX
             
                    Mike owes...
                    =============
                    - Andy:  $XXX.XX
                    - Vince:  $XXX.XX
            */

            Console.WriteLine("Welcome to the Receipt Calculator Program, written by Vincent Fantini.");
            Console.WriteLine("This calculator assumes that there are only (3) people who've submitted receipts:  Vince; Mike; and Andy.");
            Console.WriteLine("All receipts are to be sorted by the initial written on the top of each receipt.  The initial on each receipt corresponds to the person who paid for the items on the receipt.");
            Console.WriteLine("This program will assume that you have sorted all of the receipts into groups based on the initial written on the top of each receipt prior to using this program.");
            Console.WriteLine("If you haven't done this yet, then please do this now before proceeding.");
            
            Console.Write("\nWho's receipts will you be entering first?  Enter the person's first initial ([A]ndy, [V]ince, [M]ike): ");
            string receiptOwner = Console.ReadLine().ToUpper();
/*
            while (receiptOwner != "A" || receiptOwner != "V" || receiptOwner != "M") {
                Console.Write("Incorrect input.  Please enter the person's first initial ([A]ndy, [V]ince, [M]ike): ");
                receiptOwner = Console.ReadLine().ToUpper();
            }
*/
           
            string addAnotherReceipt = "Y"; // This will control the for loop that adds additional receipts to this Receipt List.
            string moveOn = "Y"; // This will control whether or not the user wishes to re-enter a receipt.
            ArrayList aReceiptList = new ArrayList(); // This ArrayList will hold Andy's receipts.
            ArrayList vReceiptList = new ArrayList(); // This ArrayList will hold Vince's receipts.
            ArrayList mReceiptList = new ArrayList(); // This ArrayList will hold Mike's receipts.
            bool aListComplete = false;
            bool vListComplete = false;
            bool mListComplete = false;

            while (aListComplete == false || vListComplete == false || mListComplete == false) {

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
                    Console.WriteLine("Communal Total = {0}", receipt.giveCommunalTotal());
                    if (receiptOwner == "A") {
                        Console.WriteLine("Additional Amount Owed By Vince: {0}", receipt.giveVTotal());
                        Console.WriteLine("Additional Amount Owed By Mike: {0}", receipt.giveMTotal());
                    }
                    else if (receiptOwner == "V") {
                        Console.WriteLine("Additional Amount Owed By Andy: {0}", receipt.giveATotal());
                        Console.WriteLine("Additional Amount Owed By Mike: {0}", receipt.giveMTotal());
                    }
                    else if (receiptOwner == "M") {
                        Console.WriteLine("Additional Amount Owed By Andy: {0}", receipt.giveATotal());
                        Console.WriteLine("Additional Amount Owed By Vince: {0}", receipt.giveVTotal());
                    }

                    Console.Write("Is this information for Receipt {0}{1} correct? (y/n): ", receiptOwner, i);
                    moveOn = Console.ReadLine().ToUpper();

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
            }

            // So now we're done entering receipts for the current Owner's List.  Let's display the results of all of the totals on this List...
            double listCommunalTotal = 0;
            double aListTotal = 0;
            double vListTotal = 0;
            double mListTotal = 0;

            foreach (Receipt receipt in aReceiptList) {
                listCommunalTotal = receipt.giveCommunalTotal();
                aListTotal += receipt.giveATotal();
                vListTotal += receipt.giveVTotal();
                mListTotal += receipt.giveMTotal();
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
                    aListComplete = true;
                    break;
                case "V":
                    vListComplete = true;
                    break;
                case "M":
                    mListComplete = true;
                    break;
            }
        }
    }
}
