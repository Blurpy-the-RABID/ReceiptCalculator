using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptCalculator {
    class List {
        string listOwner;
        ArrayList receiptList = new ArrayList();
        double listCommunalTotal = 0;
        double aListTotal = 0;
        double vListTotal = 0;
        double mListTotal = 0;
        bool isListComplete = false; // This will be switched to 'true' once we're done creating this person's list of receipts.

        public List() {
        }

        public List(string ownerInitial, ArrayList finishedList) {
            listOwner = ownerInitial;

            // Now to copy the ArrayList of receipts into this List's ArrayList...
            for (int i = 0; i < finishedList.Count; i++) {
                receiptList.Add(finishedList[i]);
            }

            // Now that we have all of the receipts in this List instance, we'll calculate all of the Totals.
            foreach (Receipt receipt in receiptList) {
                listCommunalTotal = receipt.returnCommunalTotal();
                aListTotal += receipt.returnATotal();
                vListTotal += receipt.returnVTotal();
                mListTotal += receipt.returnMTotal();
            }
        }

        public void getListOwner(string ownerInitial) {
            listOwner = ownerInitial;
        }

        public void getReceiptList(ArrayList finishedList) {
            for (int i = 0; i < finishedList.Count; i++) {
                receiptList.Add(finishedList[i]);
            }

            // Now that we have all of the receipts in this List instance, we'll calculate all of the Totals.
            foreach (Receipt receipt in receiptList) {
                listCommunalTotal += receipt.returnCommunalTotal();
                aListTotal += receipt.returnATotal();
                vListTotal += receipt.returnVTotal();
                mListTotal += receipt.returnMTotal();
            }
        }

        public void setIsListComplete(bool listStatus) {
            isListComplete = listStatus;
        }

        public double returnCommunalTotal() {
            return listCommunalTotal;
        }

        public double returnAListTotal() {
            return aListTotal;
        }

        public double returnVListTotal() {
            return vListTotal;
        }

        public double returnMListTotal() {
            return mListTotal;
        }

        public string returnListOwner() {
            return listOwner;
        }

        public ArrayList returnList() {
            return receiptList;
        }

        public bool returnIsListComplete() {
            return isListComplete;
        }

        public void showAllReceipts() {
            Console.WriteLine("\nThe following are the receipts contained within the {0} List:", listOwner);
            Console.WriteLine("==============================================================");
            
            foreach (Receipt receipt in receiptList) {
                Console.WriteLine("\nReceipt {0}{1}:", receipt.returnReceiptName(), receipt.returnReceiptNumber());
                Console.WriteLine("--------------");
                Console.WriteLine("Communal Total = {0}", receipt.returnCommunalTotal());
                if (receipt.returnATotal() != 0) {
                    Console.WriteLine("Additional Amount Owed By Andy = {0}", receipt.returnATotal());
                }
                if (receipt.returnVTotal() != 0) {
                    Console.WriteLine("Additional Amount Owed By Vince = {0}", receipt.returnVTotal());
                }
                if (receipt.returnMTotal() != 0) {
                    Console.WriteLine("Additional Amount Owed By Mike = {0}", receipt.returnMTotal());
                }
            }
        }

        public List<string> writeAllReceiptsToFile() {
            List<string> receiptListOutput = new List<string>();
            receiptListOutput.Add(Environment.NewLine);
            receiptListOutput.Add(String.Format("The following are the receipts contained within the {0} List:", listOwner));
            receiptListOutput.Add("==============================================================");

                foreach (Receipt receipt in receiptList) {
                    receiptListOutput.Add(Environment.NewLine);
                    receiptListOutput.Add(String.Format("Receipt {0}{1}:", receipt.returnReceiptName(), receipt.returnReceiptNumber()));
                    receiptListOutput.Add("--------------");
                    receiptListOutput.Add(String.Format("Communal Total = {0}", receipt.returnCommunalTotal()));
                    if (receipt.returnATotal() != 0) {
                        receiptListOutput.Add(String.Format("Additional Amount Owed By Andy = {0}", receipt.returnATotal()));
                    }
                    if (receipt.returnVTotal() != 0) {
                        receiptListOutput.Add(String.Format("Additional Amount Owed By Vince = {0}", receipt.returnVTotal()));
                    }
                    if (receipt.returnMTotal() != 0) {
                        receiptListOutput.Add(String.Format("Additional Amount Owed By Mike = {0}", receipt.returnMTotal()));
                    }
                }
            return receiptListOutput;
        }

    }
}
