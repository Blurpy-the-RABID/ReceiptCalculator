using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptCalculator {
    class Receipt {
        string receiptName; // This will match the initial marked at the top of each receipt.
        int receiptNumber; // This will store the actual receipt number as it's added to the Receipt List.
        double communalTotal = 0.00; // This will contain the communal total that will be divided 3 ways later on.
        double vTotal = 0.00; // This will contain the total of any individual items that were bought specifically for Vinny (and thus Vinny must pay back the receipt's owner).
        double aTotal = 0.00; // This will contain the total of any individual items that were bought specifically for Andy (and thus Andy must pay back the receipt's owner).
        double mTotal = 0.00; // This will contain the total of any individual items that were bought specifically for Mike (and thus Mike must pay back the receipt's owner).

        public Receipt(string receiptOwner, int receiptNum) {
            receiptName = receiptOwner;
            receiptNumber = receiptNum;
        }

        public string returnReceiptName() {
            return receiptName;
        }

        public int returnReceiptNumber() {
            return receiptNumber;
        }

        public void getCommunalTotal(double receiptTotal) {
            communalTotal += receiptTotal;
        }

        public double returnCommunalTotal() {
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

        // The following set of methods are for when the user wishes to edit an existing receipt.
        public void changeCommunalTotal(double newCommunalTotal) {
            communalTotal = newCommunalTotal;
        }

        public void changeATotal(double newATotal) {
            aTotal = newATotal;
        }

        public void changeVTotal(double newVTotal) {
            vTotal = newVTotal;
        }

        public void changeMTotal(double newMTotal) {
            mTotal = newMTotal;
        }

        // The following set of methods are for when we need to read the various totals written on an existing receipt.
        public double returnATotal() {
            return aTotal;
        }

        public double returnVTotal() {
            return vTotal;
        }

        public double returnMTotal() {
            return mTotal;
        }
    }
}
