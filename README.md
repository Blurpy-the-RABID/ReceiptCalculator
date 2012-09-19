This is a program written by me (Vincent Fantini) to assist me in calculating my apartment's communal bills & expenses.
Below are my specifications for this program:

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

The following are the steps in defining a single receipt:
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