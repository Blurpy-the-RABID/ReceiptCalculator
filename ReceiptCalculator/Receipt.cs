using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptCalculator {
    class Receipt {
/*
            Steps in defining a receipt:
             1.)  Determine who paid the receipt via the initial written on the top of the receipt (V, M, or A).  The receipt will be labeled with their initial.  NOTE:  For the ease of
                    references in these comments, the person whose initials are on the top of a receipt will be referred to as the receipt's "owner."
             2.)  Assign a number to the receipt based on how many receipts have previously been entered in for this person.  So if Vinny has 3 receipts and we've entered only one receipt
                    thus far, then the next receipt we enter for Vinny will be labeled "V2" (or something equivelant).
             3.)  Enter the total amount at the bottom of the receipt.  This amount is considered to be the communal total, and will be divided evenly later when final totals are
                    calculated.
             4.)  Determine if there are any items on the receipt that are for someone's personal usage (ex. Andy asks me to buy him mouthwash).  The item's total cost (including tax) is
                    specified, followed by whose initial is marked next to the item.  A total is calculated for all individual items that were purchased for a specific individual.
                #=- If the initial next to the item matches the initial at the top of the receipt, then we subtract the item's total from the receipt's total and update the receipt's
                        communal total.
                #=- If the initial next to the item does NOT match the initial at the top of the receipt, then we subtract the item's total from the receipt's total and update the
                        receipt's communal total.  We then flag the item as an amount that is owed to the receipt's payer by the person whose initial is next to the item.
*/
        string receiptName; // This will match the initial marked at the top of each receipt.
        int receiptNumber;
        double communalTotal = 0.00; // This will contain the communal total that will be divided 3 ways later on.
        double vTotal = 0.00; // This will contain the total of any individual items that were bought specifically for Vinny (and thus Vinny must pay back the receipt's owner).
        double aTotal = 0.00; // This will contain the total of any individual items that were bought specifically for Andy (and thus Andy must pay back the receipt's owner).
        double mTotal = 0.00; // This will contain the total of any individual items that were bought specifically for Mike (and thus Mike must pay back the receipt's owner).

        public Receipt(string receiptOwner, int receiptNum) {
            receiptName = receiptOwner;
            receiptNumber = receiptNum;
        }

        public string giveReceiptName() {
            return receiptName;
        }

        public void getCommunalTotal(double receiptTotal) {
            communalTotal += receiptTotal;
        }

        public double giveCommunalTotal() {
            return communalTotal;
        }

        public void getIndivTotal(string ownerInitial, double indivTotal) {
            switch (ownerInitial) {
                case "A":
                    aTotal += indivTotal;
                    break;
                case "M":
                    mTotal += indivTotal;
                    break;
                case "V":
                    vTotal += indivTotal;
                    break;
                default:
                    Console.WriteLine("Error: Unrecognized individual's initial for determining who owes the Receipt Owner the additional amount of (0).", indivTotal);
                    break;
            }
        }

        public double returnVTotal() {
            return vTotal;
        }

        public double returnATotal() {
            return aTotal;
        }

        public double returnMTotal() {
            return mTotal;
        }
    }
}
