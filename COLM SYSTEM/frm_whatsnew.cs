﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SEMS
{
    public partial class frm_whatsnew : Form
    {
        public frm_whatsnew()
        {
            InitializeComponent();
            textBox1.Select(0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
