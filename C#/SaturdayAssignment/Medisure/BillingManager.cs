class BillingManager
{
    public static PatientBill LastBill;
    public static bool HasLastBill;
    public static void CreateBill()
    {
        PatientBill bill = new PatientBill();
        Console.Write("Enetr Bill ID: ");
        bill.BillId = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(bill.BillId)){
            Console.WriteLine("Bill Id cannot be empty.");
            return;
        }

        Console.Write("Enter Patient Name: ");
        bill.PatientName = Console.ReadLine();

        Console.Write("Is the patient insured? (Y/N): ");
        string ins = Console.ReadLine();
        if (ins == "Y" || ins == "y")
        bill.HasInsurance = true;
        else bill.HasInsurance = false;

        Console.Write("Consultant fee ");
        bill.ConsultationFee = Convert.ToDecimal(Console.ReadLine());
        if (bill.ConsultationFee <= 0)
        {
            Console.WriteLine("Consultation fee must be greater than 0.");
            return;
        }


        Console.Write("Enter Lab Charges: ");
        bill.LabCharges = Convert.ToDecimal(Console.ReadLine());
        if (bill.LabCharges < 0)
        {
            Console.WriteLine("Lab charges cannot be negative.");
            return;
        }


        Console.Write("Enter Medicine Charges: ");
        bill.MedicineCharges = Convert.ToDecimal(Console.ReadLine());
        if (bill.MedicineCharges < 0)
        {
            Console.WriteLine("Medicine charges cannot be negative.");
            return;
        }

        bill.GrossAmount = bill.ConsultationFee + bill.LabCharges + bill.MedicineCharges;

        if (bill.HasInsurance)
            bill.DiscountAmount = bill.GrossAmount * 0.10m;
        else
            bill.DiscountAmount = 0;

        bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;

        LastBill = bill;
        HasLastBill = true;


        Console.WriteLine("\nBill created successfully.");
        Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
    }
    public static void ViewLastBill()
    {
        if (!HasLastBill)
        {
            Console.WriteLine("No bill available. Please create a new bill first.");
            return;
        }

        Console.WriteLine("\n----------- Last Bill -----------");
        Console.WriteLine("BillId: " + LastBill.BillId);
        Console.WriteLine("Patient: " + LastBill.PatientName);
        Console.WriteLine("Insured: " + (LastBill.HasInsurance ? "Yes" : "No"));
        Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
        Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
        Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
        Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
        Console.WriteLine("--------------------------------");
    }
    public static void ClearLastBill()
    {
        LastBill = null;
        HasLastBill = false;
        Console.WriteLine("Last bill cleared.");
    }
}