using System;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DeLeonQueueingSystem
{
    public partial class CustomerView : Form
    {
        private readonly Timer _displayTimer;

        public CustomerView()
        {
            InitializeComponent();

            _displayTimer = new Timer
            {
                Interval = 1000
            };
            _displayTimer.Tick += RefreshNowServing;
            _displayTimer.Start();
        }

        private void RefreshNowServing(object? sender, EventArgs e)
        {
          
            if (CashierClass.CashierQueue is { Count: > 0 } queue)
            {
                lblNowServing.Text = queue.Peek();
            }
            else
            {
                lblNowServing.Text = "P - -----";
            }
        }
    }
}