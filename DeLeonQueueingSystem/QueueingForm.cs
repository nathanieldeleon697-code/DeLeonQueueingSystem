namespace DeLeonQueueingSystem
{
    public partial class QueueingForm : Form
    {
        private readonly CashierClass _cashier = new CashierClass();
        public QueueingForm()
        {
            InitializeComponent();

            new CashierWindowQueueForm().Show();
            new CustomerView().Show();
        }
        private void btnCashier_Click(object sender, EventArgs e)
        {
            string generatedNumber = _cashier.CashierGeneratedNumber("P - ");
            lblQueue.Text = generatedNumber;

            CashierClass.CashierQueue.Enqueue(generatedNumber);
        }
    }
}
