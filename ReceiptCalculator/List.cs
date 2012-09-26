using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptCalculator {
    class List {
        string listOwner;
        ArrayList receiptList = new ArrayList();
        double listCommunalTotal = 0.00;
        double communalTotalPerPerson = 0.00;
        double aListTotal = 0.00;
        double vListTotal = 0.00;
        double mListTotal = 0.00;
        bool isListComplete = false; // This will be switched to 'true' once we're done creating this person's list of receipts.

        public List() {
        }

        public void calculateTotals() {
            foreach (Receipt receipt in receiptList) {
                listCommunalTotal += receipt.returnCommunalTotal();
                aListTotal += receipt.returnATotal();
                vListTotal += receipt.returnVTotal();
                mListTotal += receipt.returnMTotal();
            }
            Console.WriteLine("\nTotals For {0} Receipt List:", listOwner);
            Console.WriteLine("Communal Total For {0} Receipt List = {1}", listOwner, listCommunalTotal);
            Console.WriteLine("Amount Owed Per Person For Communal Total = {0}", this.returnCommunalTotalPerPerson());
            Console.WriteLine("Additional Amount Owed By Andy To {0} = {1}", listOwner, aListTotal);
            Console.WriteLine("Additional Amount Owed By Vince To {0} = {1}", listOwner, vListTotal);
            Console.WriteLine("Additional Amount Owed By Mike To {0} = {1}", listOwner, mListTotal);
        }

        public void getListOwner(string ownerInitial) {
            listOwner = ownerInitial;
        }

        public void addReceiptToList(Receipt receipt) {
            receiptList.Add(receipt);
        }

        public void setIsListComplete(bool listStatus) {
            isListComplete = listStatus;
        }

        public double returnCommunalTotal() {
            return listCommunalTotal;
        }

        public double returnCommunalTotalPerPerson() {
            communalTotalPerPerson = listCommunalTotal / 3;
            return communalTotalPerPerson;
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

        public void editReceipt(Receipt newReceipt, int receiptNumber) {
            receiptList.RemoveAt(receiptNumber - 1);
            receiptList.Insert(receiptNumber - 1, newReceipt);
            Receipt receipt = (Receipt)receiptList[receiptNumber - 1];
            Console.WriteLine("Receipt {0}{1} has been edited.  The following are the new totals for Receipt {0}{1}:", receipt.returnReceiptName(), receipt.returnReceiptNumber());
            Console.WriteLine("\nReceipt {0}{1}:", receipt.returnReceiptName(), receipt.returnReceiptNumber());
            Console.WriteLine("--------------");
            Console.WriteLine("Communal Total = {0}", receipt.returnCommunalTotal());
            Console.WriteLine("Communal Total Per Person = {0}", receipt.returnCommunalTotal() / 3);
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

        public void showAllReceipts() {
            Console.WriteLine("\nThe following are the receipts contained within the {0} List:", listOwner);
            Console.WriteLine("==============================================================");
            
            foreach (Receipt receipt in receiptList) {
                Console.WriteLine("\nReceipt {0}{1}:", receipt.returnReceiptName(), receipt.returnReceiptNumber());
                Console.WriteLine("--------------");
                Console.WriteLine("Communal Total = {0}", receipt.returnCommunalTotal());
                Console.WriteLine("Communal Total Per Person = {0}", receipt.returnCommunalTotal() / 3);
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
                    receiptListOutput.Add(String.Format("Communal Total Per Person = {0}", receipt.returnCommunalTotal() / 3));
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
