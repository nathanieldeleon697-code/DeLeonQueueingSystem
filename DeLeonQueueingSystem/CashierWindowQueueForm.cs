using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DeLeonQueueingSystem
{
    public partial class CashierWindowQueueForm : Form
    {
        private readonly Timer _updateTimer;
        public CashierWindowQueueForm()
        {
            InitializeComponent();

            _updateTimer = new Timer
            {
                Interval = 1000
            };
            _updateTimer.Tick += SyncQueueDisplay;
            _updateTimer.Start();
                }
      public void DisplayCashierQueue(IEnumerable cashierList)
        {
            listCashierQueue.Items.Clear();
            if (cashierList == null) return;

            foreach (object item in cashierList)
            {
                listCashierQueue.Items.Add(item.ToString());
            }
        }

        private void SyncQueueDisplay(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DisplayCashierQueue(CashierClass.CashierQueue);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (CashierClass.CashierQueue.Count > 0)
            {
                CashierClass.CashierQueue.Dequeue();
                DisplayCashierQueue(CashierClass.CashierQueue);
            }
            else
            {
                MessageBox.Show("No customers currently in line.", "Queue Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}