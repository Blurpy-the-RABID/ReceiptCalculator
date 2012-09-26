using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptCalculator {
    class Interface {

        // This method will go through the process of acquiring the data for an individual receipt, and then returning the finished receipt.
        public Receipt getReceiptEntry(string receiptOwner, int receiptNumber) {
            Receipt receipt = new Receipt(receiptOwner, receiptNumber);
            Console.WriteLine("\nReceipt {0}{1}:", receiptOwner, receiptNumber);
            Console.Write("Enter Receipt {0}{1}'s Communal Total: ", receiptOwner, receiptNumber);
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
                            Console.Write("\nEnter the total amount (including tax) that Andy owes for his items on Receipt {0}{1}: ", receiptOwner, receiptNumber);
                            receipt.getIndivTotal(indivItemOwner, Convert.ToDouble(Console.ReadLine()));
                            break;
                        case "V":
                            Console.Write("\nEnter the total amount (including tax) that Vinny owes for his items on Receipt {0}{1}: ", receiptOwner, receiptNumber);
                            receipt.getIndivTotal(indivItemOwner, Convert.ToDouble(Console.ReadLine()));
                            break;
                        case "M":
                            Console.Write("\nEnter the total amount (including tax) that Mike owes for his items on Receipt {0}{1}: ", receiptOwner, receiptNumber);
                            receipt.getIndivTotal(indivItemOwner, Convert.ToDouble(Console.ReadLine()));
                            break;
                        default:
                            Console.WriteLine("Error: Unrecognized first initial.");
                            break;
                    }
                }
            }
            // Now we display all of the data entered for the current receipt.
            Console.WriteLine("\nReceipt {0}{1}:", receiptOwner, receiptNumber);
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
            return receipt;
        }

        public void editReceiptEntry(List receiptList, int receiptNumber) {
            Receipt receipt = this.getReceiptEntry(receiptList.returnListOwner(), receiptNumber);
            receiptList.editReceipt(receipt, receiptNumber);
        }
    }
}
